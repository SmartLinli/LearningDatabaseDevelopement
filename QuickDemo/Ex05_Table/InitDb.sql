/*
表
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
	('3180707001','周林好','女','2000-04-17','18信管','睡觉')
	,('3180707002','林钦妹','女','1999-10-18','18信管','吃货')
	,('3180707003','胡方珍','女','2000-01-22','18信管',NULL)
	,('3180707004','谢永成','男','2000-03-02','18信管',NULL);