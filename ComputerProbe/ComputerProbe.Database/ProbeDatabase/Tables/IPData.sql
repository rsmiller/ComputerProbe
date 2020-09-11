CREATE TABLE [dbo].[IPData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[InternalAddress] [nvarchar](500) NOT NULL,
	[ExternalAddress] [nvarchar](500) NOT NULL,
	[Host] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_IPData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IPData]  WITH CHECK ADD  CONSTRAINT [FK_IPData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[IPData] CHECK CONSTRAINT [FK_IPData_ProbeData]
GO

