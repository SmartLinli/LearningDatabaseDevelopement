/*
实体框架_增查改删
*/
--创建数据库；
USE master;
IF DB_ID('EduBaseDemo') IS NOT NULL
	BEGIN
		ALTER DATABASE EduBaseDemo
			SET SINGLE_USER
			WITH ROLLBACK IMMEDIATE;
		DROP DATABASE EduBaseDemo;
	END
CREATE DATABASE EduBaseDemo
	ON
		(NAME='Datafile'
		,FILENAME='C:\DataFile.mdf')
	LOG ON
		(NAME='Logfile'
		,FILENAME='C:\Logfile.ldf');
GO
USE EduBaseDemo;
--创建表；
----班级表；
CREATE TABLE tb_Class
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL)
INSERT tb_Class
	(No,Name)
	VALUES
	(1,'18公管')
	,(2,'18信管')
	,(3,'18中医')
	,(4,'18临床');
----学生表；
CREATE TABLE tb_Student
	(No
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,Gender
		BIT
		NOT NULL
	,BirthDate
		DATE
		NOT NULL
	,PoliticalStatus
		VARCHAR(100)
		NULL
	,Nationality
		VARCHAR(100)
		NULL
	,Province
		VARCHAR(100)
		NULL
	,City
		VARCHAR(100)
		NULL
	,GraduateFrom
		VARCHAR(100)
		NULL
	,IdentificationCard
		VARCHAR(100)
		NULL
	,Phone
		VARCHAR(100)
		NULL
	,Speciality
		VARCHAR(100)
		NULL
	,Photo
		VARBINARY(MAX)
		NULL	
	,ClassNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Class(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION);
----批量插入学生表；
BULK INSERT tb_Student
	FROM 'C:\Student.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);