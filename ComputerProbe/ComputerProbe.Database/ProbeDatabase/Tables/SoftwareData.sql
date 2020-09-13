
CREATE TABLE [dbo].[SoftwareData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Vendor] [nvarchar](500) NULL,
	[Version] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_SoftwareData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SoftwareData]  WITH CHECK ADD  CONSTRAINT [FK_SoftwareData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[SoftwareData] CHECK CONSTRAINT [FK_SoftwareData_ProbeData]
GO

