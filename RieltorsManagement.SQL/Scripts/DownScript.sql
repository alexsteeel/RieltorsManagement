use RieltorDB;
go

if object_id('dbo.vRieltors') is not null
	drop view dbo.vRieltors;

go

if object_id('dbo.tRieltors') is not null
	drop table dbo.tRieltors;

go

if object_id('dbo.tDivisions') is not null
	drop table dbo.tDivisions;

go