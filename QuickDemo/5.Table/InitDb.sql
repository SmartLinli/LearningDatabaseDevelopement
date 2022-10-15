/*
表
*/
--创建数据库；
USE master;
DROP DATABASE IF EXISTS EduBaseDemo;
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
		CHAR(2)
		NOT NULL
	,BirthDate
		DATE
		NOT NULL
	,Class
		VARCHAR(50)
		NOT NULL
	,Speciality
		VARCHAR(100)
		NULL);
INSERT tb_Student
	(No,Name,Gender,BirthDate,Class,Speciality)
	VALUES
	('3210707001','田杰红','女','2001-09-10','21信管','干饭')
	,('3210707002','刘兰','女','2003-02-09','21信管','摸鱼')
	,('3210707003','吴争宇','男','2004-01-05','21信管',NULL)
	,('3210707004','廖丽珍','女','2002-11-12','21信管',NULL);