\set ON_ERROR_STOP 1
\set ECHO all
\i 01_terminate_backend.sql;
\i 02_DROP_DATABASE.sql;
\i 03_DROP_TABLESPACE.sql;