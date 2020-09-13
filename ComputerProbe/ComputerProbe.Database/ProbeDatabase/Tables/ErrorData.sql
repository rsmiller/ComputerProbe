USE [AssetDatabase]
GO

/****** Object:  Table [dbo].[ErrorData]    Script Date: 9/13/2020 7:36:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProbeDataId] [int] NOT NULL,
	[Step] [nvarchar](500) NULL,
	[Execption] [nvarchar](1500) NULL,
	[InnerExecption] [nvarchar](1500) NULL,
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

