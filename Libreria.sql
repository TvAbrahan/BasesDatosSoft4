USE master;
GO
IF DB_ID(N'Libreria') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE Libreria;');
END;
GO
USE Libreria;
GO
IF OBJECT_ID(N'dbo.Libros', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Libros
    (
        id INT IDENTITY(1, 1) NOT NULL
            CONSTRAINT PK_Libros PRIMARY KEY,
        Titulo NVARCHAR(200) NOT NULL,
        Autor NVARCHAR(150) NOT NULL,
        CantidadDisponible INT NOT NULL
            CONSTRAINT DF_Libros_CantidadDisponible DEFAULT (0),
        CONSTRAINT CK_Libros_Titulo CHECK (LEN(LTRIM(RTRIM(Titulo))) > 0),
        CONSTRAINT CK_Libros_Autor CHECK (LEN(LTRIM(RTRIM(Autor))) > 0),
        CONSTRAINT CK_Libros_Cantidad CHECK (CantidadDisponible >= 0)
    );
END;
GO

-- Por defecto, devuelve solo libros con ejemplares disponibles.
-- @SoloDisponibles = 0 permite gestionar tambien los libros agotados.
-- Columnas estables para el DataGridView: id, Titulo, Autor, CantidadDisponible.
CREATE OR ALTER PROCEDURE dbo.Libros_Listar
    @SoloDisponibles BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    IF @SoloDisponibles IS NULL
        THROW 50001, N'Indique si desea consultar solo los libros disponibles.', 1;

    SELECT id, Titulo, Autor, CantidadDisponible
    FROM dbo.Libros
    WHERE @SoloDisponibles = 0 OR CantidadDisponible > 0
    ORDER BY Titulo, id;
END;
GO

-- Parametros de texto amplios para validar y rechazar longitudes excesivas
-- antes de insertarlas, evitando truncamientos silenciosos en el procedimiento.
-- @NuevoId devuelve el identificador generado, sin consultas adicionales.
CREATE OR ALTER PROCEDURE dbo.Libros_Agregar
    @Titulo NVARCHAR(MAX),
    @Autor NVARCHAR(MAX),
    @CantidadDisponible INT,
    @NuevoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    SET @NuevoId = NULL;
    SET @Titulo = LTRIM(RTRIM(@Titulo));
    SET @Autor = LTRIM(RTRIM(@Autor));

    IF @Titulo IS NULL OR LEN(@Titulo) = 0
        THROW 50002, N'El titulo es obligatorio.', 1;
    IF DATALENGTH(@Titulo) > 400
        THROW 50003, N'El titulo admite como maximo 200 unidades de texto Unicode.', 1;
    IF @Autor IS NULL OR LEN(@Autor) = 0
        THROW 50004, N'El autor es obligatorio.', 1;
    IF DATALENGTH(@Autor) > 300
        THROW 50005, N'El autor admite como maximo 150 unidades de texto Unicode.', 1;
    IF @CantidadDisponible IS NULL OR @CantidadDisponible < 0
        THROW 50006, N'La cantidad disponible debe ser un entero mayor o igual a cero.', 1;

    INSERT INTO dbo.Libros (Titulo, Autor, CantidadDisponible)
    VALUES (@Titulo, @Autor, @CantidadDisponible);

    SET @NuevoId = CONVERT(INT, SCOPE_IDENTITY());
END;
GO

-- Reemplaza la cantidad total disponible; no suma ni resta ejemplares.
CREATE OR ALTER PROCEDURE dbo.Libros_ActualizarCantidad
    @Id INT,
    @CantidadDisponible INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF @Id IS NULL OR @Id <= 0
        THROW 50007, N'El identificador del libro debe ser un entero positivo.', 1;
    IF @CantidadDisponible IS NULL OR @CantidadDisponible < 0
        THROW 50006, N'La cantidad disponible debe ser un entero mayor o igual a cero.', 1;

    UPDATE dbo.Libros
    SET CantidadDisponible = @CantidadDisponible
    WHERE id = @Id;

    IF @@ROWCOUNT = 0
        THROW 50008, N'No existe un libro con el identificador indicado.', 1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.Libros_Eliminar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF @Id IS NULL OR @Id <= 0
        THROW 50007, N'El identificador del libro debe ser un entero positivo.', 1;

    DELETE FROM dbo.Libros WHERE id = @Id;

    IF @@ROWCOUNT = 0
        THROW 50008, N'No existe un libro con el identificador indicado.', 1;
END;
GO