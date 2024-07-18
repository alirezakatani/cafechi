

create table manager
(
id int IDENTITY(1,1) ,
[name] nvarchar(30),
[family_name] nvarchar(30),
[phone_number] nvarchar(30),
[email_address] nvarchar(30),
[rest_name] nvarchar(30) ,
[account_number] nvarchar(30),
[username] nvarchar(30) unique,
[password] nvarchar(30),
is_admin bit,
[job] nvarchar(30),
primary key ([name],[family_name],[rest_name],[job])
)


create table food
(
[name] nvarchar(20) ,
meal nvarchar(20) ,
kind nvarchar(20),
price int ,
time_prepare int ,
rest_name nvarchar(30),
image_path nvarchar(100),
score int,
id int IDENTITY(1,1) ,
list_name nvarchar(20),
food_date nvarchar(20),
primary key ([name],meal,rest_name),
foreign key ([list_name],meal,rest_name,food_date) references list([list_name],list_meal,rest_name,list_date)
)



create table employee
(
[name] nvarchar(20),
family_name nvarchar(20),
job nvarchar(20),
salary int,
phone_number nvarchar(20),
app_access bit,
image_path nvarchar(100),
rest_name nvarchar(30),
score int,
[email_address] nvarchar(30),
[account_number] nvarchar(30),
[username] nvarchar(30) unique,
[password] nvarchar(30),
primary key ([name],family_name,rest_name),
foreign key (job,rest_name) references rolej(role_name,rest_name)
)


create table list
(
list_id int IDENTITY(1,1) ,
list_name nvarchar(20),
list_meal nvarchar(20),
list_date nvarchar(20),
rest_name nvarchar(30),
image_path  nvarchar(100),
primary key([list_name],list_meal,rest_name,list_date)
)


create table list_match
(
food_name nvarchar(20),
food_meal nvarchar(20) ,
list_name nvarchar(20),
list_meal nvarchar(20) ,
rest_name nvarchar(30),
list_date nvarchar(20),
foreign key (food_name,food_meal,rest_name) references food([name],meal,rest_name),
foreign key (list_name,list_meal,rest_name,list_date) references list([list_name],list_meal,rest_name,list_date)
)




Create table rolej
(
role_name nvarchar(20),
role_salary int,
role_time nvarchar(40),
rest_name nvarchar(30),
primary key(role_name,rest_name)
)


drop table manager

select * from list inner join list_match on(list_name=name and meal=list_meal) inner join food on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name)


select * from list inner join list_match on(list_name=name and meal=list_meal) right join food on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) where list.id=2,food.rest_name='dscsdc'


select * from list inner join list_food_match on(list_name=name and meal=list_meal)





select * from food left join list_match on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) left join list on(list_name=name and meal=list_meal)   where list.id=2 and food.rest_name='dscsdc'

insert into list_match values('s','s','vf','fvdv','dscsdc')

insert into list_match values('s','s','vf','fvdv','dscsdc')


insert into rest_manager.dbo.list values('grtgdfvdfv','gregr',10/04/1402,'dscsdc','C:\\Users\\alireza\\Pictures\\Saved Pictures\\4.jpg')
insert into rest_manager.dbo.list values('vgbhn','hnjm','1402/04/10','dscsdc','C:\\Users\\alireza\\Pictures\\Saved Pictures\\5.jpg')



update list set list_name='ali',list_meal='dscsdc',list_date='1278/11/16',image_path='C:\\Users\\alireza\\Pictures\\Saved Pictures\\1.jpg'


update list set list_name='dfv',list_meal='cds',list_date=1278/11/16,image_path='C:\\Users\\alireza\\Pictures\\Saved Pictures\\1.jpg' where list_name='cddsc' and list_meal='cds' and list_date='16/11/1278 12:00:00 ق.ظ' and rest_name='dscsdc'


select * from list where list_id=3 and rest_name='dscsdc'




SET LANGUAGE Italian;  SET LANGUAGE us_english;
SET DATEFORMAT dmy;
update list set list_name='vfcfdsddv',list_meal='cds',list_date=1278/11/16,image_path='C:\\Users\\alireza\\Pictures\\Saved Pictures\\4.jpg' where list_name='cddsc' and list_meal='cds' and list_date=1900-01-08 and rest_name='dscsdc'

insert into rest_manager.dbo.list values('frefdvdfg','rtgrtg',10/04/1402,'dscsdc','C:\\Users\\alireza\\Pictures\\Saved Pictures\\1.jpg')

















create table orders_item
(
order_item_id int IDENTITY(1,1) ,
order_id int,
[food_name] nvarchar(30),
[rest_name] nvarchar(30) ,
[meal] nvarchar(30) ,
[kind] nvarchar(30),
price float,
time_prepare int,
food_id int,
[count] int,
primary key (order_item_id),
foreign key (order_id) references orders(order_id)
)


create table orders
(
order_id int IDENTITY(1,1) ,
customer_id int,
[address] nvarchar(200),
[phone_number] nvarchar(30),
sum_price float,
payment_id nvarchar(30),
primary key (order_id),
foreign key (customer_id) references customer(customer_id)
)




create table customer
(
customer_id int IDENTITY(1,1) ,
[name] nvarchar(30),
username nvarchar(30),
[password] nvarchar(30),
[phone_number] nvarchar(30),
[address] nvarchar(200),
primary key (customer_id)
)


insert into rest_manager.dbo.orders_item values(1,'vfdv','csdcsd','vdfvc','vdfv',20,20)












