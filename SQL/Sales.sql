/*
2. Есть таблица хранящая линии покупки: Sales: Id, ProductId, CustomerId, DateCreated. 
Мы хотим понять, через какие продукты клиенты «попадают» к нам в магазин. 
Напишите запрос, который выводит продукт и количество случаев, когда он был первой покупкой клиента.
*/

------------------------Таблица-------------------------------------
create table Sales
( 
	Id int primary key, 
	ProductId int, 
	CustomerId int, 
	DateCreated datetime
) 

------------------------Значения-------------------------------------

insert into Sales (id, ProductId, CustomerId, DateCreated) values (1,1,1,'2016-09-01 12:30:23')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (2,2,1,'2016-09-01 15:15:44')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (3,2,2,'2016-09-03 09:02:56')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (4,1,3,'2016-09-07 23:35:04')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (5,1,4,'2016-09-10 16:40:09')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (6,3,3,'2016-09-10 20:17:45')
insert into Sales (id, ProductId, CustomerId, DateCreated) values (7,1,3,'2016-09-12 17:49:11')

truncate table sales
------------------------Запрос---------------------------------------
;with StartTimeInfo as 
( 
	select CustomerId, min(DateCreated) as FirstEnterDT
	from Sales
	group by  CustomerId
),
FirstProductInfo as 
(
	select s.CustomerID, s.ProductId
	from Sales s
	inner join StartTimeInfo t
		on s.DateCreated = t.FirstEnterDT
) 
select ProductId, count(ProductId) as FirstEnterCount
from FirstProductInfo
group by ProductId
union 
select ProductId, 0 
from Sales
where ProductId not in
	(
		select ProductId
		from FirstProductInfo
	)
order by ProductId
-------------------------------------------------------------