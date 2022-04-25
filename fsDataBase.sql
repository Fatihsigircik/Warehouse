USE [fsDataBase]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25.04.2022 14:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](25) NOT NULL,
	[CompanyName] [nvarchar](150) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerSurname] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Phone2] [nvarchar](15) NULL,
	[Mail] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
	[RegionId] [int] NULL,
	[CityId] [int] NULL,
	[TownId] [int] NULL,
	[Address] [nvarchar](150) NULL,
	[Address2] [nvarchar](150) NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[TaxNumber] [nchar](11) NULL,
	[TaxOffice] [nvarchar](25) NULL,
	[IsDeleted] [bit] NOT NULL,
	[RetailGroupId] [int] NULL,
	[WholesaleGroupId] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](30) NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[VatPercent] [tinyint] NULL,
	[UnitId] [int] NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[HasVariant] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](20) NOT NULL,
	[CurrencyCode] [nchar](4) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[ProductDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CustomerId] [int] NULL,
	[DocumentCode] [nvarchar](50) NULL,
	[Stock] [decimal](10, 3) NULL,
	[UnitId] [int] NULL,
	[Price] [decimal](10, 3) NULL,
	[CurrencyId] [int] NULL,
	[VatPercent] [tinyint] NULL,
	[WarehouseId] [int] NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[InOrOut] [smallint] NULL,
	[VariantId] [int] NULL,
	[IsApproved] [bit] NULL,
 CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED 
(
	[ProductDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseId] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwProductDetails]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwProductDetails]
AS
SELECT        dbo.ProductDetail.ProductDetailId, dbo.ProductDetail.ProductId, dbo.ProductDetail.CustomerId, dbo.ProductDetail.DocumentCode, dbo.ProductDetail.Stock, dbo.ProductDetail.UnitId, dbo.ProductDetail.Price, 
                         dbo.ProductDetail.CurrencyId, dbo.ProductDetail.VatPercent, dbo.ProductDetail.WarehouseId, dbo.ProductDetail.CreatedId, dbo.ProductDetail.CreatedDate, dbo.ProductDetail.InOrOut, dbo.ProductDetail.VariantId, 
                         dbo.ProductDetail.IsApproved, dbo.Warehouse.WarehouseName, dbo.Currency.CurrencyName, dbo.Currency.CurrencyCode, dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.Barcode, 
                         dbo.Customer.CustomerCode, dbo.Customer.CompanyName, dbo.Customer.CustomerName, dbo.Customer.CustomerSurname, dbo.Unit.UnitName
FROM            dbo.ProductDetail INNER JOIN
                         dbo.Product ON dbo.ProductDetail.ProductId = dbo.Product.ProductId INNER JOIN
                         dbo.Unit ON dbo.ProductDetail.UnitId = dbo.Unit.UnitId INNER JOIN
                         dbo.Warehouse ON dbo.ProductDetail.WarehouseId = dbo.Warehouse.WarehouseId INNER JOIN
                         dbo.Currency ON dbo.ProductDetail.CurrencyId = dbo.Currency.CurrencyId LEFT OUTER JOIN
                         dbo.Customer ON dbo.ProductDetail.CustomerId = dbo.Customer.CustomerId
