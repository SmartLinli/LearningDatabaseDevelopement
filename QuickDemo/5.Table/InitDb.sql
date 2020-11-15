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
	('3190707001','贾雨晗','女','2001-05-08','19信管','睡觉')
	,('3190707002','温晓雯','女','2001-05-20','19信管','吃货')
	,('3190707003','张浩奇','男','2001-04-27','19信管',NULL)
	,('3190707004','李玉林','男','2000-07-08','19信管',NULL);
/*
网格视图
*/
----课程表；
CREATE TABLE tb_Course
	(Number 
		CHAR(4) 
		NOT NULL 
		PRIMARY KEY
	,Name 
		VARCHAR(50) 
		NOT NULL);
INSERT tb_Course
	(Number,Name)
	VALUES
	('A001','面向对象程序设计')
	,('A002','数据库原理')
	,('A003','数据库技术及应用');
----学生成绩表；
CREATE TABLE tb_StudentScore
	(StudentNumber 
		CHAR(10) 
		NOT NULL
	,CourseNumber 
		CHAR(4) 
		NOT NULL
	,Score 
		DECIMAL(4,1) 
		NULL
	,PRIMARY KEY(StudentNumber,CourseNumber));
INSERT tb_StudentScore
	(StudentNumber,CourseNumber,Score)
	VALUES
	('3190707001','A001',82);