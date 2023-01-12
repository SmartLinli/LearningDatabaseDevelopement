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
	(1,'21公管')
	,(2,'21信管')
	,(3,'21中医')
	,(4,'21临床');
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
	('3210707001','田杰红',0,'2001-9-10',2,'唱歌')
	,('3210707002','刘兰',0,'2003-2-9',2,'跳舞')
	,('3210707003','吴争宇',1,'2004-1-5',2,'打篮球')
	,('3210707004','廖丽珍',0,'2002-11-12',2,NULL);