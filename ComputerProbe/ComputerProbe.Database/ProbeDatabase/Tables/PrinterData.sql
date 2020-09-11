CREATE TABLE [dbo].[PrinterData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Network] [nvarchar](500) NULL,
	[Availability] [nvarchar](500) NULL,
	[IsDefault] [nvarchar](500) NULL,
	[DeviceID] [nvarchar](500) NULL,
	[Status] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PrinterData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PrinterData]  WITH CHECK ADD  CONSTRAINT [FK_PrinterData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[PrinterData] CHECK CONSTRAINT [FK_PrinterData_ProbeData]
GO