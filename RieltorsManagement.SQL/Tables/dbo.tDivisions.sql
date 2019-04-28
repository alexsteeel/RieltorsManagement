use RieltorDB;
go

--if object_id('RieltorDB.dbo.Divisions') is not null
--	drop table RieltorDB.dbo.Divisions;

--================================
-- Author: Сучков А.С.
-- Created date: 23.04.2019.
-- Task: создание хранилища данных риэлторов.
-- Description: подразделения.
--================================
create table dbo.tDivisions
(
	Id			int				not null identity(1, 1),
	Name		varchar(200)	not null,
	CreatedDateTime datetime	not null,
	constraint pk_Divisions_Id
		primary key clustered (Id)
)