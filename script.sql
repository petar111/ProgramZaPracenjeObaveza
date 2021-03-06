USE [master]
GO
/****** Object:  Database [Obaveze]    Script Date: 6/17/2020 7:02:08 PM ******/
CREATE DATABASE [Obaveze]
 CONTAINMENT = NONE
GO
ALTER DATABASE [Obaveze] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Obaveze].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Obaveze] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Obaveze] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Obaveze] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Obaveze] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Obaveze] SET ARITHABORT ON 
GO
ALTER DATABASE [Obaveze] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Obaveze] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Obaveze] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Obaveze] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Obaveze] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Obaveze] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Obaveze] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Obaveze] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Obaveze] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Obaveze] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Obaveze] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Obaveze] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Obaveze] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Obaveze] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Obaveze] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Obaveze] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Obaveze] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Obaveze] SET RECOVERY FULL 
GO
ALTER DATABASE [Obaveze] SET  MULTI_USER 
GO
ALTER DATABASE [Obaveze] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Obaveze] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Obaveze] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Obaveze] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Obaveze] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Obaveze] SET QUERY_STORE = OFF
GO
USE [Obaveze]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Obaveze]
GO
/****** Object:  Table [dbo].[IzvrsilacObaveze]    Script Date: 6/17/2020 7:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IzvrsilacObaveze](
	[IdKorisnika] [int] NOT NULL,
	[IdObaveze] [int] NOT NULL,
	[PotvrdioIzvrsenje] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKorisnika] ASC,
	[IdObaveze] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 6/17/2020 7:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[IdKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[KorisnickoIme] [varchar](50) NOT NULL,
	[Sifra] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obaveza]    Script Date: 6/17/2020 7:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obaveza](
	[IdObaveze] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[DatumPostavljanja] [date] NOT NULL,
	[DatumRokaIzvrsenja] [date] NOT NULL,
	[Potvrdjena] [bit] NOT NULL,
	[Ponistena] [bit] NOT NULL,
	[IdKorisnika] [int] NOT NULL,
	[IdTipaObaveze] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdObaveze] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaObaveze]    Script Date: 6/17/2020 7:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaObaveze](
	[IdObaveze] [int] NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[Naziv] [varchar](100) NOT NULL,
	[Napomena] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdObaveze] ASC,
	[RedniBroj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipObaveze]    Script Date: 6/17/2020 7:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipObaveze](
	[IdTipaObaveze] [int] IDENTITY(1,1) NOT NULL,
	[NazivTipaObaveze] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipaObaveze] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 3006, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 6008, 1)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 7006, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 12014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 14013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 17013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 17014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3006, 23014, 1)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 4005, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 6008, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 7006, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 11013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 12014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 14013, 1)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 15013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 20013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 22013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (3007, 24015, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (5003, 16013, 1)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (5003, 17014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (5003, 22013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (6003, 4005, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (6003, 11013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (6003, 12014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 7006, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 12014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 21013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 22014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 22015, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 22017, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 23013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 24013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (7003, 24014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (8003, 12013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (8003, 17014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (8003, 20013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (8003, 23013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (9003, 13013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (9003, 22014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11006, 17014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11006, 22013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 17014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 22013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 22014, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 22016, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 22018, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11007, 22019, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11008, 20013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (11008, 23013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (13003, 24013, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (13003, 24015, 0)
INSERT [dbo].[IzvrsilacObaveze] ([IdKorisnika], [IdObaveze], [PotvrdioIzvrsenje]) VALUES (14017, 24013, 0)
GO
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (3006, N'Petar', N'Jeremic', N'petar111', N'petar111')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (3007, N'sdad', N'sadsadsadad', N'bbb', N'bbb')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (5003, N'Laza', N'Lazarevic', N'lll', N'lll')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (6003, N'rt', N'rt', N'rt', N'rt')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (7003, N'aaa', N'aaa', N'aaa', N'aaa')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (8003, N'dada', N'kuza', N'ere', N'ere')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (9003, N'sdadad', N'asdasdads', N'111', N'111')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (11006, N'Beva', N'veca', N'www', N'222')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (11007, N'dsddsd', N'sdadsd', N'dsadsda', N'44444444444444444444')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (11008, N'Muza', N'Muzic', N'muza', N'muza')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (13003, N'Karika', N'Chain', N'ch', N'ch')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (14003, N'example', N'example', N'pera', N'111')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (14017, N'sdadad', N'dsadada', N'kkkkkkkkaaaaakkkkaaa', N'111')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (14019, N'dsd', N'dasdsada', N'sadadadasadd', N'111')
INSERT [dbo].[Korisnik] ([IdKorisnika], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (15012, N'23123', N'3213', N'323213', N'1')
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
GO
SET IDENTITY_INSERT [dbo].[Obaveza] ON 

INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (3, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (1002, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (2002, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (2003, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (2004, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (2005, N'', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (2006, N'dsadsadsad', CAST(N'2020-02-19' AS Date), CAST(N'2020-02-22' AS Date), 0, 0, 3007, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (3005, N'', CAST(N'2020-02-20' AS Date), CAST(N'2020-02-20' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (3006, N'Postavi', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-27' AS Date), 1, 0, 3006, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (4005, N'Trening', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-22' AS Date), 0, 1, 3006, 4)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (6005, N'', CAST(N'2020-02-20' AS Date), CAST(N'2020-02-20' AS Date), 0, 0, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (6006, N'aaa', CAST(N'2020-02-20' AS Date), CAST(N'2020-02-28' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (6007, N'', CAST(N'2020-02-20' AS Date), CAST(N'2020-02-20' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (6008, N'Karika', CAST(N'2020-02-22' AS Date), CAST(N'2020-03-10' AS Date), 0, 1, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (7005, N'', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-22' AS Date), 0, 0, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (7006, N'Urakan', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-24' AS Date), 1, 0, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (9005, N'dasd', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-22' AS Date), 0, 0, 3007, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (11013, N'Caturanga', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-26' AS Date), 0, 1, 3006, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (11014, N'', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-24' AS Date), 0, 0, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (12013, N'Acacaca', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-24' AS Date), 0, 1, 3006, 3)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (12014, N'Geler', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-24' AS Date), 0, 0, 3006, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (13013, N'sdassddasdad', CAST(N'2020-02-24' AS Date), CAST(N'2020-02-24' AS Date), 1, 0, 9003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (14013, N'dsdasdsadad', CAST(N'2020-02-29' AS Date), CAST(N'2020-02-29' AS Date), 0, 0, 11006, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (15013, N'aaa', CAST(N'2020-03-02' AS Date), CAST(N'2020-03-02' AS Date), 0, 1, 5003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (16013, N'mackica', CAST(N'2020-03-03' AS Date), CAST(N'2020-03-03' AS Date), 1, 0, 5003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (17013, N'Pozer', CAST(N'2020-03-09' AS Date), CAST(N'2020-03-11' AS Date), 0, 1, 5003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (17014, N'Tralala', CAST(N'2020-03-09' AS Date), CAST(N'2020-03-27' AS Date), 0, 0, 5003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (18013, N'', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 0, 0, 5003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (19013, N'', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 0, 0, 5003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (20013, N'Postavljena obaveza da', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 5003, 3)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (21013, N'Age of Empires II', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-18' AS Date), 0, 0, 3007, 4)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22013, N'Mauzer', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22014, N'Deadline more dead than line', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-26' AS Date), 0, 1, 7003, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22015, N'sdadadas', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22016, N'sdadasadad', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22017, N'aaaa', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22018, N'asdsadad', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (22019, N'sdadadasdada', CAST(N'2020-03-10' AS Date), CAST(N'2020-03-10' AS Date), 1, 0, 7003, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (23013, N'Wellness lesnik', CAST(N'2020-03-12' AS Date), CAST(N'2020-03-12' AS Date), 0, 0, 3006, 5)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (23014, N'MVP', CAST(N'2020-03-12' AS Date), CAST(N'2020-03-12' AS Date), 0, 0, 3006, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (24013, N'Tetrapak', CAST(N'2020-05-27' AS Date), CAST(N'2020-05-27' AS Date), 0, 1, 3007, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (24014, N'dsaddasdsada', CAST(N'2020-05-27' AS Date), CAST(N'2020-05-27' AS Date), 1, 0, 3007, 1)
INSERT [dbo].[Obaveza] ([IdObaveze], [Naziv], [DatumPostavljanja], [DatumRokaIzvrsenja], [Potvrdjena], [Ponistena], [IdKorisnika], [IdTipaObaveze]) VALUES (24015, N'sdasdasd', CAST(N'2020-05-27' AS Date), CAST(N'2020-05-29' AS Date), 0, 0, 3007, 3)
SET IDENTITY_INSERT [dbo].[Obaveza] OFF
GO
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (2006, 1, N'sdsadsad', N'dasdsadad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (3006, 1, N'sdad', N'dsadadsad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (3006, 2, N'sdasdsad', N'dsadadsad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (3006, 3, N'asdasdsad', N'dasdsadsada')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (4005, 1, N'Uzmi patike', N'Na tavanu su.')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (4005, 2, N'aaaaa', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (6006, 1, N'dsad', N'sdadad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (6008, 1, N'11111111111', N'111111111111')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (6008, 2, N'22', N'2222222222222222222222222222222')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (7006, 1, N'111', N'111')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (7006, 2, N'ew', N'sada')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (12013, 1, N'11', N'1111111')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (12014, 1, N'111', N'3231')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (13013, 1, N'dsadad', N'asdadad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (14013, 1, N'sdsad', N'asdasdasd')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (15013, 1, N'Ana', N'Neprekidan trud, a ne snaga i inteligencija, je kljuc da otkljucamo naše mogucnosti", kaže jedna izreka.')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (16013, 1, N'sdad', N'sdadadadsadadasasdsadsad')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (17013, 1, N'Araddd', N'Pepe Zulian Onzima')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (20013, 1, N'Kupi', N'Nemoj')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (21013, 1, N'dasd', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (22013, 1, N'Jejec', N'')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (22014, 1, N'Paviljon', N'Kezexc')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23013, 1, N'dobro', N'Baby wet wipes')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23013, 2, N'Mini puzzel', N'Waarschuwing! Niet geschikt voor kinderen onder 3 jaar. Bevat kleine onderdelen. Verstikkingsgevaar.')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23014, 1, N'User actions', N'')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23014, 2, N'Update model', N'')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23014, 3, N'Model changed', N'')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (23014, 4, N'Uptade UI', N'')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (24013, 1, N'sda', N'dasdsdadas')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (24013, 2, N'dsda', N'sdsadsada')
INSERT [dbo].[StavkaObaveze] ([IdObaveze], [RedniBroj], [Naziv], [Napomena]) VALUES (24015, 1, N'dsad', N'sdad')
GO
SET IDENTITY_INSERT [dbo].[TipObaveze] ON 

INSERT [dbo].[TipObaveze] ([IdTipaObaveze], [NazivTipaObaveze]) VALUES (1, N'SKOLSKA')
INSERT [dbo].[TipObaveze] ([IdTipaObaveze], [NazivTipaObaveze]) VALUES (2, N'KUCNA')
INSERT [dbo].[TipObaveze] ([IdTipaObaveze], [NazivTipaObaveze]) VALUES (3, N'POSLOVNA')
INSERT [dbo].[TipObaveze] ([IdTipaObaveze], [NazivTipaObaveze]) VALUES (4, N'SPORTSKA')
INSERT [dbo].[TipObaveze] ([IdTipaObaveze], [NazivTipaObaveze]) VALUES (5, N'OSTALE')
SET IDENTITY_INSERT [dbo].[TipObaveze] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Korisnik__992E6F92CA7DDE57]    Script Date: 6/17/2020 7:02:08 PM ******/
ALTER TABLE [dbo].[Korisnik] ADD UNIQUE NONCLUSTERED 
(
	[KorisnickoIme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IzvrsilacObaveze]  WITH CHECK ADD  CONSTRAINT [FK_IzvrsilacObaveze_To Korisnik] FOREIGN KEY([IdKorisnika])
REFERENCES [dbo].[Korisnik] ([IdKorisnika])
GO
ALTER TABLE [dbo].[IzvrsilacObaveze] CHECK CONSTRAINT [FK_IzvrsilacObaveze_To Korisnik]
GO
ALTER TABLE [dbo].[IzvrsilacObaveze]  WITH CHECK ADD  CONSTRAINT [FK_IzvrsilacObaveze_To Obaveza] FOREIGN KEY([IdObaveze])
REFERENCES [dbo].[Obaveza] ([IdObaveze])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IzvrsilacObaveze] CHECK CONSTRAINT [FK_IzvrsilacObaveze_To Obaveza]
GO
ALTER TABLE [dbo].[Obaveza]  WITH CHECK ADD  CONSTRAINT [FK_Obaveza_Korisnik] FOREIGN KEY([IdKorisnika])
REFERENCES [dbo].[Korisnik] ([IdKorisnika])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Obaveza] CHECK CONSTRAINT [FK_Obaveza_Korisnik]
GO
ALTER TABLE [dbo].[Obaveza]  WITH CHECK ADD  CONSTRAINT [FK_Obaveza_TipObaveze] FOREIGN KEY([IdTipaObaveze])
REFERENCES [dbo].[TipObaveze] ([IdTipaObaveze])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Obaveza] CHECK CONSTRAINT [FK_Obaveza_TipObaveze]
GO
ALTER TABLE [dbo].[StavkaObaveze]  WITH CHECK ADD  CONSTRAINT [FK_StavkaObaveze_To Obaveza] FOREIGN KEY([IdObaveze])
REFERENCES [dbo].[Obaveza] ([IdObaveze])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StavkaObaveze] CHECK CONSTRAINT [FK_StavkaObaveze_To Obaveza]
GO
ALTER TABLE [dbo].[Obaveza]  WITH CHECK ADD  CONSTRAINT [DatumPostavljanja_DatumRokaIzvrsenja] CHECK  (([DatumPostavljanja]<=[DatumRokaIzvrsenja]))
GO
ALTER TABLE [dbo].[Obaveza] CHECK CONSTRAINT [DatumPostavljanja_DatumRokaIzvrsenja]
GO
ALTER TABLE [dbo].[Obaveza]  WITH CHECK ADD  CONSTRAINT [Potvrdjena_Ponistena] CHECK  (([Potvrdjena]=(0) OR [Ponistena]=(0)))
GO
ALTER TABLE [dbo].[Obaveza] CHECK CONSTRAINT [Potvrdjena_Ponistena]
GO
USE [master]
GO
ALTER DATABASE [Obaveze] SET  READ_WRITE 
GO
