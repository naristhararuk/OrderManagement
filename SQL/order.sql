USE [Order]
GO
/****** Object:  UserDefinedFunction [dbo].[OrderNum]    Script Date: 13/08/2018 11:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[OrderNum]
(
	-- Add the parameters for the function here
	@date DATE,@customerid INT
)
RETURNS VARCHAR(20)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result VARCHAR(20)

	-- Add the T-SQL statements to compute the return value here
DECLARE @countorder TABLE
(
  row int, year int,month int, day int,customerid int
)

INSERT INTO @countorder (row, year,month, day,customerid)
SELECT 
  ROW_NUMBER() OVER(ORDER BY [CustomerID] ASC) AS Row
  ,YEAR([OrderDate]) year,MONTH([OrderDate]) month ,DAY([OrderDate]) day, [CustomerID]
FROM [Order].[dbo].[Order]
WHERE [CustomerID] = @customerid AND YEAR([OrderDate]) = YEAR(@date) AND MONTH([OrderDate]) = MONTH(@date)
  GROUP BY YEAR([OrderDate]),MONTH([OrderDate]),DAY([OrderDate]),[CustomerID]
ORDER BY [CustomerID] ASC
 --SELECT @result = RIGHT('00'+CAST(row AS VARCHAR(2)),2) 
 SELECT  @result = CASE WHEN CONVERT(VARCHAR(6),row ) IS NOT NULL 
	THEN CONVERT(VARCHAR,@customerid)+CONVERT(VARCHAR(6), @date, 112)+  CONVERT(VARCHAR(6),row )
	ELSE CONVERT(VARCHAR,@customerid)+CONVERT(VARCHAR(6), @date, 112)+ '1' END
 FROM @countorder
 WHERE year = YEAR(@date) AND month = MONTH(@date) AND day = DAY(@date)  

	-- Return the result of the function
	RETURN @result

END

GO
/****** Object:  Table [dbo].[Config]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 13/08/2018 11:44:10 ******/
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
	[UnitCarry] [int] NULL,
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
/****** Object:  View [dbo].[vwCustomerDetail]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  View [dbo].[vwOrder]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  View [dbo].[vwOrderDetail]    Script Date: 13/08/2018 11:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwOrderDetail]
AS
SELECT        o.OrderID, o.OrderDate, o.CustomerID, o.ProductID, o.ProductPrice, o.OrderPrice, o.OrderAmount, o.OrderTotal, o.Description, o.OrderStatus, DATENAME(DW, 
                         o.OrderDate) AS OrderDay, p.ProductName, p.ProductAbbr, p.Category, p.Price, p.UnitCarry, p.Unit, p.Amount, c.CitizenID, c.CustomerName, c.CustomerAbbr, c.Zone, 
                         c.Address1, c.Address2, c.Phone, c.ShowPrice
FROM            dbo.[Order] AS o INNER JOIN
                         dbo.Product AS p ON p.ProductID = o.ProductID AND p.Status = 1 INNER JOIN
                         dbo.Customer AS c ON c.CustomerID = o.CustomerID AND c.Status = 1
WHERE        (o.OrderStatus = 1)


GO
SET IDENTITY_INSERT [dbo].[Config] ON 

INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (1, N'Company', N'string', N'CompanyTaxID', N'', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (2, N'Company', N'string', N'CompanyAddress', N'', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (3, N'Company', N'string', N'CompanyLogo', N'', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (4, N'CustomerZone', N'string', N'สายที่1(น้า)', N'1', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (5, N'CustomerZone', N'string', N'สายที่2(บอล)', N'2', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (6, N'CustomerZone', N'string', N'สายที่3(โจ)', N'3', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (7, N'CustomerZone', N'string', N'สายที่4(ขนมจีน)', N'4', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (8, N'CustomerZone', N'string', N'สายที่5(ลุงแดง)', N'5', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (9, N'ProductCategory', N'string', N'กลุ่ม 1 (เส้น)', N'1', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (10, N'ProductCategory', N'string', N'กลุ่ม 2 (เต้าหู้)', N'2', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (11, N'ProductCategory', N'string', N'กลุ่ม 3 (ผัก)', N'3', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (12, N'ProductCategory', N'string', N'กลุ่ม 4 (เนื้อสัตว์)', N'4', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (13, N'ReportName', N'string', N'ใบเสร็จรับเงิน', N'1', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (14, N'ReportName', N'string', N'ใบส่งสินค้า', N'2', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (15, N'ReportName', N'string', N'ใบส่งของ', N'3', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (16, N'ReportName', N'string', N'ใบขึ้นรถ', N'4', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (17, N'Vat', N'int', N'Vat', N'7', CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (18, N'ProductCarry', N'float', N'1', N'1', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (19, N'ProductCarry', N'float', N'0.5', N'2', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (20, N'ProductCarry', N'float', N'5', N'3', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (21, N'ProductCarry', N'float', N'10', N'4', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (22, N'ProductCarry', N'float', N'12', N'5', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (23, N'ProductCarry', N'float', N'20', N'6', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (24, N'ProductCarry', N'float', N'25', N'7', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (25, N'ProductCarry', N'float', N'30', N'8', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (26, N'ProductCarry', N'float', N'40', N'9', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (27, N'ProductCarry', N'float', N'50', N'10', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (28, N'ProductCarry', N'float', N'100', N'11', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (29, N'ProductUnit', N'string', N'กก./1ถุง', N'1', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (30, N'ProductUnit', N'string', N'หลอด/1ถุง', N'2', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (31, N'ProductUnit', N'string', N'แท่ง/1ถุง', N'3', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (32, N'ProductUnit', N'string', N'เส้น/1ถุง', N'4', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (33, N'ProductUnit', N'string', N'แผ่น/1ถุง', N'5', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (34, N'ProductUnit', N'string', N'แพค/1ถุง', N'6', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (35, N'ProductUnit', N'string', N'อัน/1ถุง', N'7', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (36, N'ProductUnit', N'string', N'พวง/1ถุง', N'8', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (37, N'ProductUnit', N'string', N'ชิ้น/1ถุง', N'9', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Config] ([run], [Module], [Type], [Name], [Value], [UpdateDate], [UpdateBy]) VALUES (38, N'ProductUnit', N'string', N'ห่อ/1ถุง', N'10', CAST(N'2018-06-02 00:00:00.000' AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Config] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (1, NULL, N'คุณหมวย', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (2, NULL, N'คุณมณฑา', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 0, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (3, NULL, N'คุณเพ็ญ', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (4, NULL, N'คุณจู', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (5, NULL, N'คุณน้องเมย์', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (6, NULL, N'คุณเก้า ', NULL, 1, N'น้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (7, NULL, N'คุณตี๋ใหม่', NULL, 1, N'น้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (8, NULL, N'คุณอุเทน ', NULL, 1, N'น้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (9, NULL, N'คุณอ่อน', NULL, 1, N'น้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (10, NULL, N'คุณหมู(กอกน้อย)', NULL, 1, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (11, NULL, N'คุณพี่หน่อย', NULL, 1, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (12, NULL, N'คุณปิง', NULL, 1, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (13, NULL, N'คุณโจ', NULL, 1, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (14, NULL, N'คุณวิเชียร', NULL, 1, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (15, NULL, N'คุณตี๋(พรานนก)', NULL, 1, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (16, NULL, N'คุณตุ้ม', NULL, 1, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (17, NULL, N'คุณมิตร', NULL, 1, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (18, NULL, N'คุณนา', NULL, 1, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (19, NULL, N'คุณเล็ก(วงเวียนใหญ่)', NULL, 1, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (20, NULL, N'คุณย้ง', NULL, 1, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (21, NULL, N'คุณดาว', NULL, 1, N'บางประกอก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (22, NULL, N'คุณเอง', NULL, 1, N'บางประกอก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (23, NULL, N'คุณเล็ก(ทุ่งครุ)', NULL, 1, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (24, NULL, N'คุณโกจ๋อง', NULL, 1, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (25, NULL, N'คุณอำนาจ', NULL, 1, N'สุขสวัสดิ์38', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (26, NULL, N'คุณอำนาจ(ซอย26)', NULL, 1, N'สุขสวัสดิ์26', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (27, NULL, N'เพื่อนบ้าน', NULL, 1, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (28, NULL, N'คุณน้ำฝน(ทุ่งครุ)', NULL, 1, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (29, NULL, N'คุณปุ่น', NULL, 1, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (30, NULL, N'ร้านสมบูรณ์ ก้าวหน้า', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (31, NULL, N'คุณลิ้ม', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (32, NULL, N'คุณอ๊าท', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (33, NULL, N'คุณต่าย', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (34, NULL, N'คุณมุ่ย', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (35, NULL, N'คุณสุณีย์', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (36, NULL, N'คุณสิริกาญจน์', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (37, NULL, N'คุณน้อย', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (38, NULL, N'คุณมอส', NULL, 1, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (39, NULL, N'คุณอามีนะ', NULL, 1, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (40, NULL, N'คุณสถาวร', NULL, 1, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (41, NULL, N'คุณเก๋(2)', NULL, 1, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (42, NULL, N'คุณเพ็ญ (นครหลวง)', NULL, 1, N'นครหลวง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (43, NULL, N'คุณพิมพ์', NULL, 1, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (44, NULL, N'คุณโอ๋เอ๋', NULL, 1, N'ตลาดโอเอ๋', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (45, NULL, N'คุณโธ', NULL, 1, N'นครปฐม', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (46, NULL, N'คุณจอยหัวหิน', NULL, 1, N'หัวหิน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (47, NULL, N'หัวหิน', NULL, 1, N'หัวหิน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (48, NULL, N'หัวหิน 2', NULL, 1, N'หัวหิน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (49, NULL, N'คุณนก(บางบอน)', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (50, NULL, N'คุณนุช(โชคชัย)', NULL, 1, N'ลาดพร้าว', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (51, NULL, N'คุณสมชัย', NULL, 1, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (52, NULL, N'คุณเพ็ญ(กอกน้อย)', NULL, 1, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (53, NULL, N'คุณประเสริฐ', NULL, 1, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (54, NULL, N'เฮียเหลียง', NULL, 1, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (55, NULL, N'คุณเล็ก-ศาลา2', NULL, 1, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (56, NULL, N'คุณสมเกียรติ', NULL, 1, N'น้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (57, NULL, N'คุณเตียง', NULL, 1, N'คลองบัว', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (58, NULL, N'คุณตือ', NULL, 1, N'กรุงธน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (59, NULL, N'คุณนัส-ศาลา', NULL, 2, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (60, NULL, N'คุณเล็ก-ศาลา1', NULL, 2, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (61, NULL, N'คุณเซียง', NULL, 2, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (62, NULL, N'คุณเก๋ ', NULL, 2, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (63, NULL, N'คุณแอ๊ด', NULL, 2, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (64, NULL, N'คุณทองดี', NULL, 2, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (65, NULL, N'คุณนัส(ใหม่)', NULL, 2, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (66, NULL, N'คุณเดือน', NULL, 2, N'ดาวคะนอง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (67, NULL, N'คุณนุช', NULL, 2, N'ดาวคะนอง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (68, NULL, N'คุณกุ้ง', NULL, 2, N'เทียนทะเล', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (69, NULL, N'คุณกา', NULL, 2, N'เทียนทะเล', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (70, NULL, N'คุณปัญญาการค้า', NULL, 2, N'เคหะ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (71, NULL, N'คุณนวลจันทร์', NULL, 2, N'เคหะ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (72, NULL, N'เจ๊หมวย', NULL, 2, N'บางกระดี่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (73, NULL, N'คุณแจ่ม', NULL, 2, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (74, NULL, N'คุณน้ำ ', NULL, 2, N'บางขุนศรี', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (75, NULL, N'คุณเฮียง', NULL, 2, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (76, NULL, N'คุณใจ', NULL, 2, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (77, NULL, N'คุณสาวิตรี', NULL, 2, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (78, NULL, N'คุณสมชาย', NULL, 2, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (79, NULL, N'คุณเล็กอู๋', NULL, 2, N'ศาลาน้ำเย็น', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (80, NULL, N'คุณนวล', NULL, 2, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (81, NULL, N'คุณสม', NULL, 2, N'เทียนทะเล', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (82, NULL, N'คุณกบ', NULL, 2, N'บางขุนศรี', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (83, NULL, N'เฮียเหลียง', NULL, 3, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (84, NULL, N'อ๊าท', NULL, 3, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (85, NULL, N'มุ่ย', NULL, 3, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (86, NULL, N'สุณีย์', NULL, 3, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (87, NULL, N'สิริกาญจน์', NULL, 3, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (88, NULL, N'เก๋(2)', NULL, 3, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (89, NULL, N'คุณเพ็ญ (นครหลวง)', NULL, 4, N'นครหลวง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (90, NULL, N'คุณบางขุนศรี', NULL, 4, N'บางขุนศรี', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (91, NULL, N'คุณปัญญาการค้า', NULL, 4, N'เคหะ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (92, NULL, N'คุณน้ำฝน ( ทุ่งครุ)', NULL, 4, N'ทุ่งครุ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (93, NULL, N'คุณไล', NULL, 4, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (94, NULL, N'คุณเซียง', NULL, 4, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (95, NULL, N'คุณนวลจันทร์', NULL, 4, N'ตลาดกลาง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (96, NULL, N'คุณโอ๋เอ๋', NULL, 4, N'ตลาดโอ๋เอ๋', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (97, NULL, N'คุณเล็ก (ทุ่งครุ)', NULL, 4, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (98, NULL, N'เจ๊หมวย', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (99, NULL, N'เจ๊หมวย', NULL, 4, N'บางกระดี่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
GO
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (100, NULL, N'คุณโน๊ต', NULL, 4, N'ฟู๊ดวิลล่า', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (101, NULL, N'คุณเจ๊เล็ก-ศาลา', NULL, 4, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (102, NULL, N'คุณโจ', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (103, NULL, N'คุณนุช-ดาวคะนอง', NULL, 4, N'ดาวคะนอง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (104, NULL, N'คุณเปิ้ล', NULL, 4, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (105, NULL, N'คุณเตียง', NULL, 4, N'คลองบัว', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (106, NULL, N'คุณเก้า', NULL, 4, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (107, NULL, N'คุณมอส', NULL, 4, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (108, NULL, N'คุณเดือน', NULL, 4, N'ดาวคะนอง', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (109, NULL, N'คุณทองดี', NULL, 4, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (110, NULL, N'คุณหน่อย', NULL, 4, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (111, NULL, N'บ้านตึก', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (112, NULL, N'คุณ อู๋', NULL, 4, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (113, NULL, N'คุณอามีนะ', NULL, 4, N'ทุ่งครุ', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (114, NULL, N'คุณปุ้ย', NULL, 4, N'บางกระดี่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (115, NULL, N'คุณเพ็ญ', NULL, 4, N'-', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (116, NULL, N'คุณหยก', NULL, 4, N'ลาดพร้าว', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (117, NULL, N'คุณตูน', NULL, 4, N'วงเวียนใหญ่', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (118, NULL, N'คุณน้ำมนต์', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (119, NULL, N'คุณสาวิตรี', NULL, 4, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (120, NULL, N'คุณก้อย', NULL, 4, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (121, NULL, N'คุณใจ', NULL, 4, N'สวนผัก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (122, NULL, N'คุณลิ้ม', NULL, 4, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (123, NULL, N'คุณสิริกาญจน์', NULL, 4, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (124, NULL, N'คุณเพ็ญ (พระราม 2)', NULL, 4, N'พระราม2', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (125, NULL, N'พี่แอ๊ด', NULL, 4, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (126, NULL, N'คุณต่าย', NULL, 4, N'บางบอน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (127, NULL, N'คุณพิม', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (128, NULL, N'คุณศิริพร', NULL, 4, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (129, NULL, N'เจ๊นัส-ศาลา', NULL, 5, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (130, NULL, N'คุณโจ', NULL, 5, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (131, NULL, N'คุณตี๋', NULL, 5, N'พรานนก', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (132, NULL, N'พี่หน่อย', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (133, NULL, N'พี่แอ๊ด', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (134, NULL, N'เจ๊เฮียง', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (135, NULL, N'เจ๊นัสใหม่', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (136, NULL, N'เก๋(2)', NULL, 5, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (137, NULL, N'เมย์', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (138, NULL, N'อำนาจ', NULL, 5, N'สุขสวัสดิ์38', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (139, NULL, N'เฮียตี๋(ใหม่)', NULL, 5, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (140, NULL, N'ปิง', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (141, NULL, N'ปุ่น', NULL, 5, N'บางกอกน้อย', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (142, NULL, N'แจ่ม', NULL, 5, N'ศาลาน้ำร้อน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (143, NULL, N'นุชโชค', NULL, 5, N'ลาดพร้าว', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (144, NULL, N'เจ๊ตือ', NULL, 5, N'กรุงธน', NULL, NULL, NULL, 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'ADMIN', N'c/Sz1aT7ciLK6+FgUnVqlQ==', 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'ACCOUNT', N'9ImnF+8551TqYE9KLkay3A==', 2, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'PRICE', N'c/Sz1aT7ciLK6+FgUnVqlQ==', 1, 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (1, CAST(N'2018-08-13 00:01:37.547' AS DateTime), 1, 1, CAST(24.00 AS Decimal(14, 2)), CAST(3000.00 AS Decimal(14, 2)), 35, CAST(105000.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (2, CAST(N'2018-08-13 00:01:37.547' AS DateTime), 1, 3, CAST(22.00 AS Decimal(14, 2)), CAST(22.00 AS Decimal(14, 2)), 40, CAST(880.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (3, CAST(N'2018-08-13 00:01:37.547' AS DateTime), 1, 2, CAST(32.00 AS Decimal(14, 2)), CAST(32.00 AS Decimal(14, 2)), 15, CAST(480.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (4, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 1, 1, CAST(24.00 AS Decimal(14, 2)), CAST(24.00 AS Decimal(14, 2)), 35, CAST(840.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (5, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 1, 6, CAST(27.00 AS Decimal(14, 2)), CAST(27.00 AS Decimal(14, 2)), 15, CAST(405.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (6, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 1, 2, CAST(32.00 AS Decimal(14, 2)), CAST(32.00 AS Decimal(14, 2)), 24, CAST(768.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (7, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 1, 3, CAST(22.00 AS Decimal(14, 2)), CAST(22.00 AS Decimal(14, 2)), 155, CAST(3410.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (8, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 2, 1, CAST(24.00 AS Decimal(14, 2)), CAST(24.00 AS Decimal(14, 2)), 1, CAST(24.00 AS Decimal(14, 2)), N'', 1, CAST(N'2018-08-13 00:06:38.593' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (9, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 2, 5, CAST(25.00 AS Decimal(14, 2)), CAST(25.00 AS Decimal(14, 2)), 1, CAST(25.00 AS Decimal(14, 2)), N'', 1, CAST(N'2018-08-13 00:06:38.593' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (10, CAST(N'2018-08-14 00:01:37.547' AS DateTime), 2, 8, CAST(24.50 AS Decimal(14, 2)), CAST(24.50 AS Decimal(14, 2)), 1, CAST(24.50 AS Decimal(14, 2)), N'', 1, CAST(N'2018-08-13 00:06:38.593' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (11, CAST(N'2018-08-15 00:09:40.190' AS DateTime), 1, 1, CAST(24.00 AS Decimal(14, 2)), CAST(24.00 AS Decimal(14, 2)), 50, CAST(1200.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (12, CAST(N'2018-08-15 00:09:40.190' AS DateTime), 1, 2, CAST(24.00 AS Decimal(14, 2)), CAST(24.00 AS Decimal(14, 2)), 50, CAST(1200.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (13, CAST(N'2018-08-16 00:09:40.190' AS DateTime), 1, 1, CAST(24.00 AS Decimal(14, 2)), CAST(24.00 AS Decimal(14, 2)), 5, CAST(120.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (14, CAST(N'2018-08-17 02:02:35.170' AS DateTime), 1, 67, CAST(34.00 AS Decimal(14, 2)), CAST(34.00 AS Decimal(14, 2)), 330, CAST(11220.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (15, CAST(N'2018-08-17 02:02:35.170' AS DateTime), 1, 57, CAST(0.00 AS Decimal(14, 2)), CAST(15.00 AS Decimal(14, 2)), 2, CAST(30.00 AS Decimal(14, 2)), N'แก้ไขข้อมูล', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (16, CAST(N'2018-08-10 10:06:55.000' AS DateTime), 1, 67, CAST(34.00 AS Decimal(14, 2)), CAST(34.00 AS Decimal(14, 2)), 330, CAST(11220.00 AS Decimal(14, 2)), N'', 1, CAST(N'2018-08-13 10:10:37.097' AS DateTime), N'ADMIN')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (17, CAST(N'2018-08-10 10:06:55.000' AS DateTime), 1, 57, CAST(0.00 AS Decimal(14, 2)), CAST(15.00 AS Decimal(14, 2)), 2, CAST(30.00 AS Decimal(14, 2)), N'', 1, CAST(N'2018-08-13 10:10:37.097' AS DateTime), N'ADMIN')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'วุ้นเส้นท่าเรือ', N'', 1, CAST(24.00 AS Decimal(14, 2)), 3, 1, 15, N'5กก./1ถุง', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'วุ้นเส้นต้นไทร', N'', 1, CAST(32.00 AS Decimal(14, 2)), 3, 1, 20, N'5กก./1ถุง', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'วุ้นเส้นเขียว ', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 3, 1, 0, N'5กก./1ถุง', 1, CAST(N'2018-08-13 11:01:38.320' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (4, N'วุ้นเส้นแดง ', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (5, N'วุ้นเส้นกิเลน', NULL, 1, CAST(25.00 AS Decimal(14, 2)), 3, 1, 499, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (6, N'วุ้นเส้นกิเลนจิ๋ว', NULL, 1, CAST(27.00 AS Decimal(14, 2)), 4, 1, 0, N'10กก./1ถุง', 1, CAST(N'2018-08-13 10:10:37.097' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (7, N'วุ้นเส้นชอแชมป์', NULL, 1, CAST(23.50 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (8, N'เส้นเล็กมิตรภาพ', NULL, 1, CAST(24.50 AS Decimal(14, 2)), 4, 1, 499, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (9, N'เส้นเล็กอู๋', NULL, 1, CAST(26.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (10, N'เส้นเล็กมังกร (ธนา)', NULL, 1, CAST(21.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (11, N'เส้นเล็กซอย 60 (สั้น)', NULL, 1, CAST(21.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (12, N'เส้นเล็กซอย 60 (ยาว)', NULL, 1, CAST(21.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (13, N'เส้นเล็กมหาชัย(ยาว)', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (14, N'เส้นเล็กพระอาทิตย์', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (15, N'เส้นเล็กกิเลน', NULL, 1, CAST(20.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (16, N'เส้นหมี่สิงห์', NULL, 1, CAST(27.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (17, N'เส้นหมี่มิตรภาพ', NULL, 1, CAST(26.00 AS Decimal(14, 2)), 4, 1, 483, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (18, N'เส้นหมี่เพรช', NULL, 1, CAST(26.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (19, N'เส้นหมี่กิเลน', NULL, 1, NULL, 3, 1, 485, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (20, N'หมี่แห้งสิงห์ทอง', NULL, 1, CAST(110.00 AS Decimal(14, 2)), 1, 1, 500, N'1กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (21, N'เส้นใหญ่แผ่น 60', NULL, 1, CAST(15.50 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (22, N'เส้นใหญ่ผัด 60', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (23, N'เส้นใหญ่น้ำ 60', NULL, 1, CAST(15.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (24, N'เส้นใหญ่ม้วนแดงผัด 60', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (25, N'เส้นใหญ่ม้วนเขียวน้ำ 60', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (26, N'เส้นใหญ่ตัด 3 นิ้ว', NULL, 1, CAST(15.50 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (27, N'ก๋วยเตี๋ยวหลอด 60', NULL, 1, CAST(18.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (28, N'เส้นใหญ่แผ่น (ธนา)', NULL, 1, CAST(17.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (29, N'เส้นใหญ่น้ำ(ธนา)', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (30, N'เส้นใหญ่ม้วนแดงผัด(ธนา)', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (31, N'เส้นใหญ่ม้วนเขียวน้ำ(ธนา)', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (32, N'เส้นใหญ่ผัด 5นิ้ว (ธนา)', NULL, 1, CAST(15.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (33, N'เส้นใหญ่ผัด (ธนาสิน)', NULL, 1, CAST(17.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (34, N'ก๋วยเตี๋ยวหลอด (ม้วนยาว)', NULL, 1, CAST(18.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (35, N'ก๋วยเตี๋ยวหลอด(แผ่น)', NULL, 1, CAST(18.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (36, N'ก๋วยเตี๋ยวหลอด (หั่น)', NULL, 1, CAST(18.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (37, N'เส้นใหญ่ลุยสวน ', NULL, 1, CAST(15.50 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (38, N'เส้นใหญ่อาทิตย์', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (39, N'เส้นใหญ่ตัด (ธนาสิน)', NULL, 1, CAST(16.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (40, N'เส้นใหญ่ผัด (เจ๊กชุน)', NULL, 1, CAST(16.50 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (41, N'เส้นใหญ่น้ำ (เจ๊กชุน)', NULL, 1, CAST(16.50 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (42, N'ผัดไทยมังกร(ธนา)', NULL, 1, CAST(21.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (43, N'ผัดไทยซอย 60 (กลาง)', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (44, N'ผัดไทยซอย60 (ใหญ่)', NULL, 1, CAST(21.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (45, N'ผัดไทยอาทิตย์', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (46, N'ผัดไท (เปาบุ้นจิ้น)', NULL, 1, CAST(22.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (47, N'ผัดไทยมิตร ', NULL, 1, CAST(23.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (48, N'บะหมี่ธรรมดา(กลม)555', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (49, N'บะหมี่ธรรมดา (แบน) 555', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (50, N'บะหมี่พิเศษ (กลม)555', NULL, 1, CAST(39.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (51, N'บะหมี่พิเศษ (แบน)555', NULL, 1, CAST(39.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (52, N'บะหมี่หยก (ธรรมดา) 555', NULL, 1, CAST(32.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (53, N'บะหมี่หยก(พิเศษ) 555', NULL, 1, CAST(40.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (54, N'เกี๊ยวธรรมดา 555', NULL, 2, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (55, N'เกี๊ยวพิเศษ 555', NULL, 2, CAST(39.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (56, N'บะหมี่ธรรมดา(กลม) เพชร', NULL, 1, CAST(35.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (57, N'บะหมี่ธรรมดา (แบน) เพชร', NULL, 1, NULL, 2, 1, 496, N'1/2กก./1ถุง', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (58, N'บะหมี่พิเศษ (กลม) เพชร', NULL, 1, CAST(43.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (59, N'บะหมี่พิเศษ (แบน)เพชร', NULL, 1, CAST(43.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (60, N'เกี๊ยวทอด ', NULL, 2, CAST(41.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (61, N'เกี๊ยวพิเศษ (เพชร)', NULL, 2, CAST(43.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (62, N'บะหมี่ฮ่องกง', NULL, 1, NULL, 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (63, N'บะหมี่ธรรมดา(กลม) เซียน', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (64, N'บะหมี่ธรรมดา(แบน) เซียน', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (65, N'เกี๊ยวธรรมดา เซียน', NULL, 2, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (66, N'บะหมี่หยก เซียน', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (67, N'บะหมี่ธรรมดา (กลม1โล) เซียน', NULL, 1, CAST(34.00 AS Decimal(14, 2)), 1, 1, 0, N'1กก./1ถุง', 1, CAST(N'2018-08-13 10:09:45.497' AS DateTime), N'ADMIN')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (68, N'บะหมี่ฮ่องกง คณาวุฒิ', NULL, 1, NULL, 2, 1, 500, N'1/2กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (69, N'ก๋วยจั๊บญวณ', NULL, 1, CAST(36.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (70, N'ก๋วยจั๊บ 888', NULL, 1, CAST(23.00 AS Decimal(14, 2)), 4, 1, 500, N'10กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (71, N'เซี่ยงไฮ้สีอ่อน', NULL, 1, CAST(41.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (72, N'เซี่ยงไฮ้สีเข้ม', NULL, 1, CAST(41.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (73, N'ถั่วงอก', NULL, 3, CAST(15.50 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (74, N'ถั่วงอกเปลือย', NULL, 3, CAST(15.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (75, N'ขาไก่', NULL, 4, CAST(58.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (76, N'เต้าหู้ไข่พยาบาล', NULL, 2, CAST(6.90 AS Decimal(14, 2)), 4, 2, 500, N'10หลอด/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (77, N'เต้าหู้ขาวพยาบาล', NULL, 2, CAST(9.00 AS Decimal(14, 2)), 4, 2, 500, N'10หลอด/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (78, N'เต้าหู้ไข่ผึ้งน้อย', NULL, 2, CAST(5.00 AS Decimal(14, 2)), 10, 2, 500, N'50หลอด/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (79, N'เต้าหู้ไข่แก้มแดง', NULL, 2, CAST(5.20 AS Decimal(14, 2)), 10, 2, 500, N'50หลอด/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (80, N'เต้าหู้แผ่นขาว', NULL, 2, CAST(6.50 AS Decimal(14, 2)), 4, 5, 500, N'10แผ่น/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (81, N'เต้าหู้แผ่นเหลือง', NULL, 2, CAST(6.50 AS Decimal(14, 2)), 4, 5, 500, N'10แผ่น/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (82, N'เต้าหู้พวง', NULL, 2, CAST(15.00 AS Decimal(14, 2)), 4, 8, 500, N'10พวง/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (83, N'หมูยอพริก เชียงใหม่', NULL, 4, CAST(380.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (84, N'หมูยอแท่ง1โล เชียงใหม่', NULL, 4, CAST(80.00 AS Decimal(14, 2)), 1, 1, 500, N'1กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (85, N'หมูยอแท่ง2โล เชียงใหม่', NULL, 4, CAST(155.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (86, N'หมูยอแผ่น เชียงใหม่', NULL, 4, CAST(325.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (87, N'หมูยอเล็ก เชียงใหม่', NULL, 4, CAST(285.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (88, N'หมูยอดี เชียงใหม่', NULL, 4, CAST(375.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (89, N'ไส้อั่ว', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (90, N'ลูกชิ้นเอ็นหมู เชียงใหม่', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (91, N'หมูยอดี เชียงใหม่ (สั้น)', NULL, 4, CAST(20.00 AS Decimal(14, 2)), 1, 1, 500, N'1กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (92, N'หมูยอดี เชีบงใหม่ (ยาว)', NULL, 4, CAST(36.00 AS Decimal(14, 2)), 1, 1, 500, N'1กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (93, N'ลูกชิ้นหมู แหลม(แดง)', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (94, N'ลูกชิ้น หมูชาววัง', NULL, 4, CAST(75.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (95, N'ลูกชิ้นเอ็นไก่ ชาววัง', NULL, 4, CAST(55.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (96, N'ลูกชิ้นเนื้อใหญ่ ชาววัง', NULL, 4, CAST(85.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (97, N'หมูยอกลาง เชียงใหม่', NULL, 4, CAST(250.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (98, N'ลูกชิ้น เจ๊ใหญ่ (ใหญ่)', NULL, 4, CAST(50.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (99, N'ลูกชิ้น เจ๊ใหญ่ (เล็ก)', NULL, 4, CAST(50.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (100, N'หมูหมัก', NULL, 4, CAST(105.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (101, N'หมูกเด้ง', NULL, 4, CAST(120.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (102, N'บีลัคกี้ ', NULL, 4, CAST(123.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (103, N'บีลัคกี้ คอกเทล', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (104, N'บีลัคกี้จัมโบ้', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (105, N'แฮม', NULL, 4, CAST(192.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (106, N'เบคอน หมูสองตัว', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (107, N'หมูยอแผ่น โคราช', NULL, 4, CAST(325.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (108, N'ไก่ยอแผ่น โคราช', NULL, 4, CAST(300.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (109, N'หมูยอเล็ก โคราช', NULL, 4, CAST(425.00 AS Decimal(14, 2)), 10, 7, 500, N'50อัน/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (110, N'หมูยอกลาง โคราช', NULL, 4, CAST(350.00 AS Decimal(14, 2)), 7, 7, 500, N'25อัน/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (111, N'หมูยอเล็กดาว', NULL, 4, CAST(325.00 AS Decimal(14, 2)), 10, 7, 500, N'50อัน/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (112, N'ลูกชิ้นดาวทอง', NULL, 4, CAST(85.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (113, N'รมควัน', NULL, 4, NULL, 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (114, N'ลูกชิ้นเด่น', NULL, 4, CAST(108.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (115, N'แหนมปลาเอราวัณ', NULL, 4, CAST(340.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (116, N'แหนมแท่งรดา', NULL, 4, CAST(500.00 AS Decimal(14, 2)), 4, 6, 500, N'10แพค/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (117, N'แหนมแท่งนิตยา', NULL, 4, CAST(500.00 AS Decimal(14, 2)), 4, 6, 500, N'10แพค/1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (118, N'ยอพรพรรณ 1', NULL, 4, CAST(450.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (119, N'พอพรพรรณ 1/2', NULL, 4, CAST(460.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (120, N'ปลาหมึกใหญ่', NULL, 4, CAST(165.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (121, N'ปลาหมึกเล็ก', NULL, 4, CAST(90.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (122, N'หนังแผ่น', NULL, 4, CAST(40.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (123, N'หนังซอย', NULL, 4, CAST(38.00 AS Decimal(14, 2)), 3, 1, 500, N'5กก./1ถุง', 1, CAST(N'2018-02-16 00:00:00.000' AS DateTime), N'Import')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (124, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [UnitCarry], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (125, N'dd', N'dd', 1, CAST(200.00 AS Decimal(14, 2)), 4, 4, 100, N'10เส้น/1ถุง', 0, CAST(N'2018-06-02 14:27:41.533' AS DateTime), N'ADMIN')
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  StoredProcedure [dbo].[DeleteRecord]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCustomerSearch]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCustomerTransport]    Script Date: 13/08/2018 11:44:10 ******/
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
	@date DATE, @zone INT
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
	WHERE o.[OrderStatus] = 1
	AND (@date is null or CONVERT(DATE,o.[OrderDate]) = @date) 
	AND ((@zone is null OR @zone = 0) or c.Zone = @zone) 
	ORDER BY c.[CustomerName]
