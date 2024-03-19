create database Church; go

use Church; go

CREATE TABLE Church (
ChurchID INT PRIMARY KEY identity(1,1), Name VARCHAR(100) NOT NULL, Address VARCHAR(255) NOT NULL, established_date DATE NOT NULL);

CREATE TABLE Priest (
PriestID INT PRIMARY KEY identity(1,1), first_name VARCHAR(50) NOT NULL, last_name VARCHAR(50) NOT NULL, middle_name varchar(50), ierarch_position varchar(50) NOT NULL, church_id INT, FOREIGN KEY (church_id) REFERENCES Church(ChurchID) ); CREATE TABLE ChurchService ( ChurchServiceID INT PRIMARY KEY identity(1,1), service_date DATETIME NOT NULL, priest_id INT, church_id INT, FOREIGN KEY (priest_id) REFERENCES Priest(PriestID),);

INSERT INTO Priest(first_name, last_name, middle_name, ierarch_position)VALUES ('Иван', 'Иванов', 'Иванович', 'Священник'), ('Петр', 'Петров', 'Петрович', 'Архиепископ'), ('Анна', 'Сидорова', NULL, 'Священница'), ('Мария', 'Васильева', 'Васильевна', 'Священница'); go

INSERT INTO Church (Name, Address, established_date) VALUES ('Церковь Иисуса Христа', 'г. Москва, ул. Пушкина, д. 1', '1990-01-01'), ('Церковь Святого Духа', 'г. Санкт-Петербург, ул. Ленина, д. 2', '1985-05-15'), ('Церковь Св. Елены', 'г. Новосибирск, ул. Космонавтов, д. 3', '1995-10-20'); go

INSERT INTO ChurchService (service_date, priest_id, church_id) VALUES ('2022-01-01 10:00:00', 1, 1), ('2022-01-01 11:00:00', 2, 1), ('2022-01-02 14:00:00', 3, 2), ('2022-01-02 15:00:00', 4, 3); go
