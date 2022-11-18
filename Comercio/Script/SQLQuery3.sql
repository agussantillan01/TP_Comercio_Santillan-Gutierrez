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
Email varchar(100) null,
FechaNacimiento date not null,
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


--*********PROCEDICIMIENTOS ALMACENADOS*********

go
Create Procedure SP_ModificaProducto(
@Id bigint, 
@Nombre varchar (100),
@IdTipo bigint,
@Descripcion varchar (300),
@IdMarca bigint,
@Stock int, 
@StockMinimo smallint, 
@Precio money
)
as
Begin
update Productos set 
nombre = @nombre,
Descripcion = @descripcion,
IdMarca = @IDMarca,
IdTipo = @IdTipo,
Precio = @precio,
Stock = @stock, 
StockMinimo = @StockMinimo
Where IdProducto = @Id
end

go
create procedure SP_AgregarProducto(
	@Nombre varchar(100),
	@IdTipo bigint,
	@Descripcion varchar(300),
	@IdMarca bigint,
	@Stock int,
	@StockMinimo smallint,
	@Precio money
)as
Insert into Productos values (@Nombre,@IdTipo, @Descripcion,@IdMarca,@Stock,@StockMinimo,@Precio,1)


go

create procedure SP_ValidacionUsuario (
	@Email varchar (100),
	@Contraseña varchar(100)
)as 
BEGIN
Select U.IdUsuario from Usuarios U
Where U.Email = @Email AND U.Contraseña = @Contraseña
END

go
Create Procedure SP_EliminaProducto(@Id bigint)
as
Begin
delete Productos Where IdProducto = @Id
end
go 
--MODIFICA MARCA
Create Procedure SP_ModificaMarca(
@IdMarca bigint,
@Nombre varchar (100)
)
as
Begin
update Marcas set nombre = @Nombre
Where IdMarca = @IdMarca
end
go 

--MODIFICA CATEGORIA 


Create Procedure SP_ModificaCategoria(
	@IdCategoria bigint, 
	@Nombre varchar (100)
) as 
begin 
update Tipo_Productos set Nombre = @Nombre
Where IdTipo = @IdCategoria
end



--LISTA MARCAS

go
Create Procedure SP_ListaMarcas as 
begin 
Select IdMarca,Nombre from Marcas  
end 


go

--LISTA CATEGORIAS
Create Procedure SP_ListaCategorias as 
begin 
Select IdTipo,Nombre from Tipo_Productos
end
Go
-- LISTA CLIENTES 
Create Procedure SP_ListaClientes As 
BEGIN 
Select IdCliente, Nombre, Apellido,Email, FechaNacimiento from Clientes  
END 

--AGREGAR CLIENTES
Go 
create procedure SP_AgregarCliente(
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Email varchar(100),
	@FechaNacimiento date
)as
BEGIN
Insert into Clientes (Nombre,Apellido,Email,FechaNacimiento) values (@Nombre,@Apellido, @Email,@FechaNacimiento)
END
