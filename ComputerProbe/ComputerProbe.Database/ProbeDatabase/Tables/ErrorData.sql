CREATE TABLE [dbo].[ErrorData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Step] [nvarchar](500) NULL,
	[Exception] [nvarchar](1500) NULL,
	[InnerException] [nvarchar](1500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ErrorData]  WITH CHECK ADD  CONSTRAINT [FK_ErrorData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[ErrorData] CHECK CONSTRAINT [FK_ErrorData_ProbeData]
GO

