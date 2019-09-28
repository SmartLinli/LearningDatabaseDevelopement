/*
例4.2_记录_控件
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
GO
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
----班级表
CREATE TABLE Class
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT Class
	(No,Name)
	VALUES
	(1,'12卫管')
	,(2,'12信管')
	,(3,'12中医')
	,(4,'12临床');
----学生表；
CREATE TABLE Student
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
	,ClassNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES Class(No)
	,Speciality
		VARCHAR(100)
		NULL);
INSERT Student
	(No,Name,Gender,BirthDate,ClassNo,Speciality)
	VALUES
	('3120707001','田永申',1,'1991-10-15',2,'睡觉');
GO