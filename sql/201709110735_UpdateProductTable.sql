USE [Bangazon]
GO

UPDATE [dbo].[Product]
   SET [ProductName] = <ProductName, varchar(40),>
      ,[ProductDescription] = <ProductDescription, varchar(40),>
      ,[ProductPrice] = <ProductPrice, money,>
      ,[CurrentInventory] = <CurrentInventory, int,>
 WHERE <Search Conditions,,>
GO


