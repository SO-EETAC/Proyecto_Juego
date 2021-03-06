DROP DATABASE IF EXISTS M1_BBDD_Juego;

CREATE DATABASE M1_BBDD_Juego;

USE JUEGO;

CREATE TABLE JUGADOR (

	ID INT NOT NULL AUTO_INCREMENT,
	NOMBRE VARCHAR(60),
	USERNAME  VARCHAR(60) NOT NULL,
	PASSWORD  VARCHAR(60) NOT NULL,
	PRIMARY KEY (ID)
	

)ENGINE=InnoDB;

CREATE TABLE PARTIDA (

	ID INT NOT NULL AUTO_INCREMENT,
	FECHA_HORA DATETIME NOT NULL,
	DURACION INT,
	GANADOR VARCHAR(60),
	PRIMARY KEY (ID)

)ENGINE=InnoDB;

CREATE TABLE PARTICIPACION (

	ID_J INT,
	ID_P INT,
	POSICION INT,
	FOREIGN KEY (ID_J) REFERENCES JUGADOR(ID),
	FOREIGN KEY (ID_P) REFERENCES PARTIDA(ID)

)ENGINE=InnoDB;



INSERT INTO JUGADOR(NOMBRE, USERNAME, PASSWORD) VALUES ('Juan', 'juanito23','hola12');
INSERT INTO JUGADOR(NOMBRE, USERNAME, PASSWORD) VALUES ('Marta', 'martita21','contra');
INSERT INTO JUGADOR(NOMBRE, USERNAME, PASSWORD) VALUES ('Ana', 'anakilator','top568');


INSERT INTO PARTIDA(FECHA_HORA, DURACION, GANADOR) VALUES ('2020-10-18 14:50', '87', 'Ana');
INSERT INTO PARTIDA(FECHA_HORA, DURACION, GANADOR) VALUES ('2020-10-19 14:50', '90', 'Marta');


INSERT INTO PARTICIPACION VALUES (1,1,3);
INSERT INTO PARTICIPACION VALUES (3,1,1);
