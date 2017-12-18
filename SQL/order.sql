USE [Order]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRecord]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRecord] 
	-- Add the parameters for the stored procedure here
	@table NVARCHAR(255),@id INT,@updatedate DATETIME,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY

IF @table = 'Customer'
BEGIN
	UPDATE [dbo].[Customer] 
		SET [Status]= 0,[UpdateDate]=@updatedate,[UpdateBy]=@updateby
	WHERE [CustomerID] = @id
END
IF @table = 'Product'
BEGIN
	UPDATE [dbo].[Product] 
		SET [Status]= 0,[UpdateDate]=@updatedate,[UpdateBy]=@updateby
	WHERE [ProductID] = @id
END


COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[GetCustomerSearch]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerSearch]
	-- Add the parameters for the stored procedure here
	@customerid INT,@zone INT, @PageIndex INT = 1,@PageSize INT = 10
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @tableresult AS TABLE
		(	RowNum INT,[CustomerID] INT,[CitizenID] NVARCHAR(50),[CustomerName] NVARCHAR(255),[CustomerAbbr] NVARCHAR(255),[Zone] INT,[Address1] NVARCHAR(MAX),[Address2] NVARCHAR(MAX)
			,[Phone] NVARCHAR(50) ,[Description] NVARCHAR(MAX),[ShowPrice] BIT,[Status] BIT,[UpdateDate] DATETIME,[UpdateBy] NVARCHAR(50) 
		)

	INSERT INTO @tableresult
	SELECT ROW_NUMBER() OVER 
	( ORDER BY [CustomerID] ASC ) AS RowNum
	,[CustomerID],[CitizenID],[CustomerName],[CustomerAbbr],[Zone],[Address1],[Address2],[Phone],[Description],[ShowPrice],[Status],[UpdateDate],[UpdateBy]
	FROM [Order].[dbo].[Customer] WHERE (@customerid IS NULL OR [CustomerID] = @customerid) AND (@zone IS NULL OR [Zone] = @zone) 

    SELECT [CustomerID],[CitizenID],[CustomerName],[CustomerAbbr],[Zone],[Address1],[Address2],[Phone],[Description],[ShowPrice],[Status],[UpdateDate],[UpdateBy] FROM @tableresult
    WHERE RowNum BETWEEN (@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1 
		AND (@customerid IS NULL OR [CustomerID] = @customerid) AND (@zone IS NULL OR [Zone] = @zone) 

END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomerTransport]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerTransport]
	-- Add the parameters for the stored procedure here
	@date DATE
AS
BEGIN

	DECLARE @col VARCHAR(1000),@sql VARCHAR(2000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.[CustomerID],c.[CustomerName],p.[ProductName],o.[OrderAmount] FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID 
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE CONVERT(DATE,o.[OrderDate]) = @date

END


GO
/****** Object:  StoredProcedure [dbo].[GetCustomerTransport2]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerTransport2]
	-- Add the parameters for the stored procedure here
	@date DATE
AS
BEGIN

	DECLARE @col VARCHAR(1000),@sql VARCHAR(2000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @col = COALESCE(@col + ', ','') + QUOTENAME(t.[ProductName])
	FROM 
	(
	SELECT o.[CustomerID],p.[ProductName],o.[OrderAmount] FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID 
	WHERE CONVERT(DATE,o.[OrderDate]) = @date
	) AS t
	GROUP BY [ProductName] --ORDER BY t.[ProductName]

	SET @sql='SELECT * FROM ( SELECT c.[CustomerName],p.[ProductName],o.[OrderAmount] 
		FROM [Order].[dbo].[Order] o 
		JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID 
		JOIN [Order].[dbo].[Customer] c ON c.CustomerID = o.CustomerID 
		WHERE CONVERT(DATE,o.[OrderDate]) = ''' + CONVERT(VARCHAR(10),@date,120) + '''
		) src 
	PIVOT (MAX([OrderAmount]) FOR ProductName IN ('+@col+')) pvt'

	EXEC(@sql)

END


GO
/****** Object:  StoredProcedure [dbo].[GetDailyOrder]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDailyOrder] 
	-- Add the parameters for the stored procedure here
@day varchar(10),
@customer int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.*,DATENAME(DW,o.[OrderDate]) [WeekDay] ,p.ProductName,p.Unit,p.Amount

	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID AND p.Status =1
	INNER JOIN (SELECT MAX(OrderDate) AS MaxDate
		FROM [Order].[dbo].[Order] WHERE DATENAME(DW,[OrderDate]) = @day AND CustomerID = @customer
		GROUP BY CustomerID) max ON max.MaxDate = o.OrderDate 
	WHERE 
	DATENAME(DW,o.[OrderDate]) = @day AND o.CustomerID = @customer  AND o.OrderStatus = 1
	ORDER BY p.Category
END




GO
/****** Object:  StoredProcedure [dbo].[GetOrderbyDay]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderbyDay]
	-- Add the parameters for the stored procedure here
@date Date ,
@customer int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT o.*,DATENAME(DW,o.[OrderDate]) [WeekDay] ,p.ProductName,p.Unit,p.Amount

	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID AND p.Status =1
	WHERE 
	CONVERT(DATE,[OrderDate]) = @date AND o.CustomerID = @customer  AND o.OrderStatus = 1
	ORDER BY p.Category
END




GO
/****** Object:  StoredProcedure [dbo].[GetProductSearch]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductSearch]
	-- Add the parameters for the stored procedure here
	@productid INT,@category INT , @PageIndex INT = 1,@PageSize INT = 10
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @tableresult AS TABLE
		(	RowNum INT,[ProductID] INT,[ProductName] NVARCHAR(255),[ProductAbbr] NVARCHAR(255),[Category] INT,[Price] DECIMAL(14,2),[Unit] INT,[Amount] INT 
			,[Descripiton] NVARCHAR(MAX),[Status] BIT,[UpdateDate] DATETIME,[UpdateBy] NVARCHAR(50) 
		)
	-- Insert statements for procedure here
	INSERT INTO @tableresult
	SELECT ROW_NUMBER() OVER 
	( ORDER BY [ProductID] ASC ) AS RowNum
	,[ProductID],[ProductName],[ProductAbbr],[Category],[Price],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy]
	FROM [Order].[dbo].[Product] WHERE (@productid IS NULL OR [ProductID] = @productid) AND (@category IS NULL OR [Category] = @category) 
   
	SELECT [ProductID],[ProductName],[ProductAbbr],[Category],[Price],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy] FROM @tableresult
	WHERE RowNum BETWEEN (@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1 
		AND (@productid IS NULL OR [ProductID] = @productid) AND (@category IS NULL OR [Category] = @category) 

END

GO
/****** Object:  StoredProcedure [dbo].[GetProductTransport]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProductTransport]
	-- Add the parameters for the stored procedure here
	@date DATE, @zone INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.[ProductID]
		  ,p.[ProductName]
		  ,SUM(o.[OrderAmount]) TotalAmount
		  ,p.[Unit]

	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (@date is null or CONVERT(DATE,o.[OrderDate]) = @date) 
	AND (@zone is null or c.Zone = @zone) 
	GROUP BY o.[ProductID],p.[ProductName],p.[Unit]
END


GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCustomer]

	-- Add the parameters for the stored procedure here
	 @citizenid NVARCHAR(50),@customername NVARCHAR(255),@customerabbr NVARCHAR(255), @zone INT,@address1 NVARCHAR(MAX),@address2 NVARCHAR(MAX)
	,@phone NVARCHAR(50),@description nvarchar(max),@showprice BIT,@status BIT,@updatedate DATETIME,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY
DECLARE @dup INT
/*Select new Customer*/
SELECT @dup = COUNT(*) FROM [dbo].[Customer] WHERE [CustomerName] = @customername
IF @dup > 0
BEGIN
SELECT 11
END
ELSE 
BEGIN

INSERT INTO [dbo].[Customer] ([CitizenID],[CustomerName],[CustomerAbbr],[Zone],[Address1],[Address2],[Phone],[Description],[ShowPrice],[Status],[UpdateDate],[UpdateBy])
    VALUES (@citizenid,@customername,@customerabbr,@zone,@address1,@address2,@phone,@description,@showprice,@status,@updatedate,@updateby)
SELECT 0
END
COMMIT TRAN
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertOrder] 
	-- Add the parameters for the stored procedure here
	@orderdate DATETIME,@updatedate DATETIME, @customerid INT,@productid INT,@productprice DECIMAL(14,2)
	,@orderprice DECIMAL(14,2),@orderamount INT,@ordertotal DECIMAL(14,2),@description NVARCHAR(MAX)
	,@orderStatus BIT,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
BEGIN TRAN
BEGIN TRY
    
	INSERT INTO [dbo].[Order] ([OrderDate],[CustomerID],[ProductID],[ProductPrice],[OrderPrice],[OrderAmount],[OrderTotal],[Description],[OrderStatus],[UpdateDate],[UpdateBy])
	VALUES (@orderdate,@customerid,@productid,@productprice,@orderprice,@orderamount,@ordertotal,@description,@orderStatus,@updatedate,@updateby)


	DECLARE @oldamount INT,@newamount INT

	SET @oldamount = (SELECT [Amount] FROM [dbo].[Product] WHERE [ProductID] = @productid)
	
    IF(@oldamount > @orderamount)
	BEGIN
		SET @newamount = (@oldamount - @orderamount)
	END
	ELSE
	BEGIN
		SET @newamount = 0
	END

	UPDATE [dbo].[Product] SET [Amount] = @newamount WHERE [ProductID] = @productid

COMMIT TRAN
SELECT @@error ErrorCode
END TRY
BEGIN CATCH
SELECT ERROR_NUMBER() ErrorCode
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertProduct] 
	-- Add the parameters for the stored procedure here
	@productname NVARCHAR(255),@productabbr NVARCHAR(255), @category INT ,@productprice DECIMAL(14,2),@unit INT,@productamount INT,@description nvarchar(max),@status BIT
	,@updatedate DATETIME,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY


