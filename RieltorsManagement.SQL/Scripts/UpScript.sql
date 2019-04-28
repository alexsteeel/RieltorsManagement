create database RieltorDB;

go

use RieltorDB;
go

--================================
-- Author: ������ �.�.
-- Created date: 23.04.2019.
-- Task: �������� ��������� ������ ���������.
-- Description: �������������.
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
-- Author: ������ �.�.
-- Created date: 23.04.2019.
-- Task: �������� ��������� ������ ���������.
-- Description: ��������.
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