GO
/****** Object:  View [dbo].[VwProductStockInWarehouse]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwProductStockInWarehouse]
AS
SELECT        ProductId, ProductCode, SUM(Stock * InOrOut) AS Stock, WarehouseId, WarehouseName, UnitName
FROM            dbo.VwProductDetails
GROUP BY ProductId, ProductCode, WarehouseId, WarehouseName, UnitName
GO
/****** Object:  Table [dbo].[Variant]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Variant](
	[VariantId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[PropertyId1] [int] NULL,
	[PropertyId2] [int] NULL,
	[PropertyId3] [int] NULL,
	[PropertyId4] [int] NULL,
	[PropertyId5] [int] NULL,
	[Barcode] [nvarchar](50) NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Variant] PRIMARY KEY CLUSTERED 
(
	[VariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCode] [nvarchar](30) NOT NULL,
	[ProductName] [nvarchar](150) NULL,
	[Quantity] [decimal](10, 3) NULL,
	[UnitId] [int] NULL,
	[VatPercent] [tinyint] NULL,
	[Price] [decimal](10, 3) NULL,
	[Barcode] [nvarchar](50) NULL,
	[WarehouseId] [int] NULL,
	[InOrOut] [smallint] NULL,
	[VariantId] [int] NULL,
	[CurrencyId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwOrderDetails]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwOrderDetails]
AS
SELECT        dbo.OrderDetail.*, dbo.Currency.CurrencyName, dbo.Currency.CurrencyCode, dbo.Unit.UnitName, dbo.Variant.Barcode AS VariantBarcode, dbo.Warehouse.WarehouseName
FROM            dbo.Currency INNER JOIN
                         dbo.OrderDetail ON dbo.Currency.CurrencyId = dbo.OrderDetail.CurrencyId INNER JOIN
                         dbo.Unit ON dbo.OrderDetail.UnitId = dbo.Unit.UnitId INNER JOIN
                         dbo.Warehouse ON dbo.OrderDetail.WarehouseId = dbo.Warehouse.WarehouseId LEFT OUTER JOIN
                         dbo.Variant ON dbo.OrderDetail.VariantId = dbo.Variant.VariantId
GO
/****** Object:  Table [dbo].[City]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[RegionId] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Town]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwCustomer]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwCustomer]
AS
SELECT        TOP (100) PERCENT dbo.Customer.CustomerId, dbo.Customer.CustomerCode, dbo.Customer.CompanyName, dbo.Customer.CustomerName, dbo.Customer.CustomerSurname, dbo.Customer.Phone, dbo.Customer.Phone2, 
                         dbo.Customer.Mail, dbo.Customer.CountryId, dbo.Customer.RegionId, dbo.Customer.CityId, dbo.Customer.TownId, dbo.Customer.Address, dbo.Customer.Address2, dbo.Customer.CreatedId, dbo.Customer.CreatedDate, 
                         dbo.Customer.TaxNumber, dbo.Customer.TaxOffice, dbo.Customer.IsDeleted, dbo.City.Name AS CityName, dbo.Country.Name AS CountryName, dbo.Town.Name AS TownName, dbo.Region.Name AS RegionName, 
                         dbo.Customer.RetailGroupId, dbo.Customer.WholesaleGroupId
FROM            dbo.Customer INNER JOIN
                         dbo.Country ON dbo.Customer.CountryId = dbo.Country.CountryId INNER JOIN
                         dbo.City ON dbo.Customer.CityId = dbo.City.CityId INNER JOIN
                         dbo.Town ON dbo.Customer.TownId = dbo.Town.TownId LEFT OUTER JOIN
                         dbo.Region ON dbo.Customer.RegionId = dbo.Region.RegionId
ORDER BY dbo.Customer.CustomerId
GO
/****** Object:  View [dbo].[VwProduct]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwProduct]
AS
SELECT        dbo.Product.*, dbo.Unit.UnitName
FROM            dbo.Product INNER JOIN
                         dbo.Unit ON dbo.Product.UnitId = dbo.Unit.UnitId
GO
/****** Object:  Table [dbo].[CustomerDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetail](
	[CustomerDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DetailCode] [nvarchar](25) NULL,
	[DetailTypeId] [int] NULL,
	[Detail] [nvarchar](500) NULL,
	[Debt] [decimal](10, 2) NULL,
	[Credit] [decimal](10, 2) NULL,
	[DetailDate] [date] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_CustomerDetail] PRIMARY KEY CLUSTERED 
(
	[CustomerDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDetailType]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetailType](
	[CustomerDetailTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DetailTypeName] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_CustomerDetailType] PRIMARY KEY CLUSTERED 
(
	[CustomerDetailTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwCustomerDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwCustomerDetail]
AS
SELECT   dbo.CustomerDetail.*, dbo.Customer.CustomerCode, dbo.Customer.CompanyName, dbo.Customer.CustomerName, dbo.Customer.CustomerSurname, 
                         dbo.CustomerDetailType.DetailTypeName
FROM         dbo.Customer INNER JOIN
                         dbo.CustomerDetail ON dbo.Customer.CustomerId = dbo.CustomerDetail.CustomerId INNER JOIN
                         dbo.CustomerDetailType ON dbo.CustomerDetail.DetailTypeId = dbo.CustomerDetailType.CustomerDetailTypeId
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [nvarchar](25) NOT NULL,
	[CompanyName] [nvarchar](150) NULL,
	[SupplierName] [nvarchar](50) NULL,
	[SupplierSurname] [nvarchar](50) NULL,
	[Phone] [nchar](15) NULL,
	[Phone2] [nchar](15) NULL,
	[Mail] [nchar](50) NULL,
	[TaxNumber] [nchar](11) NULL,
	[TaxOffice] [nvarchar](25) NULL,
	[IsDeleted] [bit] NULL,
	[CountryId] [int] NULL,
	[RegionId] [int] NULL,
	[CityId] [int] NULL,
	[TownId] [int] NULL,
	[Address] [nvarchar](150) NULL,
	[Address2] [nvarchar](150) NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[DefaultCurrencyId] [int] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwSupplier]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwSupplier]
AS
SELECT        dbo.Supplier.SupplierId, dbo.Supplier.SupplierCode, dbo.Supplier.CompanyName, dbo.Supplier.SupplierName, dbo.Supplier.SupplierSurname, dbo.Supplier.Phone, dbo.Supplier.Phone2, dbo.Supplier.Mail, 
                         dbo.Supplier.TaxNumber, dbo.Supplier.TaxOffice, dbo.Supplier.IsDeleted, dbo.Supplier.CountryId, dbo.Supplier.RegionId, dbo.Supplier.CityId, dbo.Supplier.TownId, dbo.Supplier.Address, dbo.Supplier.Address2, 
                         dbo.Supplier.CreatedId, dbo.Supplier.CreatedDate, dbo.Supplier.DefaultCurrencyId, dbo.Country.Name AS CountryName, dbo.Town.Name AS TownName, dbo.City.Name AS CityName, dbo.Region.Name AS RegionName, 
                         dbo.Currency.CurrencyName, dbo.Currency.CurrencyCode
FROM            dbo.Supplier INNER JOIN
                         dbo.Country ON dbo.Supplier.CountryId = dbo.Country.CountryId INNER JOIN
                         dbo.City ON dbo.Supplier.CityId = dbo.City.CityId INNER JOIN
                         dbo.Town ON dbo.Supplier.TownId = dbo.Town.TownId LEFT OUTER JOIN
                         dbo.Region ON dbo.Supplier.RegionId = dbo.Region.RegionId INNER JOIN
                         dbo.Currency ON dbo.Supplier.DefaultCurrencyId = dbo.Currency.CurrencyId
GO
/****** Object:  Table [dbo].[SupplierDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierDetail](
	[SupplierDetailId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[DetailCode] [nvarchar](25) NULL,
	[DetailTypeId] [int] NULL,
	[Detail] [nvarchar](500) NULL,
	[Debt] [decimal](10, 2) NULL,
	[Credit] [decimal](10, 2) NULL,
	[DetailDate] [date] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_SupplierDetail] PRIMARY KEY CLUSTERED 
(
	[SupplierDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwSupplierDetail]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VwSupplierDetail]
AS
SELECT   dbo.SupplierDetail.*, dbo.Supplier.SupplierCode, dbo.Supplier.CompanyName, dbo.Supplier.SupplierName, dbo.Supplier.SupplierSurname, 
                         dbo.CustomerDetailType.DetailTypeName
FROM         dbo.Supplier INNER JOIN
                         dbo.SupplierDetail ON dbo.Supplier.SupplierId = dbo.SupplierDetail.SupplierId INNER JOIN
                         dbo.CustomerDetailType ON dbo.SupplierDetail.DetailTypeId = dbo.CustomerDetailType.CustomerDetailTypeId
GO
/****** Object:  Table [dbo].[VariantProperty]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariantProperty](
	[VariantPropertyId] [int] IDENTITY(1,1) NOT NULL,
	[VariantGroupId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_VariantProperty] PRIMARY KEY CLUSTERED 
(
	[VariantPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProductVariant]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductVariant]
AS
SELECT        dbo.Variant.VariantId, dbo.Variant.Barcode, VariantProperty_1.Name AS P1Name, VariantProperty_1.VariantPropertyId AS P1Id, VariantProperty_1.VariantGroupId AS P1GroupId, VariantProperty_2.VariantPropertyId AS P2Id, 
                         VariantProperty_2.VariantGroupId AS P2GroupId, VariantProperty_2.Name AS P2Name, VariantProperty_3.VariantPropertyId AS P3Id, VariantProperty_3.VariantGroupId AS P3GroupId, VariantProperty_3.Name AS P3Name, 
                         VariantProperty_4.VariantPropertyId AS P4Id, VariantProperty_4.VariantGroupId AS P4GroupId, VariantProperty_4.Name AS P4Name, dbo.VariantProperty.VariantPropertyId AS P5Id, 
                         dbo.VariantProperty.VariantGroupId AS P5GroupId, dbo.VariantProperty.Name AS P5Name, dbo.Variant.ProductId
FROM            dbo.Variant LEFT OUTER JOIN
                         dbo.VariantProperty ON dbo.Variant.PropertyId5 = dbo.VariantProperty.VariantPropertyId LEFT OUTER JOIN
                         dbo.VariantProperty AS VariantProperty_4 ON dbo.Variant.PropertyId4 = VariantProperty_4.VariantPropertyId LEFT OUTER JOIN
                         dbo.VariantProperty AS VariantProperty_3 ON dbo.Variant.PropertyId3 = VariantProperty_3.VariantPropertyId LEFT OUTER JOIN
                         dbo.VariantProperty AS VariantProperty_2 ON dbo.Variant.PropertyId2 = VariantProperty_2.VariantPropertyId LEFT OUTER JOIN
                         dbo.VariantProperty AS VariantProperty_1 ON dbo.Variant.PropertyId1 = VariantProperty_1.VariantPropertyId
WHERE        ((SELECT        HasVariant
                            FROM            dbo.Product AS p
                            WHERE        (ProductId = dbo.Variant.ProductId)) = 1)
GO
/****** Object:  Table [dbo].[VariantGroup]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariantGroup](
	[VariantGroupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_VariantGroup] PRIMARY KEY CLUSTERED 
(
	[VariantGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProductVariantWithGroupName]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductVariantWithGroupName]
AS
SELECT        dbo.ProductVariant.VariantId, dbo.ProductVariant.Barcode, dbo.ProductVariant.P1Name, dbo.ProductVariant.P1Id, dbo.ProductVariant.P1GroupId, dbo.ProductVariant.P2Id, dbo.ProductVariant.P2GroupId, 
                         dbo.ProductVariant.P2Name, dbo.ProductVariant.P3Id, dbo.ProductVariant.P3GroupId, dbo.ProductVariant.P3Name, dbo.ProductVariant.P4Id, dbo.ProductVariant.P4GroupId, dbo.ProductVariant.P4Name, dbo.ProductVariant.P5Id, 
                         dbo.ProductVariant.P5GroupId, dbo.ProductVariant.P5Name, dbo.VariantGroup.Name AS P1GroupName, VariantGroup_1.Name AS P2GroupName, VariantGroup_4.Name AS P3GroupName, 
                         VariantGroup_3.Name AS P4GroupName, VariantGroup_2.Name AS P5GroupName, dbo.ProductVariant.ProductId
FROM            dbo.ProductVariant LEFT OUTER JOIN
                         dbo.VariantGroup AS VariantGroup_2 ON dbo.ProductVariant.P5GroupId = VariantGroup_2.VariantGroupId LEFT OUTER JOIN
                         dbo.VariantGroup AS VariantGroup_1 ON dbo.ProductVariant.P2GroupId = VariantGroup_1.VariantGroupId LEFT OUTER JOIN
                         dbo.VariantGroup AS VariantGroup_3 ON dbo.ProductVariant.P4GroupId = VariantGroup_3.VariantGroupId LEFT OUTER JOIN
                         dbo.VariantGroup AS VariantGroup_4 ON dbo.ProductVariant.P3GroupId = VariantGroup_4.VariantGroupId LEFT OUTER JOIN
                         dbo.VariantGroup ON dbo.ProductVariant.P1GroupId = dbo.VariantGroup.VariantGroupId
GO
/****** Object:  Table [dbo].[PriceListGroup]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceListGroup](
	[PriceListGroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](25) NULL,
	[GroupType] [int] NULL,
 CONSTRAINT [PK_PriceListGroup] PRIMARY KEY CLUSTERED 
(
	[PriceListGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPriceList]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPriceList](
	[ProductPriceListId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PriceListGroupId] [int] NOT NULL,
	[Price] [decimal](15, 4) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[IsDefaultPrice] [bit] NOT NULL,
 CONSTRAINT [PK_ProductPriceList] PRIMARY KEY CLUSTERED 
(
	[ProductPriceListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwProductPriceList]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwProductPriceList]
AS
SELECT        dbo.Currency.CurrencyName, dbo.Currency.CurrencyCode, dbo.Product.ProductCode, dbo.Product.ProductName, dbo.Product.Barcode, dbo.PriceListGroup.GroupName, dbo.ProductPriceList.ProductPriceListId, 
                         dbo.ProductPriceList.ProductId, dbo.ProductPriceList.PriceListGroupId, dbo.ProductPriceList.Price, dbo.ProductPriceList.CurrencyId, dbo.ProductPriceList.IsDefaultPrice, dbo.PriceListGroup.GroupType
FROM            dbo.ProductPriceList INNER JOIN
                         dbo.Product ON dbo.ProductPriceList.ProductId = dbo.Product.ProductId INNER JOIN
                         dbo.PriceListGroup ON dbo.ProductPriceList.PriceListGroupId = dbo.PriceListGroup.PriceListGroupId INNER JOIN
                         dbo.Currency ON dbo.ProductPriceList.CurrencyId = dbo.Currency.CurrencyId
GO
/****** Object:  Table [dbo].[Order]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](25) NOT NULL,
	[CustomerCode] [nvarchar](25) NOT NULL,
	[DocNumber] [nvarchar](25) NULL,
	[OrderDate] [datetime] NULL,
	[OrderStatusId] [int] NULL,
	[TotalPrice] [decimal](10, 3) NULL,
	[TotalVal] [decimal](10, 3) NULL,
	[CurrencyId] [int] NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerSurname] [nvarchar](50) NULL,
	[CompanyName] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Mail] [nvarchar](50) NULL,
	[TaxNumber] [nchar](11) NULL,
	[TaxOffice] [nvarchar](25) NULL,
	[InvoiceCountryId] [int] NULL,
	[InvoiceRegionId] [int] NULL,
	[InvoiceCityId] [int] NULL,
	[InvoiceTownId] [int] NULL,
	[InvoiceAddress] [nvarchar](150) NULL,
	[InvoiceAddress2] [nvarchar](150) NULL,
	[DeliveryCountryId] [int] NULL,
	[DeliveryRegionId] [int] NULL,
	[DeliveryCityId] [int] NULL,
	[DeliveryTownId] [int] NULL,
	[DeliveryAddress] [nvarchar](150) NULL,
	[DeliveryAddress2] [nvarchar](150) NULL,
	[CreatedId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[OrderTypeId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusId] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatusName] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderType](
	[OrderTypeId] [int] IDENTITY(1,1) NOT NULL,
	[OrderTypeName] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VwOrder]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwOrder]
AS
SELECT        TOP (2147483647) dbo.[Order].OrderId, dbo.[Order].OrderCode, CASE WHEN isnull(dbo.[Order].CustomerCode, '') = '' THEN 'PRKND' ELSE dbo.[Order].CustomerCode END AS CustomerCode, dbo.[Order].DocNumber, 
                         dbo.[Order].OrderDate, dbo.[Order].OrderStatusId, dbo.[Order].TotalPrice, dbo.[Order].TotalVal, dbo.[Order].CurrencyId, dbo.[Order].CustomerId, dbo.[Order].CustomerName, dbo.[Order].CustomerSurname, 
                         dbo.[Order].CompanyName, dbo.[Order].Phone, dbo.[Order].Mail, dbo.[Order].TaxNumber, dbo.[Order].TaxOffice, dbo.[Order].InvoiceCountryId, dbo.[Order].InvoiceRegionId, dbo.[Order].InvoiceCityId, dbo.[Order].InvoiceTownId, 
                         dbo.[Order].InvoiceAddress, dbo.[Order].InvoiceAddress2, dbo.[Order].DeliveryCountryId, dbo.[Order].DeliveryRegionId, dbo.[Order].DeliveryCityId, dbo.[Order].DeliveryTownId, dbo.[Order].DeliveryAddress, 
                         dbo.[Order].DeliveryAddress2, dbo.[Order].CreatedId, dbo.[Order].CreatedDate, dbo.[Order].OrderTypeId, dbo.[Order].IsDeleted, dbo.OrderStatus.OrderStatusName, dbo.Currency.CurrencyName, dbo.Currency.CurrencyCode, 
                         dbo.OrderType.OrderTypeName, dbo.Country.Name AS InvoiceCountryName, dbo.City.Name AS InvoiceCityName, dbo.Town.Name AS InvoiceTownName, Country_1.Name AS DeliveryCountryName, 
                         City_1.Name AS DeliveryCityName, Town_1.Name AS DeliveryTownName
FROM            dbo.[Order] INNER JOIN
                         dbo.OrderStatus ON dbo.[Order].OrderStatusId = dbo.OrderStatus.OrderStatusId INNER JOIN
                         dbo.OrderType ON dbo.[Order].OrderTypeId = dbo.OrderType.OrderTypeId INNER JOIN
                         dbo.Currency ON dbo.[Order].CurrencyId = dbo.Currency.CurrencyId LEFT OUTER JOIN
                         dbo.Country ON dbo.[Order].InvoiceCountryId = dbo.Country.CountryId LEFT OUTER JOIN
                         dbo.City ON dbo.[Order].InvoiceCityId = dbo.City.CityId LEFT OUTER JOIN
                         dbo.Town ON dbo.[Order].InvoiceTownId = dbo.Town.TownId LEFT OUTER JOIN
                         dbo.Country AS Country_1 ON dbo.[Order].DeliveryCountryId = Country_1.CountryId LEFT OUTER JOIN
                         dbo.City AS City_1 ON dbo.[Order].DeliveryCityId = City_1.CityId LEFT OUTER JOIN
                         dbo.Town AS Town_1 ON dbo.[Order].DeliveryTownId = Town_1.TownId
ORDER BY dbo.[Order].OrderId DESC
GO
/****** Object:  Table [dbo].[Prefix]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prefix](
	[PrefixId] [int] IDENTITY(1,1) NOT NULL,
	[PrefixName] [nvarchar](50) NOT NULL,
	[PrefixCode] [nvarchar](25) NOT NULL,
	[PrefixLength] [int] NOT NULL,
	[CurrentValue] [int] NOT NULL,
 CONSTRAINT [PK_Prefix] PRIMARY KEY CLUSTERED 
(
	[PrefixId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ImagePath] [nvarchar](500) NULL,
	[LineNumber] [tinyint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ProductImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](25) NULL,
	[Surname] [nvarchar](25) NULL,
	[UserGroupId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupName] [nvarchar](15) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prefix] ADD  CONSTRAINT [DF_Prefix_CurrentValue]  DEFAULT ((0)) FOR [CurrentValue]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_HasVariant]  DEFAULT ((0)) FOR [HasVariant]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  StoredProcedure [dbo].[GetPrefix]    Script Date: 25.04.2022 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPrefix] 
	-- Add the parameters for the stored procedure here
	@prefixCode nvarchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @currentValue int,@length int
	select @currentValue=CurrentValue,@length=PrefixLength from prefix where PrefixCode=@prefixCode
	if ISNULL(@currentValue,-1)=-1 
	begin
	select null
	end
	else
	begin
	update prefix set CurrentValue=(@currentValue+1) where PrefixCode=@prefixCode
	select @prefixCode+replace(str(convert(nvarchar(6),@currentValue),@length-len(@prefixCode)),space(1),'0')
	end
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-Perakende    2-Toptan    3-Internet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PriceListGroup', @level2type=N'COLUMN',@level2name=N'GroupType'
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
         Configuration = "(H (1[41] 4[45] 2) )"
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
         Configuration = "(H (4[60] 2) )"
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
         Configuration = "(V (2) )"
      End
      ActivePaneConfig = 14
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Variant"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantProperty"
            Begin Extent = 
               Top = 535
               Left = 436
               Bottom = 665
               Right = 617
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantProperty_4"
            Begin Extent = 
               Top = 401
               Left = 434
               Bottom = 531
               Right = 615
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantProperty_3"
            Begin Extent = 
               Top = 267
               Left = 432
               Bottom = 397
               Right = 613
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantProperty_2"
            Begin Extent = 
               Top = 136
               Left = 429
               Bottom = 266
               Right = 610
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantProperty_1"
            Begin Extent = 
               Top = 0
               Left = 433
               Bottom = 130
               Right = 614
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 2265
         Alias = 1740
         Table = 2850
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[16] 2[17] 3) )"
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
      ActivePaneConfig = 8
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "VariantGroup"
            Begin Extent = 
               Top = 0
               Left = 274
               Bottom = 113
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantGroup_1"
            Begin Extent = 
               Top = 354
               Left = 341
               Bottom = 467
               Right = 511
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantGroup_4"
            Begin Extent = 
               Top = 46
               Left = 559
               Bottom = 159
               Right = 729
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantGroup_3"
            Begin Extent = 
               Top = 178
               Left = 770
               Bottom = 291
               Right = 940
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VariantGroup_2"
            Begin Extent = 
               Top = 297
               Left = 590
               Bottom = 410
               Right = 760
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductVariant"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 375
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Be' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariantWithGroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'gin ColumnWidths = 11
         Column = 1440
         Alias = 3930
         Table = 2295
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariantWithGroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ProductVariantWithGroupName'
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
         Begin Table = "Customer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 264
               Bottom = 102
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 102
               Left = 264
               Bottom = 232
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Town"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 251
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 234
               Left = 246
               Bottom = 347
               Right = 416
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
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwCustomer'
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
         Begin Table = "Customer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 191
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CustomerDetail"
            Begin Extent = 
               Top = 6
               Left = 264
               Bottom = 136
               Right = 445
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CustomerDetailType"
            Begin Extent = 
               Top = 67
               Left = 506
               Bottom = 213
               Right = 712
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
         Column = 2175
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwCustomerDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwCustomerDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[17] 2[33] 3) )"
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
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderStatus"
            Begin Extent = 
               Top = 0
               Left = 1307
               Bottom = 113
               Right = 1490
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderType"
            Begin Extent = 
               Top = 385
               Left = 37
               Bottom = 498
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 4
               Left = 4
               Bottom = 134
               Right = 174
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 86
               Left = 663
               Bottom = 182
               Right = 833
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 171
               Left = 987
               Bottom = 301
               Right = 1157
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Town"
            Begin Extent = 
               Top = 389
               Left = 1094
               Bottom = 502
               Right = 1264
            End
            DisplayFlags = 280' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
            TopColumn = 0
         End
         Begin Table = "Country_1"
            Begin Extent = 
               Top = 412
               Left = 694
               Bottom = 508
               Right = 864
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City_1"
            Begin Extent = 
               Top = 411
               Left = 375
               Bottom = 541
               Right = 545
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Town_1"
            Begin Extent = 
               Top = 0
               Left = 455
               Bottom = 113
               Right = 625
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
         Column = 2655
         Alias = 2550
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrder'
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
         Begin Table = "Currency"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderDetail"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 323
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 119
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Variant"
            Begin Extent = 
               Top = 125
               Left = 745
               Bottom = 364
               Right = 915
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Warehouse"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 119
               Right = 1050
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
         Or = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrderDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrderDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwOrderDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[24] 2[20] 3) )"
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
         Begin Table = "Product"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 266
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 25
               Left = 452
               Bottom = 227
               Right = 622
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
         Alias = 1620
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProduct'
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
      ActivePaneConfig = 8
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 317
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 11
               Left = 523
               Bottom = 141
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 144
               Left = 698
               Bottom = 274
               Right = 886
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unit"
            Begin Extent = 
               Top = 284
               Left = 789
               Bottom = 397
               Right = 959
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Warehouse"
            Begin Extent = 
               Top = 356
               Left = 250
               Bottom = 469
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 314
               Left = 484
               Bottom = 444
               Right = 654
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Column = 1440
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductDetails'
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
         Begin Table = "ProductPriceList"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 181
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 0
               Left = 590
               Bottom = 130
               Right = 760
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PriceListGroup"
            Begin Extent = 
               Top = 144
               Left = 883
               Bottom = 257
               Right = 1059
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 188
               Left = 420
               Bottom = 318
               Right = 590
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductPriceList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductPriceList'
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
         Begin Table = "VwProductDetails"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 262
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 15
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
      Begin ColumnWidths = 12
         Column = 2205
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductStockInWarehouse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwProductStockInWarehouse'
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
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 20
               Left = 453
               Bottom = 116
               Right = 623
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 174
               Left = 496
               Bottom = 304
               Right = 666
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 131
               Left = 1064
               Bottom = 261
               Right = 1234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Town"
            Begin Extent = 
               Top = 6
               Left = 885
               Bottom = 119
               Right = 1055
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Region"
            Begin Extent = 
               Top = 206
               Left = 86
               Bottom = 319
               Right = 256
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
      Begin ColumnWidths = 27
         Width = 284
         Width = 1500
         Width = 1500
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 3075
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwSupplier'
GO
