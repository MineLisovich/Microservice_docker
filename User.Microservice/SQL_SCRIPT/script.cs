/*
 
 create database UserMicro_Db


USE [UserMicro_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageForUser] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserEntity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230713141629_userMicro', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[UserEntity] ON 

INSERT [dbo].[UserEntity] ([Id], [MessageForUser]) VALUES (1, N'Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER')
INSERT [dbo].[UserEntity] ([Id], [MessageForUser]) VALUES (2, N'Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER(2)')
SET IDENTITY_INSERT [dbo].[UserEntity] OFF
GO

 
 */