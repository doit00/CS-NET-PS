-- SqlLocalDB.exe c MSSQLLocalDB
-- SqlLocalDB.exe s MSSQLLocalDB
-- SqlLocalDB.exe i MSSQLLocalDB

create database demo
go

use demo
go

Create table Logs
(
id int identity(1,1) PRIMARY KEY
,message nvarchar(255)
,date datetime2
)
go
Insert Logs(message, date)
values ('error',SYSDATETIME())
go
Insert Logs(message, date)
values 	('warning',SYSDATETIME())
go
Insert Logs(message, date)
values ('debug',SYSDATETIME())

select * from Logs

