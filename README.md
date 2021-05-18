# BackendArkade
Api .net Core Jwt


----------- Crea dataBase ------------

CREATE DATABASE [ARKADEDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARKADEDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ARKADEDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ARKADEDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ARKADEDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [ARKADEDB]
GO

CREATE TABLE [dbo].[CLIENTS](
	ID int IDENTITY(1,1) NOT NULL,
	NAMES vchar(50) NOT NULL,
	PHONE_NUMBER vchar(50) NOT NULL,
	ADDRESS vchar(50) NOT NULL,
	GENDER vchar(50) NOT NULL,
	EMAIL vchar(50) NOT NULL,
	BIRTHDAY date NOT NULL,
	ASSOCIATE_ID int NOT NULL,) ON [PRIMARY])
GO


CREATE TABLE dbo.USERSINFO
	(
	id int  IDENTITY PRIMARY KEY,
	nickName varchar(30) NOT NULL,
	userIdentification varchar(30) NOT NULL,
	fullNames varchar(30) NOT NULL,
	typeAccount bit NOT NULL,
	active bit NOT NULL
	) 


CREATE TABLE [dbo].[USERSLOGIN](
	nickName varchar(30) NOT NULL,
	password varchar(30) NOT NULL,
 ) 
GO



INSERT INTO [dbo].[USERSINFO]
           ([nickName]
           ,[userIdentification]
           ,[fullNames]
           ,[typeAccount]
           ,[active])
     VALUES
           (Admin
           ,1111111
           ,AdminPrincipal>
           ,1
           ,1
GO

INSERT INTO [dbo].[USERSLOGIN]
           ([nickName]
           ,[password])
     VALUES
           (Admin
           ,Admin123)
GO



----------- Configure la coneccion para conectar el programa a tu computador------
