﻿CREATE TABLE [dbo].[ClubMembers]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[StudentId] BIGINT NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL,
	[Gender] VARCHAR(50) NOT NULL,
	[Program] VARCHAR(50) NOT NULL
)

