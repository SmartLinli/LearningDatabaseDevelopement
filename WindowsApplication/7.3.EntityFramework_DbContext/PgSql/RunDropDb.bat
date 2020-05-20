@echo off
psql -U Administrator -d postgres -f DropDb.sql
pause