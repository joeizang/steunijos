CREATE TABLE `AspNetRoles` (
    `Id` varchar(767) NOT NULL,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    `ConcurrencyStamp` text NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AspNetUsers` (
    `Id` varchar(767) NOT NULL,
    `UserName` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `Email` varchar(256) NULL,
    `NormalizedEmail` varchar(256) NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` text NULL,
    `SecurityStamp` text NULL,
    `ConcurrencyStamp` text NULL,
    `PhoneNumber` text NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` timestamp NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `ContactUsSubmissions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SendersFullName` varchar(200) NOT NULL,
    `ReceivingEmailAddress` varchar(150) NOT NULL,
    `SubmissionDate` timestamp NOT NULL,
    `SendersEmail` varchar(150) NOT NULL,
    `MessageSent` varchar(1500) NULL,
    `MessageType` varchar(150) NULL,
    `MessageSubject` varchar(200) NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `Editors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Designation` varchar(150) NULL,
    `DepartmentName` varchar(200) NULL,
    `FacultyName` varchar(200) NULL,
    `UniversityName` varchar(200) NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `Journals` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IssnNo` varchar(20) NULL,
    `VolumeName` varchar(50) NULL,
    `ActualPath` varchar(300) NULL,
    `SavedPath` varchar(300) NULL,
    `CopyrightYear` timestamp NULL,
    `JournalContentId` int NOT NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `PaperAuthors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Designation` varchar(20) NULL,
    `DepartmentName` varchar(150) NULL,
    `FacultyName` varchar(150) NULL,
    `UniversityName` varchar(150) NULL,
    `IsValidAuthor` tinyint(1) NOT NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`)
);


CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(767) NOT NULL,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(767) NOT NULL,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(128) NOT NULL,
    `ProviderKey` varchar(128) NOT NULL,
    `ProviderDisplayName` text NULL,
    `UserId` varchar(767) NOT NULL,
    PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(767) NOT NULL,
    `RoleId` varchar(767) NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(767) NOT NULL,
    `LoginProvider` varchar(128) NOT NULL,
    `Name` varchar(128) NOT NULL,
    `Value` text NULL,
    PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `Papers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(50) NULL,
    `SavedPath` varchar(300) NULL,
    `PaperOriginalName` varchar(250) NULL,
    `ActualPath` varchar(300) NULL,
    `PaperTopic` varchar(250) NULL,
    `JournalId` int NOT NULL,
    `ThumbnailPath` varchar(300) NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Papers_Journals_JournalId` FOREIGN KEY (`JournalId`) REFERENCES `Journals` (`Id`) ON DELETE RESTRICT
);


CREATE TABLE `JournalContents` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ContentTitle` varchar(150) NULL,
    `PaperAuthorId` int NOT NULL,
    `JournalPosition` int NOT NULL,
    `JournalId` int NOT NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_JournalContents_Journals_JournalId` FOREIGN KEY (`JournalId`) REFERENCES `Journals` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_JournalContents_PaperAuthors_PaperAuthorId` FOREIGN KEY (`PaperAuthorId`) REFERENCES `PaperAuthors` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `PaperPayments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TellerNumber` varchar(150) NULL,
    `AmountPaid` decimal(12,2) NOT NULL,
    `AuthorName` varchar(150) NULL,
    `PaymentDate` timestamp NULL,
    `PaperAuthorId` int NULL,
    `CreatedAt` timestamp NOT NULL,
    `UpdatedAt` timestamp NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PaperPayments_PaperAuthors_PaperAuthorId` FOREIGN KEY (`PaperAuthorId`) REFERENCES `PaperAuthors` (`Id`) ON DELETE RESTRICT
);


CREATE TABLE `AuthorsPapers` (
    `PaperId` int NOT NULL,
    `PaperAuthorId` int NOT NULL,
    PRIMARY KEY (`PaperAuthorId`, `PaperId`),
    CONSTRAINT `FK_AuthorsPapers_PaperAuthors_PaperAuthorId` FOREIGN KEY (`PaperAuthorId`) REFERENCES `PaperAuthors` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AuthorsPapers_Papers_PaperId` FOREIGN KEY (`PaperId`) REFERENCES `Papers` (`Id`) ON DELETE CASCADE
);


CREATE TABLE `PaperPaperAuthor` (
    `AuthorsId` int NOT NULL,
    `PapersId` int NOT NULL,
    PRIMARY KEY (`AuthorsId`, `PapersId`),
    CONSTRAINT `FK_PaperPaperAuthor_PaperAuthors_AuthorsId` FOREIGN KEY (`AuthorsId`) REFERENCES `PaperAuthors` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PaperPaperAuthor_Papers_PapersId` FOREIGN KEY (`PapersId`) REFERENCES `Papers` (`Id`) ON DELETE CASCADE
);


CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);


CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);


CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);


CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);


CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);


CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);


CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);


CREATE INDEX `IX_AuthorsPapers_PaperId` ON `AuthorsPapers` (`PaperId`);


CREATE UNIQUE INDEX `IX_JournalContents_JournalId` ON `JournalContents` (`JournalId`);


CREATE INDEX `IX_JournalContents_PaperAuthorId` ON `JournalContents` (`PaperAuthorId`);


CREATE INDEX `IX_PaperPaperAuthor_PapersId` ON `PaperPaperAuthor` (`PapersId`);


CREATE INDEX `IX_PaperPayments_PaperAuthorId` ON `PaperPayments` (`PaperAuthorId`);


CREATE INDEX `IX_Papers_JournalId` ON `Papers` (`JournalId`);


