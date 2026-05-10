Create database SchoolDB
go
use SchoolDB

Create Table Students
(
Id int Primary key identity (1,1),
FirstName varchar(50),
LastName varchar(50),
Age int 
)
