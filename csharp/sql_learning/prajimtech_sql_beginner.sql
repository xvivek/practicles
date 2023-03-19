
--2 https://csharp-video-tutorials.blogspot.com/2012/08/creating-altering-and-dropping-database.html
create database prajimtech_sql_db;

use prajimtech_sql_db;
-- https://csharp-video-tutorials.blogspot.com/2012/08/creating-and-working-with-tables-part-3.html

--drop table tblGender;
--drop table tblPerson;
create table tblGender (id int not null primary key, gender nvarchar(50));

create table tblPerson(id int not null primary key, [name] nvarchar(50), email nvarchar(50), genderid int not null);

alter table tblPerson add constraint tblPerson_GenderId_FK FOREIGN KEY(genderid) references tblGender(ID);

--https://csharp-video-tutorials.blogspot.com/2012/08/default-constraint-in-sql-server-part-4.html

ALTER TABLE tblPerson ADD CONSTRAINT DF_tblPerson_GenderId DEFAULT 1 FOR genderid;

INSERT INTO tblGender(ID,gender) VALUES (1,'Male'),(2,'Female'),(3,'Unknown')
INSERT INTO tblPerson(ID,Name,Email,GenderId) VALUES (1,'Jade','j@j.com',1),(2,'Mary','m@m.com',2),(3,'Martin','ma@ma.com',1),(4,'rob','r@r.com',1),(5,'May','may@may.com',2),(6,'Kristy','k@k.com',2),(7,'Sam','s@s.com',2)
--(8,'Sam','s@s.com'),

INSERT INTO tblPerson(ID,Name,Email,GenderId) VALUES(7,'Dan','d@d.com',NULL)

--https://csharp-video-tutorials.blogspot.com/2012/08/cascading-referential-integrity.html

select * from tblGender;
select * from tblPerson;

DELETE FROM tblGender WHERE id=1
--truncate table tblPerson;
select @@VERSION
--https://learn.microsoft.com/en-us/sql/t-sql/statements/alter-table-column-constraint-transact-sql?view=sql-server-ver16
ALTER TABLE tblPerson DROP CONSTRAINT tblPerson_GenderId_FK;

ALTER TABLE tblPerson ADD 
	CONSTRAINT tblPerson_GenderId_FK 
	FOREIGN KEY(genderid) REFERENCES tblGender(ID) 
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION;

--https://csharp-video-tutorials.blogspot.com/2012/08/check-constraint-in-sql-server-part-6.html

ALTER TABLE tblPerson ADD Age decimal(5,2);
alter table tblPerson add constraint CK_tblPerson_Age check(age>0 and age<150)

INSERT INTO tblPerson(id,name,email,genderid,age) values(8,'viv','viv@viv.com',1,42);

--https://csharp-video-tutorials.blogspot.com/2012/08/identity-column-in-sql-server-part-7.html
drop table person2;
create table person2(id int not null identity, name nvarchar(50))

--create table person2(id int not null identity(1,1), name nvarchar(50))

Insert into person2 values ('Sam')
Insert into person2 values ('Sara')

--Insert into person2(name) values ('Sam')
--Insert into person2(name) values ('Sara')
set identity_insert person2 ON;
Insert into person2(id,name) values (3,'Sara')

select * from person2;
set identity_insert person2 OFF;

delete from person2;

DBCC CHECKIDENT(person2,RESEED,0);

--https://csharp-video-tutorials.blogspot.com/2012/08/how-to-get-last-generated-identity.html


Select SCOPE_IDENTITY()
Select @@IDENTITY
Select IDENT_CURRENT('tblPerson')
Select IDENT_CURRENT('person2')


--https://csharp-video-tutorials.blogspot.com/2012/08/group-by-part-11.html

create table employee(id int identity primary key, name nvarchar(150),gender varchar(50), salary decimal(10,2), city nvarchar(50));

insert into employee(name, gender, salary, city)
values('tom','male',2000, 'LDN'),
('pam','female',3000, 'NYK'),
('john','male',3500, 'LDN'),
('sam','male',4500, 'LDN'),
('todd','male',2800, 'SYD'),
('ben','male',7000, 'LDN'),
('sara','female',6000, 'LDN'),
('valarie','female',5500, 'NYK'),
('james','male',6500, 'LDN'),
('russel','male',8500, 'LDN');


SELECT city,gender, SUM(salary) total_salary FROM employee GROUP BY city,gender;

SELECT city,gender, SUM(salary) total_salary,count(1) total_employee  FROM employee GROUP BY city,gender;

SELECT city,gender, SUM(salary) total_salary,count(1) total_employee  FROM employee 
GROUP BY city,gender having SUM(salary) >6000


