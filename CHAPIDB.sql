create database CHAPIDB
go

use CHAPIDB
go

create table ObjetoJson
(
	ObjectID int identity
		constraint PK_ObjetoJson
			primary key,
	startDateTime datetime2 not null,
	endDateTime datetime2 not null,
	alt int not null,
	hdop decimal(18,2) not null,
	info nvarchar(max),
	lat decimal(12,5) not null,
	lon decimal(12,5) not null,
	deviceName nvarchar(max)
)
go

create table ChevacaPackets
(
	PacketID int identity
		constraint PK_ChevacaPackets
			primary key,
	applicationID nvarchar(max),
	applicationName nvarchar(max),
	deviceName nvarchar(max),
	devEUI nvarchar(max),
	adr bit not null,
	dr int not null,
	fCnt int not null,
	fPort int not null,
	data nvarchar(max),
	objectJSONObjectID int
		constraint FK_ChevacaPackets_ObjetoJson_objectJSONObjectID
			references ObjetoJson,
	confirmedUplink bit not null,
	devAddr nvarchar(max)
)
go