/*Insert New Product*/
	INSERT INTO [dbo].[Product] ([ProductName],[ProductAbbr],[Category],[Price],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy])
 		VALUES (@productname,@productabbr,@category,@productprice,@unit,@productamount,@description,@status,@updatedate,@updateby)

COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[SelectGridPaging]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectGridPaging] 
	-- Add the parameters for the stored procedure here
	@tablename NVARCHAR(100),@minpagesize INT
	,@intskip INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF @tablename = 'Product'
BEGIN
	SELECT TOP (@minpagesize) * FROM [dbo].[Product]
	WHERE [Status] = 1 AND 
	[ProductID] NOT IN (SELECT TOP (@intskip) [ProductID] FROM [dbo].[Product])
END

IF @tablename = 'Customer'
BEGIN
	SELECT TOP (@minpagesize) * FROM [dbo].[Customer]
	WHERE [Status] = 1 AND
	[CustomerID] NOT IN (SELECT TOP (@intskip) [CustomerID] FROM [dbo].[Customer])
END


END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCustomer]

	-- Add the parameters for the stored procedure here
	 @customerid INT,@citizenid NVARCHAR(50),@customername NVARCHAR(255),@customerabbr NVARCHAR(255), @zone INT,@address1 NVARCHAR(MAX),@address2 NVARCHAR(MAX)
	,@phone NVARCHAR(50),@description nvarchar(max),@showprice BIT,@status BIT,@updatedate DATETIME,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY

/*Select new Customer*/
UPDATE [dbo].[Customer] 
	SET [CitizenID] = @citizenid,[CustomerName] = @customername,[CustomerAbbr] = @customerabbr,[Zone] = @zone,[Address1] = @address1,[Address2]= @address2
	,[Phone] = @phone,[Description] = @description,[ShowPrice] = @showprice,[Status] = @status,[UpdateDate] = @updatedate,[UpdateBy] =@updateby 
WHERE [CustomerID] = @customerid

COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateOrder] 
	-- Add the parameters for the stored procedure here
	@orderdate DATETIME,@updatedate DATETIME,@customerid INT, @productid INT,@productprice DECIMAL(14,2)
	,@orderprice DECIMAL(14,2),@orderamount INT,@ordertotal DECIMAL(14,2),@description nvarchar(MAX),@status BIT
	,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY

	DECLARE @oldorderamount INT,@oldorderprice DECIMAL(14,2),@tmpamount INT,@productamount INT,@newamount INT


	/*Select Old Value*/
	SELECT @oldorderprice = [OrderPrice],@oldorderamount = [OrderAmount] FROM [dbo].[Order]
	WHERE CONVERT(DATE,[OrderDate]) = @orderdate AND [ProductID] = @productid AND [CustomerID] = @customerid

	/*Update order*/
	UPDATE [dbo].[Order] 
		SET [ProductPrice] = @productprice,[OrderPrice] = @orderprice,[OrderAmount] = @orderamount,[OrderTotal] = @ordertotal
		,[Description] = @description,[OrderStatus] = @status
		, [UpdateDate] = @updatedate , [UpdateBy]= @updateby
	WHERE CONVERT(DATE,[OrderDate]) = @orderdate AND [ProductID] = @productid AND [CustomerID] = @customerid
 
	/*Update product Amount*/
	SET @tmpamount = @oldorderamount - @orderamount
	SET @productamount = (SELECT [Amount] FROM [dbo].[Product] WHERE ProductID = @productid)

	IF((@productamount + @tmpamount) > 0 )
	BEGIN
		SET @newamount = (@productamount + @tmpamount)
	END
	ELSE
	BEGIN
		SET @newamount = 0
	END

	UPDATE [dbo].[Product] 
		SET [Amount] = @newamount
		,[UpdateDate] = @updatedate,[UpdateBy] = @updateby
	WHERE ProductID = @productid


COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProduct] 
	-- Add the parameters for the stored procedure here
	@productid INT,@productname NVARCHAR(255),@productabbr NVARCHAR(255), @category INT ,@productprice DECIMAL(14,2),@unit INT,@productamount INT,@description nvarchar(max),@status BIT
	,@updatedate DATETIME,@updateby NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRAN
BEGIN TRY


/*Insert New Product*/
	UPDATE [dbo].[Product] 
		SET [ProductName]=@productname,[ProductAbbr]=@productabbr,[Category]=@category,[Price]=@productprice,[Unit]=@unit,[Amount]=@productamount
		,[Descripiton]=@description,[Status]=@status,[UpdateDate]=@updatedate,[UpdateBy]=@updateby
	WHERE [ProductID] = @productid

COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END