SELECT city,gender, SUM(salary) total_salary,count(1) total_employee  FROM employee
GROUP BY city,gender having SUM(salary) >6000


--https://csharp-video-tutorials.blogspot.com/2012/08/joins-in-sql-server-part-12.html
/*
https://stackoverflow.com/questions/144283/what-is-the-difference-between-varchar-and-nvarchar
DIFFERENCE BETWEEN NVARCHAR AND VARCHAR

An nvarchar column can store any Unicode data. A varchar column is restricted to an 8-bit codepage. Some people think that varchar should 
be used because it takes up less space. I believe this is not the correct answer. 
Codepage incompatabilities are a pain, and Unicode is the cure for codepage problems. 
With cheap disk and memory nowadays, there is really no reason to waste time mucking around with code pages anymore.

All modern operating systems and development platforms use Unicode internally. By using nvarchar rather than varchar, you can avoid doing encoding 
conversions every time you read from or write to the database. Conversions take time, and are prone to errors. 
And recovery from conversion errors is a non-trivial problem.

If you are interfacing with an application that uses only ASCII, I would still recommend using Unicode in the database. The OS and database 
collation algorithms will work better with Unicode. Unicode avoids conversion problems when interfacing with other systems. 
And you will be preparing for the future. And you can always validate that your data is restricted to 7-bit ASCII for 
whatever legacy system you're having to maintain, even while enjoying some of the benefits of full Unicode storage.

*/

create table department(id int identity primary key, department_name nvarchar(100),[location] nvarchar(100), department_head nvarchar(100))

alter table employee add department_id int  


select * from department;

insert into department(department_name,[location], department_head) 
values('IT','LDN', 'Rick'),
('Payroll','DEL', 'ron'),
('HR','NYK', 'cristie'),
('Other Dept','SYD', 'Cindrella');

delete from employee;
dbcc checkident(employee, reseed,0)
insert into employee(name, gender, salary, city, department_id)
values('tom','male',2000, 'LDN',1),
('pam','female',3000, 'NYK',2),
('john','male',3500, 'LDN',3),
('sam','male',4500, 'LDN',1),
('todd','male',2800, 'SYD',2),
('ben','male',7000, 'LDN',2),
('sara','female',6000, 'LDN',2),
('valarie','female',5500, 'NYK',1),
('james','male',6500, 'LDN',null),
('russel','male',8500, 'LDN',null);

select * from employee;

select [name],gender, department_name, department_head from employee cross join department


--INNER
select [name],gender, department_name, department_head from employee e inner join department d
on e.department_id=d.id

select [name],gender, department_name, department_head from employee e join department d
on e.department_id=d.id
--LEFT
select [name],gender, department_name, department_head from employee e left join department d
on e.department_id=d.id

--RIGHT
select [name],gender, department_name, department_head from employee e right join department d
on e.department_id=d.id

--https://csharp-video-tutorials.blogspot.com/2012/08/advanced-joins-part-13.html
select [name],gender, department_name, department_head from employee e right join department d
on e.department_id=d.id
where e.gender is null

--https://csharp-video-tutorials.blogspot.com/2012/08/self-join-in-sql-server-part-14.html

select * from employee;


alter table employee add manager_id int


delete from employee;
dbcc checkident(employee, reseed,0)
insert into employee(name, gender, salary, city, department_id,manager_id)
values('tom','male',2000, 'LDN',1,4),
('pam','female',3000, 'NYK',2,4),
('john','male',3500, 'LDN',3,null),
('sam','male',4500, 'LDN',1,null),
('todd','male',2800, 'SYD',2,3),
('ben','male',7000, 'LDN',2,3),
('sara','female',6000, 'LDN',2,1),
('valarie','female',5500, 'NYK',1,1),
('james','male',6500, 'LDN',null,4),
('russel','male',8500, 'LDN',null,3);



select * from employee;
select e.[name] emp_name, m.[name] from employee e inner join employee m on e.manager_id = m.id


select * from employee;
select e.[name] emp_name, m.[name] from employee e left join employee m on e.manager_id = m.id

--https://csharp-video-tutorials.blogspot.com/2012/08/different-ways-to-replace-null-in-sql.html

select e.[name] employee_name ,isnull(m.[name],'No Manager') manager from employee e left join employee m on e.manager_id = m.id

select e.[name] employee_name ,case when m.[name] is null then 'No Manager' else m.[name] end manager from employee e left join employee m on e.manager_id = m.id

select e.[name] employee_name ,coalesce(m.[name],'No Manager') manager from employee e left join employee m on e.manager_id = m.id

