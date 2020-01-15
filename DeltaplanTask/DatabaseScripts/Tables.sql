USE [DP_Main]
GO

/****** Object:  Table [dbo].[dt_Tech]    Script Date: 26.03.2019 12:03:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ref_MediaType](
	[MediaType_ID] [smallint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FK_ref_MediaGroup_ID] [smallint] NOT NULL,
	[MediaType] [nvarchar](50) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [ref_Media_PK] PRIMARY KEY CLUSTERED ([MediaType_ID] ASC) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[dt_Base](
	[Object_UID] [nvarchar](32) NOT NULL,
	[Object_UID_Oper] [nvarchar](32) NULL,
	[dt_Geo_Object_GeoUID] [nvarchar](32) NULL,
	[FK_ref_MediaType_ID] [smallint] NULL,
	[FK_ref_MediaNetwork_ID] [int] NULL,
	[FK_ref_Partner_ID] [int] NULL,
	[FK_ref_UrFace_ID] [int] NULL,
	[FK_ref_License_ID] [int] NULL,
	[Legacy_ID] [nvarchar](50) NULL,
	[Common_ID] [nvarchar](50) NULL,
	[ObjectName] [nvarchar](150) NULL,
	[Reference] [nvarchar](4000) NULL,
	[URL_Photo] [nvarchar](2000) NULL,
	[URL_Schema] [nvarchar](2000) NULL,
	[URL_Presentation] [nvarchar](2000) NULL,
	[Autor_ID] [int] NULL,
	[EntryDate] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DateDelete] [date] NULL,
 CONSTRAINT [PK_dt_Basic] PRIMARY KEY CLUSTERED ([Object_UID] ASC) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[dt_Base] ADD  CONSTRAINT [DF_dt_Base_Object_UID]  DEFAULT (N'=replace(newid(),''-'','')''') FOR [Object_UID]
GO

ALTER TABLE [dbo].[dt_Base] ADD  CONSTRAINT [DF_dt_Basic_Actuate_Date]  DEFAULT (getdate()) FOR [EntryDate]
GO

ALTER TABLE [dbo].[dt_Base] ADD  CONSTRAINT [DF_dt_Base_LastUpdateDate]  DEFAULT (getdate()) FOR [LastUpdate]
GO

ALTER TABLE [dbo].[dt_Base] ADD  CONSTRAINT [DF_dt_Basic_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[dt_Base]  WITH CHECK ADD  CONSTRAINT [FK_dt_Base_FK_MediaType] FOREIGN KEY([FK_ref_MediaType_ID])
REFERENCES [dbo].[ref_MediaType] ([MediaType_ID])
GO

CREATE TABLE [dbo].[dt_Tech](
	[dt_Base_Object_UID] [nvarchar](32) NOT NULL,
	[Version] [smallint] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Autor_ID] [int] NULL,
	[FK_ref_Exposition_Type_ID] [int] NULL,
	[FK_ref_SideType_ID] [int] NULL,
	[FK_ref_Side_ID] [int] NULL,
	[FK_ref_Size_ID] [int] NULL,
	[FK_ref_ConstrType_ID] [smallint] NULL,
	[FK_v_ref_InstallationTypeID] [int] NULL,
	[FK_v_ref_PlacementTypeID] [int] NULL,
	[Width] [numeric](10, 3) NULL,
	[Height] [numeric](10, 3) NULL,
	[Requirements] [nvarchar](2000) NULL,
	[Image] [nvarchar](2000) NULL,
	[Materials] [nvarchar](2000) NULL,
	[Light] [tinyint] NULL,
	[Param01] [float] NULL,
	[Param02] [float] NULL,
	[Param03] [float] NULL,
	[Param04] [float] NULL,
 CONSTRAINT [PK_dt_Tech] PRIMARY KEY CLUSTERED ([dt_Base_Object_UID] ASC,[Version] ASC) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[dt_Tech] ADD  CONSTRAINT [DF_dt_Tech_Version]  DEFAULT ((0)) FOR [Version]
GO

ALTER TABLE [dbo].[dt_Tech] ADD  CONSTRAINT [DF_dt_Tech_Date_Actuate]  DEFAULT (getdate()) FOR [EntryDate]
GO

ALTER TABLE [dbo].[dt_Tech]  WITH CHECK ADD  CONSTRAINT [FK_dt_Tech_dt_Base] FOREIGN KEY([dt_Base_Object_UID])
REFERENCES [dbo].[dt_Base] ([Object_UID])
GO

CREATE TABLE [dbo].[ref_Partners](
	[Partner_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_ref_Partner_ID] [int] NULL,
	[PartnerName] [nvarchar](250) NOT NULL,
	[PartnerNameFull] [nvarchar](500) NOT NULL,
	[Synonyms] [nvarchar](250) NULL,
	[Status_ID] [int] NOT NULL,
	[IsClient] [bit] NOT NULL,
	[IsSupplier] [bit] NOT NULL,
	[IsOpex] [bit] NOT NULL,
	[IsCompetitor] [bit] NOT NULL,
	[IsCarrier] [bit] NOT NULL,
	[MainEmployer_ID] [int] NOT NULL,
	[WithoutContractSupplier] [bit] NOT NULL,
	[WithoutContractClient] [bit] NOT NULL,
	[Category_Clnt_ID] [int] NULL,
	[Category_Supp_ID] [int] NULL,
	[IsPrivatePerson] [bit] NOT NULL,
	[PP_Sex] [nvarchar](1) NULL,
	[PP_Birthday] [date] NULL,
	[Keywords] [nvarchar](500) NULL,
	[Category_Clnt_Comment] [nvarchar](500) NULL,
	[Category_Supp_Comment] [nvarchar](500) NULL,
	[Comments] [nvarchar](max) NULL,
	[Conditions] [nvarchar](max) NULL,
	[EntryDate] [datetime] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ref_Partners] PRIMARY KEY CLUSTERED ([Partner_ID] ASC) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ref_Partners] ADD  CONSTRAINT [DF_ref_Partners_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO

ALTER TABLE [dbo].[ref_Partners] ADD  CONSTRAINT [DF_krn_Partners_LastUpdate]  DEFAULT (getdate()) FOR [LastUpdate]
GO

ALTER TABLE [dbo].[ref_Partners] ADD  CONSTRAINT [DF_ref_Partners_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

CREATE TABLE [dbo].[stm_api_Clients](
	[Client_ID] [int] NOT NULL,
	[ClientName] [nvarchar](150) NOT NULL,
	[API_KEY] [nvarchar](250) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ExpirationDate] [date] NULL,
 CONSTRAINT [PK_ext_api_Clients] PRIMARY KEY CLUSTERED 
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[stm_api_Clients] ADD  CONSTRAINT [DF_ext_api_Clients_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO