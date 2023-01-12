/*
表_适配器
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
	('3210707001','田杰红','女','2001-9-10','21信管','唱歌')
	,('3210707002','刘兰','女','2003-2-9','21信管','跳舞')
	,('3210707003','吴争宇','男','2004-1-5','21信管','打篮球')
	,('3210707004','廖丽珍','女','2002-11-12','21信管',NULL);