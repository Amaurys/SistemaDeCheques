create database SistemaDeCheques;

use SistemaDeCheques;

create table conceptoDePago(
	id int primary key auto_increment,
    descripcion nvarchar(100) not null,
    estado bit not null
);

CREATE TABLE Proveedores(
	id INT auto_increment PRIMARY KEY NOT NULL, 
    Nombre nvarchar(50) NOT NULL, 
    Tipo_Persona nvarchar(45) NOT NULL, 
    Cedula_O_RNC nvarchar(15) NOT NULL, 
    Balance decimal(8,2) NOT NULL, 
    Cuenta_C_Proveedor nvarchar(15) NOT NULL, 
    Estado bit NOT NULL
);

CREATE TABLE Registro_Solicitud_Cheque(
    Numero_Solicitud INT primary key auto_increment NOT NULL, 
    idProveedor int NOT NULL, 
    Monto decimal(8,2) NOT NULL, 
    Fecha_Registro DATE NOT NULL, 
    Estado bit NOT NULL,
    Cuenta_C_Cuenta_CR_Banco varchar(15) NOT NULL,
    foreign key (Numero_Solicitud) references Proveedores(id)
);


