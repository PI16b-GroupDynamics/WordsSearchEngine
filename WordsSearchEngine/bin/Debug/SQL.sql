insert into Users (Name, Login, Password, Salt)
values('Влада', 'vlada', '5555', '6uygjgj');

select * from Users;
delete from Users;

update Users set texts = 'ghg', results = 'fff' where login = 'vladamamutova';
update Users set texts = null, results = null where login = 'vladamamutova';

update Users set Name = 'vlada' where login = 'vlada';
update Users set Login = 'l' where login = 'vlada';

delete from Users where login = 'vlada';