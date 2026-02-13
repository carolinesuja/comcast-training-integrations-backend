-- creating a db
CREATE DATABASE EventManagementDB;

-- creating a table in that db
CREATE TABLE Events
(
    EventId INT PRIMARY KEY,
    Name NVARCHAR(100),
    Location NVARCHAR(100),
    Date DATE,
    Cost FLOAT,
    NumberOfGuests INT,
    EventType NVARCHAR(50)
);