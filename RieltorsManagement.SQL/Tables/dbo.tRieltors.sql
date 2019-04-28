use RieltorDB;
go

--if object_id('RieltorDB.dbo.Rieltors') is not null
--	drop table RieltorDB.dbo.Rieltors;

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
)