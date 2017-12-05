USE [Order]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 6/12/2560 0:29:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CitizenID] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[Login]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  View [dbo].[vwCustomerDetail]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  View [dbo].[vwOrder]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  View [dbo].[vwOrderDetail]    Script Date: 6/12/2560 0:29:23 ******/
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

INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'1111111111111', N'Alex', N'Alex', 1, N'bangkok', NULL, N'021133224', NULL, 1, 1, NULL, NULL)
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'2222222222222', N'Jessie', N'Jmart', 2, N'jaran', N'', N'0819955595', N'', 1, 1, CAST(N'2017-11-03 17:34:43.857' AS DateTime), N'Admin')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'3333333333333', N'Justin', N'Timberland', 3, N'AIS', N'', N'024564561', N'', 0, 1, CAST(N'2017-11-03 17:32:06.287' AS DateTime), N'Admin')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (4, N'fads', N'aadd', N'dd', 2, N'aaa', N'', N'asdf', N'', 1, 0, CAST(N'2017-11-03 17:53:19.247' AS DateTime), N'Admin')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (5, N'd', N'aa5dd', N'd', 2, N'd', N'', N'd', N'dd', 0, 0, CAST(N'2017-11-03 17:49:52.867' AS DateTime), N'Admin')
INSERT [dbo].[Customer] ([CustomerID], [CitizenID], [CustomerName], [CustomerAbbr], [Zone], [Address1], [Address2], [Phone], [Description], [ShowPrice], [Status], [UpdateDate], [UpdateBy]) VALUES (6, N'88888', N'aadds', N'', 1, N'ss boulervard', N'', N'', N'', 0, 1, CAST(N'2017-11-17 14:18:29.833' AS DateTime), N'Admin')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'Admin', N'1234', 1, 1, NULL, NULL)
INSERT [dbo].[Login] ([run], [UserName], [Password], [UserGroup], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'Account', N'2', 2, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (1, CAST(N'2017-11-16 15:23:27.190' AS DateTime), 1, 1, CAST(500.00 AS Decimal(14, 2)), CAST(600.00 AS Decimal(14, 2)), 10, CAST(6000.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (2, CAST(N'2017-10-02 05:00:00.000' AS DateTime), 1, 2, CAST(190.50 AS Decimal(14, 2)), CAST(250.00 AS Decimal(14, 2)), 20, CAST(5000.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (3, CAST(N'2017-10-16 00:00:00.000' AS DateTime), 1, 3, CAST(5000.20 AS Decimal(14, 2)), CAST(6000.00 AS Decimal(14, 2)), 5, CAST(30000.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (4, CAST(N'2017-11-16 15:23:27.190' AS DateTime), 1, 2, CAST(190.50 AS Decimal(14, 2)), CAST(250.00 AS Decimal(14, 2)), 5, CAST(1250.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (5, CAST(N'2017-10-02 00:00:00.000' AS DateTime), 2, 1, CAST(500.00 AS Decimal(14, 2)), CAST(250.00 AS Decimal(14, 2)), 2, CAST(500.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (6, CAST(N'2017-10-09 00:00:00.000' AS DateTime), 2, 2, CAST(190.50 AS Decimal(14, 2)), CAST(250.00 AS Decimal(14, 2)), 2, CAST(500.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (7, CAST(N'2017-09-25 00:00:00.000' AS DateTime), 2, 1, CAST(500.00 AS Decimal(14, 2)), CAST(200.00 AS Decimal(14, 2)), 1, CAST(200.00 AS Decimal(14, 2)), NULL, 1, NULL, NULL)
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (60, CAST(N'2017-11-16 15:23:27.190' AS DateTime), 3, 1, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 2, CAST(1000.00 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:23:47.367' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (61, CAST(N'2017-11-16 15:23:27.190' AS DateTime), 3, 3, CAST(5000.20 AS Decimal(14, 2)), CAST(5000.20 AS Decimal(14, 2)), 1, CAST(5000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:23:47.367' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (62, CAST(N'2017-11-15 15:24:36.003' AS DateTime), 3, 1, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (63, CAST(N'2017-11-15 15:24:36.003' AS DateTime), 3, 3, CAST(5000.20 AS Decimal(14, 2)), CAST(5000.20 AS Decimal(14, 2)), 1, CAST(5000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (64, CAST(N'2017-11-15 15:24:36.003' AS DateTime), 3, 5, CAST(15000.20 AS Decimal(14, 2)), CAST(15000.20 AS Decimal(14, 2)), 1, CAST(15000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (65, CAST(N'2017-11-17 15:24:36.003' AS DateTime), 3, 1, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (66, CAST(N'2017-11-17 15:24:36.003' AS DateTime), 3, 3, CAST(5000.20 AS Decimal(14, 2)), CAST(5000.20 AS Decimal(14, 2)), 1, CAST(5000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (67, CAST(N'2017-11-17 15:24:36.003' AS DateTime), 3, 5, CAST(15000.20 AS Decimal(14, 2)), CAST(15000.20 AS Decimal(14, 2)), 1, CAST(15000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (68, CAST(N'2017-11-17 16:35:09.000' AS DateTime), 3, 1, CAST(500.00 AS Decimal(14, 2)), CAST(500.00 AS Decimal(14, 2)), 1, CAST(500.00 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-24 16:35:42.977' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (69, CAST(N'2017-11-17 16:35:09.000' AS DateTime), 3, 3, CAST(5000.20 AS Decimal(14, 2)), CAST(5000.20 AS Decimal(14, 2)), 1, CAST(5000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-24 16:35:42.977' AS DateTime), N'Admin')
INSERT [dbo].[Order] ([OrderID], [OrderDate], [CustomerID], [ProductID], [ProductPrice], [OrderPrice], [OrderAmount], [OrderTotal], [Description], [OrderStatus], [UpdateDate], [UpdateBy]) VALUES (70, CAST(N'2017-11-17 16:35:09.000' AS DateTime), 3, 5, CAST(15000.20 AS Decimal(14, 2)), CAST(15000.20 AS Decimal(14, 2)), 1, CAST(15000.20 AS Decimal(14, 2)), N'', 1, CAST(N'2017-11-24 16:35:42.977' AS DateTime), N'Admin')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (1, N'Mobile Phone', N'phone', 1, CAST(500.00 AS Decimal(14, 2)), 5, 10, N'', 1, CAST(N'2017-11-24 16:35:42.977' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (2, N'Tablet', N'tablet', 2, CAST(190.50 AS Decimal(14, 2)), 10, 45, NULL, 1, CAST(N'2017-10-31 10:41:15.200' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (3, N'Computer', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 12, N'Lenovo', 1, CAST(N'2017-11-24 16:35:42.977' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (5, N'Notebook', N'NB', 1, CAST(15000.20 AS Decimal(14, 2)), 5, 10, NULL, 1, CAST(N'2017-11-17 15:26:12.100' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (6, N'เครื่องคิดเลข', N'CAL', 4, CAST(100.00 AS Decimal(14, 2)), 1, 30, NULL, 1, CAST(N'2017-10-03 00:00:00.000' AS DateTime), N'admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (7, N'Computer1', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo', 1, CAST(N'2017-11-17 14:32:17.107' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (8, N'Computer2', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo 2', 1, CAST(N'2017-11-17 14:32:11.563' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (9, N'Computer3', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo 23', 1, CAST(N'2017-11-17 14:32:05.923' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (10, N'Computer4', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (11, N'Computer5', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-12-01 00:00:00.000' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (12, N'Computer6', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (13, N'Computer7', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (14, N'Computer8', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (15, N'Computer9', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (16, N'Computer10', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (17, N'Computer11', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (18, N'Computer12', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (19, N'Computer13', N'PC', 1, CAST(5000.20 AS Decimal(14, 2)), 5, 120, N'Lenovo-Pc', 1, CAST(N'2017-11-17 14:31:57.270' AS DateTime), N'Admin')
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductAbbr], [Category], [Price], [Unit], [Amount], [Descripiton], [Status], [UpdateDate], [UpdateBy]) VALUES (20, N'เครื่องเคลือบบัตร', N'เครื่องเคลือบ', 4, CAST(4600.00 AS Decimal(14, 2)), 1, 12, N'', 1, CAST(N'2017-12-05 12:59:28.573' AS DateTime), N'Admin')
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  StoredProcedure [dbo].[DeleteRecord]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCustomerTransport]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetDailyOrder]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetOrderbyDay]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetProductTransport]    Script Date: 6/12/2560 0:29:23 ******/
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
	UNION ALL
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
	UNION ALL
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
	UNION ALL
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
	UNION ALL
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
	UNION ALL
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
	UNION ALL
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
	UNION ALL
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
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[SelectGridPaging]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 6/12/2560 0:29:23 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 6/12/2560 0:29:23 ******/
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
