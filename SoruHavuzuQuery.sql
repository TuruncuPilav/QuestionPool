CREATE DATABASE QuestionPool;

USE QuestionPool;

CREATE TABLE _Member_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(MAX),
    Surname VARCHAR(MAX),
    Email VARCHAR(MAX),
    Gender VARCHAR(MAX),
    Birthday DATE
);

CREATE TABLE _MemberSecurity_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
    Password VARCHAR(64)
);

CREATE TABLE _MemberSettings_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
    CreateDate DATETIME DEFAULT GETDATE(),
    LastEditedDate DATETIME DEFAULT GETDATE(),
    DeletedDate DATETIME,
    Role VARCHAR(MAX) DEFAULT 'student', --admin, teacher, student, (guest)
    Language VARCHAR(MAX) DEFAULT 'tr'
);

CREATE TABLE _Library_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
    Name VARCHAR(MAX),
    Description VARCHAR(MAX),
    Category VARCHAR(MAX)
);

CREATE TABLE _LibrarySettings_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    LibraryId INT FOREIGN KEY REFERENCES _Library_(Id),
    Visibility BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastEditedDate DATETIME DEFAULT GETDATE(),
    DeletedDate DATETIME DEFAULT NULL
);

CREATE TABLE _LibraryMembers_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    LibraryId INT,
    MemberId INT,
    Role VARCHAR(MAX) DEFAULT 'Student',
    AddedDate DATETIME DEFAULT GETDATE(),
    DeletedDate DATETIME DEFAULT NULL,
    FOREIGN KEY (LibraryId) REFERENCES _Library_(Id),
    FOREIGN KEY (MemberId) REFERENCES _Member_(Id)
);


CREATE TABLE _QuestionType_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(MAX)
);

CREATE TABLE _Question_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
    LibraryId INT FOREIGN KEY REFERENCES _Library_(Id),
    QuestionType INT FOREIGN KEY REFERENCES _QuestionType_(Id),
    Question VARCHAR(MAX),
    TrueAnswer VARCHAR(MAX),
    FalseAnswer2 VARCHAR(MAX),
    FalseAnswer3 VARCHAR(MAX),
    FalseAnswer4 VARCHAR(MAX),
    FalseAnswer5 VARCHAR(MAX),
    QuestionImg VARCHAR(MAX)
);

CREATE TABLE _QuestionSettings_(
    Id INT PRIMARY KEY IDENTITY(1,1),
    QuestionId INT FOREIGN KEY REFERENCES _Question_(Id),
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastEditedDate DATETIME DEFAULT GETDATE(),
    DeletedDate DATETIME DEFAULT NULL
);

CREATE TRIGGER trg_ForMemberSettings_
ON _Member_
AFTER INSERT
AS
BEGIN
    INSERT INTO _MemberSettings_ (MemberId)
    SELECT Id
    FROM inserted;
END;

CREATE TRIGGER trg_ForLibrarySettings_
ON _Library_
AFTER INSERT
AS
BEGIN
    INSERT INTO _LibrarySettings_ (LibraryId)
    SELECT Id
    FROM inserted;
END;

CREATE TRIGGER trg_ForLibraryMember_
ON _Library_
AFTER INSERT
AS
BEGIN
    INSERT INTO _LibraryMembers_ (LibraryId, MemberId)
    SELECT Id, MemberId
    FROM inserted;
END;

CREATE TRIGGER trg_QuestionSettings_
ON _Question_
AFTER INSERT
AS
BEGIN
    INSERT INTO _QuestionSettings_ (QuestionId)
    SELECT Id
    FROM inserted;
END;

CREATE TRIGGER trg_UpdateLastEditedDate
ON _QuestionSettings_
AFTER UPDATE
AS
BEGIN
    UPDATE _QuestionSettings_
    SET LastEditedDate = GETDATE()
    FROM inserted
    WHERE _QuestionSettings_.QuestionId = inserted.QuestionId;
