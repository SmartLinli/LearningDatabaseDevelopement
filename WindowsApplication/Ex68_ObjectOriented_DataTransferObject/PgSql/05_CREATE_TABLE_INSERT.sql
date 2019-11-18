/*此脚本包含中文数据，可使用记事本将此文件保存为ANSI编码*/
DROP TABLE IF EXISTS "Role" CASCADE;
--角色表；
CREATE TABLE "Role"
	("No"
		SERIAL
		NOT NULL
		PRIMARY KEY
	,"Name"
		VARCHAR(10)
		NOT NULL
		UNIQUE);
INSERT INTO "Role"
	("Name")
	VALUES
	('学生')
	,('教师');
DROP TABLE IF EXISTS "User" CASCADE;
--用户表；
CREATE TABLE "User"
	("No"
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,"Password"
		BYTEA
		NOT NULL
	,"IsActivated"
		BOOLEAN
	 	NOT NULL
	,"LoginFailCount"
		INTEGER
		NOT NULL
		DEFAULT 0
	,"RoleNo"
		INT
		NOT NULL
		REFERENCES "Role"("No"));
INSERT INTO "User"
	("No","Password","IsActivated","RoleNo")
	VALUES
	('3180707001',DECODE(MD5('7001'),'HEX'),TRUE,1);