CREATE DATABASE ParcialDb
go
use ParcialDb
go
CREATE TABLE Grupos
(

	ArticuloId int primary key identity(1,1),
	Fecha DateTime,
	Descripcion varchar,
	Cantidad int,
	Grupo int,
	Integrantes int,


);
