create database proyect_tds

use proyect_tds





create table tipo_user
(
id_type int primary key,
tipo_usuario varchar (50)
);

create table log_in
(
id_user int primary key,
nombre varchar(50),
pass varchar (50),
id_Tipo int not null
);

insert tipo_user values (2, 'Empleado')

insert log_in values (1,'Cristopher', '123456', 1)

select * from log_in


