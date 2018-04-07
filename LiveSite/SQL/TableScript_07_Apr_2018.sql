-- Alter Table Script

alter table Idv_chetana_Account_main add [STATE_CODE] [nvarchar](10) NULL
alter table Idv_chetana_Account_main add [GST_NO] [nvarchar](20) NULL,
alter table Idv_chetana_Account_main add [APPLICABLE_GST] [nvarchar](100) NULL,


-- Create Table

CREATE TABLE [dbo].[tblSupplierBill](
	[SBillID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [nvarchar](50) NULL,
	[PurchaseCode] [nvarchar](50) NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[InvoiceDate] [datetime] NULL,
	[GSTPer] [int] NULL,
	[FY] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblSupplierBill] PRIMARY KEY CLUSTERED 
(
	[SBillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



CREATE TABLE [dbo].[tblSupplierBillDetails](
	[SBillDID] [int] IDENTITY(1,1) NOT NULL,
	[SBillID] [nvarchar](50) NULL,
	[AccountCode] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 0) NULL,
	[Remark] [varchar](500) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblSupplierBillDetails] PRIMARY KEY CLUSTERED 
(
	[SBillDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

