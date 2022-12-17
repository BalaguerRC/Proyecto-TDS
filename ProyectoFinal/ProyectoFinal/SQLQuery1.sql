create database proyect_tds

use proyect_tds

--usuario
create table tipo_user
(
id_type int not null primary key identity(1,1),
tipo_usuario varchar (50)
);
insert into tipo_user(tipo_usuario) values('client')
create table log_in
(
id_user int not null primary key identity(1,1),
nombre varchar(50),
pass varchar (50),
id_Tipo int not null,
Fecha datetime default getdate()
);
select * from log_in
--Select lg.id_user,lg.nombre,lg.pass,u.tipo_usuario as Type from log_in lg join tipo_user u on lg.id_Tipo=u.id_type
--producto
create table prod_type
(
id_typProd int not null primary key identity(1,1),
type_names varchar(50)
)
insert into prod_type(type_names) values('otro')
insert into prod_type(type_names) values('Electronico')
--select * from prod_type
create table product
(
id_prod int not null primary key identity(1,1),
prod_name varchar(150),
prod_price varchar(50),
prod_date datetime default getdate(),
prod_type int
);
--Select pr.id_prod,pr.prod_name,pr.prod_price,prt.type_names as ProductTipo from product pr join prod_type prt on pr.prod_type=prt.id_typProd
--select * from product
--update product set prod_type=1 where id_prod=2
insert into product(id_prod,prod_name,prod_price,prod_type) values(1, 'test',10.00,1)

select * from product

select * from log_in

insert into log_in(nombre,pass,id_Tipo) values('admin','12345','1')


--exec usp_registrar 'prueba', '100', 2
exec usp_obtener 2
exec usp_listar

--api producto
if Exists (select * from sys.objects where type= 'p' and name = 'usp_registrar')
drop procedure usp_registrar
go
/*if Exists (select * from sys.objects where type= 'p' and name = 'usp_modificar')
drop procedure usp_modificar
go*/
if Exists (select * from sys.objects where type= 'p' and name = 'usp_obtener')
drop procedure usp_obtener
go
if Exists (select * from sys.objects where type= 'p' and name = 'usp_listar')
drop procedure usp_listar
go
/*if Exists (select * from sys.objects where type= 'p' and name = 'usp_eliminar')
drop procedure usp_eliminar
go*/

create procedure usp_registrar(
@name varchar(60),
@precio varchar(60),
@tipo int
)
as 
begin
insert into product(prod_name,prod_price,prod_type)
values(
@name,
@precio,
@tipo
)
end
go

---modificar--

/*create procedure usp_modificar(
@id int,
@name varchar(60),
@precio varchar(60),
@type int
)
as 
begin
update product set prod_name= @name, prod_price=@precio, prod_type=@type where id_prod=@id
end
go*/

--obtener--

create procedure usp_obtener(@id int)
as
begin
select * from product where id_prod=@id
end

go

--listar

create procedure usp_listar
as begin
select * from product
end

go

/*
--eliminar

create procedure usp_eliminar(@id int)
as 
begin
delete from product where id_prod= @id*/