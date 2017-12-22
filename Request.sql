--create database
CREATE DATABASE Phoenix


--create table
USE [Phoenix]
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [varchar] (40) NOT NULL,
	[RequestTitle] [nvarchar](400) NOT NULL,
	[RequestDetail] [nvarchar](600) NOT NULL,
	[Comments] [nvarchar](400) NULL,
	[RequestStatus] [int] NOT NULL,
        [EditDttm] [datetime]NOT NULL 
PRIMARY KEY CLUSTERED 
(
	[RequestId]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

