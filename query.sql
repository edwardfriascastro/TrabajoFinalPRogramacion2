
CREATE DATABASE [GestionInventario]

GO
ALTER DATABASE [GestionInventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionInventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionInventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionInventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionInventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionInventario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionInventario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionInventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionInventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionInventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionInventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionInventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionInventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionInventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionInventario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestionInventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionInventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionInventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionInventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionInventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionInventario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionInventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionInventario] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionInventario] SET  MULTI_USER 
GO
ALTER DATABASE [GestionInventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionInventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionInventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionInventario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionInventario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionInventario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GestionInventario] SET QUERY_STORE = OFF
GO
USE [GestionInventario]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[idVentas] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[totalVentas] [int] NOT NULL,
	[cantidadProducto] [int] NOT NULL,
	[idFactura] [int] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[idVentas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[idCompra] [int] NOT NULL,
	[idProducto] [int] NULL,
	[cantidadProducto] [int] NULL,
	[precioCompra] [decimal](18, 0) NULL,
	[proveedor] [varchar](50) NULL,
	[fechaCompra] [date] NULL,
	[totalCompras] [decimal](18, 0) NULL,
 CONSTRAINT [PK__Compras__48B99DB71AA58EC2] PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] NOT NULL,
	[nombreProducto] [varchar](30) NULL,
	[descripcion] [varchar](30) NULL,
	[cantidadProducto] [int] NULL,
	[precioVenta] [decimal](18, 0) NULL,
	[proveedor] [varchar](50) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InventarioVentas]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InventarioVentas]
AS
SELECT 
    p.idProducto, 
    p.nombreProducto, 
    p.descripcion, 
    p.cantidadProducto AS stock, 
    p.precioVenta, 
    p.proveedor, 
    ISNULL(SUM(c.cantidadProducto), 0) AS cantidadComprada,
    ISNULL(SUM(c.totalCompras), 0) AS totalComprado,
    ISNULL(SUM(v.cantidadProducto), 0) AS cantidadVendida,
    ISNULL(SUM(v.totalVentas), 0) AS totalVendido,
    (p.cantidadProducto - ISNULL(SUM(v.cantidadProducto), 0)) AS stockDisponible
FROM 
    Productos p 
    LEFT JOIN Compras c ON p.idProducto = c.idProducto
    LEFT JOIN Ventas v ON p.idProducto = v.idProducto
GROUP BY 
    p.idProducto, 
    p.nombreProducto, 
    p.descripcion, 
    p.cantidadProducto, 
    p.precioVenta, 
    p.proveedor

