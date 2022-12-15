create database proyect_tds

use proyect_tds





create table producto
(
id_prod int not null primary key identity(1,1),
prod_name varchar(150),
prod_price varchar(50),
prod_date datetime default getdate(),
prod_type int not null,
CONSTRAINT FK_producto_prod_type FOREIGN KEY (prod_type) REFERENCES prod_type (id_typProd)
);

/*create table prod_type
(
id_typProd int not null primary key identity (1,1),
type_names varchar (50),

)*/





select * from log_in





