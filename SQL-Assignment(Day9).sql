--Create a database named BookStoreDB.
create database BookStoreDB

use BookStoreDB

--creating tables
create table Authors(
AuthorId int identity primary key,
Name varchar(50) not null,
Country varchar(50) not null)

create table Books(
BookId int identity primary key,
Title varchar(50) not null,
AuthorId int foreign key (AuthorId) references Authors(AuthorId),
Price decimal,
PublishedYear int)

exec sp_help;

create table Customers(
CustomerId int identity primary key,
Name varchar(50) not null,
Email varchar(50) unique,
PhoneNumber varchar(13))

create table Orders(
OrderId int identity primary key,
CustomerId int foreign key (CustomerId) references Customers(CustomerId),
OrderDate date,
TotalAmount decimal)

create table OrderItems(
OrderItemId int identity primary key,
OrderId int foreign key (OrderId) references Orders(OrderId),
BookId int foreign key (BookId) references Books(BookId),
Quantity int,
SubTotal decimal)


