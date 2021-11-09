/*
实体框架_投影
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
----院系表；
CREATE TABLE tb_Department
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT tb_Department
	(No,Name)
	VALUES
	(1,'管理学院')
	,(2,'中医学院');
----专业表；
CREATE TABLE tb_Major
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,DepartmentNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Department(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION);
INSERT tb_Major
	(No,Name,DepartmentNo)
	VALUES
	(1,'公管',1)
	,(2,'信管',1)
	,(3,'中医',2)
	,(4,'临床',2);
----班级表；
CREATE TABLE tb_Class
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,MajorNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Major(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION)
INSERT tb_Class
	(No,Name,MajorNo)
	VALUES
	(1,'19公管1',1)
	,(2,'19公管2',1)
	,(3,'19信管',2)
	,(4,'19中医',3)
	,(5,'19临床',4);
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