-- Create the Staffs database
CREATE DATABASE Staffs;

-- Use the Staffs database
USE Staffs;

-- Create the Gender table
CREATE TABLE Gender (
    GenderID INT AUTO_INCREMENT PRIMARY KEY,
    GenderName VARCHAR(50) NOT NULL
);

-- Create the Department table
CREATE TABLE Department (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

-- Create the Employee table
CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    StartingDate DATE NOT NULL,
    GenderID INT,
    DepartmentID INT,
    FOREIGN KEY (GenderID) REFERENCES Gender(GenderID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);


insert into Gender (GenderName) values 
	('Male'),
    ('Female');
    
insert into Department (DepartmentName) values 
	('Human Resource'),
    ('Marketing'),
    ('R&D');
insert into Employee(FirstName, LastName, Email, StartingDate, GenderID, DepartmentID) values 
	('Tran Hai', 'Dang', 'acb@gmail.com', '2004-02-02', 1, 1),
    ('Nguyen Thanh', 'Ngan', 'xyz@gmail.com', '2004-02-02', 2, 2),
    ('Nguyen Van', 'A', 'xyz@gmail.com', '2004-02-02', 2, 2),
    ('Tran Van', 'B', 'xyz@gmail.com', '2004-02-02', 2, 3);