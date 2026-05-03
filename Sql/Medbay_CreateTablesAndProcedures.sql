CREATE TABLE dbo.Gender (
    GenderID INT IDENTITY PRIMARY KEY,
    GenderName NVARCHAR(30) NOT NULL
)

GO

CREATE TABLE dbo.Patients (
    ID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Dob DATE NOT NULL,
    GenderID INT REFERENCES dbo.Gender(GenderID),
    Phone VARCHAR(50),
    Address NVARCHAR(500)
)

GO

CREATE PROCEDURE dbo.Patients_List
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.ID,
           p.FullName,
           p.Dob,
           p.GenderID,
           g.GenderName,
           p.Phone,
           p.Address
    FROM dbo.Patients AS p
    INNER JOIN dbo.Gender AS g ON g.GenderID = p.GenderID
    ORDER BY p.ID DESC;
END
GO

CREATE PROCEDURE dbo.Patients_Insert
    @FullName NVARCHAR(200),
    @Dob DATE,
    @GenderID INT,
    @Phone VARCHAR(50) = NULL,
    @Address NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Patients (FullName, Dob, GenderID, Phone, Address)
    VALUES (@FullName, @Dob, @GenderID, @Phone, @Address);

    SELECT SCOPE_IDENTITY() AS NewID;
END
GO

CREATE PROCEDURE dbo.Patients_Update
    @ID INT,
    @FullName NVARCHAR(200),
    @Dob DATE,
    @GenderID INT,
    @Phone VARCHAR(50) = NULL,
    @Address NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Patients
    SET FullName = @FullName,
        Dob = @Dob,
        GenderID = @GenderID,
        Phone = @Phone,
        Address = @Address
    WHERE ID = @ID;
END
GO

CREATE PROCEDURE dbo.Patients_Delete @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Patients
    WHERE ID = @ID;
END
GO