GO
/****** Object:  View [dbo].[Inventario]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Inventario] AS
SELECT 
    p.idProducto,
    p.nombreProducto,
    p.descripcion,
    p.cantidadProducto,
    p.precioVenta,
    p.proveedor,
    COALESCE(SUM(c.cantidadProducto), 0) AS cantidadComprada,
    COALESCE(SUM(c.totalCompras), 0) AS totalComprado,
    COALESCE(AVG(c.precioCompra), 0) AS precioCompra
FROM Productos p
LEFT JOIN Compras c ON p.idProducto = c.idProducto
GROUP BY p.idProducto, p.nombreProducto, p.descripcion, p.cantidadProducto, p.precioVenta, p.proveedor;

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
	[apellido] [varchar](30) NULL,
	[telefono] [varchar](30) NULL,
	[documento] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[fechaIngreso] [date] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[idFactura] [int] NOT NULL,
	[Cliente] [varchar](30) NULL,
	[Descripcion] [varchar](1000) NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK__Factura__3CD5687E272A7E91] PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[admin] [bit] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Productos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Productos]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarCliente]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_ActualizarCliente]
    @idCliente INT,
    @nombre VARCHAR(30),
    @apellido VARCHAR(30),
    @telefono VARCHAR(30),
    @documento VARCHAR(50),
    @direccion VARCHAR(50),
    @fechaIngreso DATE
AS
BEGIN
    UPDATE Cliente
    SET nombre = @nombre,
        apellido = @apellido,
        telefono = @telefono,
        documento = @documento,
        direccion = @direccion,
        fechaIngreso = @fechaIngreso
    WHERE idCliente = @idCliente
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarProducto]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_ActualizarProducto]
    @idProducto int,
    @nombreProducto varchar(30),
    @descripcion varchar(30),
    @cantidadProducto int,
    @precioVenta decimal(18,0),
    @proveedor varchar(50)
AS
BEGIN
    UPDATE Productos
    SET nombreProducto = @nombreProducto,
        descripcion = @descripcion,
        cantidadProducto = @cantidadProducto,
        precioVenta = @precioVenta,
        proveedor = @proveedor
    WHERE idProducto = @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCliente]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarCliente]
    @idCliente int
AS
BEGIN
    DELETE FROM [dbo].[Cliente] WHERE idCliente = @idCliente
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProducto]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarProducto]
    @idProducto int
AS
BEGIN
    DELETE FROM Productos WHERE idProducto = @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCliente]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarCliente]
    @nombre varchar(30),
    @apellido varchar(30),
    @telefono varchar(30),
    @documento varchar(50),
    @direccion varchar(50),
    @fechaIngreso date
AS
BEGIN
    INSERT INTO [dbo].[Cliente] (nombre, apellido, telefono, documento, direccion, fechaIngreso)
    VALUES (@nombre, @apellido, @telefono, @documento, @direccion, @fechaIngreso)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCompra]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[sp_InsertarCompra]
	@idCompra int,
    @idProducto int,
    @cantidadProducto int,
    @precioCompra decimal(18,0),
	@totalCompras decimal(18,0),
    @proveedor varchar(50),
    @fechaCompra date
AS
BEGIN
    INSERT INTO [dbo].[Compras] (idCompra,idProducto, cantidadProducto, precioCompra,proveedor,totalCompras, fechaCompra)
    VALUES (@idCompra,@idProducto, @cantidadProducto, @precioCompra, @proveedor,@totalCompras, @fechaCompra)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarFactura]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[sp_InsertarFactura](

        @idFactura int,

        @Cliente varchar(30),

        @Descripcion varchar(100),

        @Total int

        )

 

as

 

if not exists(SELECT * from Factura where idFactura = @idFactura)

    begin

 

        insert into Factura(idFactura,Cliente,descripcion,Total)

        values (@idFactura,@Cliente,@Descripcion,@Total)

        print 'La factura fue agregada correctamente' 

        return

    end

 

else 

BEGIN

 

    print 'La factura ya existe.'

    return

END


GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProducto]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarProducto]
	@idProducto int,
    @nombreProducto varchar(30),
    @descripcion varchar(30),
    @cantidadProducto int,
    @precioVenta decimal(18,0),
    @proveedor varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos (idProducto,nombreProducto, descripcion, cantidadProducto, precioVenta, proveedor)
    VALUES (@idProducto,@nombreProducto, @descripcion, @cantidadProducto, @precioVenta, @proveedor);

END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarUsuario]
	@nombreUsuario VARCHAR(50),
	@contrasena VARCHAR(50),
	@admin BIT
AS
BEGIN
	INSERT INTO Usuario (nombreUsuario, contrasena, admin)
	VALUES (@nombreUsuario, @contrasena, @admin)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarVenta]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarVenta]
	@idCliente INT,
	@idProducto INT,
	@fechaVenta DATE,
	@totalVentas INT,
	@cantidadProducto INT,
	@idFactura INT
AS
BEGIN
	INSERT INTO Ventas (idCliente, idProducto, fechaVenta, totalVentas, cantidadProducto, idFactura)
	VALUES (@idCliente, @idProducto, @fechaVenta, @totalVentas, @cantidadProducto, @idFactura)
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Reporte]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Reporte]
as
begin
Select * from InventarioVentas
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarCliente]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_SeleccionarCliente]
@idCliente int
AS
begin
    SELECT * FROM Cliente where idCliente = @idCliente;
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarClienteDocumento]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[Sp_SeleccionarClienteDocumento]
@documento varchar(50)
AS
BEGIN
    SELECT * FROM Cliente where [documento] = @documento;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarClienteNombre]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[Sp_SeleccionarClienteNombre]
@nombre varchar(30)
AS
BEGIN
    SELECT * FROM Cliente where nombre = @nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SeleccionarClientes]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SeleccionarClientes]
AS
BEGIN
    SELECT * FROM [dbo].[Cliente]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SeleccionarCompras]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SeleccionarCompras]
AS
BEGIN
    SELECT * FROM [dbo].[Compras]
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarProducto]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_SeleccionarProducto]
@idProducto int
AS
begin
    SELECT * FROM Productos where idProducto = @idProducto;
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarProductoNombre]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Sp_SeleccionarProductoNombre]
@nombreProducto varchar(30)
AS
BEGIN
    SELECT * FROM Productos where nombreProducto = @nombreProducto;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_SeleccionarProductos]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Sp_SeleccionarProductos]
AS
BEGIN
    SELECT * FROM Productos;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SeleccionarUsuarios]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SeleccionarUsuarios]
AS
BEGIN
	SELECT * FROM Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SeleccionarVentas]    Script Date: 4/20/2023 6:42:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SeleccionarVentas]
AS
BEGIN
	SELECT * FROM Ventas
END
GO
USE [master]
GO
ALTER DATABASE [GestionInventario] SET  READ_WRITE 
GO
