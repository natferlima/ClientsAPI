CREATE DATABASE ClientsAPI

GO

USE ClientsAPI

CREATE TABLE ClientTypes
(
	Id int not null identity(1,1),
	Description varchar(100),
	PRIMARY KEY (Id)
)

CREATE TABLE ClientSituations
(
	Id int not null identity(1,1),
	Description varchar(100),
	PRIMARY KEY (Id)
)


CREATE TABLE Clients
(
	Id int not null identity(1,1),
	Name varchar(100),
	CPF varchar(20) UNIQUE,
	Gender varchar(100),
	IdType int,
	IdSituation int,
	PRIMARY KEY (Id)
)

alter table Clients add constraint FK1Clients foreign key (IdSituation)
references ClientSituations (Id);

alter table Clients add constraint FK2Clients foreign key (IdType)
references ClientTypes (Id);

INSERT INTO ClientTypes (Description) values('Tipo1');
INSERT INTO ClientTypes (Description) values('Tipo2');
INSERT INTO ClientTypes (Description) values('Tipo3');

INSERT INTO ClientSituations (Description) values('Situação1');
INSERT INTO ClientSituations (Description) values('Situação2');
INSERT INTO ClientSituations (Description) values('Situação3');

INSERT INTO Clients (Name, CPF, Gender, IdType, IdSituation) values ('Natália', '123.456.678-10', 'Feminino', 1, 1);
INSERT INTO Clients (Name, CPF, Gender, IdType, IdSituation) values ('Ana', '123.123.123-12', 'Feminino', 2, 2);

