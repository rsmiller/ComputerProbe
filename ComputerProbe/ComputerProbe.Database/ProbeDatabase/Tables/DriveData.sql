CREATE TABLE [dbo].[DriveData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[DriveData] [nvarchar](500) NULL,
	[DriveType] [nvarchar](500) NULL,
	[VolumeLabel] [nvarchar](500) NULL,
	[DriveFormat] [nvarchar](500) NULL,
	[UserAvailableSpace] [nvarchar](500) NULL,
	[AvailableSpace] [bigint] NULL,
	[TotalSpace] [bigint] NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_DriveData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DriveData]  WITH CHECK ADD  CONSTRAINT [FK_DriveData_ProbeData] FOREIGN KEY([ProbeDataId])
REFERENCES [dbo].[ProbeData] ([Id])
GO

ALTER TABLE [dbo].[DriveData] CHECK CONSTRAINT [FK_DriveData_ProbeData]
GO

