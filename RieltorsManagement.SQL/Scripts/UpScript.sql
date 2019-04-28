create database RieltorDB;

go

use RieltorDB;
go

--================================
-- Author: Сучков А.С.
-- Created date: 23.04.2019.
-- Task: создание хранилища данных риэлторов.
-- Description: подразделения.
--================================
create table dbo.tDivisions
(
	Id			int				not null identity(1, 1),
	Name		varchar(200)	not null unique,
	CreatedDateTime datetime	not null,
	constraint pk_Divisions_Id
		primary key clustered (Id)
);

go

--================================
-- Author: Сучков А.С.
-- Created date: 23.04.2019.
-- Task: создание хранилища данных риэлторов.
-- Description: риэлторы.
--================================
create table dbo.tRieltors
(
	Id				int				not null identity(1, 1),
	Firstname		varchar(200)	not null,
	Lastname		varchar(200)	not null,
	DivisionId		int				not null,
	CreatedDateTime datetime		not null,
	constraint pk_Rieltors_Id
		primary key clustered (Id),
	constraint fk_Rieltors_Divisions
		foreign key (DivisionId)
		references dbo.tDivisions(Id)
);

go

--================================
-- Author: Сучков А.С.
-- Created date: 23.04.2019.
-- Task: создание хранилища данных риэлторов.
-- Description: представление для таблицы Риэлторы.
--================================
create view dbo.vRieltors
as

select
	a.Firstname			as [Имя],
	a.Lastname			as [Фамилия],
	d.Name				as [Подразделение],
	a.CreatedDateTime	as [Дата создания пользователя]
from
	dbo.tRieltors as a
inner join
	dbo.tDivisions as d
	on d.Id = a.DivisionId;

go