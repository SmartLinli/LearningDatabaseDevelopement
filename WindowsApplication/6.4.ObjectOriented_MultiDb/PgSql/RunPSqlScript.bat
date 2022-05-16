@echo off
psql -h 127.0.0.1 -U Administrator -d postgres -f PSqlBatch.sql
pause