DROP TABLE IF EXISTS [dbo].[Unit]
GO
DROP TABLE IF EXISTS [dbo].[SuspendedProduct]
GO
DROP TABLE IF EXISTS [dbo].[SpeciesSynonym]
GO
DROP TABLE IF EXISTS [dbo].[Species]
GO
DROP TABLE IF EXISTS [dbo].[ReferenceProductTargetSpecies]
GO
DROP TABLE IF EXISTS [dbo].[ReferenceProductActiveSubstance]
GO
DROP TABLE IF EXISTS [dbo].[ReferenceProduct]
GO
DROP TABLE IF EXISTS [dbo].[PackageType]
GO
DROP TABLE IF EXISTS [dbo].[PackagedProduct]
GO
DROP TABLE IF EXISTS [dbo].[Package]
GO
DROP TABLE IF EXISTS [dbo].[HomoeopathicProduct]
GO
DROP TABLE IF EXISTS [dbo].[ExpiredProduct]
GO
DROP TABLE IF EXISTS [dbo].[Distributor]
GO
DROP TABLE IF EXISTS [dbo].[CurrentlyAuthorisedProductDistributor]
GO
DROP TABLE IF EXISTS [dbo].[CurrentlyAuthorisedProduct]
GO
DROP TABLE IF EXISTS [dbo].[ActiveSubstance]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveSubstance](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentlyAuthorisedProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[ControlledDrug] [nvarchar](255) NOT NULL,
	[DistributionCategory] [nvarchar](255) NOT NULL,
	[PharmaceuticalForm] [nvarchar](255) NOT NULL,
	[TherapeuticGroup] [nvarchar](255) NOT NULL,
	[SPC_Link] [nvarchar](max) NOT NULL,
	[UKPAR_Link] [nvarchar](max) NOT NULL,
	[PAAR_Link] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentlyAuthorisedProductDistributor](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[CurrentlyAuthorisedProduct] [uniqueidentifier] NOT NULL,
	[Distributor] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributor](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpiredProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[DateOfExpiration] [datetime] NOT NULL,
	[SPC_Link] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomoeopathicProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[DateOfSuspension] [datetime] NOT NULL,
	[ControlledDrug] [nvarchar](255) NOT NULL,
	[DistributionCategory] [nvarchar](255) NOT NULL,
	[PharmaceuticalForm] [nvarchar](255) NOT NULL,
	[TherapeuticGroup] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[PackageType] [uniqueidentifier] NOT NULL,
	[PackageSize] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackagedProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Product] [uniqueidentifier] NULL,
	[Package] [uniqueidentifier] NULL,
	[Expiry] [datetime] NULL,
	[Batch] [nvarchar](255) NULL,
	[GTIN] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageType](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Unit] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[MAHolder] [nvarchar](max) NOT NULL,
	[VMNo] [nvarchar](255) NOT NULL,
	[AuthorisationRoute] [nvarchar](255) NOT NULL,
	[DateOfIssue] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[VMNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceProductActiveSubstance](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[ReferenceProduct] [uniqueidentifier] NOT NULL,
	[ActiveSubstance] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceProductTargetSpecies](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[ReferenceProduct] [uniqueidentifier] NOT NULL,
	[TargetSpecies] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Species](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpeciesSynonym](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[CanonicalName] [uniqueidentifier] NULL,
	[Synonym] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuspendedProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[DateOfSuspension] [datetime] NOT NULL,
	[ControlledDrug] [nvarchar](255) NOT NULL,
	[DistributionCategory] [nvarchar](255) NOT NULL,
	[PharmaceuticalForm] [nvarchar](255) NOT NULL,
	[TherapeuticGroup] [nvarchar](255) NOT NULL,
	[SPC_Link] [nvarchar](max) NOT NULL,
	[UKPAR_Link] [nvarchar](max) NOT NULL,
	[PAAR_Link] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[ID] [uniqueidentifier] NOT NULL,
	[createdon] [datetime] NOT NULL,
	[updatedon] [datetime] NOT NULL,
	[createdby] [sysname] NOT NULL,
	[updatedby] [sysname] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActiveSubstance] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ActiveSubstance] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[ActiveSubstance] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[ActiveSubstance] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[ActiveSubstance] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[Distributor] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Distributor] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[Distributor] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[Distributor] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[Distributor] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[ExpiredProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[ExpiredProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[ExpiredProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[ExpiredProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[HomoeopathicProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[HomoeopathicProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[HomoeopathicProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[HomoeopathicProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[Package] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Package] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[Package] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[Package] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[Package] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[PackageType] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[PackageType] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[PackageType] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[PackageType] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[PackageType] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[ReferenceProduct] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ReferenceProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[ReferenceProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[ReferenceProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[ReferenceProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[Species] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Species] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[Species] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[Species] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[Species] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[SpeciesSynonym] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[SpeciesSynonym] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[SpeciesSynonym] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[SpeciesSynonym] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[SpeciesSynonym] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[SuspendedProduct] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[SuspendedProduct] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[SuspendedProduct] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[SuspendedProduct] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT (getdate()) FOR [createdon]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT (getdate()) FOR [updatedon]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT (suser_sname()) FOR [createdby]
GO
ALTER TABLE [dbo].[Unit] ADD  DEFAULT (suser_sname()) FOR [updatedby]
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProduct]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor]  WITH CHECK ADD FOREIGN KEY([CurrentlyAuthorisedProduct])
REFERENCES [dbo].[CurrentlyAuthorisedProduct] ([ID])
GO
ALTER TABLE [dbo].[CurrentlyAuthorisedProductDistributor]  WITH CHECK ADD FOREIGN KEY([Distributor])
REFERENCES [dbo].[Distributor] ([ID])
GO
ALTER TABLE [dbo].[ExpiredProduct]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[HomoeopathicProduct]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD FOREIGN KEY([PackageType])
REFERENCES [dbo].[PackageType] ([ID])
GO
ALTER TABLE [dbo].[PackagedProduct]  WITH CHECK ADD FOREIGN KEY([Package])
REFERENCES [dbo].[Package] ([ID])
GO
ALTER TABLE [dbo].[PackagedProduct]  WITH CHECK ADD FOREIGN KEY([Product])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[PackagedProduct]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[PackageType]  WITH CHECK ADD FOREIGN KEY([Unit])
REFERENCES [dbo].[Unit] ([ID])
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance]  WITH CHECK ADD FOREIGN KEY([ActiveSubstance])
REFERENCES [dbo].[ActiveSubstance] ([ID])
GO
ALTER TABLE [dbo].[ReferenceProductActiveSubstance]  WITH CHECK ADD FOREIGN KEY([ReferenceProduct])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies]  WITH CHECK ADD FOREIGN KEY([ReferenceProduct])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO
ALTER TABLE [dbo].[ReferenceProductTargetSpecies]  WITH CHECK ADD FOREIGN KEY([TargetSpecies])
REFERENCES [dbo].[Species] ([ID])
GO
ALTER TABLE [dbo].[SpeciesSynonym]  WITH CHECK ADD FOREIGN KEY([CanonicalName])
REFERENCES [dbo].[Species] ([ID])
GO
ALTER TABLE [dbo].[SpeciesSynonym]  WITH CHECK ADD FOREIGN KEY([Synonym])
REFERENCES [dbo].[Species] ([ID])
GO
ALTER TABLE [dbo].[SuspendedProduct]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[ReferenceProduct] ([ID])
GO