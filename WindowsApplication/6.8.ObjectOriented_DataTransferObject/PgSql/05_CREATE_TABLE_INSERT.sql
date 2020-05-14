/*此脚本包含中文数据，可使用记事本将此文件保存为ANSI编码*/
DROP TABLE IF EXISTS tb_role CASCADE;
--角色表；
CREATE TABLE tb_role
	(no
		SERIAL
		NOT NULL
		PRIMARY KEY
	,name
		VARCHAR(10)
		NOT NULL
		UNIQUE);
INSERT INTO tb_role
	(name)
	VALUES
	('学生')
	,('教师');
DROP TABLE IF EXISTS tb_user CASCADE;
--用户表；
CREATE TABLE tb_user
	(no
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,password
		BYTEA
		NOT NULL
	,is_activated
		BOOLEAN
	 	NOT NULL
	,login_fail_count
		INTEGER
		NOT NULL
		DEFAULT 0
	,role_no
		INT
		NOT NULL
		REFERENCES tb_role(no));
INSERT INTO tb_user
	(no,password,is_activated,role_no)
	VALUES
	('3180707001',DECODE(MD5('7001'),'HEX'),TRUE,1)
	,('2004034',DECODE(MD5('1234'),'HEX'),TRUE,2);