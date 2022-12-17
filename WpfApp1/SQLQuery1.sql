create database OneToOneDb
GO
use  OneToOneDb
GO

create table Countries(
CountryId int primary key identity(1,1) not null,
[Name] nvarchar(30) not null
)
GO
insert into Countries([Name])
values('Norway'),('Azerbaijan'),('Turkish')

GO
create table Capitals(
CapitalId int primary key identity(1,1) not null,
[Name] nvarchar(30) not null,
CountryId int foreign key references Countries(CountryId),
Unique(CountryId)
)

GO
insert into Capitals([Name],[CountryId])
values('Oslo',1),('Baku',2),('Ankara',3)
