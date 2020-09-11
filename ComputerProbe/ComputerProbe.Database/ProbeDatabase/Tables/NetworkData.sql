CREATE TABLE [dbo].[NetworkData](
	[Id] [int] NOT NULL,
	[ProbeDataId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Type] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_NetworkData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[NetworkData]  WITH CHECK ADD  CONSTRAINT [FK_NetworkData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[NetworkData] CHECK CONSTRAINT [FK_NetworkData_ProbeData]
GO

