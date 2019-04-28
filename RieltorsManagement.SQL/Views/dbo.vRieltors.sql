use RieltorDB;
go

--if object_id('RieltorDB.dbo.vRieltors') is not null
--	drop table RieltorDB.dbo.vRieltors;

--================================
-- Author: ������ �.�.
-- Created date: 23.04.2019.
-- Task: �������� ��������� ������ ���������.
-- Description: ������������� ��� ������� ��������.
--================================
create view dbo.vRieltors
as

select
	a.Firstname			as [���],
	a.Lastname			as [�������],
	d.Name				as [�������������],
	a.CreatedDateTime	as [���� �������� ������������]
from
	dbo.tRieltors as a
inner join
	dbo.tDivisions as d
	on d.Id = a.DivisionId;

go