Create database TP_Comercio
go
Use TP_Comercio
go 
Create table Marcas(
IdMarca bigint not null identity(1,1) primary key,
Nombre varchar (100) not null
)
go
Create table Tipo_Productos(
IdTipo bigint not null identity(1,1) primary key, 
Nombre varchar (100) not null
)
go
Create table Productos(
IdProducto bigint not null identity(1,1) primary key,
Nombre varchar (100) not null, 
IdTipo bigint not null foreign key references Tipo_Productos (IdTipo),
Descripcion varchar (300) null, 
IdMarca bigint not null foreign key references Marcas (IdMarca), 
Stock int not null, 
StockMinimo smallint not null,
Precio Money not null,
Estado bit not null default 1
)
go 
Create table Usuarios (
IdUsuario bigint not null identity (1,1) primary key, 
Nombre varchar (50) not null,
Apellido varchar (50) not null,
Email varchar (100) not null,
Contraseña varchar (100) not null,
FechaNacimiento date not null, 
Estado bit not null default 1
)
go 
Create table Usuario_X_Productos (
IdUsuario bigint not null foreign key references Usuarios(IdUsuario),
IdProducto bigint not null foreign key references Productos (IdProducto),
Cantidad int not null
)
go
Create table Proveedores(
IdProveedor bigint not null identity(1,1) primary key,
razonSocial varchar (200) not null, 
Domicilio varchar(200) not null, 
IdProducto bigint not null foreign key references Productos (IdProducto), 
Estado bit not null default 1
)
go
Create table Clientes(
IdCliente bigint not null identity(1,1) primary key, 
Nombre varchar (100) not null, 
Apellido varchar (100) not null, 
FechaNacimiento datetime not null,
Estado bit default 1
)
go
--Productos (mios) que se vende a clientes
Create table Ventas_movimiento (
IdVentaMovimiento bigint not null identity(1,1) primary key, 
IdCliente bigint not null foreign key references Clientes (IdCliente), 
IdProducto bigint not null foreign key references Productos (IdProducto), 
Cantidad int not null
)
go
--Productos que se compra a los proveedores
Create table Compra_movimiento(
IdCompraMovimiento bigint not null identity (1,1) primary key, 
IdProducto bigint not null foreign key references Productos (IdProducto),
IdProveedor bigint not null foreign key references Proveedores (IdProveedor),
IdUsuario bigint not null foreign key references Usuarios(IdUsuario),
Cantidad smallint not null,
Precio money not null
)