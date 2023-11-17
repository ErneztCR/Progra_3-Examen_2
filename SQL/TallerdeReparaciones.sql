-- Crear la base de datos
CREATE DATABASE TallerReparacion;
GO

-- Seleccionar la base de datos
USE TallerReparacion;
GO

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(50),
    Telefono VARCHAR(15) UNIQUE
);
GO

-- Crear la tabla Equipos
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50),
    UsuarioID INT FOREIGN KEY REFERENCES Usuarios(UsuarioID)
);
GO

-- Crear la tabla Reparaciones
CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT FOREIGN KEY REFERENCES Equipos(EquipoID),
    FechaSolicitud DATETIME,
    Estado VARCHAR(50)
);
GO

-- Crear la tabla Tecnicos
CREATE TABLE Tecnicos (
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Especialidad VARCHAR(50)
);
GO

-- Crear la tabla Asignaciones
CREATE TABLE Asignaciones (
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
    TecnicoID INT FOREIGN KEY REFERENCES Tecnicos(TecnicoID),
    FechaAsignacion DATETIME
);
GO

-- Crear la tabla DetallesReparacion
CREATE TABLE DetallesReparacion (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
    Descripcion VARCHAR(50),
    FechaInicio DATETIME,
    FechaFin DATETIME
);

-- STORE PROCEDURE

-- Stored Procedure para insertar un nuevo usuario

CREATE PROCEDURE InsertarUsuario
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;

-- Stored Procedure para actualizar los datos de un usuario
CREATE PROCEDURE ActualizarUsuario
    @UsuarioID INT,
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID;
END;

-- Stored Procedure para eliminar un usuario
CREATE PROCEDURE EliminarUsuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM Usuarios
    WHERE UsuarioID = @UsuarioID;
END;

-- Stored Procedure para obtener todos los usuarios
CREATE PROCEDURE ObtenerTodosLosUsuarios
AS
BEGIN
    SELECT * FROM Usuarios;
END;


-- Stored Procedure para insertar un nuevo equipo
CREATE PROCEDURE InsertarEquipo
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;

-- Stored Procedure para actualizar los datos de un equipo
CREATE PROCEDURE ActualizarEquipo
    @EquipoID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo, Modelo = @Modelo, UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID;
END;

-- Stored Procedure para eliminar un equipo
CREATE PROCEDURE EliminarEquipo
    @EquipoID INT
AS
BEGIN
    DELETE FROM Equipos
    WHERE EquipoID = @EquipoID;
END;

-- Stored Procedure para obtener todos los equipos
CREATE PROCEDURE ObtenerTodosLosEquipos
AS
BEGIN
    SELECT * FROM Equipos;
END;


-- Stored Procedure para insertar una nueva reparación
CREATE PROCEDURE InsertarReparacion
    @EquipoID INT,
    @FechaSolicitud DATETIME,
    @Estado VARCHAR(50)
AS
BEGIN
    INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado)
    VALUES (@EquipoID, @FechaSolicitud, @Estado);
END;

-- Stored Procedure para actualizar los datos de una reparación
CREATE PROCEDURE ActualizarReparacion
    @ReparacionID INT,
    @EquipoID INT,
    @FechaSolicitud DATETIME,
    @Estado VARCHAR(50)
AS
BEGIN
    UPDATE Reparaciones
    SET EquipoID = @EquipoID, FechaSolicitud = @FechaSolicitud, Estado = @Estado
    WHERE ReparacionID = @ReparacionID;
END;

-- Stored Procedure para eliminar una reparación
CREATE PROCEDURE EliminarReparacion
    @ReparacionID INT
AS
BEGIN
    DELETE FROM Reparaciones
    WHERE ReparacionID = @ReparacionID;
END;

-- Stored Procedure para obtener todas las reparaciones
CREATE PROCEDURE ObtenerTodasLasReparaciones
AS
BEGIN
    SELECT * FROM Reparaciones;
END;


-- Stored Procedure para insertar un nuevo técnico
CREATE PROCEDURE InsertarTecnico
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO Tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;

-- Stored Procedure para actualizar los datos de un técnico
CREATE PROCEDURE ActualizarTecnico
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre, Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID;
END;

-- Stored Procedure para eliminar un técnico
CREATE PROCEDURE EliminarTecnico
    @TecnicoID INT
AS
BEGIN
    DELETE FROM Tecnicos
    WHERE TecnicoID = @TecnicoID;
END;

-- Stored Procedure para obtener todos los técnicos
CREATE PROCEDURE ObtenerTodosLosTecnicos
AS
BEGIN
    SELECT * FROM Tecnicos;
END;

-- Stored Procedure para asignar un técnico a una reparación
CREATE PROCEDURE AsignarTecnicoAReparacion
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion DATETIME
AS
BEGIN
    INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion)
    VALUES (@ReparacionID, @TecnicoID, @FechaAsignacion);
END;

-- Stored Procedure para actualizar la asignación de un técnico a una reparación
CREATE PROCEDURE ActualizarAsignacion
    @AsignacionID INT,
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion DATETIME
AS
BEGIN
    UPDATE Asignaciones
    SET ReparacionID = @ReparacionID, TecnicoID = @TecnicoID, FechaAsignacion = @FechaAsignacion
    WHERE AsignacionID = @AsignacionID;
END;

-- Stored Procedure para eliminar una asignación
CREATE PROCEDURE EliminarAsignacion
    @AsignacionID INT
AS
BEGIN
    DELETE FROM Asignaciones
    WHERE AsignacionID = @AsignacionID;
END;

-- Stored Procedure para obtener todas las reparaciones
CREATE PROCEDURE ObtenerTodasLasReparaciones
AS
BEGIN
    SELECT * FROM Reparaciones;
END;

