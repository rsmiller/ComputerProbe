CREATE TABLE [dbo].[OSData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[CountryCode] [nvarchar](500) NULL,
	[EncryptionLevel] [nvarchar](500) NULL,
	[Version] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_OSData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OSData]  WITH CHECK ADD  CONSTRAINT [FK_OSData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[OSData] CHECK CONSTRAINT [FK_OSData_ProbeData]
GO