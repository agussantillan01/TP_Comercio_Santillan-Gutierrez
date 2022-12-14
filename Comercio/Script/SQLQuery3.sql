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


create table Productos(
IdProducto bigint not null identity(1,1) primary key,
Nombre varchar (100) not null, 
IdTipo bigint not null foreign key references Tipo_Productos (IdTipo),
Descripcion varchar (300) null, 
IdMarca bigint not null foreign key references Marcas (IdMarca), 
Stock int not null, 
StockMinimo smallint not null,
Precio Money not null,
Porcentaje int not null,
Estado bit not null default 1
)
go 
Create table Usuarios (
IdUsuario bigint not null identity (1,1) primary key, 
Email varchar (100) not null,
Contraseņa varchar (100) not null,
TipoUser int not null
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
Nombre varchar (100) not null,
Cuil varchar (200) not null, 
Domicilio varchar(200) not null, 
Email varchar(100) null, 
Estado bit not null default 1
)
go
Create table Clientes(
IdCliente bigint not null identity(1,1) primary key, 
Nombre varchar (100) not null, 
Apellido varchar (100) not null,
Email varchar(100) null,
FechaNacimiento datetime not null,
Estado bit default 1
)
go

--Productos (mios) que se vende a clientes
Create table Ventas_movimiento (
IdVentaMovimiento bigint not null identity(1,1) primary key, 
IdCliente bigint not null foreign key references Clientes (IdCliente), 
IdProducto bigint not null foreign key references Productos (IdProducto), 
FechaVenta datetime null,
Cantidad int not null, 
Precio decimal not null
)

go


--Productos que se compra a los proveedores
Create table Compra_movimiento(
IdCompraMovimiento bigint not null identity (1,1) primary key, 
IdProducto bigint not null foreign key references Productos (IdProducto),
IdProveedores bigint not null foreign key references Proveedores (IdProveedor),
Cantidad smallint not null,
Precio money not null
)


						--*********PROCEDICIMIENTOS ALMACENADOS*********

