USE [master]
GO
/****** Object:  Database [StoreNet]    Script Date: 7/5/2023 12:43:44 AM ******/
CREATE DATABASE [StoreNet]

ALTER DATABASE [StoreNet] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreNet] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoreNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreNet] SET RECOVERY FULL 
GO
ALTER DATABASE [StoreNet] SET  MULTI_USER 
GO
ALTER DATABASE [StoreNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreNet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreNet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreNet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreNet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreNet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'StoreNet', N'ON'
GO
ALTER DATABASE [StoreNet] SET QUERY_STORE = ON
GO
ALTER DATABASE [StoreNet] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StoreNet]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 7/10/2023 1:48:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Lastname] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/10/2023 1:48:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Barcode] [varchar](100) NOT NULL,
	[Description] [varchar](100) NULL,
	[Image] [varbinary](max) NULL,
	[Price] [decimal](19, 4) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStore]    Script Date: 7/10/2023 1:48:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ProductStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 7/10/2023 1:48:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](19, 4) NOT NULL,
	[Total] [decimal](19, 4) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [Sales_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 7/10/2023 1:48:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Branch] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Lastname], [Address]) VALUES (1, N'Gilbert', N'Tamayo', N'Aqui cerca de una escuela')
INSERT [dbo].[Customers] ([Id], [Name], [Lastname], [Address]) VALUES (3, N'Juan', N'Perez', N'Cerca de un super mercado')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Barcode], [Description], [Image], [Price], [Stock]) VALUES (1, N'123456789', N'Coca-Cola', NULL, CAST(30.0000 AS Decimal(19, 4)), 599)
INSERT [dbo].[Products] ([Id], [Barcode], [Description], [Image], [Price], [Stock]) VALUES (2, N'494949848', N'Chetos', NULL, CAST(15.0000 AS Decimal(19, 4)), 800)
INSERT [dbo].[Products] ([Id], [Barcode], [Description], [Image], [Price], [Stock]) VALUES (3, N'1165645498', N'Helado', NULL, CAST(20.0000 AS Decimal(19, 4)), 50)
INSERT [dbo].[Products] ([Id], [Barcode], [Description], [Image], [Price], [Stock]) VALUES (4, N'159498494', N'Kilo de Manzana', NULL, CAST(60.0000 AS Decimal(19, 4)), 798)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductStore] ON 

INSERT [dbo].[ProductStore] ([Id], [ProductId], [StoreId], [CreatedDate], [UpdatedDate]) VALUES (1, 3, 1, CAST(N'2023-07-07T00:00:00.000' AS DateTime), CAST(N'2023-07-10T14:11:55.617' AS DateTime))
INSERT [dbo].[ProductStore] ([Id], [ProductId], [StoreId], [CreatedDate], [UpdatedDate]) VALUES (2, 2, 5, CAST(N'2023-07-10T19:22:05.063' AS DateTime), CAST(N'2023-07-10T19:27:52.153' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductStore] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([Id], [CustomerId], [ProductId], [Quantity], [UnitPrice], [Total], [CreatedDate], [UpdatedDate]) VALUES (5, 1, 1, 100, CAST(10.1000 AS Decimal(19, 4)), CAST(1010.0000 AS Decimal(19, 4)), CAST(N'2023-07-06T18:47:51.600' AS DateTime), NULL)
INSERT [dbo].[Sales] ([Id], [CustomerId], [ProductId], [Quantity], [UnitPrice], [Total], [CreatedDate], [UpdatedDate]) VALUES (7, 1, 1, 100, CAST(30.0000 AS Decimal(19, 4)), CAST(3000.0000 AS Decimal(19, 4)), CAST(N'2023-07-08T18:34:11.430' AS DateTime), NULL)
INSERT [dbo].[Sales] ([Id], [CustomerId], [ProductId], [Quantity], [UnitPrice], [Total], [CreatedDate], [UpdatedDate]) VALUES (9, 1, 4, 2, CAST(60.0000 AS Decimal(19, 4)), CAST(120.0000 AS Decimal(19, 4)), CAST(N'2023-07-10T14:34:43.127' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
SET IDENTITY_INSERT [dbo].[Stores] ON 

INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (1, N'Tienda de la esquina', N'Local de la esquina')
INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (2, N'Tienda de cozumel', N'Malecón')
INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (3, N'Tienda matriz', N'Paseo montejo')
INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (4, N'El amigo Juan', N'Con el Juan')
INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (5, N'El amigo Luis', N'Con el Luis')
INSERT [dbo].[Stores] ([Id], [Branch], [Address]) VALUES (7, N'Tienda de la esquina', N'En la esquina')
SET IDENTITY_INSERT [dbo].[Stores] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Products__177800D32ED31F33]    Script Date: 7/10/2023 1:48:02 PM ******/
ALTER TABLE [dbo].[Products] ADD UNIQUE NONCLUSTERED 
(
	[Barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0.00)) FOR [Price]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[ProductStore]  WITH CHECK ADD  CONSTRAINT [FK_ProductStore_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductStore] CHECK CONSTRAINT [FK_ProductStore_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductStore]  WITH CHECK ADD  CONSTRAINT [FK_ProductStore_Stores_StoreId] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([Id])
GO
ALTER TABLE [dbo].[ProductStore] CHECK CONSTRAINT [FK_ProductStore_Stores_StoreId]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [StoreNet] SET  READ_WRITE 
GO
