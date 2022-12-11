select * from log_in;

use proyect_tds;

create table product
(
id_prod int not null primary key,
prod_type varchar(150),
prod_name varchar(150),
prod_price varchar(50)
);