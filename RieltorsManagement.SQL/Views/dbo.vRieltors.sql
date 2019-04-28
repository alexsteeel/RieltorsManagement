use RieltorDB;
go

--if object_id('RieltorDB.dbo.vRieltors') is not null
--	drop table RieltorDB.dbo.vRieltors;

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