﻿CREATE TABLE [dbo].[ToDoItem]
(
	ToDoItemId INT IDENTITY(1,1) NOT NULL 
		CONSTRAINT PK_ToDoItem PRIMARY KEY CLUSTERED (ToDoItemId)
	,ToDoItemName NVARCHAR(255) 
	,IsComplete BIT NOT NULL  
		CONSTRAINT DF_ToDoItem_IsComplete DEFAULT 0
	,CreatedDate DATETIMEOFFSET(2) NOT NULL 
		CONSTRAINT DF_ToDoItem_CreatedDate DEFAULT GETUTCDATE() 
)