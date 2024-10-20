create database employees;

use employees;

CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Adress VARCHAR(100) NOT NULL,
    StartingDate DATE NOT NULL,
    EduID INT,
    DepartmentID INT,
    FOREIGN KEY (EduID) REFERENCES Education(EduID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

create table Education (
	EduID INT AUTO_INCREMENT PRIMARY KEY,
    eduName nvarchar(100)
);

CREATE TABLE Department (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);



insert into Education (eduName) values 
	('UnderGraduate'),
    ('PostGraduate');
    
insert into Department (DepartmentName) values 
	('Human Resource'),
    ('Marketing'),
    ('R&D');

insert into Employee(FirstName, LastName, Email, StartingDate, EduID, DepartmentID) values 
	('Tran Hai', 'Dang', 'acb@gmail.com', '2004-02-02', 1, 1),
    ('Nguyen Thanh', 'Ngan', 'xyz@gmail.com', '2004-02-02', 2, 2),
    ('Nguyen Van', 'A', 'xyz@gmail.com', '2004-02-02', 2, 2),
    ('Tran Van', 'B', 'xyz@gmail.com', '2004-02-02', 2, 3);
