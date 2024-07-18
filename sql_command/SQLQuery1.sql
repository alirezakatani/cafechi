/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [name]
      ,[family_name]
      ,[job]
      ,[salary]
      ,[phone_number]
      ,[app_access]
      ,[image_path]
      ,[rest_name]
      ,[score]
      ,[email_address]
      ,[account_number]
      ,[username]
      ,[password]
  FROM [rest_manager].[dbo].[employee]


  insert into rest_manager.dbo.customer values('alireza','alireza','1080566783','546532135341','csdcsdcsdsd','csdcsdcsdsd')
  SELECT * FROM rest_manager.dbo.customer where username='alireza' and passwordu='1080566783'