CREATE TABLE [dbo].[RAMData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Size] [bigint] NOT NULL,
	[Part] [nvarchar](150) NOT NULL,
	[SerialNumber] [nvarchar](150) NOT NULL,
	[MemoryType] [nvarchar](150) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_RAMData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RAMData]  WITH CHECK ADD  CONSTRAINT [FK_RAMData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[RAMData] CHECK CONSTRAINT [FK_RAMData_ProbeData]
GO
