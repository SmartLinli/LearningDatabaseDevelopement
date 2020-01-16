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
		DEFAULT 0);
INSERT INTO tb_user
	(no,password,is_activated)
	VALUES
	('3180707001',DECODE(MD5('7001'),'HEX'),TRUE);
--根据用户号查询用户计数；
CREATE OR REPLACE FUNCTION usp_select_user_count
	(p_no CHAR(10))
	RETURNS INTEGER
	AS
$$
DECLARE
v_count INTEGER;
BEGIN
SELECT 
		INTO v_count COUNT(*)
	FROM
		tb_user AS u
	WHERE
		u.no=p_no;
RETURN v_count;						
END;
$$
LANGUAGE PLPGSQL;
--根据用户号查询用户；
CREATE OR REPLACE FUNCTION usp_select_user
	(p_no CHAR(10))
	RETURNS SETOF tb_user
	AS
$$
DECLARE
BEGIN
RETURN QUERY
SELECT 
		U.no
		,U.password
		,U.is_activated
	    ,U.login_fail_count
	FROM
		tb_user AS u
	WHERE
		u.no=p_no;
END;
$$
LANGUAGE PLPGSQL;
--更新用户；						
CREATE OR REPLACE FUNCTION usp_update_user
	(p_no CHAR(10)
	,p_password BYTEA
	,p_is_activated BOOLEAN
	,p_login_fail_count INTEGER)
   	RETURNS INTEGER
	AS
$$
DECLARE
v_row_affected INTEGER;
BEGIN					
UPDATE tb_user
	SET
		password=p_password
		,is_activated=p_is_activated
		,login_fail_count=p_login_fail_count
	WHERE
	   	no=p_no;
GET DIAGNOSTICS v_row_affected:=ROW_COUNT;
RETURN v_row_affected;
END;
$$
LANGUAGE PLPGSQL;
--插入用户；						
CREATE OR REPLACE FUNCTION usp_insert_user
	(p_no CHAR(10)
	,p_password BYTEA
	,p_is_activated BOOLEAN)
   	RETURNS INTEGER
	AS
$$
DECLARE
v_row_affected INTEGER;
BEGIN					
INSERT INTO tb_user
	(no,password,is_activated)
	VALUES
	(p_no,p_password,p_is_activated);
GET DIAGNOSTICS v_row_affected:=ROW_COUNT;
RETURN v_row_affected;
END;
$$
LANGUAGE PLPGSQL;