/*
表_网格视图
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
----班级表
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
	(1,'20公管')
	,(2,'20信管')
	,(3,'20中医')
	,(4,'20临床');
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
	,ClassNo
		INT
		NOT NULL
	,Speciality
		VARCHAR(100)
		NULL
	,Photo
		VARBINARY(MAX)
		NULL);
INSERT tb_Student
	(No,Name,Gender,BirthDate,ClassNo,Speciality)
	VALUES
	('3200707001','闭敏媛',0,'2001-7-21',2,'唱歌')
	,('3200707003','储艺',0,'2001-7-12',2,'跳舞')
	,('3200707014','胡江彬',1,'2001-9-6',2,'打篮球')
	,('3200707023','林金川',1,'2001-7-18',2,NULL);