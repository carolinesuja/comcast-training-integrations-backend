--Add Event
CREATE PROCEDURE AddEvent
    @Id INT,
    @Name NVARCHAR(100),
    @Location NVARCHAR(100),
    @Date DATETIME,
    @Cost FLOAT,
    @Guests INT,
    @Type NVARCHAR(50)
AS
BEGIN
    INSERT INTO Events
    VALUES (@Id, @Name, @Location, @Date, @Cost, @Guests, @Type)
END

--Get All Events
CREATE PROCEDURE GetAllEvents
AS
BEGIN
    SELECT * FROM Events
END

--Get Events By Type
CREATE PROCEDURE GetEventsByType
    @Type NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Events
    WHERE EventType = @Type
END

--Update Event Cost
CREATE PROCEDURE UpdateEventCost
    @Id INT,
    @Cost FLOAT
AS
BEGIN
    UPDATE Events
    SET Cost = @Cost
    WHERE EventId = @Id
END

--Delete Event
CREATE PROCEDURE DeleteEvent
    @Id INT
AS
BEGIN
    DELETE FROM Events
    WHERE EventId = @Id
END