@echo off
md C:\EduBaseDemo
psql -U Administrator -d postgres -f PgSqlBatch.sql
pause