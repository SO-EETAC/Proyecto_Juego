#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
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
	serv_adr.sin_port = htons(9080);
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
			
			//4)PREPARA LA RESPUESTA
			
			if (codigo == 0)
			{//piden DESCONECTARSE
				terminar = 1;
			}
			else if (codigo ==1)
			{//piden DARSE DE ALTA
				//tengo que comprobar que el username no existe
				err=mysql_query (conn, "SELECT COUNT USERNAME FROM JUGADOR WHERE JUGADOR.USERNAME ='" );
				strcat (consulta, username);
				strcat (consulta, "';'");
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				//tengo que introducir variables(nombre,username,password) en BBDD --> INSERT INTO JUGADOR(NOMBRE, USERNAME, PASSWORD) VALUES(...)
				if (row[0] != NULL)
				{//no se ha podido dar de alta, ya hay otro username igual
					sprintf(respuesta, "Lo sentimos, el usuario ya existe.");
				}
				else
				{//se puede dar de alta
					strcpy (values, "INSERT INTO JUEGO (NOMBRE, USERNAME, PASSWORD) VALUES ('");
					strcat (consulta, nombre); 
					strcat (consulta, "','");
					strcat (consulta, username); 
					strcat (consulta, "',");
					strcat (consulta, password); 
					strcat (consulta, ");");
					sprintf(respuesta, "Enhorabuena! Se ha dado de alta en el juego!");
				}
					
			}
			//AQUI TERMINA DARSE DE ALTA DE JUDITH
			
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