GO
/****** Object:  Table [dbo].[Config]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[run] [int] IDENTITY(1,1) NOT NULL,
	[Module] [nvarchar](200) NULL,
	[Type] [nvarchar](200) NULL,
	[Name] [nvarchar](200) NULL,
	[Value] [nvarchar](200) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[run] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CitizenID] [nvarchar](255) NULL,
	[CustomerName] [nvarchar](255) NULL,
	[CustomerAbbr] [nvarchar](255) NULL,
	[Zone] [int] NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ShowPrice] [bit] NULL,
	[Status] [bit] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[run] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](200) NULL,
	[UserGroup] [int] NULL,
	[Status] [bit] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[run] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 18/12/2017 16:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[ProductID] [int] NULL,
	[ProductPrice] [decimal](14, 2) NULL,
	[OrderPrice] [decimal](14, 2) NULL,
	[OrderAmount] [int] NULL,
	[OrderTotal] [decimal](14, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[OrderStatus] [bit] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 18/12/2017 16:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[ProductAbbr] [nvarchar](255) NULL,
	[Category] [int] NULL,
	[Price] [decimal](14, 2) NULL,
	[Unit] [int] NULL,
	[Amount] [int] NULL,
	[Descripiton] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwCustomerDetail]    Script Date: 18/12/2017 16:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwCustomerDetail]
AS
SELECT        c.CustomerID, c.CitizenID, c.CustomerName, c.CustomerAbbr, c.Zone, cf.Name, c.Address1, c.Address2, c.Phone, c.Description, c.ShowPrice, c.Status
FROM            dbo.Customer AS c INNER JOIN
                         dbo.Config AS cf ON cf.Value = c.Zone AND cf.Module = 'CustomerZone'
WHERE        (c.Status = 1)



GO
/****** Object:  View [dbo].[vwOrder]    Script Date: 18/12/2017 16:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwOrder]
AS
SELECT        OrderID, OrderDate, CustomerID, ProductID, ProductPrice, DATENAME(DW, OrderDate) AS OrderDay, OrderPrice, OrderAmount, OrderTotal, Description, OrderStatus, UpdateDate, UpdateBy
FROM            dbo.[Order]
WHERE        (OrderStatus = 1)



GO
/****** Object:  View [dbo].[vwOrderDetail]    Script Date: 18/12/2017 16:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwOrderDetail]
AS
SELECT        o.OrderID, o.OrderDate, o.CustomerID, o.ProductID, o.ProductPrice, o.OrderPrice, o.OrderAmount, o.OrderTotal, o.Description, o.OrderStatus, DATENAME(DW, o.OrderDate) AS OrderDay, p.ProductName, 
                         p.ProductAbbr, p.Category, p.Price, p.Unit, p.Amount, c.CitizenID, c.CustomerName, c.CustomerAbbr, c.Zone, c.Address1, c.Address2, c.Phone, c.ShowPrice
FROM            dbo.[Order] AS o INNER JOIN
                         dbo.Product AS p ON p.ProductID = o.ProductID AND p.Status = 1 INNER JOIN
                         dbo.Customer AS c ON c.CustomerID = o.CustomerID AND c.Status = 1
WHERE        (o.OrderStatus = 1)




GO
SET IDENTITY_INSERT [dbo].[Config] ON 

INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (1, N'Vat', N'int', N'Vat', N'7', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (2, N'CustomerZone', N'string', N'เขต 1', N'1', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (3, N'CustomerZone', N'string', N'เขต 2', N'2', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (4, N'CustomerZone', N'string', N'เขต 3', N'3', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (5, N'Company', N'string', N'CompanyLogo', N'c:\Logo.png', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (6, N'Company', N'string', N'CompanyAddress', N'Bangkok Thailand', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (7, N'Company', N'string', N'CompanyTaxID', N'111111111', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (8, N'ProductCategory', N'string', N'กลุ่ม 1', N'1', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (9, N'ProductCategory', N'string', N'กลุ่ม 2', N'2', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (10, N'ProductCategory', N'string', N'กลุ่ม 3', N'3', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (11, N'ProductCategory', N'string', N'กลุ่ม 4', N'4', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (12, N'ReportName', N'string', N'ใบเสร็จรับเงิน', N'1', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (13, N'ReportName', N'string', N'ใบส่งสินค้า', N'2', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (14, N'ReportName', N'string', N'ใบส่งของ', N'3', NULL, NULL)
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (15, N'ReportName', N'string', N'ใบขึ้นรถ', N'4', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Config] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'1112225554446', N'นายพิเชษฐ์ รักงาม', N'พิเชษฐ์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485456', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'1112225554447', N'นายสุพจน์ ใจเย็น', N'สุพจน์', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485457', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'1112225554448', N'นายสมศักดิ์ สุขมะโน', N'สมศักดิ์', 1, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485458', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (4, N'1112225554449', N'นายประสาร ระดมยศ', N'ประสาร', 1, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485459', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (5, N'1112225554450', N'นางอำไพ แย้มสรวล', N'อำไพ', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485460', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (6, N'1112225554451', N'นายวรพจน์ ฉายศิริ', N'วรพจน์', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485461', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (7, N'1112225554452', N'นางสมจิตร มะลิหน', N'สมจิตร', 1, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485462', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (8, N'1112225554453', N'นายกิตต์ คำวงศ์', N'กิตต์', 2, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485463', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (9, N'1112225554454', N'นายณรงค์ ศิริศักดิ์', N'ณรงค์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485464', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (10, N'1112225554455', N'นายระดม โผพ่วงพันธ์', N'ระดม', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485465', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (11, N'1112225554456', N'นายพยนต์ ศิลารักษ์', N'พยนต์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485466', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (12, N'1112225554457', N'นายพิจิตร สิมบุตร', N'พิจิตร', 1, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485467', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (13, N'1112225554458', N'นายวศิลป์ คัมภิรานนท์', N'วศิลป์', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485468', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (14, N'1112225554459', N'นายชัยพงษ์ ผ่องศรี', N'ชัยพงษ์', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485469', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (15, N'1112225554460', N'นายธวัชชัย มีศรี', N'ธวัชชัย', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485470', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (16, N'1112225554461', N'นายจันทร์ บุญแก้ว', N'จันทร์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485471', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (17, N'1112225554462', N'นายศุภสิทธิ์ แดงไสว', N'ศุภสิทธิ์', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485472', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (18, N'1112225554463', N'นายไพรบูล ร่มไทร', N'ไพรบูล', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485473', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (19, N'1112225554464', N'นายรังสรรค์ ราชสมบูรณ์', N'รังสรรค์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485474', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (20, N'1112225554465', N'นายสุชาติ พนมใส', N'สุชาติ', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485475', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (21, N'1112225554466', N'นายวันชัย จับจิตร', N'วันชัย', 2, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485476', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (22, N'1112225554467', N'นายธงชัย วรินกุล', N'ธงชัย', 3, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485477', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (23, N'1112225554468', N'นายจารึก สระ', N'จารึก', 1, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485478', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (24, N'1112225554469', N'นายธันกร อิศรา', N'ธันว์ยากร', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485479', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (25, N'1112225554470', N'นายสมยศ ใจเที่ยง', N'สมยศ', 3, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485480', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (26, N'1112225554471', N'นายประมวล โสมณี', N'ประมวล', 1, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485481', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (27, N'1112225554472', N'นายปรีชา ญาณจรูญ', N'ปรีชา', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485482', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (28, N'1112225554473', N'นายทวี พิมพา', N'ทวี', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485483', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (29, N'1112225554474', N'นางราตรี อชะเมตรา', N'ราตรี', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485484', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (30, N'1112225554475', N'นายวรชาติ ศรีเมือง', N'วรชาติ', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485485', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (31, N'1112225554476', N'นายเจษฏา มีครุฑ', N'เจษฏา', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485486', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (32, N'1112225554477', N'นายฉลวย ศรีมั่น', N'ฉลวย', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485487', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (33, N'1112225554478', N'นายณรงค์พล ทองเกิด', N'ณรงค์พล', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485488', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (34, N'1112225554479', N'นายเสถียร พันธุ์สนธิ', N'เสถียร', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485489', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (35, N'1112225554480', N'นายพิรุณ ทองเกิด', N'พิรุณ', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485490', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (36, N'1112225554481', N'นายอังคาร จาดจุ้ย', N'อังคาร', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485491', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (37, N'1112225554482', N'นายชาลี บัวแดง', N'ชาลี', 3, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485492', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (38, N'1112225554483', N'นายมานะ เจริญจิตร', N'มานะ', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485493', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (39, N'1112225554484', N'นายญาณภัทร ผดุงตระกูล', N'ญาณภัทร', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485494', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (40, N'1112225554485', N'นายวินัย เชื้อสายเหลือง', N'วินัย', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485495', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (41, N'1112225554486', N'นายปัญญา วรพุฒ', N'ปัญญา', 1, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485496', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (42, N'1112225554487', N'นายเล็ก อำไพ', N'เล็ก', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485497', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (43, N'1112225554488', N'นายวิชิต กิตติคุณ', N'วิชิต', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485498', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (44, N'1112225554489', N'นายศักดิ์สิทธิ์ ศรมณี', N'ศักดิ์สิทธิ์', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485499', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (45, N'1112225554490', N'นายมะณี สุประกาศ', N'มะณี', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485500', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (46, N'1112225554491', N'นายสมพงษ์ กมลศิริ', N'สมพงษ์', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485501', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (47, N'1112225554492', N'นายคำรณ เรืองฤทธิ์', N'คำรณ', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485502', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (48, N'1112225554493', N'นายสมาน เหล็กเพ็ชร', N'สมาน', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485503', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (49, N'1112225554494', N'นายชูชาติ ซ่อนกลิ่น', N'ชูชาติ', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485504', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (50, N'1112225554495', N'นางบังอร นันทวิชิต', N'บังอร', 3, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485505', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (51, N'1112225554496', N'นายใหญ่ ประไพวิทย์', N'ใหญ่', 3, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485506', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (52, N'1112225554497', N'นายสายัณห์ ทับแสง', N'สายัณห์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485507', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (53, N'1112225554498', N'นางวารี นิธิกุล', N'วารี', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485508', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (54, N'1112225554499', N'นายพนมเทียน ชายทวีป', N'พนมเทียน', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485509', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (55, N'1112225554500', N'นายพัฒนะ สืบแก้ว', N'พัฒนะ', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485510', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (56, N'1112225554501', N'นายมานิตย์ พุ่มคำ', N'มานิตย์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485511', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (57, N'1112225554502', N'นายสำรวย แสงนิล', N'สำรวย', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485512', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (58, N'1112225554503', N'นายเทวินทร์ ป่าไม้', N'เทวินทร์', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485513', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (59, N'1112225554504', N'นายอุรินทร์ ช่างเหล็ก', N'อุรินทร์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485514', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (60, N'1112225554505', N'นายศักดา ศรทองคำ', N'ศักดา', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485515', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (61, N'1112225554506', N'นายสุชาย หาดแก้ว', N'สุชาย', 1, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485516', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (62, N'1112225554507', N'นายปรีชา ถิรพัฒน', N'ปรีชา', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485517', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (63, N'1112225554508', N'นายวีระ สุทธิรัตน์', N'วีระ', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485518', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (64, N'1112225554509', N'นายจตุรงค์ สื่อไพศาล', N'จตุรงค์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485519', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (65, N'1112225554510', N'นางปัทมา เพชรรื่น', N'ปัทมา', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485520', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (66, N'1112225554511', N'นายวินัย แตงเจริญ', N'วินัย', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485521', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (67, N'1112225554512', N'นายวิทยา แก้วมณี', N'วิทยา', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485522', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (68, N'1112225554513', N'นายวิรัช สุขสว่าง', N'วิรัช', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485523', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (69, N'1112225554514', N'นายชาญณรงค์ แก้วเกตุ', N'ชาญณรงค์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485524', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (70, N'1112225554515', N'นายชาญวุทธ ทั่งจันทร์', N'ชาญวุทธ', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485525', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (71, N'1112225554516', N'นายจุฬา คุ้มคง', N'จุฬา', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485526', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (72, N'1112225554517', N'นายประสงค์ วินไชย', N'ประสงค์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485527', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (73, N'1112225554518', N'นายเกียรติศักดิ์ รอสง', N'เกียรติศักดิ์', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485528', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (74, N'1112225554519', N'นายไสว หมอกม่วง', N'ไสว', 3, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485529', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (75, N'1112225554520', N'นายสุริยา เสลานอก', N'สุริยา', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485530', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (76, N'1112225554521', N'นายพิมล ผาสุข', N'พิมล', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485531', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (77, N'1112225554522', N'นายสุเทพ อัจนิวัฒน์', N'สุเทพ', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485532', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (78, N'1112225554523', N'นายประเทือง ช่วยสิทธิ์', N'ประเทือง', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485533', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (79, N'1112225554524', N'นายสาธิต ตุลาพันธ์', N'สาธิต', 3, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485534', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (80, N'1112225554525', N'นายลือชา จินตกา', N'ลือชา', 1, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485535', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (81, N'1112225554526', N'นายสัมฤทธิ์ ตุลาพันธ์', N'สัมฤทธิ์', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485536', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (82, N'1112225554527', N'นายวิจิตร ตาตะกรุด', N'วิจิตร', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485537', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (83, N'1112225554528', N'นายสงวน ไทยตรง', N'สงวน', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485538', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (84, N'1112225554529', N'นายสมชาย คชสิทธิ์', N'สมชาย', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485539', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (85, N'1112225554530', N'นายสุมาน ศิริเคารพ', N'สุมาน', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485540', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (86, N'1112225554531', N'นายบุญนำ วรรณไชย', N'บุญนำ', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485541', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (87, N'1112225554532', N'นายสมเสรีย์ ปัญจะมูล', N'สมเสรีย์', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485542', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (88, N'1112225554533', N'นายสมนึก งามวงศ์', N'สมนึก', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485543', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (89, N'1112225554534', N'นายจเร เต็มสอาด', N'จเร', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485544', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (90, N'1112225554535', N'นายวิลาศ โยคาวจร', N'วิลาศ', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485545', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (91, N'1112225554536', N'นายประสาร พิณเสนาะ', N'ประสาร', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485546', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (92, N'1112225554537', N'นายสุขสรรค์ สุขสว่าง', N'สุขสรรค์', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485547', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (93, N'1112225554538', N'นายศักดิ์สิทธิ์ สุวรรณ', N'ศักดิ์สิทธิ์', 1, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485548', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (94, N'1112225554539', N'นายดำ กระชาย', N'ดำ', 3, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485549', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (95, N'1112225554540', N'นายปลื้ม จรัสแสง', N'ปลื้ม', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485550', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (96, N'1112225554541', N'นายวิภพ ชินวงศ์', N'วิภพ', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485551', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (97, N'1112225554542', N'นายจิรบูรณ์ ดวงสุขขี', N'จิรบูรณ์', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485552', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (98, N'1112225554543', N'นายพินิจ ก่อพิเศษ', N'พินิจ', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485553', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (99, N'1112225554544', N'นายสมบูรณ์ วัฒน์เดชา', N'สมบูรณ์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485554', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
GO
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (100, N'1112225554545', N'นายประสาน ภูรินันทน์', N'ประสาน', 1, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485555', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (101, N'1112225554546', N'นายสนิท แสนอินตา', N'สนิท', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485556', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (102, N'1112225554547', N'นายเจียม ศรีวิจารณ์', N'เจียม', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485557', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (103, N'1112225554548', N'นายไพบูลย์ มัจฉา', N'ไพบูลย์', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485558', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (104, N'1112225554549', N'นายเฉลิม ขาวงาม', N'เฉลิม', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485559', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (105, N'1112225554550', N'นายทองเลื่อน กระโทก', N'ทองเลื่อน', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485560', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (106, N'1112225554551', N'นายประทาน กิตสุวัฒน์', N'ประทาน', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485561', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (107, N'1112225554552', N'นายไพฑูรย์ อินอ่อน', N'ไพฑูรย์', 3, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485562', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (108, N'1112225554553', N'นายชัยชาญ วัฒยุ', N'ชัยชาญ', 1, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485563', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (109, N'1112225554554', N'นายสุพรรณ เหลืองทอง', N'สุพรรณ', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485564', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (110, N'1112225554555', N'นายธวัช บุญตวง', N'ธวัช', 3, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485565', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (111, N'1112225554556', N'นายคมสรรค์ หินโม', N'คมสรรค์', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485566', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (112, N'1112225554557', N'นายสอน บุญโต', N'สอน', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485567', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (113, N'1112225554558', N'นายสมจิตร วิทยา', N'สมจิตร', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485568', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (114, N'1112225554559', N'นายสุทัศน์ พลเยี่ยม', N'สุทัศน์', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485569', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (115, N'1112225554560', N'นายบุญเสริม ผันสูงเนิน', N'บุญเสริม', 3, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485570', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (116, N'1112225554561', N'นายธเนศ มาตรจันทร์', N'ธเนศ', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485571', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (117, N'1112225554562', N'นายทวิช นิลคง', N'ทวิชา', 1, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485572', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (118, N'1112225554563', N'นายประยูร เรียงผา', N'ประยูร', 1, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485573', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (119, N'1112225554564', N'นายชื่น เหมาะทอง', N'ชื่น', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485574', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (120, N'1112225554565', N'นายทองอิน คุ้มทั่ว', N'ทองอิน', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485575', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (121, N'1112225554566', N'นายยิ่งยง โพธิขำ', N'ยิ่งยง', 2, N'แขวงห้วยขวาง เขตห้วยขวาง จังหวัดกรุงเทพมหานคร', NULL, N'284485576', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (122, N'1112225554567', N'นายคมสันต์ สุขบง', N'คมสันต์', 3, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485577', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (123, N'1112225554568', N'นายบรรจง คนเพียร', N'บรรจง', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485578', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (124, N'1112225554569', N'นายโสภิต คุณมาศ', N'โสภิต', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485579', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (125, N'1112225554570', N'นายมงคล โจมภาค', N'มงคล', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485580', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (126, N'1112225554571', N'นายยุทธพงษ์ แสงอร่าม', N'ยุทธพงษ์', 1, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485581', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (127, N'1112225554572', N'นายสุรพล ชัยหงษ์', N'สุรพล', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485582', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (128, N'1112225554573', N'นายอมตะ คุณล้าน', N'อมตะ', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485583', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (129, N'1112225554574', N'นางสุชาดา สาแก้ว', N'สุชาดา', 2, N'แขวงบางยี่เรือ เขตธนบุรี จังหวัดกรุงเทพมหานคร', NULL, N'284485584', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (130, N'1112225554575', N'นายสุรศักดิ์ คบพิทักษ์', N'สุรศักดิ์', 3, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485585', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (131, N'1112225554576', N'นายสามารถ สิงห์ใน', N'สามารถ', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485586', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (132, N'1112225554577', N'นายสมศักดิ์ กอวิเศษ', N'สมศักดิ์', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485587', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (133, N'1112225554578', N'นางวราภรณ์ ทรงคาศรี', N'วราภรณ์', 3, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485588', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (134, N'1112225554579', N'นางสาวเพ็ญ คำสงค์', N'เพ็ญ', 1, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485589', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (135, N'1112225554580', N'นายประยูร ทองมูล', N'ประยูร', 2, N'แขวงหนองค้างพลู เขตหนองแขม จังหวัดกรุงเทพมหานคร', NULL, N'284485590', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (136, N'1112225554581', N'นายสมบูรณ์ ทองมะดัน', N'สมบูรณ์', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485591', NULL, 1, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (137, N'1112225554582', N'นายบรรชา ราษีทอง', N'บรรชา', 2, N'แขวงศาลาธรรมสพน์ เขตทวีวัฒนา จังหวัดกรุงเทพมหานคร', NULL, N'284485592', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (138, N'1112225554583', N'นายภิรมย์ วรภักดี', N'ภิรมย์', 2, N'ต.บางรักพัฒนา อ.บางบัวทอง จังหวัดนนทบุรี', NULL, N'284485593', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (139, N'1112225554584', N'นายรังสรรค์ เสียงรัมย์', N'รังสรรค์', 2, N'แขวงทุ่งสองห้อง เขตหลักสี่ จังหวัดกรุงเทพมหานคร', NULL, N'284485594', NULL, 0, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'Admin', N'1234', 1, 1, NULL, NULL)
INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'Account', N'2', 2, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (1, CAST(0x0000A82D00FDA214 AS DateTime), 1, 1, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (2, CAST(0x0000A82D00FDA214 AS DateTime), 1, 2, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (3, CAST(0x0000A82D00FDA214 AS DateTime), 1, 3, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (4, CAST(0x0000A82D00FDA214 AS DateTime), 1, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (5, CAST(0x0000A82D00FDA214 AS DateTime), 1, 5, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 2, CAST(290.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (6, CAST(0x0000A82D00FDA214 AS DateTime), 1, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (7, CAST(0x0000A82D00FDA214 AS DateTime), 1, 7, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 2, CAST(650.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (8, CAST(0x0000A82D00FDA214 AS DateTime), 1, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (9, CAST(0x0000A82D00FDA214 AS DateTime), 1, 9, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (10, CAST(0x0000A82D00FDA214 AS DateTime), 1, 10, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (11, CAST(0x0000A82D00FDA214 AS DateTime), 1, 11, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (12, CAST(0x0000A82D00FDA214 AS DateTime), 1, 12, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (13, CAST(0x0000A82D00FDA214 AS DateTime), 1, 13, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (14, CAST(0x0000A83A00FDA214 AS DateTime), 2, 5, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (15, CAST(0x0000A83A00FDA214 AS DateTime), 2, 6, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (16, CAST(0x0000A83A00FDA214 AS DateTime), 2, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (17, CAST(0x0000A83A00FDA214 AS DateTime), 2, 8, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (18, CAST(0x0000A83A00FDA214 AS DateTime), 2, 9, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (19, CAST(0x0000A83A00FDA214 AS DateTime), 2, 10, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (20, CAST(0x0000A83A00FDA214 AS DateTime), 2, 11, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (21, CAST(0x0000A83A00FDA214 AS DateTime), 2, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (22, CAST(0x0000A83A00FDA214 AS DateTime), 2, 13, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (23, CAST(0x0000A83A00FDA214 AS DateTime), 2, 14, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (24, CAST(0x0000A83A00FDA214 AS DateTime), 2, 15, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (25, CAST(0x0000A83A00FDA214 AS DateTime), 2, 16, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (26, CAST(0x0000A83A00FDA214 AS DateTime), 2, 17, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (27, CAST(0x0000A83A00FDA214 AS DateTime), 2, 18, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (28, CAST(0x0000A82D00FDA214 AS DateTime), 3, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (29, CAST(0x0000A82D00FDA214 AS DateTime), 3, 13, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (30, CAST(0x0000A82D00FDA214 AS DateTime), 3, 14, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (31, CAST(0x0000A82D00FDA214 AS DateTime), 3, 15, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 3, CAST(1500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (32, CAST(0x0000A82D00FDA214 AS DateTime), 3, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (33, CAST(0x0000A82D00FDA214 AS DateTime), 3, 17, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (34, CAST(0x0000A82D00FDA214 AS DateTime), 3, 18, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (35, CAST(0x0000A82D00FDA214 AS DateTime), 3, 19, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 7, CAST(2275.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (36, CAST(0x0000A82D00FDA214 AS DateTime), 3, 20, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (37, CAST(0x0000A82D00FDA214 AS DateTime), 3, 21, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (38, CAST(0x0000A82D00FDA214 AS DateTime), 3, 22, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (39, CAST(0x0000A82D00FDA214 AS DateTime), 3, 23, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (40, CAST(0x0000A82D00FDA214 AS DateTime), 3, 24, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (41, CAST(0x0000A82D00FDA214 AS DateTime), 3, 25, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (42, CAST(0x0000A82D00FDA214 AS DateTime), 3, 26, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (43, CAST(0x0000A85700FDA214 AS DateTime), 4, 1, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (44, CAST(0x0000A85800FDA214 AS DateTime), 4, 2, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (45, CAST(0x0000A85900FDA214 AS DateTime), 4, 3, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 5, CAST(1625.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (46, CAST(0x0000A85A00FDA214 AS DateTime), 4, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (47, CAST(0x0000A85B00FDA214 AS DateTime), 4, 5, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (48, CAST(0x0000A85C00FDA214 AS DateTime), 4, 6, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (49, CAST(0x0000A85D00FDA214 AS DateTime), 4, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (50, CAST(0x0000A85E00FDA214 AS DateTime), 4, 8, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (51, CAST(0x0000A85F00FDA214 AS DateTime), 4, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (52, CAST(0x0000A86000FDA214 AS DateTime), 4, 30, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (53, CAST(0x0000A86100FDA214 AS DateTime), 4, 31, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (54, CAST(0x0000A86200FDA214 AS DateTime), 4, 32, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (55, CAST(0x0000A86300FDA214 AS DateTime), 4, 33, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (56, CAST(0x0000A86400FDA214 AS DateTime), 4, 34, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (57, CAST(0x0000A86500FDA214 AS DateTime), 4, 35, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (58, CAST(0x0000A82E00FDA214 AS DateTime), 3, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (59, CAST(0x0000A82E00FDA214 AS DateTime), 3, 17, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (60, CAST(0x0000A82E00FDA214 AS DateTime), 3, 18, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (61, CAST(0x0000A82E00FDA214 AS DateTime), 3, 19, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (62, CAST(0x0000A82E00FDA214 AS DateTime), 3, 20, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 7, CAST(1015.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (63, CAST(0x0000A82E00FDA214 AS DateTime), 3, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (64, CAST(0x0000A82E00FDA214 AS DateTime), 3, 30, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (65, CAST(0x0000A82E00FDA214 AS DateTime), 3, 40, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (66, CAST(0x0000A82E00FDA214 AS DateTime), 3, 41, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (67, CAST(0x0000A82E00FDA214 AS DateTime), 3, 42, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (68, CAST(0x0000A82E00FDA214 AS DateTime), 3, 43, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (69, CAST(0x0000A82E00FDA214 AS DateTime), 3, 44, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (70, CAST(0x0000A82E00FDA214 AS DateTime), 3, 45, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (71, CAST(0x0000A82E00FDA214 AS DateTime), 3, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (72, CAST(0x0000A82E00FDA214 AS DateTime), 3, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (73, CAST(0x0000A82E00FDA214 AS DateTime), 3, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (74, CAST(0x0000A82E00FDA214 AS DateTime), 3, 32, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 3, CAST(975.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (75, CAST(0x0000A82E00FDA214 AS DateTime), 5, 33, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (76, CAST(0x0000A82E00FDA214 AS DateTime), 5, 34, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 5, CAST(1350.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (77, CAST(0x0000A82E00FDA214 AS DateTime), 5, 35, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 6, CAST(3000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (78, CAST(0x0000A82E00FDA214 AS DateTime), 5, 36, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (79, CAST(0x0000A82E00FDA214 AS DateTime), 5, 37, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (80, CAST(0x0000A82E00FDA214 AS DateTime), 5, 38, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (81, CAST(0x0000A82E00FDA214 AS DateTime), 5, 39, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (82, CAST(0x0000A82E00FDA214 AS DateTime), 5, 5, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (83, CAST(0x0000A82E00FDA214 AS DateTime), 5, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (84, CAST(0x0000A82E00FDA214 AS DateTime), 5, 7, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (85, CAST(0x0000A82E00FDA214 AS DateTime), 5, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (86, CAST(0x0000A82E00FDA214 AS DateTime), 5, 29, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (87, CAST(0x0000A82E00FDA214 AS DateTime), 5, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 6, CAST(870.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (88, CAST(0x0000A82E00FDA214 AS DateTime), 5, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (89, CAST(0x0000A82E00FDA214 AS DateTime), 5, 47, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (90, CAST(0x0000A82E00FDA214 AS DateTime), 5, 48, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (91, CAST(0x0000A82E00FDA214 AS DateTime), 5, 49, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (92, CAST(0x0000A82E00FDA214 AS DateTime), 5, 50, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (93, CAST(0x0000A82D00FDA214 AS DateTime), 14, 1, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (94, CAST(0x0000A82D00FDA214 AS DateTime), 14, 2, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (95, CAST(0x0000A82D00FDA214 AS DateTime), 14, 3, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (96, CAST(0x0000A82D00FDA214 AS DateTime), 14, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (97, CAST(0x0000A82D00FDA214 AS DateTime), 14, 5, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 2, CAST(290.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (98, CAST(0x0000A82D00FDA214 AS DateTime), 14, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (99, CAST(0x0000A82D00FDA214 AS DateTime), 14, 7, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 2, CAST(650.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
GO
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (100, CAST(0x0000A82D00FDA214 AS DateTime), 14, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (101, CAST(0x0000A82D00FDA214 AS DateTime), 14, 9, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (102, CAST(0x0000A82D00FDA214 AS DateTime), 14, 10, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (103, CAST(0x0000A82D00FDA214 AS DateTime), 14, 11, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (104, CAST(0x0000A82D00FDA214 AS DateTime), 14, 12, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (105, CAST(0x0000A82D00FDA214 AS DateTime), 14, 13, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (106, CAST(0x0000A83A00FDA214 AS DateTime), 12, 5, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (107, CAST(0x0000A83A00FDA214 AS DateTime), 12, 6, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (108, CAST(0x0000A83A00FDA214 AS DateTime), 12, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (109, CAST(0x0000A83A00FDA214 AS DateTime), 12, 8, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (110, CAST(0x0000A83A00FDA214 AS DateTime), 12, 9, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (111, CAST(0x0000A83A00FDA214 AS DateTime), 12, 10, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (112, CAST(0x0000A83A00FDA214 AS DateTime), 12, 11, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (113, CAST(0x0000A83A00FDA214 AS DateTime), 12, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (114, CAST(0x0000A83A00FDA214 AS DateTime), 12, 13, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (115, CAST(0x0000A83A00FDA214 AS DateTime), 12, 14, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (116, CAST(0x0000A83A00FDA214 AS DateTime), 12, 15, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (117, CAST(0x0000A83A00FDA214 AS DateTime), 12, 16, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (118, CAST(0x0000A83A00FDA214 AS DateTime), 12, 17, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (119, CAST(0x0000A83A00FDA214 AS DateTime), 12, 18, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (120, CAST(0x0000A82D00FDA214 AS DateTime), 13, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (121, CAST(0x0000A82D00FDA214 AS DateTime), 13, 13, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (122, CAST(0x0000A82D00FDA214 AS DateTime), 13, 14, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (123, CAST(0x0000A82D00FDA214 AS DateTime), 13, 15, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 3, CAST(1500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (124, CAST(0x0000A82D00FDA214 AS DateTime), 13, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (125, CAST(0x0000A82D00FDA214 AS DateTime), 13, 17, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (126, CAST(0x0000A82D00FDA214 AS DateTime), 13, 18, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (127, CAST(0x0000A82D00FDA214 AS DateTime), 13, 19, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 7, CAST(2275.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (128, CAST(0x0000A82D00FDA214 AS DateTime), 13, 20, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (129, CAST(0x0000A82D00FDA214 AS DateTime), 13, 21, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (130, CAST(0x0000A82D00FDA214 AS DateTime), 13, 22, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (131, CAST(0x0000A82D00FDA214 AS DateTime), 13, 23, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (132, CAST(0x0000A82D00FDA214 AS DateTime), 13, 24, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (133, CAST(0x0000A82D00FDA214 AS DateTime), 13, 25, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (134, CAST(0x0000A82D00FDA214 AS DateTime), 13, 26, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (135, CAST(0x0000A85700FDA214 AS DateTime), 22, 1, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (136, CAST(0x0000A85800FDA214 AS DateTime), 22, 2, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (137, CAST(0x0000A85900FDA214 AS DateTime), 22, 3, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 5, CAST(1625.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (138, CAST(0x0000A85A00FDA214 AS DateTime), 22, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (139, CAST(0x0000A85B00FDA214 AS DateTime), 22, 5, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (140, CAST(0x0000A85C00FDA214 AS DateTime), 22, 6, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (141, CAST(0x0000A85D00FDA214 AS DateTime), 22, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (142, CAST(0x0000A85E00FDA214 AS DateTime), 22, 8, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (143, CAST(0x0000A85F00FDA214 AS DateTime), 22, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (144, CAST(0x0000A86000FDA214 AS DateTime), 22, 30, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (145, CAST(0x0000A86100FDA214 AS DateTime), 22, 31, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (146, CAST(0x0000A86200FDA214 AS DateTime), 22, 32, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (147, CAST(0x0000A86300FDA214 AS DateTime), 22, 33, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (148, CAST(0x0000A86400FDA214 AS DateTime), 22, 34, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (149, CAST(0x0000A86500FDA214 AS DateTime), 22, 35, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (150, CAST(0x0000A82E00FDA214 AS DateTime), 23, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (151, CAST(0x0000A82E00FDA214 AS DateTime), 23, 17, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (152, CAST(0x0000A82E00FDA214 AS DateTime), 23, 18, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (153, CAST(0x0000A82E00FDA214 AS DateTime), 23, 19, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (154, CAST(0x0000A82E00FDA214 AS DateTime), 23, 20, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 7, CAST(1015.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (155, CAST(0x0000A82E00FDA214 AS DateTime), 23, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (156, CAST(0x0000A82E00FDA214 AS DateTime), 23, 30, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (157, CAST(0x0000A82E00FDA214 AS DateTime), 23, 40, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (158, CAST(0x0000A82E00FDA214 AS DateTime), 23, 41, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (159, CAST(0x0000A82E00FDA214 AS DateTime), 23, 42, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (160, CAST(0x0000A82E00FDA214 AS DateTime), 23, 43, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (161, CAST(0x0000A82E00FDA214 AS DateTime), 23, 44, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (162, CAST(0x0000A82E00FDA214 AS DateTime), 23, 45, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (163, CAST(0x0000A82E00FDA214 AS DateTime), 23, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (164, CAST(0x0000A82E00FDA214 AS DateTime), 23, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (165, CAST(0x0000A82E00FDA214 AS DateTime), 23, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (166, CAST(0x0000A82E00FDA214 AS DateTime), 23, 32, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 3, CAST(975.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (167, CAST(0x0000A82E00FDA214 AS DateTime), 75, 33, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (168, CAST(0x0000A82E00FDA214 AS DateTime), 75, 34, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 5, CAST(1350.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (169, CAST(0x0000A82E00FDA214 AS DateTime), 75, 35, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 6, CAST(3000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (170, CAST(0x0000A82E00FDA214 AS DateTime), 75, 36, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (171, CAST(0x0000A82E00FDA214 AS DateTime), 75, 37, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (172, CAST(0x0000A82E00FDA214 AS DateTime), 75, 38, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (173, CAST(0x0000A82E00FDA214 AS DateTime), 75, 39, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (174, CAST(0x0000A82E00FDA214 AS DateTime), 75, 5, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (175, CAST(0x0000A82E00FDA214 AS DateTime), 75, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (176, CAST(0x0000A82E00FDA214 AS DateTime), 75, 7, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (177, CAST(0x0000A82E00FDA214 AS DateTime), 75, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (178, CAST(0x0000A82E00FDA214 AS DateTime), 75, 29, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (179, CAST(0x0000A82E00FDA214 AS DateTime), 75, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 6, CAST(870.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (180, CAST(0x0000A82E00FDA214 AS DateTime), 75, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (181, CAST(0x0000A82E00FDA214 AS DateTime), 75, 47, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (182, CAST(0x0000A82E00FDA214 AS DateTime), 75, 48, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (183, CAST(0x0000A82E00FDA214 AS DateTime), 75, 49, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (184, CAST(0x0000A82E00FDA214 AS DateTime), 75, 50, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (185, CAST(0x0000A82D00FDA214 AS DateTime), 34, 1, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (186, CAST(0x0000A82D00FDA214 AS DateTime), 34, 2, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (187, CAST(0x0000A82D00FDA214 AS DateTime), 34, 3, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (188, CAST(0x0000A82D00FDA214 AS DateTime), 34, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (189, CAST(0x0000A82D00FDA214 AS DateTime), 34, 5, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 2, CAST(290.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (190, CAST(0x0000A82D00FDA214 AS DateTime), 34, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (191, CAST(0x0000A82D00FDA214 AS DateTime), 34, 7, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 2, CAST(650.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (192, CAST(0x0000A82D00FDA214 AS DateTime), 34, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (193, CAST(0x0000A82D00FDA214 AS DateTime), 34, 9, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (194, CAST(0x0000A82D00FDA214 AS DateTime), 34, 10, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (195, CAST(0x0000A82D00FDA214 AS DateTime), 34, 11, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (196, CAST(0x0000A82D00FDA214 AS DateTime), 34, 12, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (197, CAST(0x0000A82D00FDA214 AS DateTime), 34, 13, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (198, CAST(0x0000A83A00FDA214 AS DateTime), 77, 5, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (199, CAST(0x0000A83A00FDA214 AS DateTime), 77, 6, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
GO
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (200, CAST(0x0000A83A00FDA214 AS DateTime), 77, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (201, CAST(0x0000A83A00FDA214 AS DateTime), 77, 8, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (202, CAST(0x0000A83A00FDA214 AS DateTime), 77, 9, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (203, CAST(0x0000A83A00FDA214 AS DateTime), 77, 10, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (204, CAST(0x0000A83A00FDA214 AS DateTime), 77, 11, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (205, CAST(0x0000A83A00FDA214 AS DateTime), 77, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (206, CAST(0x0000A83A00FDA214 AS DateTime), 77, 13, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (207, CAST(0x0000A83A00FDA214 AS DateTime), 77, 14, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (208, CAST(0x0000A83A00FDA214 AS DateTime), 77, 15, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (209, CAST(0x0000A83A00FDA214 AS DateTime), 77, 16, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (210, CAST(0x0000A83A00FDA214 AS DateTime), 77, 17, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (211, CAST(0x0000A83A00FDA214 AS DateTime), 77, 18, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (212, CAST(0x0000A82D00FDA214 AS DateTime), 100, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (213, CAST(0x0000A82D00FDA214 AS DateTime), 100, 13, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (214, CAST(0x0000A82D00FDA214 AS DateTime), 100, 14, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (215, CAST(0x0000A82D00FDA214 AS DateTime), 100, 15, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 3, CAST(1500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (216, CAST(0x0000A82D00FDA214 AS DateTime), 100, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (217, CAST(0x0000A82D00FDA214 AS DateTime), 100, 17, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (218, CAST(0x0000A82D00FDA214 AS DateTime), 100, 18, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (219, CAST(0x0000A82D00FDA214 AS DateTime), 100, 19, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 7, CAST(2275.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (220, CAST(0x0000A82D00FDA214 AS DateTime), 100, 20, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (221, CAST(0x0000A82D00FDA214 AS DateTime), 100, 21, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (222, CAST(0x0000A82D00FDA214 AS DateTime), 100, 22, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (223, CAST(0x0000A82D00FDA214 AS DateTime), 100, 23, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (224, CAST(0x0000A82D00FDA214 AS DateTime), 100, 24, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (225, CAST(0x0000A82D00FDA214 AS DateTime), 100, 25, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (226, CAST(0x0000A82D00FDA214 AS DateTime), 100, 26, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (227, CAST(0x0000A85700FDA214 AS DateTime), 111, 1, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (228, CAST(0x0000A85800FDA214 AS DateTime), 111, 2, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (229, CAST(0x0000A85900FDA214 AS DateTime), 111, 3, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 5, CAST(1625.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (230, CAST(0x0000A85A00FDA214 AS DateTime), 111, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (231, CAST(0x0000A85B00FDA214 AS DateTime), 111, 5, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (232, CAST(0x0000A85C00FDA214 AS DateTime), 111, 6, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (233, CAST(0x0000A85D00FDA214 AS DateTime), 111, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (234, CAST(0x0000A85E00FDA214 AS DateTime), 111, 8, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (235, CAST(0x0000A85F00FDA214 AS DateTime), 111, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (236, CAST(0x0000A86000FDA214 AS DateTime), 111, 30, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (237, CAST(0x0000A86100FDA214 AS DateTime), 111, 31, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (238, CAST(0x0000A86200FDA214 AS DateTime), 111, 32, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (239, CAST(0x0000A86300FDA214 AS DateTime), 111, 33, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (240, CAST(0x0000A86400FDA214 AS DateTime), 111, 34, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (241, CAST(0x0000A86500FDA214 AS DateTime), 111, 35, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (242, CAST(0x0000A82E00FDA214 AS DateTime), 32, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (243, CAST(0x0000A82E00FDA214 AS DateTime), 32, 17, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (244, CAST(0x0000A82E00FDA214 AS DateTime), 32, 18, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (245, CAST(0x0000A82E00FDA214 AS DateTime), 32, 19, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (246, CAST(0x0000A82E00FDA214 AS DateTime), 32, 20, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 7, CAST(1015.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (247, CAST(0x0000A82E00FDA214 AS DateTime), 32, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (248, CAST(0x0000A82E00FDA214 AS DateTime), 32, 30, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (249, CAST(0x0000A82E00FDA214 AS DateTime), 32, 40, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (250, CAST(0x0000A82E00FDA214 AS DateTime), 32, 41, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (251, CAST(0x0000A82E00FDA214 AS DateTime), 32, 42, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (252, CAST(0x0000A82E00FDA214 AS DateTime), 32, 43, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (253, CAST(0x0000A82E00FDA214 AS DateTime), 32, 44, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (254, CAST(0x0000A82E00FDA214 AS DateTime), 32, 45, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (255, CAST(0x0000A82E00FDA214 AS DateTime), 32, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (256, CAST(0x0000A82E00FDA214 AS DateTime), 32, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (257, CAST(0x0000A82E00FDA214 AS DateTime), 32, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (258, CAST(0x0000A82E00FDA214 AS DateTime), 32, 32, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 3, CAST(975.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (259, CAST(0x0000A82E00FDA214 AS DateTime), 45, 33, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (260, CAST(0x0000A82E00FDA214 AS DateTime), 45, 34, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 5, CAST(1350.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (261, CAST(0x0000A82E00FDA214 AS DateTime), 45, 35, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 6, CAST(3000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (262, CAST(0x0000A82E00FDA214 AS DateTime), 45, 36, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (263, CAST(0x0000A82E00FDA214 AS DateTime), 45, 37, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (264, CAST(0x0000A82E00FDA214 AS DateTime), 45, 38, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (265, CAST(0x0000A82E00FDA214 AS DateTime), 45, 39, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (266, CAST(0x0000A82E00FDA214 AS DateTime), 45, 5, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (267, CAST(0x0000A82E00FDA214 AS DateTime), 45, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (268, CAST(0x0000A82E00FDA214 AS DateTime), 45, 7, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (269, CAST(0x0000A82E00FDA214 AS DateTime), 45, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (270, CAST(0x0000A82E00FDA214 AS DateTime), 45, 29, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (271, CAST(0x0000A82E00FDA214 AS DateTime), 45, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 6, CAST(870.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (272, CAST(0x0000A82E00FDA214 AS DateTime), 45, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (273, CAST(0x0000A82E00FDA214 AS DateTime), 45, 47, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (274, CAST(0x0000A82E00FDA214 AS DateTime), 45, 48, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (275, CAST(0x0000A82E00FDA214 AS DateTime), 45, 49, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (276, CAST(0x0000A82E00FDA214 AS DateTime), 45, 50, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (277, CAST(0x0000A83000FDA214 AS DateTime), 1, 1, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), N'Edit', 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (278, CAST(0x0000A83000FDA214 AS DateTime), 1, 2, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (279, CAST(0x0000A83000FDA214 AS DateTime), 1, 3, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (280, CAST(0x0000A83000FDA214 AS DateTime), 1, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (281, CAST(0x0000A83000FDA214 AS DateTime), 1, 5, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 2, CAST(290.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (282, CAST(0x0000A83000FDA214 AS DateTime), 1, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (283, CAST(0x0000A83000FDA214 AS DateTime), 1, 7, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 2, CAST(650.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (284, CAST(0x0000A83000FDA214 AS DateTime), 1, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (285, CAST(0x0000A83000FDA214 AS DateTime), 1, 9, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (286, CAST(0x0000A83000FDA214 AS DateTime), 1, 10, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (287, CAST(0x0000A83000FDA214 AS DateTime), 1, 11, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (288, CAST(0x0000A83000FDA214 AS DateTime), 1, 12, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (289, CAST(0x0000A83000FDA214 AS DateTime), 1, 13, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (290, CAST(0x0000A82C00FDA214 AS DateTime), 1, 5, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (291, CAST(0x0000A82C00FDA214 AS DateTime), 1, 6, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (292, CAST(0x0000A82C00FDA214 AS DateTime), 1, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (293, CAST(0x0000A82C00FDA214 AS DateTime), 1, 8, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (294, CAST(0x0000A82C00FDA214 AS DateTime), 1, 9, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (295, CAST(0x0000A82C00FDA214 AS DateTime), 1, 10, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (296, CAST(0x0000A82C00FDA214 AS DateTime), 1, 11, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (297, CAST(0x0000A82C00FDA214 AS DateTime), 1, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (298, CAST(0x0000A82C00FDA214 AS DateTime), 1, 13, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (299, CAST(0x0000A82C00FDA214 AS DateTime), 1, 14, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
GO
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (300, CAST(0x0000A82C00FDA214 AS DateTime), 1, 15, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (301, CAST(0x0000A82C00FDA214 AS DateTime), 1, 16, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (302, CAST(0x0000A82C00FDA214 AS DateTime), 1, 17, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (303, CAST(0x0000A82C00FDA214 AS DateTime), 1, 18, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (304, CAST(0x0000A83700FDA214 AS DateTime), 3, 12, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (305, CAST(0x0000A83700FDA214 AS DateTime), 3, 13, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (306, CAST(0x0000A83700FDA214 AS DateTime), 3, 14, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (307, CAST(0x0000A83700FDA214 AS DateTime), 3, 15, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 3, CAST(1500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (308, CAST(0x0000A83700FDA214 AS DateTime), 3, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (309, CAST(0x0000A83700FDA214 AS DateTime), 3, 17, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (310, CAST(0x0000A83700FDA214 AS DateTime), 3, 18, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (311, CAST(0x0000A83700FDA214 AS DateTime), 3, 19, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 7, CAST(2275.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (312, CAST(0x0000A83700FDA214 AS DateTime), 3, 20, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (313, CAST(0x0000A83700FDA214 AS DateTime), 3, 21, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (314, CAST(0x0000A83700FDA214 AS DateTime), 3, 22, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (315, CAST(0x0000A83700FDA214 AS DateTime), 3, 23, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (316, CAST(0x0000A83700FDA214 AS DateTime), 3, 24, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (317, CAST(0x0000A83700FDA214 AS DateTime), 3, 25, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (318, CAST(0x0000A83700FDA214 AS DateTime), 3, 26, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (319, CAST(0x0000A84300FDA214 AS DateTime), 4, 1, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (320, CAST(0x0000A84300FDA214 AS DateTime), 4, 2, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (321, CAST(0x0000A84300FDA214 AS DateTime), 4, 3, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 5, CAST(1625.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (322, CAST(0x0000A84300FDA214 AS DateTime), 4, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (323, CAST(0x0000A84300FDA214 AS DateTime), 4, 5, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (324, CAST(0x0000A84300FDA214 AS DateTime), 4, 6, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (325, CAST(0x0000A84300FDA214 AS DateTime), 4, 7, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (326, CAST(0x0000A84300FDA214 AS DateTime), 4, 8, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (327, CAST(0x0000A84300FDA214 AS DateTime), 4, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (328, CAST(0x0000A84300FDA214 AS DateTime), 4, 30, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (329, CAST(0x0000A84300FDA214 AS DateTime), 4, 31, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (330, CAST(0x0000A84300FDA214 AS DateTime), 4, 32, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (331, CAST(0x0000A84300FDA214 AS DateTime), 4, 33, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (332, CAST(0x0000A84300FDA214 AS DateTime), 4, 34, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (333, CAST(0x0000A84300FDA214 AS DateTime), 4, 35, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (334, CAST(0x0000A84600FDA214 AS DateTime), 3, 16, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (335, CAST(0x0000A84600FDA214 AS DateTime), 3, 17, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (336, CAST(0x0000A84600FDA214 AS DateTime), 3, 18, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (337, CAST(0x0000A84600FDA214 AS DateTime), 3, 19, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (338, CAST(0x0000A84600FDA214 AS DateTime), 3, 20, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 7, CAST(1015.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (339, CAST(0x0000A84600FDA214 AS DateTime), 3, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (340, CAST(0x0000A84600FDA214 AS DateTime), 3, 30, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (341, CAST(0x0000A84600FDA214 AS DateTime), 3, 40, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (342, CAST(0x0000A84600FDA214 AS DateTime), 3, 41, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (343, CAST(0x0000A84600FDA214 AS DateTime), 3, 42, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (344, CAST(0x0000A84600FDA214 AS DateTime), 3, 43, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 5, CAST(850.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (345, CAST(0x0000A84600FDA214 AS DateTime), 3, 44, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (346, CAST(0x0000A84600FDA214 AS DateTime), 3, 45, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (347, CAST(0x0000A84600FDA214 AS DateTime), 3, 29, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (348, CAST(0x0000A84600FDA214 AS DateTime), 3, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 4, CAST(580.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (349, CAST(0x0000A84600FDA214 AS DateTime), 3, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (350, CAST(0x0000A84600FDA214 AS DateTime), 3, 32, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 3, CAST(975.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (351, CAST(0x0000A84500FDA214 AS DateTime), 5, 33, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (352, CAST(0x0000A84500FDA214 AS DateTime), 5, 34, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 5, CAST(1350.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (353, CAST(0x0000A84500FDA214 AS DateTime), 5, 35, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 6, CAST(3000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (354, CAST(0x0000A84500FDA214 AS DateTime), 5, 36, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (355, CAST(0x0000A84500FDA214 AS DateTime), 5, 37, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 1, CAST(145.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (356, CAST(0x0000A84500FDA214 AS DateTime), 5, 38, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (357, CAST(0x0000A84500FDA214 AS DateTime), 5, 39, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (358, CAST(0x0000A84500FDA214 AS DateTime), 5, 5, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (359, CAST(0x0000A84500FDA214 AS DateTime), 5, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (360, CAST(0x0000A84500FDA214 AS DateTime), 5, 7, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 3, CAST(435.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (361, CAST(0x0000A84500FDA214 AS DateTime), 5, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 4, CAST(680.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (362, CAST(0x0000A84500FDA214 AS DateTime), 5, 29, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 5, CAST(725.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (363, CAST(0x0000A84500FDA214 AS DateTime), 5, 30, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 6, CAST(870.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (364, CAST(0x0000A84500FDA214 AS DateTime), 5, 31, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 7, CAST(1190.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (365, CAST(0x0000A84500FDA214 AS DateTime), 5, 47, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 1, CAST(325.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (366, CAST(0x0000A84500FDA214 AS DateTime), 5, 48, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (367, CAST(0x0000A84500FDA214 AS DateTime), 5, 49, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 1, CAST(270.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (368, CAST(0x0000A84500FDA214 AS DateTime), 5, 50, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (369, CAST(0x0000A82300FDA214 AS DateTime), 14, 1, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), N'Edit', 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (370, CAST(0x0000A82300FDA214 AS DateTime), 14, 2, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 2, CAST(540.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (371, CAST(0x0000A82300FDA214 AS DateTime), 14, 3, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (372, CAST(0x0000A82300FDA214 AS DateTime), 14, 4, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 1, CAST(170.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (373, CAST(0x0000A82300FDA214 AS DateTime), 14, 5, CAST(130.00 AS Decimal(14, 2)), CAST(145.00 AS Decimal(14, 2)), 2, CAST(290.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (374, CAST(0x0000A82300FDA214 AS DateTime), 14, 6, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 2, CAST(340.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (375, CAST(0x0000A82300FDA214 AS DateTime), 14, 7, CAST(300.00 AS Decimal(14, 2)), CAST(325.00 AS Decimal(14, 2)), 2, CAST(650.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (376, CAST(0x0000A82300FDA214 AS DateTime), 14, 8, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 3, CAST(510.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (377, CAST(0x0000A82300FDA214 AS DateTime), 14, 9, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 4, CAST(1080.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (378, CAST(0x0000A82300FDA214 AS DateTime), 14, 10, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 5, CAST(2500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (379, CAST(0x0000A82300FDA214 AS DateTime), 14, 11, CAST(150.00 AS Decimal(14, 2)), CAST(170.00 AS Decimal(14, 2)), 6, CAST(1020.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (380, CAST(0x0000A82300FDA214 AS DateTime), 14, 12, CAST(250.00 AS Decimal(14, 2)), CAST(270.00 AS Decimal(14, 2)), 7, CAST(1890.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (381, CAST(0x0000A82300FDA214 AS DateTime), 14, 13, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'วุ้นเส่น1', N'วุ้นเส่น1', 1, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'วุ้นเส่น2', N'วุ้นเส่น2', 1, CAST(600.00 AS Decimal(14, 2)), 5, 40, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'วุ้นเส่น3', N'วุ้นเส่น3', 1, CAST(1200.00 AS Decimal(14, 2)), 10, 30, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (4, N'วุ้นเส่น4', N'วุ้นเส่น4', 1, CAST(89.00 AS Decimal(14, 2)), 5, 31, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (5, N'วุ้นเส่น5', N'วุ้นเส่น5', 1, CAST(89.00 AS Decimal(14, 2)), 5, 32, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (6, N'เส้นเล็ก1', N'เส้นเล็ก1', 1, CAST(120.00 AS Decimal(14, 2)), 1, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (7, N'เส้นเล็ก2', N'เส้นเล็ก2', 1, CAST(600.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (8, N'เส้นเล็ก3', N'เส้นเล็ก3', 1, CAST(1200.00 AS Decimal(14, 2)), 10, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (9, N'เส้นเล็ก4', N'เส้นเล็ก4', 1, CAST(55.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (10, N'เส้นเล็ก5', N'เส้นเล็ก5', 1, CAST(55.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (11, N'เส้นเล็ก6', N'เส้นเล็ก6', 1, CAST(55.00 AS Decimal(14, 2)), 5, 79, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (12, N'เส้นเล็ก7', N'เส้นเล็ก7', 1, CAST(55.00 AS Decimal(14, 2)), 5, 80, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (13, N'เส้นเล็ก8', N'เส้นเล็ก8', 1, CAST(55.00 AS Decimal(14, 2)), 5, 81, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (14, N'เส้นใหญ่1', N'เส้นใหญ่1', 1, CAST(120.00 AS Decimal(14, 2)), 1, 82, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (15, N'เส้นใหญ่2', N'เส้นใหญ่2', 1, CAST(600.00 AS Decimal(14, 2)), 5, 83, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (16, N'เส้นใหญ่3', N'เส้นใหญ่3', 1, CAST(1200.00 AS Decimal(14, 2)), 10, 84, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (17, N'เส้นใหญ่4', N'เส้นใหญ่4', 1, CAST(75.00 AS Decimal(14, 2)), 5, 85, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (18, N'เส้นใหญ่5', N'เส้นใหญ่5', 1, CAST(75.00 AS Decimal(14, 2)), 5, 86, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (19, N'เส้นหมี่1', N'เส้นหมี่1', 1, CAST(120.00 AS Decimal(14, 2)), 1, 87, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (20, N'เส้นหมี่2', N'เส้นหมี่2', 1, CAST(600.00 AS Decimal(14, 2)), 5, 88, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (21, N'เส้นหมี่3', N'เส้นหมี่3', 1, CAST(1200.00 AS Decimal(14, 2)), 10, 89, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (22, N'เส้นหมี่4', N'เส้นหมี่4', 1, CAST(85.00 AS Decimal(14, 2)), 5, 90, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (23, N'เส้นหมี่5', N'เส้นหมี่5', 1, CAST(85.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (24, N'เส้นก๋วยจั๊บ1', N'เส้นก๋วยจั๊บ1', 1, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (25, N'เส้นก๋วยจั๊บ2', N'เส้นก๋วยจั๊บ2', 1, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (26, N'เส้นก๋วยจั๊บ3', N'เส้นก๋วยจั๊บ3', 1, CAST(1200.00 AS Decimal(14, 2)), 10, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (27, N'เส้นก๋วยจั๊บ4', N'เส้นก๋วยจั๊บ4', 1, CAST(60.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (28, N'เส้นก๋วยจั๊บ5', N'เส้นก๋วยจั๊บ5', 1, CAST(60.00 AS Decimal(14, 2)), 5, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (29, N'เส้นก๋วยจั๊บ6', N'เส้นก๋วยจั๊บ6', 1, CAST(60.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (30, N'ถั่วงอก1', N'ถั่วงอก1', 2, CAST(120.00 AS Decimal(14, 2)), 1, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (31, N'ถั่วงอก2', N'ถั่วงอก2', 2, CAST(600.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (32, N'ถั่วงอก3', N'ถั่วงอก3', 2, CAST(1200.00 AS Decimal(14, 2)), 10, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (33, N'ถั่วงอก4', N'ถั่วงอก4', 2, CAST(75.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (34, N'ถั่วงอก5', N'ถั่วงอก5', 2, CAST(75.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (35, N'ถั่วงอก6', N'ถั่วงอก6', 2, CAST(75.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (36, N'เต้าหู้1', N'เต้าหู้1', 3, CAST(120.00 AS Decimal(14, 2)), 1, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (37, N'เต้าหู้2', N'เต้าหู้2', 3, CAST(600.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (38, N'เต้าหู้3', N'เต้าหู้3', 3, CAST(1200.00 AS Decimal(14, 2)), 10, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (39, N'เต้าหู้4', N'เต้าหู้4', 3, CAST(85.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (40, N'เต้าหู้5', N'เต้าหู้5', 3, CAST(85.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (41, N'เต้าหู้6', N'เต้าหู้6', 3, CAST(85.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (42, N'เต้าหู้7', N'เต้าหู้7', 3, CAST(85.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (43, N'ต้นหอม1', N'ต้นหอม1', 2, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (44, N'ต้นหอม2', N'ต้นหอม2', 2, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (45, N'ต้นหอม3', N'ต้นหอม3', 2, CAST(1200.00 AS Decimal(14, 2)), 10, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (46, N'ผักชี1', N'ผักชี1', 2, CAST(120.00 AS Decimal(14, 2)), 1, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (47, N'ผักชี2', N'ผักชี2', 2, CAST(600.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (48, N'ผักชี3', N'ผักชี3', 2, CAST(1200.00 AS Decimal(14, 2)), 10, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (49, N'ผักชี4', N'ผักชี4', 2, CAST(120.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (50, N'ผักชี5', N'ผักชี5', 2, CAST(120.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (51, N'ผักชี6', N'ผักชี6', 2, CAST(120.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (52, N'หมูสับ1', N'หมูสับ1', 4, CAST(140.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (53, N'หมูสับ2', N'หมูสับ2', 4, CAST(130.00 AS Decimal(14, 2)), 5, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (54, N'หมูเด้ง1', N'หมูเด้ง1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (55, N'หมูเด้ง2', N'หมูเด้ง2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (56, N'หมูเด้ง3', N'หมูเด้ง3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (57, N'หมูเด้ง4', N'หมูเด้ง4', 4, CAST(155.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (58, N'ลูกชิ้นหมู1', N'ลูกชิ้นหมู1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (59, N'ลูกชิ้นหมู2', N'ลูกชิ้นหมู2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (60, N'ลูกชิ้นหมู3', N'ลูกชิ้นหมู3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (61, N'ลูกชิ้นหมู4', N'ลูกชิ้นหมู4', 4, CAST(185.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (62, N'ลูกชิ้นกุ้ง1', N'ลูกชิ้นกุ้ง1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (63, N'ลูกชิ้นกุ้ง2', N'ลูกชิ้นกุ้ง2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (64, N'ลูกชิ้นกุ้ง3', N'ลูกชิ้นกุ้ง3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (65, N'ลูกชิ้นกุ้ง4', N'ลูกชิ้นกุ้ง4', 4, CAST(175.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (66, N'ลูกชิ้นกุ้ง5', N'ลูกชิ้นกุ้ง5', 4, CAST(175.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (67, N'ลูกชิ้นกุ้ง6', N'ลูกชิ้นกุ้ง6', 4, CAST(175.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (68, N'ลูกชิ้นปลา1', N'ลูกชิ้นปลา1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (69, N'ลูกชิ้นปลา2', N'ลูกชิ้นปลา2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (70, N'ลูกชิ้นปลา3', N'ลูกชิ้นปลา3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (71, N'ลูกชิ้นปลา4', N'ลูกชิ้นปลา4', 4, CAST(130.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (72, N'ลูกชิ้นเนื้อ1', N'ลูกชิ้นเนื้อ1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (73, N'ลูกชิ้นเนื้อ2', N'ลูกชิ้นเนื้อ2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (74, N'ลูกชิ้นเนื้อ3', N'ลูกชิ้นเนื้อ3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (75, N'ลูกชิ้นเนื้อ4', N'ลูกชิ้นเนื้อ4', 4, CAST(140.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (76, N'ฮื่อก้วย1', N'ฮื่อก้วย1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (77, N'ฮื่อก้วย2', N'ฮื่อก้วย2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (78, N'ฮื่อก้วย3', N'ฮื่อก้วย3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (79, N'ฮื่อก้วย4', N'ฮื่อก้วย4', 4, CAST(170.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (80, N'ฮื่อก้วย5', N'ฮื่อก้วย5', 4, CAST(170.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (81, N'เต้าหู้หลอด1', N'เต้าหู้หลอด1', 3, CAST(120.00 AS Decimal(14, 2)), 1, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (82, N'เต้าหู้หลอด2', N'เต้าหู้หลอด2', 3, CAST(600.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (83, N'เต้าหู้หลอด3', N'เต้าหู้หลอด3', 3, CAST(1200.00 AS Decimal(14, 2)), 10, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (84, N'เต้าหู้หลอด4', N'เต้าหู้หลอด4', 3, CAST(80.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (85, N'เต้าหู้หลอด5', N'เต้าหู้หลอด5', 3, CAST(80.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (86, N'หมูยอ1', N'หมูยอ1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (87, N'หมูยอ2', N'หมูยอ2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (88, N'หมูยอ3', N'หมูยอ3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (89, N'หมูยอ4', N'หมูยอ4', 4, CAST(250.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (90, N'หมูยอ5', N'หมูยอ5', 4, CAST(250.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (91, N'เลือดหมู1', N'เลือดหมู1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (92, N'เลือดหมู2', N'เลือดหมู2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (93, N'เลือดหมู3', N'เลือดหมู3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (94, N'เลือดหมู4', N'เลือดหมู4', 4, CAST(110.00 AS Decimal(14, 2)), 5, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (95, N'เลือดหมู5', N'เลือดหมู5', 4, CAST(110.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (96, N'เลือดหมู6', N'เลือดหมู6', 4, CAST(110.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (97, N'กระดูกหมู1', N'กระดูกหมู1', 4, CAST(100.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (98, N'กระดูกหมู2', N'กระดูกหมู2', 4, CAST(100.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (99, N'กระดูกหมู3', N'กระดูกหมู3', 4, CAST(100.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (100, N'กุนเชียง1', N'กุนเชียง1', 4, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (101, N'กุนเชียง2', N'กุนเชียง2', 4, CAST(600.00 AS Decimal(14, 2)), 5, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (102, N'กุนเชียง3', N'กุนเชียง3', 4, CAST(1200.00 AS Decimal(14, 2)), 10, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (103, N'กุนเชียง4', N'กุนเชียง4', 4, CAST(700.00 AS Decimal(14, 2)), 5, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (104, N'กุนเชียง5', N'กุนเชียง5', 4, CAST(750.00 AS Decimal(14, 2)), 5, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (105, N'กุนเชียง6', N'กุนเชียง6', 4, CAST(800.00 AS Decimal(14, 2)), 5, 78, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (106, N'กระหล่ำปลี1', N'กระหล่ำปลี1', 2, CAST(120.00 AS Decimal(14, 2)), 1, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (107, N'กระหล่ำปลี2', N'กระหล่ำปลี2', 2, CAST(600.00 AS Decimal(14, 2)), 5, 150, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (108, N'กระหล่ำปลี3', N'กระหล่ำปลี3', 2, CAST(1200.00 AS Decimal(14, 2)), 10, 33, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (109, N'หัวไชเท้า1', N'หัวไชเท้า1', 2, CAST(120.00 AS Decimal(14, 2)), 1, 75, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (110, N'หัวไชเท้า2', N'หัวไชเท้า2', 2, CAST(600.00 AS Decimal(14, 2)), 5, 76, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (111, N'หัวไชเท้า3', N'หัวไชเท้า3', 2, CAST(1200.00 AS Decimal(14, 2)), 10, 77, NULL, 1, CAST(0x0000A84D00000000 AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Product] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "cf"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 242
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwCustomerDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwCustomerDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[36] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Order"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 8
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3120
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "o"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwOrderDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwOrderDetail'
GO
