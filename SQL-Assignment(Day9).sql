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


--Insert at least 5 records into each table. 
select * from Authors
insert into Authors values('John Smith','USA')
insert into Authors values('Amit Patel','India')
insert into Authors values('Maria Garcia','Spain')
insert into Authors values('James Brown','UK')
insert into Authors values('Rajesh Kumar','India')


select * from Books
insert into Books values('Sql Mastery',1,1800,2020)
insert into Books values('Advanced C#',2,2500,2022)
insert into Books values('Python Basics',3,1500,2018)
insert into Books values('Data Science Fundamentals',4,2800,2021)
insert into Books values('SQL for Beginners',5,2000,2019)


select * from Customers
insert into Customers values('Amit Sharma','amit.sharma@gmail.com','9876543210')
insert into Customers values('John Doe','john.doe@gmail.com','9876543211')
insert into Customers values('Jessica Roy','jessica.roy@gmail.com','9876543212')
insert into Customers values('Raj Malhotra','raj.malhotra@gmail.com','9876543213')
insert into Customers values('Arjun Verma','arjun.verma@gmail.com','9876543214')


select * from Orders
insert into Orders values(1,'2024-02-10',4300)
insert into Orders values(3,'2024-02-12',2800)
insert into Orders values(5,'2024-02-15',1500)


select * from OrderItems
insert into OrderItems values(1,2,1,2500)
insert into OrderItems values(1,1,1,1800)
insert into OrderItems values(2,4,1,2800)
insert into OrderItems values(3,3,1,1500)


--Update the price of a book titled "SQL Mastery" by increasing it by 10%.
update books set Price=Price*1.10 where Title='SQL Mastery'
select * from Books



--Delete a customer who has not placed any orders.
select * from Customers
select * from Orders

delete from Customers where CustomerId not in(select distinct CustomerId from Orders)


--Retrieve all books with a price greater than 2000
select * from Books where Price>2000


--Find the total number of books available. 
select count(*) as Total_Books from Books


--Find books published between 2015 and 2023
select * from Books where PublishedYear between 2015 and 2023


--Find all customers who have placed at least one order
select distinct C.CustomerId, C.Name, C.Email, C.PhoneNumber
from Customers C
inner join Orders O on C.CustomerId=O.CustomerId


--Retrieve books where the title contains the word "SQL"
select * from Books where title like '%SQL%'


--Find the most expensive book in the store. 
select * from Books where Price=(select max(Price) from Books)


--Retrieve customers whose name starts with "A" or "J". 
select * from Customers where name like 'A%' or name like'J%'


--Calculate the total revenue from all orders.
select sum(TotalAmount) Total_Revenue from Orders




--Retrieve all book titles along with their respective author names.
select * from Books
select * from Authors
select B.Title, A.Name
from Books B
join Authors A
on B.AuthorId=A.AuthorId



--List all customers and their orders (if any).
select * from Customers
select * from Orders
select C.Name, O.*
from Customers C
join Orders O 
on C.CustomerId=O.CustomerId


--Find all books that have never been ordered.
select * from Books
select * from OrderItems
select B.Title Books_Never_Ordered
from Books B
left join OrderItems OI on OI.BookId=B.BookId
where OI.BookId is null




--Retrieve the total number of orders placed by each customer.
select * from Orders
select * from Customers
select C.Name, count(O.OrderId) as Total_Orders
from Customers C
join Orders O on C.CustomerId=O.CustomerId
group by C.Name

--Find the books ordered along with the quantity for each order.



--Display all customers, even those who haven’t placed any orders.
select * from Customers

--Find authors who have not written any books 





