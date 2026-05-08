
CREATE TABLE dbo.Gender
(
    GenderID   INT           NOT NULL CONSTRAINT PK_Gender PRIMARY KEY IDENTITY(1, 1),
    GenderName NVARCHAR(30)  NOT NULL
);

GO

CREATE TABLE dbo.Patients
(
    ID       INT           NOT NULL CONSTRAINT PK_Patients PRIMARY KEY IDENTITY(1, 1),
    FullName NVARCHAR(200) NOT NULL,
    Dob      DATE          NOT NULL,
    GenderID INT           NOT NULL,
    Phone    VARCHAR(50)   NULL,
    Address  NVARCHAR(500) NULL,
    PersonalNumber VARCHAR(11)  NULL,
    Email          VARCHAR(254) NULL,
    CONSTRAINT FK_Patients_Gender FOREIGN KEY (GenderID) REFERENCES dbo.Gender (GenderID)
);
GO

ALTER TABLE dbo.Patients
ADD CONSTRAINT CK_Patients_PersonalNumber_11Digits
CHECK (
    PersonalNumber IS NULL
    OR (LEN(PersonalNumber) = 11 AND PersonalNumber NOT LIKE '%[^0-9]%')
);
GO

ALTER TABLE dbo.Patients
ADD CONSTRAINT CK_Patients_Email_HasAt
CHECK (
    Email IS NULL
    OR Email LIKE '%@%'
);
GO

CREATE UNIQUE INDEX UX_Patients_PersonalNumber
ON dbo.Patients (PersonalNumber)
WHERE PersonalNumber IS NOT NULL;
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
           p.Address,
           p.PersonalNumber,
           p.Email
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
    @Address NVARCHAR(500) = NULL,
    @PersonalNumber VARCHAR(11) = NULL,
    @Email VARCHAR(254) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Patients (FullName, Dob, GenderID, Phone, Address, PersonalNumber, Email)
    VALUES (@FullName, @Dob, @GenderID, @Phone, @Address, @PersonalNumber, @Email);

    SELECT SCOPE_IDENTITY() AS NewID;
END
GO

CREATE PROCEDURE dbo.Patients_Update
    @ID INT,
    @FullName NVARCHAR(200),
    @Dob DATE,
    @GenderID INT,
    @Phone VARCHAR(50) = NULL,
    @Address NVARCHAR(500) = NULL,
    @PersonalNumber VARCHAR(11) = NULL,
    @Email VARCHAR(254) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Patients
    SET FullName = @FullName,
        Dob = @Dob,
        GenderID = @GenderID,
        Phone = @Phone,
        Address = @Address,
        PersonalNumber = @PersonalNumber,
        Email = @Email
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
