CREATE TABLE [dbo].[Request](
	[RequestId] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestTitle] [nvarchar](400) NOT NULL,
	[RequestDetials] [nvarchar](600) NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[Comments] [nvarchar](400) NULL,
	[CreateUserId] [nvarchar](50) NOT NULL,
	[UpdateUserId] [nvarchar](50) NOT NULL,
	[CreateDttm] [datetime] NOT NULL,
	[UpdateDttm] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

