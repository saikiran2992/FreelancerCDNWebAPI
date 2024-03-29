USE [RegisterationForm]
GO
ALTER TABLE [dbo].[UserSkills] DROP CONSTRAINT [FK_UserSkills_User_UserId]
GO
ALTER TABLE [dbo].[UserSkills] DROP CONSTRAINT [FK_UserSkills_Skill_SkillId]
GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 06-01-2024 20:45:27 ******/
DROP TABLE [dbo].[UserSkills]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06-01-2024 20:45:27 ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 06-01-2024 20:45:27 ******/
DROP TABLE [dbo].[Skill]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 06-01-2024 20:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06-01-2024 20:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Hobby] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 06-01-2024 20:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_UserSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Skill] ON 
GO
INSERT [dbo].[Skill] ([Id], [Title]) VALUES (1, N'Dotnet')
GO
INSERT [dbo].[Skill] ([Id], [Title]) VALUES (2, N'Java')
GO
INSERT [dbo].[Skill] ([Id], [Title]) VALUES (3, N'SQL')
GO
INSERT [dbo].[Skill] ([Id], [Title]) VALUES (4, N'ReactJS')
GO
INSERT [dbo].[Skill] ([Id], [Title]) VALUES (5, N'Project Management')
GO
SET IDENTITY_INSERT [dbo].[Skill] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Username], [Email], [Phone], [Hobby]) VALUES (1, N'Sai', N'sai@gmail.com', N'1111111111', N'Playing Batminton')
GO
INSERT [dbo].[User] ([Id], [Username], [Email], [Phone], [Hobby]) VALUES (2, N'Mohana', N'mona@gmail.com', N'2222222222', N'Cooking')
GO
INSERT [dbo].[User] ([Id], [Username], [Email], [Phone], [Hobby]) VALUES (3, N'Jai', N'jai@gmail.com', N'3333333333', N'Coding')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserSkills] ON 
GO
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId]) VALUES (3, 2, 3)
GO
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId]) VALUES (4, 3, 4)
GO
INSERT [dbo].[UserSkills] ([Id], [UserId], [SkillId]) VALUES (5, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[UserSkills] OFF
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_Skill_SkillId] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_Skill_SkillId]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_User_UserId]
GO
