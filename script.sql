USE [master]
GO
/****** Object:  Database [PlanDaily]    Script Date: 23/06/2018 5:29:46 CH ******/
CREATE DATABASE [PlanDaily]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PlanDaily', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PlanDaily.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PlanDaily_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PlanDaily_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PlanDaily] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PlanDaily].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PlanDaily] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PlanDaily] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PlanDaily] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PlanDaily] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PlanDaily] SET ARITHABORT OFF 
GO
ALTER DATABASE [PlanDaily] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PlanDaily] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PlanDaily] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PlanDaily] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PlanDaily] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PlanDaily] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PlanDaily] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PlanDaily] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PlanDaily] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PlanDaily] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PlanDaily] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PlanDaily] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PlanDaily] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PlanDaily] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PlanDaily] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PlanDaily] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PlanDaily] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PlanDaily] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PlanDaily] SET  MULTI_USER 
GO
ALTER DATABASE [PlanDaily] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PlanDaily] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PlanDaily] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PlanDaily] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PlanDaily] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PlanDaily]
GO
/****** Object:  Table [dbo].[Plans]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plans](
	[PlanId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[FinishRate] [float] NULL,
	[Create_At] [datetime] NULL,
 CONSTRAINT [PK_Plans] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report_Plan]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report_Plan](
	[Report_Plane_Id] [uniqueidentifier] NOT NULL,
	[ReportId] [uniqueidentifier] NOT NULL,
	[PlanId] [uniqueidentifier] NOT NULL,
	[FinishDate] [date] NULL,
 CONSTRAINT [PK_Report_Plane] PRIMARY KEY CLUSTERED 
(
	[Report_Plane_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportItems]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportItems](
	[ReportId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Du_dinh] [nvarchar](max) NULL,
	[IsFinish] [bit] NULL,
	[Ke_hoach] [nvarchar](max) NOT NULL,
	[Issue] [nvarchar](max) NULL,
	[Created_At] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Reports]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Reports](
	[User_Report_Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ReportId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User_Reports] PRIMARY KEY CLUSTERED 
(
	[User_Report_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Create_At] [datetime] NULL,
	[ReportReceiver] [uniqueidentifier] NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Plans] ADD  CONSTRAINT [DF_Plans_PlanId]  DEFAULT (newid()) FOR [PlanId]
GO
ALTER TABLE [dbo].[Report_Plan] ADD  CONSTRAINT [DF_Report_Plane_Report_Plane]  DEFAULT (newid()) FOR [Report_Plane_Id]
GO
ALTER TABLE [dbo].[ReportItems] ADD  CONSTRAINT [DF_ReportItems_ReportId]  DEFAULT (newid()) FOR [ReportId]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_RoleId]  DEFAULT ((0)) FOR [RoleId]
GO
ALTER TABLE [dbo].[User_Reports] ADD  CONSTRAINT [DF_User_Reports_User_Report_Id]  DEFAULT (newid()) FOR [User_Report_Id]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserId]  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[Report_Plan]  WITH CHECK ADD  CONSTRAINT [FK_Report_Plane_Plans] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plans] ([PlanId])
GO
ALTER TABLE [dbo].[Report_Plan] CHECK CONSTRAINT [FK_Report_Plane_Plans]
GO
ALTER TABLE [dbo].[ReportItems]  WITH CHECK ADD  CONSTRAINT [FK_ReportItems_Report_Plane] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Report_Plan] ([Report_Plane_Id])
GO
ALTER TABLE [dbo].[ReportItems] CHECK CONSTRAINT [FK_ReportItems_Report_Plane]
GO
ALTER TABLE [dbo].[ReportItems]  WITH CHECK ADD  CONSTRAINT [FK_ReportItems_User_Reports] FOREIGN KEY([ReportId])
REFERENCES [dbo].[User_Reports] ([User_Report_Id])
GO
ALTER TABLE [dbo].[ReportItems] CHECK CONSTRAINT [FK_ReportItems_User_Reports]
GO
ALTER TABLE [dbo].[User_Reports]  WITH CHECK ADD  CONSTRAINT [FK_User_Reports_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[User_Reports] CHECK CONSTRAINT [FK_User_Reports_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Plane_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Delete]
@id uniqueidentifier
AS
BEGIN
	Delete from Plans
	where PlanId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Plane_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Insert]
@id uniqueidentifier,
@title nvarchar(500),
@description nvarchar(max),
@finishrate float,
@createdate datetime 
AS
BEGIN
	insert into Plans(PlanId,Title,Description,FinishRate,Create_At)
	values(@id,@title,@description,@finishrate,@createdate)
END

GO
/****** Object:  StoredProcedure [dbo].[Plane_Select_all]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Select_all]
AS
BEGIN
	Select * from Plans
END

GO
/****** Object:  StoredProcedure [dbo].[Plane_Select_by_id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Select_by_id]
@id uniqueidentifier
AS
BEGIN
	Select * from Plans
	where PlanId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Plane_Select_by_paging_With_search]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Select_by_paging_With_search]
	@KeyString nvarchar(500),
	@start int,
	@length int
AS
BEGIN
	IF @KeyString Is Null
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			PlanId,Title,Description,FinishRate,Create_At,
			ROW_NUMBER() OVER (ORDER BY Create_At asc) as RC 
			FROM Plans
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
	ELSE
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			PlanId,Title,Description,FinishRate,Create_At,
			ROW_NUMBER() OVER (ORDER BY Create_At asc) as RC 
			FROM Plans WHERE Title LIKE '%' + @KeyString + '%'
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Plane_Update]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Plane_Update]
@id uniqueidentifier,
@title nvarchar(500),
@description nvarchar(max),
@finishrate float,
@createdate datetime 
AS
BEGIN
	Update Plans
	set Title = @title, Description = @description, FinishRate = @finishrate, Create_At = @createdate
	where PlanId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Report_Plan_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_Plan_Delete]
@id uniqueidentifier
AS
BEGIN
	delete from Report_Plan
	where Report_Plane_Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Report_Plan_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_Plan_Insert]
@id uniqueidentifier,
@reportId uniqueidentifier,
@planid uniqueidentifier,
@finishdate date
AS
BEGIN
	insert into Report_Plan(Report_Plane_Id,ReportId,PlanId,FinishDate)
	values(@id,@reportId,@planid,@finishdate)
END

GO
/****** Object:  StoredProcedure [dbo].[Report_Plan_Select_all]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_Plan_Select_all]
AS
BEGIN
	select * from Report_Plan
END
GO
/****** Object:  StoredProcedure [dbo].[Report_Plan_Select_by_id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report_Plan_Select_by_id]
@id uniqueidentifier
AS
BEGIN
	select * from Report_Plan
	where Report_Plane_Id = @id 
END

GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Delete]
@id uniqueidentifier
AS
BEGIN
	delete from ReportItems
	where ReportId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Insert]
@id uniqueidentifier,
@title nvarchar(250),
@du_dinh nvarchar(max),
@isfinish bit,
@kehoach nvarchar(max),
@issue nvarchar(max),
@createdate datetime
AS
BEGIN
	insert into ReportItems(ReportId,Title,Du_dinh,IsFinish,Ke_hoach,Issue,Created_At)
	values(@id,@title,@du_dinh,@isfinish,@kehoach,@issue,@createdate)
END
GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Select_All]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Select_All]
AS
BEGIN
	select * from ReportItems
END

GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Select_by_Id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Select_by_Id]
@id uniqueidentifier
AS
BEGIN
	select * from ReportItems
	where ReportId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Select_by_paging_With_search]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Select_by_paging_With_search]
	@KeyString nvarchar(250),
	@start int,
	@length int
AS
BEGIN
	IF @KeyString Is Null
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			ReportId,Title,Du_dinh,IsFinish,Ke_hoach,Issue,Created_At,
			ROW_NUMBER() OVER (ORDER BY Created_At asc) as RC 
			FROM ReportItems
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
	ELSE
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			ReportId,Title,Du_dinh,IsFinish,Ke_hoach,Issue,Created_At,
			ROW_NUMBER() OVER (ORDER BY Created_At asc) as RC 
			FROM ReportItems WHERE Title LIKE '%' + @KeyString + '%'
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
END

GO
/****** Object:  StoredProcedure [dbo].[ReportItem_Update]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportItem_Update]
@id uniqueidentifier,
@title nvarchar(250),
@du_dinh nvarchar(max),
@isfinish bit,
@kehoach nvarchar(max),
@issue nvarchar(max),
@createdate datetime
AS
BEGIN
	update ReportItems
	set Title = @title,Du_dinh = @du_dinh,IsFinish = @isfinish,Ke_hoach = @kehoach,Issue = @issue, Created_At = @createdate
	where ReportId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Delete]
@id int
AS
BEGIN
	Delete from Roles
	where RoleId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Insert]
@id int,
@rolename nvarchar(50)
AS
BEGIN
	Insert into Roles(RoleId,RoleName)
	values(@id,@rolename)

END

GO
/****** Object:  StoredProcedure [dbo].[Role_Select_All]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Select_All]
AS
BEGIN
	select * from Roles
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Select_By_Id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Select_By_Id]
@id int
AS
BEGIN
	select * from Roles
	where RoleId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Update]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Update]
@id int,
@rolename nvarchar(50)
AS
BEGIN
	Update Roles
	set RoleName = @rolename
	where RoleId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[User_CheckLogin]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_CheckLogin]
@username varchar(50),
@password varchar(50)
AS
BEGIN
	select * from Users
	where UserName = @username and PassWord = @password
END

GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Delete]
@userid uniqueidentifier
AS
BEGIN
	delete from Users
	where UserId = @userid
END

GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[User_Insert]
@userid uniqueidentifier,
@username varchar(50),
@password varchar(50),
@email varchar(50),
@CreateAt datetime,
@ReportReceiver uniqueidentifier,
@roleid int
AS
BEGIN
	Insert into Users(UserId,UserName,PassWord,Email,Create_At,ReportReceiver,RoleId)
	values(@userid,@username,@password,@email,@CreateAt,@ReportReceiver,@roleid)
END

GO
/****** Object:  StoredProcedure [dbo].[User_Report_Delete]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Report_Delete]
@idUR uniqueidentifier
AS
BEGIN
	delete from User_Reports
	where User_Report_Id = @idUR
END

GO
/****** Object:  StoredProcedure [dbo].[User_Report_Insert]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Report_Insert]
@idUR uniqueidentifier,
@idU uniqueidentifier,
@idR uniqueidentifier
AS
BEGIN
	Insert into User_Reports(User_Report_Id,UserId,ReportId)
	values(@idUR,@idU,@idR)
END

GO
/****** Object:  StoredProcedure [dbo].[User_Report_Select_all]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Report_Select_all]
AS
BEGIN
	Select * from User_Reports
END

GO
/****** Object:  StoredProcedure [dbo].[User_Report_Select_by_id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Report_Select_by_id]
@id uniqueidentifier
AS
BEGIN
	Select * from User_Reports
	where User_Report_Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_Select_All]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Select_All]
AS
BEGIN
	select *
	from Users

END

GO
/****** Object:  StoredProcedure [dbo].[User_Select_by_id]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Select_by_id]
@id uniqueidentifier
AS
BEGIN
	select u.UserId,u.UserName, u.PassWord,u.Email,u.Create_At,u.ReportReceiver,r.RoleName
	from Users u inner join Roles r on u.RoleId = r.RoleId
	where u.UserId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[User_Select_by_paging]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Select_by_paging]
	@KeyString nvarchar(250),
	@start int,
	@length int
AS
BEGIN
	IF @KeyString Is Null
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			UserId,UserName, PassWord, Email,Create_At,ReportReceiver,RoleId,
			ROW_NUMBER() OVER (ORDER BY UserName asc) as RC 
			FROM Users
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
	ELSE
	BEGIN
		SELECT * FROM(
			SELECT DISTINCT
			UserId,UserName, PassWord, Email,Create_At,ReportReceiver,RoleId,
			ROW_NUMBER() OVER (ORDER BY UserName asc) as RC 
			FROM Users WHERE UserName  LIKE '%' + @KeyString + '%'
		) a
		WHERE RC > @start AND RC <= @start + @length
	END
END

GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 23/06/2018 5:29:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update]
@userid uniqueidentifier,
@username varchar(50),
@password varchar(50),
@email varchar(50),
@CreateAt datetime,
@ReportReceiver uniqueidentifier,
@roleid int
AS
BEGIN
	Update Users
	set UserName = @username, PassWord = @password, Email = @email, Create_At = @CreateAt, ReportReceiver = @ReportReceiver, RoleId = @roleid
	where UserId = @userid
END

GO
USE [master]
GO
ALTER DATABASE [PlanDaily] SET  READ_WRITE 
GO
