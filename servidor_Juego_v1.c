#include <mysql.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//EN ESTA VERSION, HAY LA PARTE DE SERVIDOR DE JUDITH: DARSE DE ALTA.

int main(int argc, char *argv[])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[80];
	char values[80];
	
	//crear conexion a BBDD
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar conexion a BBDD
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "JUEGO",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9040);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	
	
	for(;;){
		printf ("Escuchando\n");
		
		//1)ESPERANDO CONEXION
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		//Bucle de atencion al cliente 
		int terminar = 0;
		while (terminar ==0)
		{
			
			// Ahora recibimos su nombre, que dejamos en buff
			//2)RECOGE LA PETICION
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			//Escribimos el nombre en la consola
			
			printf ("Se ha conectado: %s\n",peticion);
			
			//AQUI EMPIEZA LA PARTE DE JUDITH
			//3)DETERMINA QUE ME PIDEN
			//peticion: 1/nombre/username/password
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
			
			
			//4)PREPARA LA RESPUESTA
			
			if (codigo == 0)
			{//piden DESCONECTARSE
				terminar = 1;
			}
			else if (codigo ==1)
			{//piden DARSE DE ALTA
				char nombre[20];
				char username[20];
				char password[20];
				
				if (codigo !=0)
				{
					p = strtok( NULL, "/");
					strcpy(nombre, p);
					p = strtok(NULL, "/");
					strcpy(username, p);
					p = strtok(NULL, "/");
					strcpy(password, p);
					printf ("Codigo: %d, Nombre: %s, Username: %s, Password: %s\n", codigo, nombre, username, password);
				}
				resultado = NULL;
				row = NULL;
				
				sprintf(consulta,"SELECT count(*) FROM JUGADOR WHERE JUGADOR.USERNAME ='%s';",username );
				err=mysql_query (conn, consulta);
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				if (atoi(row[0]) >0)
				{//no se ha podido dar de alta, ya hay otro username igual
					
					sprintf(respuesta, "Lo sentimos, el usuario ya existe.");
				}
				else
				{//se puede dar de alta
					
					strcpy (values, "INSERT INTO JUGADOR (NOMBRE, USERNAME, PASSWORD) VALUES ('");
					strcat (values, nombre); 
					strcat (values, "','");
					strcat (values, username); 
					strcat (values, "','");
					strcat (values, password); 
					strcat (values, "');");
					
					err=mysql_query (conn, values);
					sprintf(respuesta, "Enhorabuena! Se ha dado de alta en el juego!");
				}
					
			}
			//AQUI TERMINA DARSE DE ALTA DE JUDITH
			//AQUI EMPIEZA LOGUEARSE DE HECTOR
			else if (codigo == 2)
			{
				char usuario[20];
				char contra[20];
				char decision[20];
				
				strcpy(decision,"Prueba");
				
				printf("Esto es una %s \n",decision);
				
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				p = strtok( NULL, "/");
				strcpy (contra, p);
				printf ("Usuario: %s, Contraseña: %s\n", usuario, contra);
				
				
				// construimos la consulta SQL
				strcpy (consulta,"SELECT PASSWORD FROM JUGADOR WHERE USERNAME = '"); 
				strcat (consulta, usuario);
				strcat (consulta,"';");
				
				printf ("%s",consulta);
				
				// hacemos la consulta 
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//recogemos el resultado de la con2sulta 
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL){
					printf ("No se han obtenido datos en la consulta\n");
				    strcpy (decision,"USER_NOT_FOUND");
				}
				else{
					
					if (strcmp(row[0], contra) == 0) {
						printf ("Autentificacion exitosa! \n");
						strcpy (decision,"Y");
					}
					else {
						printf ("Autentificacion fallida :(  \n");
						strcpy (decision,"N");
					}
					
				}
				sprintf(respuesta, "%s",decision);
			}
			else if (codigo == 3){

				char fecha[20];
				char decision[20];
				p = strtok( NULL, "/");
				strcpy (fecha, p);

				printf ("Fecha: %s\n", fecha);
				
				
				// construimos la consulta SQL
				 
				sprintf (consulta,"SELECT JUGADOR.USERNAME, PARTIDA.GANADOR FROM JUGADOR INNER JOIN PARTIDA ON JUGADOR.NOMBRE = PARTIDA.GANADOR WHERE DATE(PARTIDA.FECHA_HORA) = DATE('%s') ;",fecha); 

				// hacemos la consulta 
				
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//recogemos el resultado de la con2sulta 
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL){
					printf ("No hay ganadores para la fecha seleccionada\n");
					strcpy(decision,"NOT_FOUND");
				}
				else{
					
					sprintf (decision,"Nombre del ganador : %s, Usuario del ganador : %s\n",row[1],row[0]);
					
				}
				sprintf(respuesta, "%s",decision);
				
				
	
			}
			else if (codigo == 4){
				
				char duracion[20];
				char decision[20];
				p = strtok( NULL, "/");
				strcpy(duracion, p);

				printf ("duracion: %s \n", duracion);
				
				// construimos la consulta SQL
				strcpy (consulta,"SELECT GANADOR FROM PARTIDA WHERE DURACION = '"); 
				strcat (consulta, duracion);
				strcat (consulta,"';");
				
				printf("%s\n",consulta);
				
				
				// hacemos la consulta 
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//recogemos el resultado de la consulta 
				resultado = mysql_store_result (conn); 
				row = mysql_fetch_row (resultado);
				if (row == NULL){
					printf ("No se han obtenido datos en la consulta\n");
					strcpy(decision,"NOT_FOUND");
				}
				else{
					
						// la columna 0 contiene el nombre del primer jugador
					sprintf (decision,"Nombre del ganador : %s",row[0]);
					
				}
				sprintf(respuesta, "%s",decision);
			}
			
			if (codigo !=0)
			{
				printf ("%s\n", respuesta);
				
				//5)ENVIA LA RESPUESTA
				// Y lo enviamos
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
			
		//6)CIERRA LA CONEXION
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
}
