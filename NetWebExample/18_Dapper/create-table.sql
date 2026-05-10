create database ETradeDB
go
use ETradeDB

create table Categories(
	CategoryId int primary key identity(1,1),
	[Name] nvarchar(max) not null   
)

create table Products(
	ProductId int primary key identity(1,1),
	[Name] nvarchar(50) not null,
	Price decimal(18,2) not null,
	CategoryId int,
	Foreign key (CategoryId) references Categories(CategoryId)
)
declare @Id int =4;
select * from Products where ProductId=@Id