create schema announcements;
use announcements;
create table anuncios(
id_anuncios int auto_increment primary key,
titulo varchar(45),
descripcion text,
imagen text
);
create table usuarios(
id_usuarios int auto_increment primary key,
nombres varchar(80),
email varchar(80),
password varchar(80),
icon text
);