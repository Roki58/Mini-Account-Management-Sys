-- Create Tables
CREATE TABLE ChartOfAccounts (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    ParentId INT NULL,
    AccountType NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Vouchers (
    Id INT PRIMARY KEY IDENTITY,
    VoucherType NVARCHAR(50) NOT NULL,  -- Journal, Payment, Receipt
    VoucherDate DATE NOT NULL,
    ReferenceNo NVARCHAR(50),
    CreatedBy NVARCHAR(450),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE VoucherEntries (
    Id INT PRIMARY KEY IDENTITY,
    VoucherId INT NOT NULL FOREIGN KEY REFERENCES Vouchers(Id),
    AccountId INT NOT NULL FOREIGN KEY REFERENCES ChartOfAccounts(Id),
    Debit DECIMAL(18, 2) DEFAULT 0,
    Credit DECIMAL(18, 2) DEFAULT 0,
    Narration NVARCHAR(255)
);
GO

CREATE TABLE UserPermissions (
    Id INT PRIMARY KEY IDENTITY,
    UserId NVARCHAR(450) NOT NULL,
    Module NVARCHAR(100) NOT NULL,
    CanAccess BIT NOT NULL
);
GO

-- Create Table Type
CREATE TYPE VoucherEntryType AS TABLE (
    AccountId INT,
    Debit DECIMAL(18,2),
    Credit DECIMAL(18,2),
    Narration NVARCHAR(255)
);
GO

-- Stored Procedure: sp_ManageChartOfAccounts
CREATE PROCEDURE sp_ManageChartOfAccounts
    @Action NVARCHAR(10),
    @Id INT = NULL,
    @Name NVARCHAR(100) = NULL,
    @ParentId INT = NULL,
    @AccountType NVARCHAR(50) = NULL
AS
BEGIN
    IF @Action = 'Insert'
    BEGIN
        INSERT INTO ChartOfAccounts (Name, ParentId, AccountType)
        VALUES (@Name, @ParentId, @AccountType);
    END
    ELSE IF @Action = 'Update'
    BEGIN
        UPDATE ChartOfAccounts
        SET Name = @Name, ParentId = @ParentId, AccountType = @AccountType
        WHERE Id = @Id;
    END
    ELSE IF @Action = 'Delete'
    BEGIN
        DELETE FROM ChartOfAccounts WHERE Id = @Id;
    END
    ELSE IF @Action = 'GetAll'
    BEGIN
        SELECT * FROM ChartOfAccounts;
    END
END;
GO

-- Stored Procedure: sp_SaveVoucher
CREATE PROCEDURE sp_SaveVoucher
    @VoucherType NVARCHAR(50),
    @VoucherDate DATE,
    @ReferenceNo NVARCHAR(50),
    @CreatedBy NVARCHAR(450),
    @Entries VoucherEntryType READONLY
AS
BEGIN
    DECLARE @VoucherId INT;

    INSERT INTO Vouchers (VoucherType, VoucherDate, ReferenceNo, CreatedBy)
    VALUES (@VoucherType, @VoucherDate, @ReferenceNo, @CreatedBy);

    SET @VoucherId = SCOPE_IDENTITY();

    INSERT INTO VoucherEntries (VoucherId, AccountId, Debit, Credit, Narration)
    SELECT @VoucherId, AccountId, Debit, Credit, Narration FROM @Entries;
END;
GO