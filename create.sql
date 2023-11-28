-- Create a new database called 'Dokumenti2'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'Dokumenti2'
)
CREATE DATABASE Dokumenti2
GO