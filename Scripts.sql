USE [master]
GO
/****** Object:  Database [ResidentExecutor_DB]    Script Date: 6/6/2018 1:10:29 AM ******/
CREATE DATABASE [ResidentExecutor_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResidentExecutor_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ResidentExecutor_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ResidentExecutor_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ResidentExecutor_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ResidentExecutor_DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResidentExecutor_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResidentExecutor_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResidentExecutor_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResidentExecutor_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ResidentExecutor_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResidentExecutor_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [ResidentExecutor_DB] SET  MULTI_USER 
GO
ALTER DATABASE [ResidentExecutor_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResidentExecutor_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResidentExecutor_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResidentExecutor_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ResidentExecutor_DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ResidentExecutor_DB', N'ON'
GO
ALTER DATABASE [ResidentExecutor_DB] SET QUERY_STORE = OFF
GO
USE [ResidentExecutor_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ResidentExecutor_DB]
GO
/****** Object:  Table [dbo].[FunkcijaAverage]    Script Date: 6/6/2018 1:10:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunkcijaAverage](
	[IDGeoPodrucja] [varchar](2) NOT NULL,
	[VremeProracuna] [datetime] NOT NULL,
	[AverageVrednost] [float] NOT NULL,
	[RedniBroj] [int] IDENTITY(1,1) NOT NULL,
	[PoslednjeVreme] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FunkcijaMaximum]    Script Date: 6/6/2018 1:10:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunkcijaMaximum](
	[IDGeoPodrucja] [varchar](2) NOT NULL,
	[VremeProracuna] [datetime] NOT NULL,
	[MaximalnaVrednost] [float] NOT NULL,
	[RedniBroj] [int] IDENTITY(1,1) NOT NULL,
	[PoslednjeVreme] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FunkcijaMinimum]    Script Date: 6/6/2018 1:10:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunkcijaMinimum](
	[IDGeoPodrucja] [varchar](2) NOT NULL,
	[VremeProracuna] [datetime] NOT NULL,
	[MinimalnaVrednost] [float] NOT NULL,
	[RedniBroj] [int] IDENTITY(1,1) NOT NULL,
	[PoslednjeVreme] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoPodrucje]    Script Date: 6/6/2018 1:10:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoPodrucje](
	[IDGeoPodrucja] [varchar](2) NOT NULL,
	[NazivGeoPodrucja] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GeoPodrucje] PRIMARY KEY CLUSTERED 
(
	[IDGeoPodrucja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UneseneVrednosti]    Script Date: 6/6/2018 1:10:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UneseneVrednosti](
	[IDGeoPodrucja] [varchar](2) NOT NULL,
	[VremeMerenja] [datetime] NOT NULL,
	[Vrednost] [float] NOT NULL,
	[RedniBroj] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FunkcijaAverage] ON 

INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 621, 2, CAST(N'2018-06-01T07:40:12.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 455, 3, CAST(N'2018-06-01T02:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 22, 4, CAST(N'2018-06-01T01:29:06.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 9878, 5, CAST(N'2018-06-01T01:01:01.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 230.6667, 6, CAST(N'2018-06-01T00:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 2303.5, 7, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 621, 8, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 230.6667, 9, CAST(N'2018-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 150, 16, CAST(N'2018-06-02T15:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 260, 17, CAST(N'2018-06-02T20:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 110, 18, CAST(N'2018-06-02T04:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 92.5, 19, CAST(N'2018-06-02T12:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 155, 20, CAST(N'2018-06-02T08:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-02T20:42:27.000' AS DateTime), 109.6667, 21, CAST(N'2018-06-02T03:50:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T00:15:16.000' AS DateTime), 110, 22, CAST(N'2018-06-03T00:12:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T01:38:15.000' AS DateTime), 116.6667, 23, CAST(N'2018-06-03T01:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T01:45:13.000' AS DateTime), 112.5, 24, CAST(N'2018-06-03T01:40:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T01:57:05.000' AS DateTime), 175, 25, CAST(N'2018-06-03T01:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'TR', CAST(N'2018-06-03T02:06:43.000' AS DateTime), 180, 26, CAST(N'2018-06-03T02:06:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'TR', CAST(N'2018-06-03T02:11:00.000' AS DateTime), 190, 27, CAST(N'2018-06-03T02:07:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T02:44:45.000' AS DateTime), 210, 28, CAST(N'2018-06-03T02:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-03T02:47:53.000' AS DateTime), 50, 29, CAST(N'2018-06-03T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T03:05:32.000' AS DateTime), 146.6667, 30, CAST(N'2018-06-03T01:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T12:04:08.000' AS DateTime), 192.4, 31, CAST(N'2018-06-03T03:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 500, 45, CAST(N'2018-06-04T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 120, 46, CAST(N'2018-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-04T14:10:52.000' AS DateTime), 233, 47, CAST(N'2018-06-04T04:07:07.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-04T18:00:36.000' AS DateTime), 207, 48, CAST(N'2018-06-04T14:17:13.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-05T23:41:55.000' AS DateTime), 45, 49, CAST(N'2018-06-05T12:12:00.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-05T23:42:26.000' AS DateTime), 90, 50, CAST(N'2018-06-05T08:08:08.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-06T00:51:29.000' AS DateTime), 20, 51, CAST(N'2018-06-06T00:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaAverage] ([IDGeoPodrucja], [VremeProracuna], [AverageVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-06T00:55:30.000' AS DateTime), 2, 52, CAST(N'2018-06-06T00:54:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FunkcijaAverage] OFF
SET IDENTITY_INSERT [dbo].[FunkcijaMaximum] ON 

INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 1007, 31, CAST(N'2018-06-01T07:40:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 455, 32, CAST(N'2018-06-01T02:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 22, 33, CAST(N'2018-06-01T01:29:06.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 9878, 34, CAST(N'2018-06-01T01:01:01.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 234, 35, CAST(N'2018-06-01T00:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 4554, 36, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 1007, 37, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T12:40:43.000' AS DateTime), 234, 38, CAST(N'2018-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T17:37:39.000' AS DateTime), 1007, 39, CAST(N'2018-06-01T13:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-01T17:37:39.000' AS DateTime), 899, 40, CAST(N'2018-06-01T12:13:14.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-01T17:38:44.000' AS DateTime), 9878, 41, CAST(N'2018-06-01T12:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 200, 56, CAST(N'2018-06-02T15:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 300, 57, CAST(N'2018-06-02T20:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 110, 58, CAST(N'2018-06-02T04:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 150, 59, CAST(N'2018-06-02T12:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 230, 60, CAST(N'2018-06-02T08:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 120, 61, CAST(N'2018-06-02T03:50:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T00:15:57.000' AS DateTime), 120, 62, CAST(N'2018-06-03T00:12:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T01:45:33.000' AS DateTime), 130, 63, CAST(N'2018-06-03T01:40:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T01:53:47.000' AS DateTime), 200, 64, CAST(N'2018-06-03T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T01:56:45.000' AS DateTime), 200, 65, CAST(N'2018-06-03T01:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'TR', CAST(N'2018-06-03T02:10:40.000' AS DateTime), 200, 66, CAST(N'2018-06-03T02:07:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T02:16:50.000' AS DateTime), 250, 67, CAST(N'2018-06-03T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T02:41:01.000' AS DateTime), 250, 68, CAST(N'2018-06-03T02:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-03T02:48:04.000' AS DateTime), 50, 69, CAST(N'2018-06-03T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T12:04:08.000' AS DateTime), 250, 70, CAST(N'2018-06-03T03:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T12:04:08.000' AS DateTime), 200, 71, CAST(N'2018-06-03T01:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 500, 74, CAST(N'2018-06-04T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 120, 75, CAST(N'2018-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-04T14:10:52.000' AS DateTime), 233, 76, CAST(N'2018-06-04T04:07:07.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-04T18:00:36.000' AS DateTime), 207, 77, CAST(N'2018-06-04T14:17:13.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-05T23:41:55.000' AS DateTime), 45, 78, CAST(N'2018-06-05T12:12:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-05T23:42:26.000' AS DateTime), 90, 79, CAST(N'2018-06-05T08:08:08.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-06T00:51:29.000' AS DateTime), 20, 80, CAST(N'2018-06-06T00:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMaximum] ([IDGeoPodrucja], [VremeProracuna], [MaximalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-06T00:55:30.000' AS DateTime), 2, 81, CAST(N'2018-06-06T00:54:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FunkcijaMaximum] OFF
SET IDENTITY_INSERT [dbo].[FunkcijaMinimum] ON 

INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 13, 1, CAST(N'2018-06-01T07:40:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 455, 2, CAST(N'2018-06-01T02:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 22, 3, CAST(N'2018-06-01T01:29:06.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 9878, 4, CAST(N'2018-06-01T01:01:01.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 214, 5, CAST(N'2018-06-01T00:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 53, 6, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 13, 7, CAST(N'2018-06-01T00:15:15.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-01T13:39:47.000' AS DateTime), 214, 8, CAST(N'2018-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-01T16:45:08.000' AS DateTime), 9, 9, CAST(N'2018-06-01T13:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-01T16:45:08.000' AS DateTime), 22, 10, CAST(N'2018-06-01T12:13:14.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-01T17:38:44.000' AS DateTime), 123, 11, CAST(N'2018-06-01T12:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 100, 26, CAST(N'2018-06-02T15:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 220, 27, CAST(N'2018-06-02T20:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'MO', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 110, 28, CAST(N'2018-06-02T04:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'GR', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 50, 29, CAST(N'2018-06-02T12:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 80, 30, CAST(N'2018-06-02T08:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-02T20:39:51.000' AS DateTime), 99, 31, CAST(N'2018-06-02T03:50:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T00:13:56.000' AS DateTime), 100, 32, CAST(N'2018-06-03T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T00:14:36.000' AS DateTime), 100, 33, CAST(N'2018-06-03T00:12:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-03T01:45:33.000' AS DateTime), 100, 34, CAST(N'2018-06-03T01:40:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T01:53:47.000' AS DateTime), 200, 35, CAST(N'2018-06-03T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T01:56:45.000' AS DateTime), 150, 36, CAST(N'2018-06-03T01:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'TR', CAST(N'2018-06-03T02:11:00.000' AS DateTime), 180, 37, CAST(N'2018-06-03T02:07:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T02:16:50.000' AS DateTime), 250, 38, CAST(N'2018-06-03T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T02:41:21.000' AS DateTime), 190, 39, CAST(N'2018-06-03T02:20:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BN', CAST(N'2018-06-03T02:47:53.000' AS DateTime), 50, 40, CAST(N'2018-06-03T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BI', CAST(N'2018-06-03T03:05:32.000' AS DateTime), 90, 41, CAST(N'2018-06-03T01:12:12.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'PR', CAST(N'2018-06-03T03:40:37.000' AS DateTime), 122, 42, CAST(N'2018-06-03T03:03:03.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'SA', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 500, 45, CAST(N'2018-06-04T02:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'BL', CAST(N'2018-06-04T13:55:34.000' AS DateTime), 120, 46, CAST(N'2018-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'DO', CAST(N'2018-06-04T14:10:52.000' AS DateTime), 233, 47, CAST(N'2018-06-04T04:07:07.000' AS DateTime))
INSERT [dbo].[FunkcijaMinimum] ([IDGeoPodrucja], [VremeProracuna], [MinimalnaVrednost], [RedniBroj], [PoslednjeVreme]) VALUES (N'ZV', CAST(N'2018-06-04T18:00:36.000' AS DateTime), 207, 48, CAST(N'2018-06-04T14:17:13.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FunkcijaMinimum] OFF
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'BI', N'Bihac')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'BL', N'Banjaluka')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'BN', N'Bijeljina')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'DO', N'Doboj')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'GR', N'Gradiska')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'MO', N'Mostar')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'PR', N'Prnjavor')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'SA', N'Sarajevo')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'TR', N'Trebinje')
INSERT [dbo].[GeoPodrucje] ([IDGeoPodrucja], [NazivGeoPodrucja]) VALUES (N'ZV', N'Zvornik')
SET IDENTITY_INSERT [dbo].[UneseneVrednosti] ON 

INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2015-12-10T23:33:12.000' AS DateTime), 1234, 1)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2015-12-11T23:33:12.000' AS DateTime), 1234, 3)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-04-29T11:22:33.000' AS DateTime), 12, 7)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-01-29T11:22:33.000' AS DateTime), 12, 10)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-05-22T00:30:20.000' AS DateTime), 653, 12)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-05-01T23:22:02.000' AS DateTime), 123, 14)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-05-04T01:01:01.000' AS DateTime), 12, 15)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-05-06T01:05:02.000' AS DateTime), 99999, 16)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-05-06T12:13:14.000' AS DateTime), 234, 17)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-05-31T12:31:56.000' AS DateTime), 987, 18)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-05-31T12:12:12.000' AS DateTime), 99, 19)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'TR', CAST(N'2018-05-31T03:05:05.000' AS DateTime), 44, 20)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:00:00.000' AS DateTime), 234, 23)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:20:00.000' AS DateTime), 234, 24)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-06-01T02:03:03.000' AS DateTime), 455, 26)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-01T01:29:06.000' AS DateTime), 22, 28)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-01T01:01:01.000' AS DateTime), 9878, 30)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:30:00.000' AS DateTime), 234, 33)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-01T00:15:15.000' AS DateTime), 53, 35)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-01T00:16:16.000' AS DateTime), 4554, 36)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T00:15:15.000' AS DateTime), 567, 38)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T00:15:15.000' AS DateTime), 13, 39)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:30:00.000' AS DateTime), 234, 40)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:36:00.000' AS DateTime), 234, 41)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-01T00:46:00.000' AS DateTime), 214, 42)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T07:40:12.000' AS DateTime), 450, 43)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T08:40:12.000' AS DateTime), 460, 44)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T08:42:12.000' AS DateTime), 470, 45)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T08:52:12.000' AS DateTime), 1000, 46)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T08:54:12.000' AS DateTime), 1001, 47)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T08:58:12.000' AS DateTime), 1007, 48)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-01T13:20:00.000' AS DateTime), 9, 49)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-01T12:13:14.000' AS DateTime), 899, 50)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-01T12:12:12.000' AS DateTime), 123, 51)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-02T00:00:00.000' AS DateTime), 99, 53)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-02T01:00:00.000' AS DateTime), 120, 54)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-02T03:50:00.000' AS DateTime), 110, 56)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-06-02T02:00:00.000' AS DateTime), 80, 57)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-06-02T08:00:00.000' AS DateTime), 230, 58)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-02T12:00:00.000' AS DateTime), 300, 59)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-02T20:00:00.000' AS DateTime), 220, 60)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'MO', CAST(N'2018-06-02T04:00:00.000' AS DateTime), 110, 61)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-02T00:00:00.000' AS DateTime), 50, 62)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-02T02:00:00.000' AS DateTime), 100, 63)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-02T05:00:00.000' AS DateTime), 70, 64)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-02T12:00:00.000' AS DateTime), 150, 65)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'ZV', CAST(N'2018-06-02T00:00:00.000' AS DateTime), 200, 66)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'ZV', CAST(N'2018-06-02T04:00:00.000' AS DateTime), 150, 68)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'ZV', CAST(N'2018-06-02T15:00:00.000' AS DateTime), 100, 69)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-03T00:00:00.000' AS DateTime), 100, 71)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-03T00:12:00.000' AS DateTime), 120, 72)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-03T01:00:00.000' AS DateTime), 130, 73)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-03T01:40:00.000' AS DateTime), 100, 74)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BI', CAST(N'2018-06-03T00:00:00.000' AS DateTime), 200, 75)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BI', CAST(N'2018-06-03T01:00:00.000' AS DateTime), 150, 76)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'TR', CAST(N'2018-06-03T02:06:00.000' AS DateTime), 180, 77)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'TR', CAST(N'2018-06-03T02:07:00.000' AS DateTime), 200, 78)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-03T02:00:00.000' AS DateTime), 250, 79)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-03T02:05:00.000' AS DateTime), 200, 80)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-03T02:15:00.000' AS DateTime), 200, 81)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-03T02:20:00.000' AS DateTime), 190, 82)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-06-03T02:00:00.000' AS DateTime), 50, 83)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BI', CAST(N'2018-06-03T01:12:12.000' AS DateTime), 90, 84)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-03T03:03:03.000' AS DateTime), 122, 85)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'TR', CAST(N'2014-12-15T02:02:02.000' AS DateTime), 333, 86)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BI', CAST(N'2018-05-30T06:07:56.000' AS DateTime), 999999, 87)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-04T00:00:00.000' AS DateTime), 120, 88)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'SA', CAST(N'2018-06-04T02:00:00.000' AS DateTime), 500, 89)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'DO', CAST(N'2018-06-04T04:07:07.000' AS DateTime), 233, 90)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'ZV', CAST(N'2018-06-04T14:17:13.000' AS DateTime), 207, 91)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-05T12:12:00.000' AS DateTime), 45, 93)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'GR', CAST(N'2018-06-05T08:08:08.000' AS DateTime), 90, 94)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'PR', CAST(N'2018-06-05T21:00:00.000' AS DateTime), 68, 95)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BL', CAST(N'2018-06-06T00:12:12.000' AS DateTime), 20, 97)
INSERT [dbo].[UneseneVrednosti] ([IDGeoPodrucja], [VremeMerenja], [Vrednost], [RedniBroj]) VALUES (N'BN', CAST(N'2018-06-06T00:54:00.000' AS DateTime), 2, 98)
SET IDENTITY_INSERT [dbo].[UneseneVrednosti] OFF
ALTER TABLE [dbo].[FunkcijaAverage]  WITH CHECK ADD  CONSTRAINT [FK_FunkcijaAverage_GeoPodrucje] FOREIGN KEY([IDGeoPodrucja])
REFERENCES [dbo].[GeoPodrucje] ([IDGeoPodrucja])
GO
ALTER TABLE [dbo].[FunkcijaAverage] CHECK CONSTRAINT [FK_FunkcijaAverage_GeoPodrucje]
GO
ALTER TABLE [dbo].[FunkcijaMaximum]  WITH CHECK ADD  CONSTRAINT [FK_FunkcijaMaximum_GeoPodrucje] FOREIGN KEY([IDGeoPodrucja])
REFERENCES [dbo].[GeoPodrucje] ([IDGeoPodrucja])
GO
ALTER TABLE [dbo].[FunkcijaMaximum] CHECK CONSTRAINT [FK_FunkcijaMaximum_GeoPodrucje]
GO
ALTER TABLE [dbo].[FunkcijaMinimum]  WITH CHECK ADD  CONSTRAINT [FK_FunkcijaMinimum_GeoPodrucje] FOREIGN KEY([IDGeoPodrucja])
REFERENCES [dbo].[GeoPodrucje] ([IDGeoPodrucja])
GO
ALTER TABLE [dbo].[FunkcijaMinimum] CHECK CONSTRAINT [FK_FunkcijaMinimum_GeoPodrucje]
GO
ALTER TABLE [dbo].[UneseneVrednosti]  WITH CHECK ADD  CONSTRAINT [FK_UneseneVrednosti_GeoPodrucje] FOREIGN KEY([IDGeoPodrucja])
REFERENCES [dbo].[GeoPodrucje] ([IDGeoPodrucja])
GO
ALTER TABLE [dbo].[UneseneVrednosti] CHECK CONSTRAINT [FK_UneseneVrednosti_GeoPodrucje]
GO
USE [master]
GO
ALTER DATABASE [ResidentExecutor_DB] SET  READ_WRITE 
GO
