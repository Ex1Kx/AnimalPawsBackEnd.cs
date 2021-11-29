create schema announcements;
use announcements;
create table anuncios(
id_anuncios int auto_increment primary key,
titulo varchar(45),
descripcion text,
imagen text
);
insert into anuncios (titulo, descripcion, imagen)
values('Prueba1', 'Una Pequeña Prueba Namas UwU', 'https://i.imgur.com/EtlPQKC.jpeg');