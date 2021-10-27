-- This file contains SQL statements that will be executed after the build script.

insert into Colors (Title) values ('Black');
insert into Colors (Title) values ('Red');
insert into Colors (Title) values ('Green');
insert into Colors (Title) values ('Blue');


declare @id int = (select Id from Colors where Title = 'Blue');

insert into Phones
values (NEWID(), 'IPhone 8', 0, 4.7, @id , '2000-04-11 00:00:00');

---------------------

insert into Roles
values (0, 'User'),
(1, 'Manager'),
(2, 'Admin');

insert into Users(Id, [Login], FirstName, LastName, [Password], RoleId, IsActive)
values (NEWID(), 'Admin', 'AdminName', 'AdminLastName', 'NgAgJYx5Rcu/glVJpfix6RB11/6aDevwy3dSV407NkM=', 2, 1);