USE [master]
GO 

SET NOCOUNT ON; 

IF DB_ID('ToDo') IS NULL 
BEGIN 
	EXEC SP_ExecuteSql N'CREATE DATABASE Todo'
END 
ELSE 
BEGIN 
	PRINT 'DB Already Exists '
END 

CREATE LOGIN [ToDoApp] WITH PASSWORD = 'ToDo@App123!'

USE ToDo 
GO

CREATE USER [ToDoApp] FOR LOGIN [ToDoApp] 

EXEC sp_addrolemember 'db_owner', 'ToDoApp'