END





GO
/****** Object:  StoredProcedure [dbo].[GetCustomerTransport2]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[GetDailyOrder]    Script Date: 13/08/2018 11:44:10 ******/
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
	SELECT o.*,DATENAME(DW,o.[OrderDate]) [WeekDay] ,p.ProductName,p.UnitCarry,p.Unit,p.Amount

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
/****** Object:  StoredProcedure [dbo].[GetOrderbyDay]    Script Date: 13/08/2018 11:44:10 ******/
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

	SELECT o.*,DATENAME(DW,o.[OrderDate]) [WeekDay] ,p.ProductName,p.UnitCarry,p.Unit,p.Amount

	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.ProductID = o.ProductID AND p.Status =1
	WHERE 
	CONVERT(DATE,[OrderDate]) = @date AND o.CustomerID = @customer  AND o.OrderStatus = 1
	ORDER BY p.Category
END







GO
/****** Object:  StoredProcedure [dbo].[GetOrderCustomer]    Script Date: 13/08/2018 11:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderCustomer]
	-- Add the parameters for the stored procedure here
	@date DATE,@customerID INT,@report VARCHAR(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF(@report = 'INV')
BEGIN

SELECT TOP 1 c.[CustomerID],c.[CitizenID],c.[CustomerName],c.[Zone],c.[Address1],c.[Address2],c.[Phone],c.[ShowPrice]
,@date OrderStartDate, @date OrderEndDate
,@report + [dbo].[OrderNum](@date,c.[CustomerID])  DocumentID
FROM [Order].[dbo].[Order] o
JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
WHERE  o.[OrderStatus] = 1
AND CONVERT(DATE,o.[OrderDate]) = @date
AND o.CustomerID = @customerID
ORDER BY o.[OrderID] DESC
END

IF(@report = 'RCD')
BEGIN

	DECLARE @dateWeek DATE, @dw INT,@datestart DATE ,@datend DATE
    -- Insert statements for procedure here
	IF(@date IS NOT NULL)
	BEGIN
	SET @dw = DATEPART(DW,@date) 
	SET @dateWeek = @date
	END
	ELSE
	BEGIN
	SET @dw = DATEPART(DW,GETDATE()) 
	SET @dateWeek = GETDATE()
	END

	IF(@dw = 1)
	BEGIN
	SET @datestart = @dateWeek 
	SET @datend = DATEADD(DAY,6,@dateWeek)
	END
	ELSE IF(@dw = 2)
	BEGIN
	SET @datestart = DATEADD(DAY,-1,@dateWeek) 
	SET @datend = DATEADD(DAY,5,@dateWeek)
	END IF(@dw = 3)
	BEGIN
	SET @datestart = DATEADD(DAY,-2,@dateWeek)
	SET @datend = DATEADD(DAY,4,@dateWeek)
	END IF(@dw = 4)
	BEGIN
	SET @datestart = DATEADD(DAY,-3,@dateWeek)
	SET @datend = DATEADD(DAY,3,@dateWeek)
	END IF(@dw = 5)
	BEGIN
	SET @datestart = DATEADD(DAY,-4,@dateWeek)
	SET @datend = DATEADD(DAY,2,@dateWeek)
	END IF(@dw = 6)
	BEGIN
	SET @datestart = DATEADD(DAY,-5,@dateWeek) 
	SET @datend = DATEADD(DAY,1,@dateWeek)
	END IF(@dw = 7)
	BEGIN
	SET @datestart = DATEADD(DAY,-6,@dateWeek)
	SET @datend = @dateWeek 
	END


SELECT t1.*,@report + [dbo].[OrderNum](t2.[Date],t1.[CustomerID]) DocumentID 
FROM (
SELECT c.[CustomerID],c.[CitizenID],c.[CustomerName],c.[Zone],c.[Address1],c.[Address2],c.[Phone],c.[ShowPrice]
,@datestart OrderStartDate, @datend OrderEndDate
--,@report + [dbo].[OrderNum](o.[OrderDate],c.[CustomerID]) DocumentID 
FROM [Order].[dbo].[Order] o
JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
WHERE  o.[OrderStatus] = 1
AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
AND o.CustomerID = @customerID
GROUP BY c.[CustomerID],c.[CitizenID],c.[CustomerName],c.[Zone],c.[Address1],c.[Address2],c.[Phone],c.[ShowPrice]
) t1 
LEFT JOIN (
SELECT o.CustomerID CustomerID,MAX(o.[OrderDate]) date
FROM [Order].[dbo].[Order] o
WHERE  o.[OrderStatus] = 1
AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
AND o.CustomerID = @customerID
GROUP BY o.CustomerID 
) t2 ON t1.CustomerID = t2.CustomerID
END

END
GO
/****** Object:  StoredProcedure [dbo].[GetProductSearch]    Script Date: 13/08/2018 11:44:10 ******/
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
		(	RowNum INT,[ProductID] INT,[ProductName] NVARCHAR(255),[ProductAbbr] NVARCHAR(255),[Category] INT,[Price] DECIMAL(14,2),[UnitCarry] DECIMAL(14,2),[Unit] INT,[Amount] INT 
			,[Descripiton] NVARCHAR(MAX),[Status] BIT,[UpdateDate] DATETIME,[UpdateBy] NVARCHAR(50) 
		)
	-- Insert statements for procedure here
	INSERT INTO @tableresult
	SELECT ROW_NUMBER() OVER 
	( ORDER BY [ProductID] ASC ) AS RowNum
	,[ProductID],[ProductName],[ProductAbbr],[Category],[Price],[UnitCarry],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy]
	FROM [Order].[dbo].[Product] WHERE (@productid IS NULL OR [ProductID] = @productid) AND (@category IS NULL OR [Category] = @category) 
   
	SELECT [ProductID],[ProductName],[ProductAbbr],[Category],[Price],[UnitCarry],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy] FROM @tableresult
	WHERE RowNum BETWEEN (@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1 
		AND (@productid IS NULL OR [ProductID] = @productid) AND (@category IS NULL OR [Category] = @category) 

END




GO
/****** Object:  StoredProcedure [dbo].[GetProductTransport]    Script Date: 13/08/2018 11:44:10 ******/
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
		  ,p.[UnitCarry],p.[Unit]

	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (@date is null or CONVERT(DATE,o.[OrderDate]) = @date) 
	AND (@zone is null or c.Zone = @zone) 
	GROUP BY o.[ProductID],p.[ProductName],p.[UnitCarry],p.[Unit]
END





GO
/****** Object:  StoredProcedure [dbo].[GetReceiveWeekly]    Script Date: 13/08/2018 11:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReceiveWeekly]
	-- Add the parameters for the stored procedure here
	@dateWeek DATE,@customerID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--Find Weekday to get StartDate and EndDate (Sun - Sat)
	DECLARE @date DATE, @dw INT,@datestart DATE ,@datend DATE
    -- Insert statements for procedure here
	IF(@dateWeek IS NOT NULL)
	BEGIN
	SET @dw = DATEPART(DW,@dateWeek) 
	SET @date = @dateWeek
	END
	ELSE
	BEGIN
	SET @dw = DATEPART(DW,GETDATE()) 
	SET @date = GETDATE()
	END

	IF(@dw = 1)
	BEGIN
	SET @datestart = @date 
	SET @datend = DATEADD(DAY,6,@date)
	END
	ELSE IF(@dw = 2)
	BEGIN
	SET @datestart = DATEADD(DAY,-1,@date) 
	SET @datend = DATEADD(DAY,5,@date)
	END IF(@dw = 3)
	BEGIN
	SET @datestart = DATEADD(DAY,-2,@date)
	SET @datend = DATEADD(DAY,4,@date)
	END IF(@dw = 4)
	BEGIN
	SET @datestart = DATEADD(DAY,-3,@date)
	SET @datend = DATEADD(DAY,3,@date)
	END IF(@dw = 5)
	BEGIN
	SET @datestart = DATEADD(DAY,-4,@date)
	SET @datend = DATEADD(DAY,2,@date)
	END IF(@dw = 6)
	BEGIN
	SET @datestart = DATEADD(DAY,-5,@date) 
	SET @datend = DATEADD(DAY,1,@date)
	END IF(@dw = 7)
	BEGIN
	SET @datestart = DATEADD(DAY,-6,@date)
	SET @datend = @date 
	END

	SELECT t1.[ProductID],t1.[ProductName]
		,sun.[OrderTotal] sun
	,mon.[OrderTotal] mon
	,tue.[OrderTotal] tue
	,wed.[OrderTotal] wed
	,thr.[OrderTotal] thr
	,fri.[OrderTotal] fri
	,sat.[OrderTotal] sat

	,sun.[OrderAmount] sunamount
	,mon.[OrderAmount] monamount
	,tue.[OrderAmount] tueamount
	,wed.[OrderAmount] wedamount
	,thr.[OrderAmount] thramount
	,fri.[OrderAmount] friamount
	,sat.[OrderAmount] satamount

	,totalamount.[totalamount]
	,total.[total]
	
	FROM ( SELECT o.[ProductID],p.[ProductName],c.[CustomerID],c.[CustomerName]
		FROM [Order].[dbo].[Order] o
		JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
		JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
		WHERE  o.[OrderStatus] = 1
		AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
		AND o.CustomerID = @customerID
		GROUP BY o.[ProductID],p.[ProductName],c.[CustomerID],c.[CustomerName]
	) t1
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 1
	AND o.CustomerID = @customerID
	) sun ON sun.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 2
	AND o.CustomerID = @customerID
	) mon ON mon.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 3
	AND o.CustomerID = @customerID
	) tue ON tue.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 4
	AND o.CustomerID = @customerID
	) wed ON wed.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 5
	AND o.CustomerID = @customerID
	) thr ON thr.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 6
	AND o.CustomerID = @customerID
	) fri ON fri.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 7
	AND o.CustomerID = @customerID
	) sat ON sat.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID]
	,SUM([OrderAmount]) totalamount
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND o.CustomerID = @customerID
	GROUP BY o.[ProductID]
	) totalamount ON totalamount.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID]
	,SUM([OrderTotal]) total
	FROM [Order].[dbo].[Order] o
	JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
	JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND o.CustomerID = @customerID
	GROUP BY o.[ProductID]
	) total ON total.[ProductID] = t1.[ProductID]

END

GO
/****** Object:  StoredProcedure [dbo].[GetReceiveWeeklyPrice]    Script Date: 13/08/2018 11:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReceiveWeeklyPrice]
	-- Add the parameters for the stored procedure here
	@dateWeek DATE,@customerID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DECLARE @date DATE, @dw INT,@datestart DATE ,@datend DATE
    -- Insert statements for procedure here
	IF(@dateWeek IS NOT NULL)
	BEGIN
	SET @dw = DATEPART(DW,@dateWeek) 
	SET @date = @dateWeek
	END
	ELSE
	BEGIN
	SET @dw = DATEPART(DW,GETDATE()) 
	SET @date = GETDATE()
	END

	IF(@dw = 1)
	BEGIN
	SET @datestart = @date 
	SET @datend = DATEADD(DAY,6,@date)
	END
	ELSE IF(@dw = 2)
	BEGIN
	SET @datestart = DATEADD(DAY,-1,@date) 
	SET @datend = DATEADD(DAY,5,@date)
	END IF(@dw = 3)
	BEGIN
	SET @datestart = DATEADD(DAY,-2,@date)
	SET @datend = DATEADD(DAY,4,@date)
	END IF(@dw = 4)
	BEGIN
	SET @datestart = DATEADD(DAY,-3,@date)
	SET @datend = DATEADD(DAY,3,@date)
	END IF(@dw = 5)
	BEGIN
	SET @datestart = DATEADD(DAY,-4,@date)
	SET @datend = DATEADD(DAY,2,@date)
	END IF(@dw = 6)
	BEGIN
	SET @datestart = DATEADD(DAY,-5,@date) 
	SET @datend = DATEADD(DAY,1,@date)
	END IF(@dw = 7)
	BEGIN
	SET @datestart = DATEADD(DAY,-6,@date)
	SET @datend = @date 
	END

	SELECT t1.[ProductID],t1.[ProductName]
	
	,sun.[OrderTotal] sun
	,mon.[OrderTotal] mon
	,tue.[OrderTotal] tue
	,wed.[OrderTotal] wed
	,thr.[OrderTotal] thr
	,fri.[OrderTotal] fri
	,sat.[OrderTotal] sat

	,sun.[OrderAmount] sunamount
	,mon.[OrderAmount] monamount
	,tue.[OrderAmount] tueamount
	,wed.[OrderAmount] wedamount
	,thr.[OrderAmount] thramount
	,fri.[OrderAmount] friamount
	,sat.[OrderAmount] satamount

	,tp.[MaxPrice] price
	,totalamount.[totalamount]
	,total.[total]
	

	FROM ( SELECT o.[ProductID],p.[ProductName],c.[CustomerID],c.[CustomerName]
		FROM [Order].[dbo].[Order] o
		JOIN [Order].[dbo].[Product] p ON p.[ProductID] = o.[ProductID]
		JOIN [Order].[dbo].[Customer] c ON c.[CustomerID] = o.[CustomerID]
		WHERE  o.[OrderStatus] = 1
		AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
		AND o.CustomerID = @customerID
		GROUP BY o.[ProductID],p.[ProductName],c.[CustomerID],c.[CustomerName]
	) t1
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 1
	AND o.CustomerID = @customerID
	) sun ON sun.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 2
	AND o.CustomerID = @customerID
	) mon ON mon.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 3
	AND o.CustomerID = @customerID
	) tue ON tue.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 4
	AND o.CustomerID = @customerID
	) wed ON wed.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 5
	AND o.CustomerID = @customerID
	) thr ON thr.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 6
	AND o.CustomerID = @customerID
	) fri ON fri.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID],o.[ProductPrice],o.[OrderPrice],o.[OrderAmount],o.[OrderTotal]
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND DATEPART(DW,o.[OrderDate]) = 7
	AND o.CustomerID = @customerID
	) sat ON sat.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID]
	,SUM([OrderAmount]) totalamount
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND o.CustomerID = @customerID
	GROUP BY o.[ProductID]
	) totalamount ON totalamount.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
	SELECT o.[ProductID]
	,SUM([OrderTotal]) total
	FROM [Order].[dbo].[Order] o
	WHERE  o.[OrderStatus] = 1
	AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
	AND o.CustomerID = @customerID
	GROUP BY o.[ProductID]
	) total ON total.[ProductID] = t1.[ProductID]
	LEFT JOIN 
	(
		SELECT o.[ProductID], MAX(o.[OrderPrice]) AS MaxPrice
		FROM [dbo].[Order] o 
		WHERE o.[OrderStatus] = 1 AND o.CustomerID = @customerID
		AND (CONVERT(DATE,o.[OrderDate]) BETWEEN  @datestart AND @datend)
		GROUP BY o.[ProductID]
	) tp ON tp.[ProductID] = t1.[ProductID]

END

GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 13/08/2018 11:44:10 ******/
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
	@productname NVARCHAR(255),@productabbr NVARCHAR(255), @category INT ,@productprice DECIMAL(14,2),@unitCarry DECIMAL(14,2),@unit INT,@productamount INT,@description nvarchar(max),@status BIT
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
	INSERT INTO [dbo].[Product] ([ProductName],[ProductAbbr],[Category],[Price],[UnitCarry],[Unit],[Amount],[Descripiton],[Status],[UpdateDate],[UpdateBy])
 		VALUES (@productname,@productabbr,@category,@productprice,@unitCarry,@unit,@productamount,@description,@status,@updatedate,@updateby)

COMMIT TRAN
SELECT 0
END TRY
BEGIN CATCH
SELECT 99
ROLLBACK TRAN
END CATCH

END







GO
/****** Object:  StoredProcedure [dbo].[SelectGridPaging]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 13/08/2018 11:44:10 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 13/08/2018 11:44:10 ******/
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
	WHERE CONVERT(DATE,[OrderDate]) = CONVERT(DATE,@orderdate) AND [ProductID] = @productid AND [CustomerID] = @customerid

	/*Update order*/
	UPDATE [dbo].[Order] 
		SET [ProductPrice] = @productprice,[OrderPrice] = @orderprice,[OrderAmount] = @orderamount,[OrderTotal] = @ordertotal
		,[Description] = @description,[OrderStatus] = @status
		, [UpdateDate] = @updatedate , [UpdateBy]= @updateby
	WHERE CONVERT(DATE,[OrderDate]) = CONVERT(DATE,@orderdate) AND [ProductID] = @productid AND [CustomerID] = @customerid
 
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
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 13/08/2018 11:44:10 ******/
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
	@productid INT,@productname NVARCHAR(255),@productabbr NVARCHAR(255), @category INT ,@productprice DECIMAL(14,2),@unitcarry DECIMAL(14,2),@unit INT,@productamount INT,@description nvarchar(max),@status BIT
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
		SET [ProductName]=@productname,[ProductAbbr]=@productabbr,[Category]=@category,[Price]=@productprice,[UnitCarry] = @unitcarry,[Unit]=@unit,[Amount]=@productamount
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
               Bottom = 264
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 252
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 246
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 3
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
