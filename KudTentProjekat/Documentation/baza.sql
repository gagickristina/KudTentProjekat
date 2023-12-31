create database [KulturnoUmetnickoDrustvo]
GO

USE [KulturnoUmetnickoDrustvo]
GO
ALTER TABLE [dbo].[Priznanica] DROP CONSTRAINT [FK_Priznanica_Clan]
GO
ALTER TABLE [dbo].[Placeno] DROP CONSTRAINT [FK_Placeno_MesecnaClanarina]
GO
ALTER TABLE [dbo].[Placeno] DROP CONSTRAINT [FK_Placeno_godisnjaClanarina]
GO
ALTER TABLE [dbo].[Clan] DROP CONSTRAINT [FK_Clan_Sekcije]
GO
ALTER TABLE [dbo].[Clan] DROP CONSTRAINT [FK_Clan_Privilegije]
GO
ALTER TABLE [dbo].[Clan] DROP CONSTRAINT [FK_Clan_Placeno]
GO
/****** Object:  Table [dbo].[Sekcije]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sekcije]') AND type in (N'U'))
DROP TABLE [dbo].[Sekcije]
GO
/****** Object:  Table [dbo].[Priznanica]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priznanica]') AND type in (N'U'))
DROP TABLE [dbo].[Priznanica]
GO
/****** Object:  Table [dbo].[Privilegije]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Privilegije]') AND type in (N'U'))
DROP TABLE [dbo].[Privilegije]
GO
/****** Object:  Table [dbo].[Placeno]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Placeno]') AND type in (N'U'))
DROP TABLE [dbo].[Placeno]
GO
/****** Object:  Table [dbo].[MesecnaClanarina]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MesecnaClanarina]') AND type in (N'U'))
DROP TABLE [dbo].[MesecnaClanarina]
GO
/****** Object:  Table [dbo].[GodisnjaClanarina]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GodisnjaClanarina]') AND type in (N'U'))
DROP TABLE [dbo].[GodisnjaClanarina]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 10/17/2023 7:28:21 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clan]') AND type in (N'U'))
DROP TABLE [dbo].[Clan]
GO
USE [master]
GO
/****** Object:  Database [KulturnoUmetnickoDrustvo]    Script Date: 10/17/2023 7:28:21 PM ******/
DROP DATABASE [KulturnoUmetnickoDrustvo]
GO
/****** Object:  Database [KulturnoUmetnickoDrustvo]    Script Date: 10/17/2023 7:28:21 PM ******/
CREATE DATABASE [KulturnoUmetnickoDrustvo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KulturnoUmetnickoDrustvo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KulturnoUmetnickoDrustvo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KulturnoUmetnickoDrustvo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KulturnoUmetnickoDrustvo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KulturnoUmetnickoDrustvo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ARITHABORT OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET RECOVERY FULL 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET  MULTI_USER 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KulturnoUmetnickoDrustvo', N'ON'
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET QUERY_STORE = OFF
GO
USE [KulturnoUmetnickoDrustvo]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clan](
	[IDClana] [int] IDENTITY(1,1) NOT NULL,
	[korisnickoIme] [nvarchar](50) NOT NULL,
	[lozinka] [nvarchar](50) NOT NULL,
	[prezimeIme] [nvarchar](50) NOT NULL,
	[popust] [nvarchar](50) NOT NULL,
	[IDPrivilegije] [int] NOT NULL,
	[IDSekcije] [int] NOT NULL,
	[IDPlaceno] [int] NOT NULL,
 CONSTRAINT [PK_Clan] PRIMARY KEY CLUSTERED 
(
	[IDClana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GodisnjaClanarina]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GodisnjaClanarina](
	[IDGodisnja] [int] NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[cenaObicna] [int] NOT NULL,
	[cenaPopust] [int] NOT NULL,
 CONSTRAINT [PK_godisnjaClanarina] PRIMARY KEY CLUSTERED 
(
	[IDGodisnja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MesecnaClanarina]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesecnaClanarina](
	[IDMesecna] [int] NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[cenaObicna] [int] NOT NULL,
	[cenaPopust] [int] NOT NULL,
 CONSTRAINT [PK_MesecnaClanarina] PRIMARY KEY CLUSTERED 
(
	[IDMesecna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Placeno]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Placeno](
	[IDPlaceno] [int] NOT NULL,
	[IDGodisnja] [int] NOT NULL,
	[IDMesecna] [int] NOT NULL,
 CONSTRAINT [PK_Placeno_1] PRIMARY KEY CLUSTERED 
(
	[IDPlaceno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilegije]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privilegije](
	[IDPrivilegije] [int] NOT NULL,
	[naziv] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Privilegije] PRIMARY KEY CLUSTERED 
(
	[IDPrivilegije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priznanica]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priznanica](
	[IDPriznanice] [int] IDENTITY(1,1) NOT NULL,
	[datum] [nvarchar](30) NOT NULL,
	[cena] [int] NOT NULL,
	[nazivMeseca] [nvarchar](20) NOT NULL,
	[IDKorisnika] [int] NOT NULL,
 CONSTRAINT [PK_Priznanica] PRIMARY KEY CLUSTERED 
(
	[IDPriznanice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sekcije]    Script Date: 10/17/2023 7:28:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sekcije](
	[IDSekcije] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sekcije] PRIMARY KEY CLUSTERED 
(
	[IDSekcije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clan] ON 

INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (61, N'GagicKristina', N'Kristina2020&', N'Gagic Kristina', N'Da', 1, 2, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (65, N'FilipFilipovic', N'Filip2023&', N'Filip Filipovic', N'Da', 2, 3, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (66, N'MilicMile', N'Mile2020&', N'Milic Mile', N'Da', 1, 1, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (69, N'MirkicMirko', N'Mirko2020&', N'Mirko Mirkic', N'Da', 2, 3, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (70, N'TeodoraTanasic', N'Teodora2020&', N'Teodora Teodoric', N'Da', 2, 1, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (73, N'SaraSaric', N'Sara2020&', N'Sara Saric', N'Ne', 3, 3, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (74, N'PetrovicPera', N'Pera2020&', N'Petrovic Pera', N'Ne', 2, 2, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (76, N'IvicIva', N'Iva2020&', N'Ivić Iva', N'Da', 2, 3, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (95, N'ZikicZika', N'Zika2020&', N'Zikić Zika', N'Da', 2, 2, 1)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (96, N'LazicLaza', N'Laza2020&', N'Lazić Laza', N'Ne', 3, 2, 4)
INSERT [dbo].[Clan] ([IDClana], [korisnickoIme], [lozinka], [prezimeIme], [popust], [IDPrivilegije], [IDSekcije], [IDPlaceno]) VALUES (105, N'LukicLuka', N'Luka2020&', N'Lukic Luka', N'Ne', 2, 3, 1)
SET IDENTITY_INSERT [dbo].[Clan] OFF
GO
INSERT [dbo].[GodisnjaClanarina] ([IDGodisnja], [status], [cenaObicna], [cenaPopust]) VALUES (1, N'Placena', 1500, 1000)
INSERT [dbo].[GodisnjaClanarina] ([IDGodisnja], [status], [cenaObicna], [cenaPopust]) VALUES (2, N'Nije placena', 1500, 1000)
GO
INSERT [dbo].[MesecnaClanarina] ([IDMesecna], [status], [cenaObicna], [cenaPopust]) VALUES (1, N'Placena', 1000, 800)
INSERT [dbo].[MesecnaClanarina] ([IDMesecna], [status], [cenaObicna], [cenaPopust]) VALUES (2, N'Nije placena', 1000, 800)
GO
INSERT [dbo].[Placeno] ([IDPlaceno], [IDGodisnja], [IDMesecna]) VALUES (1, 1, 1)
INSERT [dbo].[Placeno] ([IDPlaceno], [IDGodisnja], [IDMesecna]) VALUES (2, 1, 2)
INSERT [dbo].[Placeno] ([IDPlaceno], [IDGodisnja], [IDMesecna]) VALUES (3, 2, 1)
INSERT [dbo].[Placeno] ([IDPlaceno], [IDGodisnja], [IDMesecna]) VALUES (4, 2, 2)
GO
INSERT [dbo].[Privilegije] ([IDPrivilegije], [naziv]) VALUES (1, N'Admin               ')
INSERT [dbo].[Privilegije] ([IDPrivilegije], [naziv]) VALUES (2, N'Korisnik            ')
INSERT [dbo].[Privilegije] ([IDPrivilegije], [naziv]) VALUES (3, N'Asistent            ')
GO
SET IDENTITY_INSERT [dbo].[Priznanica] ON 

INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (30, N'23/08/2023', 1500, N'Godisnja', 73)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (41, N'28/09/2023', 800, N'Mesecna', 69)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (42, N'21/08/2023', 800, N'Mesecna', 70)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (45, N'06/09/2023', 1500, N'Godisnja', 74)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (46, N'06/09/2023', 1000, N'Mesecna', 74)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (48, N'06/09/2023', 800, N'Mesecna', 61)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (54, N'06/09/2023', 1000, N'Mesecna', 74)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (55, N'06/09/2023', 1000, N'Mesecna', 74)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (57, N'06/09/2023', 1000, N'Mesecna', 73)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (76, N'07/09/2023', 800, N'Mesecna', 70)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (80, N'08/09/2023', 800, N'Mesecna', 69)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (92, N'15/09/2023', 800, N'Mesecna', 61)
INSERT [dbo].[Priznanica] ([IDPriznanice], [datum], [cena], [nazivMeseca], [IDKorisnika]) VALUES (94, N'15/09/2023', 800, N'Mesecna', 76)
SET IDENTITY_INSERT [dbo].[Priznanica] OFF
GO
INSERT [dbo].[Sekcije] ([IDSekcije], [Naziv]) VALUES (1, N'Izvođački ansambl')
INSERT [dbo].[Sekcije] ([IDSekcije], [Naziv]) VALUES (2, N'Omladinski ansambl')
INSERT [dbo].[Sekcije] ([IDSekcije], [Naziv]) VALUES (3, N'Narodni orkestar')
INSERT [dbo].[Sekcije] ([IDSekcije], [Naziv]) VALUES (4, N'Pevačka grupa')
INSERT [dbo].[Sekcije] ([IDSekcije], [Naziv]) VALUES (5, N'Škola folklora')
GO
ALTER TABLE [dbo].[Clan]  WITH CHECK ADD  CONSTRAINT [FK_Clan_Placeno] FOREIGN KEY([IDPlaceno])
REFERENCES [dbo].[Placeno] ([IDPlaceno])
GO
ALTER TABLE [dbo].[Clan] CHECK CONSTRAINT [FK_Clan_Placeno]
GO
ALTER TABLE [dbo].[Clan]  WITH CHECK ADD  CONSTRAINT [FK_Clan_Privilegije] FOREIGN KEY([IDPrivilegije])
REFERENCES [dbo].[Privilegije] ([IDPrivilegije])
GO
ALTER TABLE [dbo].[Clan] CHECK CONSTRAINT [FK_Clan_Privilegije]
GO
ALTER TABLE [dbo].[Clan]  WITH CHECK ADD  CONSTRAINT [FK_Clan_Sekcije] FOREIGN KEY([IDSekcije])
REFERENCES [dbo].[Sekcije] ([IDSekcije])
GO
ALTER TABLE [dbo].[Clan] CHECK CONSTRAINT [FK_Clan_Sekcije]
GO
ALTER TABLE [dbo].[Placeno]  WITH CHECK ADD  CONSTRAINT [FK_Placeno_godisnjaClanarina] FOREIGN KEY([IDGodisnja])
REFERENCES [dbo].[GodisnjaClanarina] ([IDGodisnja])
GO
ALTER TABLE [dbo].[Placeno] CHECK CONSTRAINT [FK_Placeno_godisnjaClanarina]
GO
ALTER TABLE [dbo].[Placeno]  WITH CHECK ADD  CONSTRAINT [FK_Placeno_MesecnaClanarina] FOREIGN KEY([IDMesecna])
REFERENCES [dbo].[MesecnaClanarina] ([IDMesecna])
GO
ALTER TABLE [dbo].[Placeno] CHECK CONSTRAINT [FK_Placeno_MesecnaClanarina]
GO
ALTER TABLE [dbo].[Priznanica]  WITH CHECK ADD  CONSTRAINT [FK_Priznanica_Clan] FOREIGN KEY([IDKorisnika])
REFERENCES [dbo].[Clan] ([IDClana])
GO
ALTER TABLE [dbo].[Priznanica] CHECK CONSTRAINT [FK_Priznanica_Clan]
GO
USE [master]
GO
ALTER DATABASE [KulturnoUmetnickoDrustvo] SET  READ_WRITE 
GO
