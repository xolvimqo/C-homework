
use Obento;
go

select * from orderTable;
go

select * from orderTable where paid <> 1;
go

alter table orderTable add paid int default 0;
go

update orderTable set paid=0;
go
