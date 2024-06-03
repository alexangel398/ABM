create database ABMProveedoresDb;
GO
use ABMProveedoresDb;
GO

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(15),
    Email NVARCHAR(50)
);
drop table Proveedores
