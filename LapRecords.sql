BEGIN TRANSACTION;
CREATE TABLE Lap
(
    LapNumber INTEGER PRIMARY KEY,
    DriverName VARCHAR NOT NULL,
    CarNumber VARCHAR NOT NULL,
    LapTime INTEGER NOT NULL
);
INSERT INTO Lap VALUES(1,'John Smith','56',64);
INSERT INTO Lap VALUES(2,'John Smith','56',64);
INSERT INTO Lap VALUES(3,'John Smith','56',64);
INSERT INTO Lap VALUES(4,'John Smith','56',64);
INSERT INTO Lap VALUES(5,'John Smith','56',64);
INSERT INTO Lap VALUES(6,'John Smith','56',64);
INSERT INTO Lap VALUES(7,'John Smith','33',60);
INSERT INTO Lap VALUES(8,'John Smith','33',60);
INSERT INTO Lap VALUES(9,'John Smith','33',60);
INSERT INTO Lap VALUES(10,'John Smith','33',60);
INSERT INTO Lap VALUES(11,'John Smith','33',60);
INSERT INTO Lap VALUES(12,'John Smith','33',60);
INSERT INTO Lap VALUES(13,'Alice Doe','55',59);
INSERT INTO Lap VALUES(14,'Alice Doe','55',59);
INSERT INTO Lap VALUES(15,'Alice Doe','55',59);
INSERT INTO Lap VALUES(16,'Alice Doe','55',59);
INSERT INTO Lap VALUES(17,'Alice Doe','55',59);
INSERT INTO Lap VALUES(18,'Alice Doe','44',59);
INSERT INTO Lap VALUES(19,'Alice Doe','44',59);
INSERT INTO Lap VALUES(20,'Alice Doe','44',62);
INSERT INTO Lap VALUES(21,'Alice Doe','44',62);
COMMIT;