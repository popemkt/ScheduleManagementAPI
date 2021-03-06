USE [master]
GO
/****** Object:  Database [ScheduleManagement]    Script Date: 4/7/2020 2:49:56 PM ******/
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
/****** Object:  Table [dbo].[ArrangedSchedule]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArrangedSchedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[HourSlot] [int] NULL,
	[SpecialtyID] [int] NULL,
	[EmpID] [int] NULL,
 CONSTRAINT [PK_ArrangedSchedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Fullname] [varchar](50) NULL,
	[RoleID] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpScheduleRegistration]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpScheduleRegistration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[HourSlot] [int] NULL,
	[SpecialtyID] [int] NULL,
	[EmpID] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_EmpSchedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpSpecialty]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpSpecialty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[SpecialtyID] [int] NULL,
 CONSTRAINT [PK_EmpSpecialty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/7/2020 2:49:57 PM ******/
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
/****** Object:  Table [dbo].[ScheduleTemplate]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[HourSlot] [int] NULL,
	[NoOfEmp] [int] NULL,
	[SpecialtyID] [int] NULL,
 CONSTRAINT [PK_ScheduleTemplate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialty]    Script Date: 4/7/2020 2:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmpID], [Username], [Password], [Fullname], [RoleID], [Active]) VALUES (1, N'admin', N'admin', N'admin', 1, 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Name]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[ArrangedSchedule]  WITH CHECK ADD  CONSTRAINT [FK_ArrangedSchedule_Employees] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employees] ([EmpID])
GO
ALTER TABLE [dbo].[ArrangedSchedule] CHECK CONSTRAINT [FK_ArrangedSchedule_Employees]
GO
ALTER TABLE [dbo].[ArrangedSchedule]  WITH CHECK ADD  CONSTRAINT [FK_ArrangedSchedule_Specialty] FOREIGN KEY([SpecialtyID])
REFERENCES [dbo].[Specialty] ([ID])
GO
ALTER TABLE [dbo].[ArrangedSchedule] CHECK CONSTRAINT [FK_ArrangedSchedule_Specialty]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[EmpScheduleRegistration]  WITH CHECK ADD  CONSTRAINT [FK_EmpSchedule_Employees] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employees] ([EmpID])
GO
ALTER TABLE [dbo].[EmpScheduleRegistration] CHECK CONSTRAINT [FK_EmpSchedule_Employees]
GO
ALTER TABLE [dbo].[EmpScheduleRegistration]  WITH CHECK ADD  CONSTRAINT [FK_EmpScheduleRegistration_Specialty] FOREIGN KEY([SpecialtyID])
REFERENCES [dbo].[Specialty] ([ID])
GO
ALTER TABLE [dbo].[EmpScheduleRegistration] CHECK CONSTRAINT [FK_EmpScheduleRegistration_Specialty]
GO
ALTER TABLE [dbo].[EmpSpecialty]  WITH CHECK ADD  CONSTRAINT [FK_EmpSpecialty_Employees] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employees] ([EmpID])
GO
ALTER TABLE [dbo].[EmpSpecialty] CHECK CONSTRAINT [FK_EmpSpecialty_Employees]
GO
ALTER TABLE [dbo].[EmpSpecialty]  WITH CHECK ADD  CONSTRAINT [FK_EmpSpecialty_Specialty] FOREIGN KEY([SpecialtyID])
REFERENCES [dbo].[Specialty] ([ID])
GO
ALTER TABLE [dbo].[EmpSpecialty] CHECK CONSTRAINT [FK_EmpSpecialty_Specialty]
GO
ALTER TABLE [dbo].[ScheduleTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleTemplate_Specialty] FOREIGN KEY([SpecialtyID])
REFERENCES [dbo].[Specialty] ([ID])
GO
ALTER TABLE [dbo].[ScheduleTemplate] CHECK CONSTRAINT [FK_ScheduleTemplate_Specialty]
GO
USE [master]
GO
ALTER DATABASE [ScheduleManagement] SET  READ_WRITE 
GO