END;

CREATE TRIGGER trg_UpdateLibrarySettingsLastEditedDate
ON _LibrarySettings_
AFTER UPDATE
AS
BEGIN
    UPDATE _LibrarySettings_
    SET LastEditedDate = GETDATE()
    FROM inserted
    WHERE _LibrarySettings_.LibraryId = inserted.LibraryId;
END;

CREATE TRIGGER trg_UpdateMemberSettingsLastEditedDate
ON _MemberSettings_
AFTER UPDATE
AS
BEGIN
    UPDATE _MemberSettings_
    SET LastEditedDate = GETDATE()
    FROM inserted
    WHERE _MemberSettings_.MemberId = inserted.MemberId;
END;




//////////////////

CREATE TRIGGER trg_ForMemberSettings_
AFTER INSERT ON _Member_
BEGIN
    INSERT INTO _MemberSettings_ (MemberId, CreateDate, LastEditedDate)
    VALUES (NEW.Id, datetime('now'), datetime('now'));
END;

CREATE TRIGGER trg_ForLibrarySettings_
AFTER INSERT ON _Library_
BEGIN
    INSERT INTO _LibrarySettings_ (LibraryId, CreatedDate, LastEditedDate)
    VALUES (NEW.Id, datetime('now'), datetime('now'));
END;

CREATE TRIGGER trg_ForLibraryMember_
AFTER INSERT ON _Library_
BEGIN
    INSERT INTO _LibraryMembers_ (LibraryId, MemberId)
    VALUES (NEW.Id, NEW.MemberId);
END;

CREATE TRIGGER trg_QuestionSettings_
AFTER INSERT ON _Question_
BEGIN
    INSERT INTO _QuestionSettings_ (QuestionId, CreatedDate, LastEditedDate)
    VALUES (NEW.Id, datetime('now'), datetime('now'));
END;

CREATE TRIGGER trg_UpdateLastEditedDate
AFTER UPDATE ON _QuestionSettings_
BEGIN
    UPDATE _QuestionSettings_
    SET LastEditedDate = datetime('now')
    WHERE QuestionId = NEW.QuestionId;
END;

CREATE TRIGGER trg_UpdateLibrarySettingsLastEditedDate
AFTER UPDATE ON _LibrarySettings_
BEGIN
    UPDATE _LibrarySettings_
    SET LastEditedDate = datetime('now')
    WHERE LibraryId = NEW.LibraryId;
END;

CREATE TRIGGER trg_UpdateMemberSettingsLastEditedDate
AFTER UPDATE ON _MemberSettings_
BEGIN
    UPDATE _MemberSettings_
    SET LastEditedDate = datetime('now')
    WHERE MemberId = NEW.MemberId;
END;


//////////////////








































--CREATE TABLE _Member_(
--	Id INT PRIMARY KEY IDENTITY(1,1),
--	Name VARCHAR(MAX),
--	Surname VARCHAR(MAX),
--	Email VARCHAR(MAX),
--	Password VARCHAR(64),
--	Gender VARCHAR(MAX),
--	Birthday DATE,
--)

--CREATE TABLE _MembersSecurity_(
--	MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
--	Password varchar(64)
--)

--CREATE TABLE _MemberSettings_(
--	MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
--	CreateDate DATETIME DEFAULT GETDATE(),
--	LastEditedDate DATETIME DEFAULT GETDATE(),
--	DeletedDate DATETIME,
--	Role VARCHAR(MAX) DEFAULT 'user',
--	Language VARCHAR(MAX) DEFAULT 'tr',
--)

--CREATE TABLE _Library_(
--	Id INT PRIMARY KEY IDENTITY(1,1),
--	MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
--	Name VARCHAR(MAX),
--	Description VARCHAR(MAX),
--	Category VARCHAR(MAX),
--)

