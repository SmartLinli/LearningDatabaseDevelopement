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
		DEFAULT 0);
INSERT INTO "User"
	("No","Password","IsActivated")
	VALUES
	('3180707001',DECODE(MD5('7001'),'HEX'),TRUE);