--MODIFICA PRODUCTOS
go
Create Procedure SP_ModificaProducto(
@Id bigint, 
@Nombre varchar (100),
@IdTipo bigint,
@Descripcion varchar (300),
@IdMarca bigint,
@Stock int, 
@StockMinimo smallint, 
@Precio money,
@Porcentaje int
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
StockMinimo = @StockMinimo,
Porcentaje = @Porcentaje
Where IdProducto = @Id
end


--AGREGA PRODUCTOS
go
create procedure SP_AgregarProducto(
	@Nombre varchar(100),
	@IdTipo bigint,
	@Descripcion varchar(300),
	@IdMarca bigint,
	@Stock int,
	@StockMinimo smallint,
	@Precio money,
	@Porcentaje int
)as
Insert into Productos values (@Nombre,@IdTipo, @Descripcion,@IdMarca,@Stock,@StockMinimo,@Precio,@Porcentaje,1)


go

-- VALIDA USUARIO  => CHEQUEAR
create procedure SP_ValidacionUsuario (
	@Email varchar (100),
	@Contraseņa varchar(100)
)as 
BEGIN
Select U.IdUsuario from Usuarios U
Where U.Email = @Email AND U.Contraseņa = @Contraseņa
END


--ELIMINA PRODUCTO
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
Create Procedure SP_AgregarCliente(
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Email varchar(100),
	@FechaNacimiento date
)as
BEGIN
Insert into Clientes (Nombre,Apellido,Email,FechaNacimiento) values (@Nombre,@Apellido, @Email,@FechaNacimiento)
END

GO
-- LISTA PROVEEDORES
Create Procedure SP_ListaProveedores As 
BEGIN 
Select IdProveedor, Nombre, Domicilio,Email, Cuil from Proveedores  
END 

--AGREGAR Proveedores
Go 
create Procedure SP_AgregarProveedores(
	@Nombre varchar(100),
	@Domicilio varchar(100),
	@Email varchar(100),
	@Cuil varchar(100)
)as
BEGIN
Insert into Proveedores (Nombre,Domicilio,Email,Cuil) values (@Nombre,@Domicilio, @Email,@Cuil)
END

Go
--MODIFICA CLIENTE
Create Procedure SP_ModificaCliente(
	@IdCliente bigint,
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Email varchar(100),
	@FechaNacimiento datetime
)as
BEGIN
Update Clientes set Nombre=@Nombre,Apellido=@Apellido, Email=@Email,FechaNacimiento=@FechaNacimiento
Where IdCliente=@IdCliente
END
Go
--MODIFICA PROVEEDOR
Create Procedure SP_ModificaProveedor(
	@IdProveedor bigint,
	@Nombre varchar(100),
	@Cuil varchar (200),
	@Domicilio varchar(200),
	@Email varchar(100)
	
)as
BEGIN
Update Proveedores set Nombre=@Nombre,Cuil=@Cuil,Domicilio=@Domicilio, Email=@Email
Where IdProveedor=@IdProveedor
END


GO

--AGREGAR COMPRA
CREATE PROCEDURE SP_AgregarCompra (
	@IDProducto bigint, 
	@IdProveedor bigint, 
	@Cantidad smallint,
	@Precio Money
)AS 
BEGIN 
	Insert into Compra_movimiento(IdProducto,IdProveedores, Cantidad, Precio)
	values (@IDProducto,@IdProveedor,@Cantidad,@Precio)

	
	declare @cantidadStock int 
	declare @stockActual int 
	Select @cantidadStock=Stock from Productos where idProducto=@IDProducto
	set @stockActual = @cantidadStock+ @Cantidad 
	Update Productos SET Stock=@stockActual WHERE IdProducto= @IdProducto
	Update Productos SET Precio=@Precio WHERE IdProducto= @IdProducto
END

GO
--AGREGAR USUARIO
CREATE PROCEDURE SP_AgregarUsuario( 
@Email varchar (100),
@Contraseņa varchar(100)
) AS
BEGIN
Declare @CantidadUsuarios int 
Select @CantidadUsuarios= COUNT(DISTINCT U.IdUsuario) from Usuarios U 
IF (@CantidadUsuarios = 0) BEGIN 
insert into Usuarios (Email,Contraseņa,TipoUser) output inserted.IdUsuario values (@Email,@Contraseņa,2)
END 
ELSE BEGIN
insert into Usuarios (Email,Contraseņa,TipoUser) output inserted.IdUsuario values (@Email,@Contraseņa,1)
END 
END

--AGREGA VENTA 
Go
CREATE PROCEDURE SP_AgregarVenta (
	@IdCliente bigint, 
	@IdProducto bigint, 
	@Cantidad int, 
	@Precio decimal
)AS
BEGIN
		Insert into Ventas_movimiento (IdCliente, IdProducto, FechaVenta, Cantidad, Precio)
		values (@IdCliente,@IdProducto,getdate(),@Cantidad, @Precio)

	declare @cantidadStock int 
	declare @stockActual int 
	Select @cantidadStock=Stock from Productos where IdProducto=@IdProducto
	set @stockActual = @cantidadStock- @Cantidad 
	Update Productos SET Stock=@stockActual WHERE IdProducto= @IdProducto
END

--LISTA USUARIOS
Go
CREATE PROCEDURE SP_listarUsuarios (
	@Email varchar (100)
)AS 
BEGIN 
	Select u.IdUsuario,Email,Contraseņa,TipoUser from usuarios U
	Where Email not like @Email AND TipoUser = 1
END

--HACER ADMIN
go
create Procedure SP_HacerAdmin(@IdUsuario bigint)
as
Begin
update Usuarios SET TipoUser=2  Where IdUsuario = @IdUsuario
end
go


-- ELIMINA PRODUCTO 
drop Procedure SP_EliminaProducto 
--ELIMINA PRODUCTO
go
Create Procedure SP_EliminaProducto(@Id bigint)
as
Begin
update Productos set Estado = 0 Where IdProducto = @Id
end