--https://csharp-video-tutorials.blogspot.com/2012/08/coalesce-function-in-sql-server-part-16.html
--whichever field is first available it will be returned with in firstName,middleName, lastName
SELECT Id, COALESCE(FirstName, MiddleName, LastName) AS Name
FROM Employee

--https://csharp-video-tutorials.blogspot.com/2012/08/union-and-union-all-in-sql-server-part.html

Select Id, Name, Email from tblIndiaCustomers
UNION ALL
Select Id, Name, Email from tblUKCustomers


Select Id, Name, Email from tblIndiaCustomers
UNION
Select Id, Name, Email from tblUKCustomers

--https://csharp-video-tutorials.blogspot.com/2012/08/stored-procedures-part-18.html

create procedure spGetEmployees
as
begin
	Select * from employee;
end

exec spGetEmployees

alter procedure spGetEmployeeByGenderNDepartment
@gender nvarchar(50),
@department nvarchar(50)
--WITH ENCRYPTION
as
begin

select e.name,e.gender,e.salary,e.city,d.department_name,m.name manager from employee e 
left join department d on e.department_id=d.id
left join employee m on e.manager_id=m.id
WHERE e.gender=@gender;

end

exec spGetEmployeeByGenderNDepartment 'male','IT'

sp_helptext spGetEmployeeByGenderNDepartment

drop proc spGetEmployeeByGenderNDepartment;
drop procedure spGetEmployeeByGenderNDepartment;

--https://csharp-video-tutorials.blogspot.com/2012/08/stored-procedures-with-output.html

alter proc spGetEmployeeCountByGender
@gender varchar(50),
@employeeCount int output
as
begin

select gender,count(1) employeeCount from employee where gender=@gender group by gender;

end;

declare @empCount int,@return int

exec @return =spGetEmployeeCountByGender 'female', @empCount output

print @empCount
print 'Return Result :' + convert(varchar(20),@return)

exec sp_depends spGetEmployeeCountByGender;

--https://csharp-video-tutorials.blogspot.com/2012/09/inline-table-valued-functions-part-31.html

create function fn_GetEmployeeByGender(@gender varchar(20))
returns table
as
Return (SELECT * FROM employee where gender=@gender);


select * from dbo.fn_GetEmployeeByGender('female')


create function fn_GetEmployeeByGender2(@gender varchar(20))
returns @table table(id int,name varchar(50),gender varchar(50),salary decimal(10,2),city varchar(20))
as
begin
  insert into @table
  SELECT id,name,gender,salary,city FROM employee where gender=@gender;

  return;

end;

select * from fn_GetEmployeeByGender2('female');

update fn_GetEmployeeByGender2('female') set name='pam 1' where id=2;

update fn_GetEmployeeByGender('female') set name='pam 1' where id=2;
--https://csharp-video-tutorials.blogspot.com/2012/09/multi-statement-table-valued-functions.html
--


--https://csharp-video-tutorials.blogspot.com/2012/09/temporary-tables-in-sql-server-part-34.html


--https://csharp-video-tutorials.blogspot.com/2012/09/indexes-in-sql-server-part-35.html
Select * from employee where Salary > 5000 and Salary < 7000

create index ix_employee_employee on employee(salary);


--CREATE [UNIQUE] CLUSTERED | NONCLEUTERED INDEX index_name on TABLE_NAME([COLUMN_1 [ASC|DESC],COLUMN_2 [ASC|DESC],COLUMN_3 [ASC|DESC]....])

create table table_name_1(column_name_1 int,column_name_2 varchar(50),column_name_3 Datetime)

create clustered index ci_table_name_1_column_name_1 on table_name_1(column_name_1)

--create unique clustered index ci_table_name_1_column_name_1 on table_name_1(column_name_1)

insert into table_name_1(column_name_1,column_name_2,column_name_3) values(1,'1a',getdate()),(1,'1a',getdate())

select * from table_name_1;

delete from table_name_1

drop index table_name_1.ci_table_name_1_column_name_1

--https://csharp-video-tutorials.blogspot.com/2012/09/dml-triggers-part-43.html

CREATE TABLE tblEmployee
(
 Id int Primary Key,
 Name nvarchar(30),
 Salary int,
 Gender nvarchar(10),
 DepartmentId int
)

Insert into tblEmployee values (1,'John', 5000, 'Male', 3)
Insert into tblEmployee values (2,'Mike', 3400, 'Male', 2)
Insert into tblEmployee values (3,'Pam', 6000, 'Female', 1)


CREATE TABLE tblEmployeeAudit
(
 Id int identity(1,1) primary key,
 AuditData nvarchar(1000)
)


