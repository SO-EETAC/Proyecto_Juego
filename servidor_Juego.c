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
#include <pthread.h>
#include <stdbool.h>

//EN ESTA VERSION, HAY LA PRIMERA PARTE DE LA VERSION 2: SERVIDOR CONCURRENTE

//INTRODUCIDA LA EXCLUSIÓN

//Primero creamos las estrucutras necesarias para gestionar la lista de conectados


typedef struct {
	char nombre[20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
} ListaConectados;

//???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
typedef struct {
	int oc; //0 indica que la entrada esta libre y 1 que esta ocupada
	char nombre [30];
	int socket;
} TConectado;

typedef TConectado TablaConectados [100];

void Inicializar (TablaConectados tabla)
{
	int i;
	for (i=0; i<100; i++)
		tabla[i].oc=0;
}

int PonJugador (TablaConectados tabla, char nombre[30], int socket) //DONDE PONGO ESTA FUNCION?
{
	int encontrado =0;
	int i=0;
	while ((i<100) && !encontrado)
	{
		if (tabla[i].oc==0)
			encontrado = 1;
		else
			i=i+1;
	}
	if (!encontrado)
		return -1;
	else {
		tabla[i].socket = socket;
		strcpy (tabla[i].nombre, nombre);
		tabla[i].oc=1;
		return i;
	}
}
//???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????

ListaConectados lista_jugadores;

int i;
int sockets[100];

//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int Pon(ListaConectados *lista, char nombre[20], int socket){
	//Añade nuevo conectados. Retorna 0  si ok y -1 si la lista ya esta llena
	//y no se puede añadir
	
	if (lista->num == 100)
		
		return -1;
		
	else{
		
		strcpy(lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num = lista->num + 1;
		return 0;
		
	}
}
	
int Eliminar(ListaConectados *lista, char nombre[20]){
	//Retorna 0 si elimina y -1 si dicho usuario no está en la lista
	
	int i = 0;
	int encontrado = 0;
	
	while ((i < lista->num) && (!encontrado)){
		
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado = 1;
		if (!encontrado)
			i = i + 1;
	}
	if (encontrado == 1){
		
		int j;
		for(j = i; j < lista->num-1; j++){
			
			strcpy(lista->conectados[j].nombre, lista->conectados[j+1].nombre);
			lista->conectados[j].socket = lista->conectados[j+1].socket;
		}
		lista->num--;
		return 0;
	}
	else
		return -1;
	
}	
	
void DameConectados (ListaConectados *lista, char conectados[400]){
	//Recibe la lista de conectados y retorna un vector de caracteres con los nombres
	//separados por _. --> "3_Juan_Maria_Pedro"
	
	sprintf(conectados, "%d", lista->num);
	
	int i;
	
	for (i = 0; i < lista->num; i++){
		
		sprintf(conectados, "%s_%s", conectados, lista->conectados[i].nombre);
		
	}		
}

int DameSocket(ListaConectados *lista, char nom[20]){
	//devuelve el numero de socket. Si no encuentra el nombre, devuelve -1.
	int i = 0;
	int encontrado = 0;
	while ((i<lista->num) && encontrado!=1)
	{
		if (strcmp(lista->conectados[i].nombre, nom ) == 0)
		{
			encontrado=1;
		}
		else{
			i++;
		}
		
	}
	if (encontrado==1)
	{
		
		return lista->conectados[i].socket;
		
	}
	else{
		
		return -1;
	}
	
}

void *AtenderCliente(void *socket){

	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[80];
	char values[80];
	char usuario[20];
	
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
	
	int sock_conn;
	int *s;
	s =(int *) socket;
	sock_conn = *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	//Bucle de atencion al cliente 
	int terminar = 0;
	
	while (terminar ==0)
	{
		bool notificacion_n = false;
		// Ahora recibimos su nombre, que dejamos en buff
		
		//2)RECOGE LA PETICION
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que añadirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos el nombre en la consola
		
		printf ("Peticion: %s\n",peticion);
		
		//AQUI EMPIEZA DARSE DE ALTA DE JUDITH
		
		//3)DETERMINA QUE ME PIDEN
		
		//peticion: 1/nombre/username/password
		
		char jugadores_conectados[400];
		
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		
		
		//4)PREPARA LA RESPUESTA
		
		if (codigo == 0){//piden DESCONECTARSE
			
			pthread_mutex_lock(&mutex); //No me interrumpas ahora
			
			int err_2 = Eliminar(&lista_jugadores, usuario);
			
			pthread_mutex_unlock(&mutex); //Ya me puedes interrumpir
	
			if (err_2 == -1){
				
				printf("No se encuentra en la lista\n");
				
			}				
			else{
				
				printf("Elminado\n");
				
			}
			
			notificacion_n = true;
			
			terminar = 1;
			
			
		}
		
		//****************************************************************
		
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
				
				sprintf(respuesta, "1/Lo sentimos, el usuario ya existe.");
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
				sprintf(respuesta, "1/Enhorabuena! Se ha dado de alta en el juego!");
				
				pthread_mutex_lock(&mutex); //No me interrumpas ahora
				
				int err_1 = Pon(&lista_jugadores, username, sock_conn);
				
				pthread_mutex_unlock(&mutex); //Ya me puedes interrumpir
			}
			
			notificacion_n = true;
			
		}
		//AQUI TERMINA DARSE DE ALTA DE JUDITH
		
		//****************************************************************
		
		//AQUI EMPIEZA LOGUEARSE DE HECTOR
		else if (codigo == 2)
		{//piden loguearse
			char contra[20];
			char decision[20];
			
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
			//recogemos el resultado de la consulta 
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL){
				//el usuario no existe
				printf ("No se han obtenido datos en la consulta\n");
				strcpy (decision,"USER_NOT_FOUND");
			}
			else{
				
				if (strcmp(row[0], contra) == 0) {
					//la contraseña coincide con el username, login OK
					printf ("Autentificacion exitosa! \n");
					sprintf (decision,"Y_%s",usuario);
					
					pthread_mutex_lock(&mutex); //No me interrumpas ahora
					
					int err_1 = Pon(&lista_jugadores, usuario, sock_conn);
					
					pthread_mutex_unlock(&mutex); //Ya me puedes interrumpir
					
					if (err_1 == -1)						
						printf("Lista llena. No se ha podido añadir\n");
					else{
						
						printf("Añadido satisfactoriamente. \n");
					}
				}
				else {
					//la contraseña es incorrecta
					printf ("Autentificacion fallida :(  \n");
					sprintf (decision,"N_%s",usuario);
				}
				
			}
			sprintf(respuesta, "2/%s",decision);
			
			notificacion_n = true;
		}
		//AQUI TERMINA LOGUEARSE DE HECTOR
		
		//****************************************************************
		
		//AQUI EMPIEZA CONSULTA DE JUDITH
		else if (codigo == 3)
		{//piden consultar ganador por fecha
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
			//recogemos el resultado de la consulta 
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL){
				printf ("No hay ganadores para la fecha seleccionada\n");
				strcpy(decision,"NOT_FOUND");
			}
			else{
				
				sprintf (decision,"Nombre del ganador : %s, Usuario del ganador : %s\n",row[1],row[0]);
			}
			sprintf(respuesta, "3/%s",decision);
			
			
			
		}
		//AQUI TERMINA CONSULTA DE JUDITH
		
		//****************************************************************
		
		//AQUI EMPIEZA CONSULTA DE GILBERT
		else if (codigo == 4)
		{//piden consultar ganador por duracion
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
			sprintf(respuesta, "4/%s",decision);
		}
		//AQUI ACABA CONSULTA DE GILBERT
		
		//****************************************************************
		
		//Ahora crearemos una consulta que nos devuelva la lista de conectados en el servidor
		
		else if (codigo == 5)
		{//piden una lista con los conectados
			
			DameConectados(&lista_jugadores,jugadores_conectados);
			
			sprintf(respuesta, "5/%s",jugadores_conectados);
		}
		else if (codigo== 6) //   6/anakilator/1/juanito23
		{//piden invitar a otro jugador(de momento solo 1)
			//tengo que consultar el socket de juanito23
			char invitador[20];
			char invitado[20];
			char num_invitados[10];
			p = strtok( NULL, "/");
			strcpy(invitador, p);
			p= strtok(NULL, "/");
			strcpy(num_invitados,p);
			p=strtok(NULL, "/");
			strcpy(invitado,p);
			
			sprintf(respuesta, "7/%s_%s_%s", invitador, num_invitados, invitado); //esto le llega al que recibe la invitacion
			
			int socket_i=DameSocket(&lista_jugadores,invitado); //ahora que hago con este socket? Es el socket por donde envio la respuesta
			
			write(socket_i, respuesta, strlen(respuesta));
			
		}
		else if (codigo == 8) //     8/invitador/num_invitadoe/invitado/si
		{//pide mandar la respuesta de la invitacion a quien me ha invitado
			char respuesta_invitacion[10];
			char invitador[20];
			char invitado[20];
			char num_invitados[10];
			p = strtok( NULL, "/");
			strcpy(invitador, p);
			p= strtok(NULL, "/");
			strcpy(num_invitados,p);
			p=strtok(NULL, "/");
			strcpy(invitado,p);
			p=strtok(NULL,"/");
			strcpy(respuesta_invitacion,p);
			
			sprintf(respuesta, "8/%s_%s_%s_%s", invitador, num_invitados, invitado, respuesta_invitacion);
			int socket_i=DameSocket(&lista_jugadores,invitado);	
			int socket_j=DameSocket(&lista_jugadores,invitador);
			
			write(socket_i, respuesta, strlen(respuesta));
			write(socket_j,respuesta,strlen(respuesta));
		}
		
		if (codigo !=0)
		{
			printf ("Respuesta: %s\n", respuesta);
			
			//5)ENVIA LA RESPUESTA
			// Y lo enviamos
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		if (notificacion_n){//Enviamos la lista de jugadores_conectados a todos los sockets
			
			char notificacion[400];
			
			DameConectados(&lista_jugadores,jugadores_conectados);
			
			sprintf(notificacion, "6/%s", jugadores_conectados);
			
			for(int j=0; j < i; j++){
				
				write(sockets[j], notificacion, strlen(notificacion));
				
			}
			
		}
	}
	
	//6)CIERRA LA CONEXION
	// Se acabo el servicio para este cliente
	close(sock_conn); 
}
int main(int argc, char *argv[]){
	
	lista_jugadores.num = 0;
	
	int sock_conn, sock_listen, ret;
	
	struct sockaddr_in serv_adr;
	
	
	// INICIALITZACIONS SOCKET
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	
	
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la maquina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9004); //50001
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind\n");
	//La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	pthread_t thread[100];
	
	//atendemos infinitas peticiones
	for(i=0;;i++){
		printf ("Escuchando\n");
		
		//1)ESPERANDO CONEXION
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		sockets[i] = sock_conn; //guardo el socket para comunicarme con el nuevo cliente
		//sock_conn es el socket que usaremos para este cliente
			
		//Crear un thread y decirle lo que tiene que hacer
		pthread_create(&thread[i],NULL, AtenderCliente, &sockets[i]);
		//thread[i] es un parametro de salida, la funcion mete dentro un id de thread
		//socket[i] es un parametro de entrada, la funcion necesita saber que socket se esta usando
		
	}
	return 0;
}