--CREATE TABLE _LibrarySettings_(
--	LibraryId INT FOREIGN KEY REFERENCES _Library_(Id),
--	Visibility BIT DEFAULT 1,
--	CreatedDate DATETIME DEFAULT GETDATE(),
--	LastEditedDate DATETIME DEFAULT GETDATE(),
--	DeletedDate DATETIME DEFAULT NULL,
--)

--CREATE TABLE _LibraryMembers_(
--	LibraryId INT FOREIGN KEY REFERENCES _Library_(Id),
--	MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
--	Role VARCHAR(MAX) DEFAULT 'Admin',
--	AddedDate DATETIME DEFAULT GETDATE(),
--	DeletedDate DATETIME DEFAULT NULL,
--)

--CREATE TABLE _QuestionType_(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	Type VARCHAR(MAX)
--)

--CREATE TABLE _Question_(
--	Id INT PRIMARY KEY IDENTITY(1,1),
--	MemberId INT FOREIGN KEY REFERENCES _Member_(Id),
--	LibraryId INT FOREIGN KEY REFERENCES _Library_(Id),
--	QuestionType INT FOREIGN KEY REFERENCES _QuestionType_(Id),
--	Question VARCHAR(MAX),
--	TrueAnswer VARCHAR(MAX),
--	FalseAnswer2 VARCHAR(MAX),
--	FalseAnswer3 VARCHAR(MAX),
--	FalseAnswer4 VARCHAR(MAX),
--	FalseAnswer5 VARCHAR(MAX),
--	QuestionImg VARCHAR(MAX),
--)

--CREATE TABLE _QuestionSettings_(
--	QuestionId INT FOREIGN KEY REFERENCES _Question_(Id),
--	CreatedDate DATETIME DEFAULT GETDATE(),
--	LastEditedDate DATETIME DEFAULT GETDATE(),
--	DeletedDate DATETIME DEFAULT NULL,
--)

--CREATE TRIGGER trg_ForMemberSettings_
--ON _Member_
--AFTER INSERT
--AS
--BEGIN
--    INSERT INTO _MemberSettings_ (MemberId)
--    SELECT Id
--    FROM inserted
--END

--CREATE TRIGGER trg_ForLibrarySettings_
--ON _Library_
--AFTER INSERT
--AS
--BEGIN
--    INSERT INTO _LibrarySettings_ (LibraryId)
--    SELECT Id
--    FROM inserted
--END

--CREATE TRIGGER trg_ForLibraryMember_
--ON _Library_
--AFTER INSERT
--AS
--BEGIN
--    INSERT INTO _LibraryMembers_ (LibraryId, MemberId)
--    SELECT Id, MemberId
--    FROM inserted
--END

--CREATE TRIGGER trg_QuestionSettings_
--ON _Question_
--AFTER INSERT
--AS
--BEGIN
--    INSERT INTO _QuestionSettings_ (QuestionId)
--    SELECT Id
--    FROM inserted
--END

--CREATE TRIGGER trg_UpdateLastEditedDate
--ON _QuestionSettings_
--AFTER UPDATE
--AS
--BEGIN
--    UPDATE _QuestionSettings_
--    SET LastEditedDate = GETDATE()
--    FROM inserted
--    WHERE _QuestionSettings_.QuestionId = inserted.QuestionId;
--END

--CREATE TRIGGER trg_UpdateLibrarySettingsLastEditedDate
--ON _LibrarySettings_
--AFTER UPDATE
--AS
--BEGIN
--    UPDATE _LibrarySettings_
--    SET LastEditedDate = GETDATE()
--    FROM inserted
--    WHERE _LibrarySettings_.Id = inserted.Id;
--END

--CREATE TRIGGER trg_UpdateMemberSettingsLastEditedDate
--ON _MemberSettings_
--AFTER UPDATE
--AS
--BEGIN
--    UPDATE _MemberSettings_
--    SET LastEditedDate = GETDATE()
--    FROM inserted
--    WHERE _MemberSettings_.Id = inserted.Id;
--END