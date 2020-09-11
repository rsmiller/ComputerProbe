CREATE TABLE [dbo].[ProcessorData](
	[Id] [int] NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[DeviceId] [nvarchar](500) NULL,
	[CurrentClockSpeed] [nvarchar](200) NULL,
	[NumberOfCores] [nvarchar](100) NULL,
	[AddressWidth] [nvarchar](100) NULL,
	[NumberOfEnabledCores] [nvarchar](100) NULL,
	[NumberOfLogicalProcessors] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProcessorData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProcessorData]  WITH CHECK ADD  CONSTRAINT [FK_ProcessorData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[ProcessorData] CHECK CONSTRAINT [FK_ProcessorData_ProbeData]
GO