alter trigger tr_employee_for
on tblemployee
for insert
as
begin
declare @id int;
select @id=id from inserted;

insert into tblEmployeeAudit(auditdata) values('New employee with Id  = ' + Cast(@Id as nvarchar(5)) + ' is added at ' + cast(Getdate() as nvarchar(20)));

end;


Insert into tblEmployee values (4,'Pam', 6000, 'Female', 1)

select * from tblEmployeeAudit

--https://csharp-video-tutorials.blogspot.com/2012/09/after-update-trigger-part-44.html
Create trigger tr_tblEmployee_ForUpdate
on tblEmployee
for Update
as
Begin
 Select * from deleted
 Select * from inserted 
End


Update tblEmployee set Name = 'Tods', Salary = 2000, 
Gender = 'Female' where Id = 4

drop table if exists tblEmployee;

drop table if exists tblDepartment;


CREATE TABLE tblEmployee
(
 Id int Primary Key,
 Name nvarchar(30),
 Gender nvarchar(10),
 DepartmentId int
)

CREATE TABLE tblDepartment
(
 DeptId int Primary Key,
 DeptName nvarchar(20)
)

Insert into tblDepartment values (1,'IT')
Insert into tblDepartment values (2,'Payroll')
Insert into tblDepartment values (3,'HR')
Insert into tblDepartment values (4,'Admin')

Insert into tblEmployee values (1,'John', 'Male', 3)
Insert into tblEmployee values (2,'Mike', 'Male', 2)
Insert into tblEmployee values (3,'Pam', 'Female', 1)
Insert into tblEmployee values (4,'Todd', 'Male', 4)
Insert into tblEmployee values (5,'Sara', 'Female', 1)
Insert into tblEmployee values (6,'Ben', 'Male', 3)

Create view vWEmployeeDetails
as
Select Id, Name, Gender, DeptName
from tblEmployee 
join tblDepartment
on tblEmployee.DepartmentId = tblDepartment.DeptId


select * from vWEmployeeDetails;

Insert into vWEmployeeDetails values(7, 'Valarie', 'Female', 'IT')

Create trigger tr_vWEmployeeDetails_InsteadOfInsert
on vWEmployeeDetails
Instead Of Insert
as
Begin
 Declare @DeptId int
 
 --Check if there is a valid DepartmentId
 --for the given DepartmentName
 Select @DeptId = DeptId 
 from tblDepartment 
 join inserted
 on inserted.DeptName = tblDepartment.DeptName
 
 --If DepartmentId is null throw an error
 --and stop processing
 if(@DeptId is null)
 Begin
  Raiserror('Invalid Department Name. Statement terminated', 16, 1)
  return
 End
 
 --Finally insert into tblEmployee table
 Insert into tblEmployee(Id, Name, Gender, DepartmentId)
 Select Id, Name, Gender, @DeptId
 from inserted
End

Insert into vWEmployeeDetails values(7, 'Valarie', 'Female', 'IT')


Create Table tblProductSales
(
 SalesAgent nvarchar(50),
 SalesCountry nvarchar(50),
 SalesAmount int
)

Insert into tblProductSales values('Tom', 'UK', 200)
Insert into tblProductSales values('John', 'US', 180)
Insert into tblProductSales values('John', 'UK', 260)
Insert into tblProductSales values('David', 'India', 450)
Insert into tblProductSales values('Tom', 'India', 350)
Insert into tblProductSales values('David', 'US', 200)
Insert into tblProductSales values('Tom', 'US', 130)
Insert into tblProductSales values('John', 'India', 540)
Insert into tblProductSales values('John', 'UK', 120)
Insert into tblProductSales values('David', 'UK', 220)
Insert into tblProductSales values('John', 'UK', 420)
Insert into tblProductSales values('David', 'US', 320)
Insert into tblProductSales values('Tom', 'US', 340)
Insert into tblProductSales values('Tom', 'UK', 660)
Insert into tblProductSales values('John', 'India', 430)
Insert into tblProductSales values('David', 'India', 230)
Insert into tblProductSales values('David', 'India', 280)
Insert into tblProductSales values('Tom', 'UK', 480)
Insert into tblProductSales values('John', 'US', 360)
Insert into tblProductSales values('David', 'UK', 140)

Select * from tblProductSales

Select SalesCountry, SalesAgent, SUM(SalesAmount) as Total
from tblProductSales
group by SalesCountry, SalesAgent
order by SalesCountry, SalesAgent


Select SalesAgent, India, US, UK
from tblProductSales
Pivot
(
   Sum(SalesAmount) for SalesCountry in ([India],[US],[UK])
) as PivotTable

