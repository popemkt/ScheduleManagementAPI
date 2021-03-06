USE [master]
GO
/****** Object:  Database [ScheduleManagement]    Script Date: 3/28/2020 5:12:20 PM ******/
CREATE DATABASE [ScheduleManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScheduleManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ScheduleManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ScheduleManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ScheduleManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ScheduleManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScheduleManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScheduleManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScheduleManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScheduleManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScheduleManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScheduleManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScheduleManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScheduleManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScheduleManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScheduleManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ScheduleManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ScheduleManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScheduleManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScheduleManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScheduleManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ScheduleManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ScheduleManagement', N'ON'
GO
ALTER DATABASE [ScheduleManagement] SET QUERY_STORE = OFF
GO
USE [ScheduleManagement]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Fullname] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[Phone] [varchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[RoleID] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[ExID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[TypeID] [int] NULL,
	[ExperienceTime] [float] NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[ExID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoursRegistration]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoursRegistration](
	[HrID] [int] IDENTITY(1,1) NOT NULL,
	[FromTime] [datetime] NULL,
	[ToTime] [datetime] NULL,
 CONSTRAINT [PK_HoursRegistration] PRIMARY KEY CLUSTERED 
(
	[HrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HrT]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HrT](
	[HrTID] [int] IDENTITY(1,1) NOT NULL,
	[HrID] [int] NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_HrT] PRIMARY KEY CLUSTERED 
(
	[HrTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MappingScheduler]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MappingScheduler](
	[MapID] [int] IDENTITY(1,1) NOT NULL,
	[WeekID] [int] NULL,
	[HrTID] [int] NULL,
 CONSTRAINT [PK_MappingScheduler] PRIMARY KEY CLUSTERED 
(
	[MapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfWork]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWork](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
 CONSTRAINT [PK_TypeOfWork] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeelySchedule]    Script Date: 3/28/2020 5:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeelySchedule](
	[WeekID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_WeelySchedule] PRIMARY KEY CLUSTERED 
(
	[WeekID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[Experiences]  WITH CHECK ADD  CONSTRAINT [FK_Experiences_Accounts] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employees] ([EmpID])
GO
ALTER TABLE [dbo].[Experiences] CHECK CONSTRAINT [FK_Experiences_Accounts]
GO
ALTER TABLE [dbo].[Experiences]  WITH CHECK ADD  CONSTRAINT [FK_Experiences_TypeOfWork] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeOfWork] ([TypeID])
GO
ALTER TABLE [dbo].[Experiences] CHECK CONSTRAINT [FK_Experiences_TypeOfWork]
GO
ALTER TABLE [dbo].[HrT]  WITH CHECK ADD  CONSTRAINT [FK_HrT_HoursRegistration] FOREIGN KEY([HrID])
REFERENCES [dbo].[HoursRegistration] ([HrID])
GO
ALTER TABLE [dbo].[HrT] CHECK CONSTRAINT [FK_HrT_HoursRegistration]
GO
ALTER TABLE [dbo].[HrT]  WITH CHECK ADD  CONSTRAINT [FK_HrT_TypeOfWork] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeOfWork] ([TypeID])
GO
ALTER TABLE [dbo].[HrT] CHECK CONSTRAINT [FK_HrT_TypeOfWork]
GO
ALTER TABLE [dbo].[MappingScheduler]  WITH CHECK ADD  CONSTRAINT [FK_MappingScheduler_HrT] FOREIGN KEY([HrTID])
REFERENCES [dbo].[HrT] ([HrTID])
GO
ALTER TABLE [dbo].[MappingScheduler] CHECK CONSTRAINT [FK_MappingScheduler_HrT]
GO
ALTER TABLE [dbo].[MappingScheduler]  WITH CHECK ADD  CONSTRAINT [FK_MappingScheduler_WeelySchedule] FOREIGN KEY([WeekID])
REFERENCES [dbo].[WeelySchedule] ([WeekID])
GO
ALTER TABLE [dbo].[MappingScheduler] CHECK CONSTRAINT [FK_MappingScheduler_WeelySchedule]
GO
USE [master]
GO
ALTER DATABASE [ScheduleManagement] SET  READ_WRITE 
GO
