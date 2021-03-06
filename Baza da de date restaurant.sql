USE [master]
GO
/****** Object:  Database [Restaurant]    Script Date: 5/31/2020 1:40:34 PM ******/
CREATE DATABASE [Restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Restaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Restaurant] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Restaurant] SET QUERY_STORE = OFF
GO
USE [Restaurant]
GO
/****** Object:  Table [dbo].[Alergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergen](
	[Id_alergen] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Alergen] PRIMARY KEY CLUSTERED 
(
	[Id_alergen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[Id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[Id_categorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda](
	[Id_comanda] [int] IDENTITY(1,1) NOT NULL,
	[Stare] [nvarchar](50) NOT NULL,
	[Cost_mancare] [float] NOT NULL,
	[Cost_transport] [float] NOT NULL,
	[Data_comanda] [date] NOT NULL,
	[Ora_livrarii] [time](7) NOT NULL,
	[Id_utilizator] [int] NOT NULL,
 CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED 
(
	[Id_comanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Meniu]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Meniu](
	[Id_comanda_meniu] [int] IDENTITY(1,1) NOT NULL,
	[Id_comanda] [int] NOT NULL,
	[Id_meniu] [int] NOT NULL,
	[Bucati] [int] NOT NULL,
 CONSTRAINT [PK_Comanda_Meniu_1] PRIMARY KEY CLUSTERED 
(
	[Id_comanda_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Produs]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Produs](
	[Id_comanda_produs] [int] IDENTITY(1,1) NOT NULL,
	[Id_comanda] [int] NOT NULL,
	[Id_produs] [int] NOT NULL,
	[Bucati] [int] NOT NULL,
 CONSTRAINT [PK_Comanda_Produs_1] PRIMARY KEY CLUSTERED 
(
	[Id_comanda_produs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu](
	[Id_meniu] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
	[Imagine] [nvarchar](50) NOT NULL,
	[Id_categorie] [int] NOT NULL,
 CONSTRAINT [PK_Meniu] PRIMARY KEY CLUSTERED 
(
	[Id_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu_Produs]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu_Produs](
	[Id_meniu_produs] [int] IDENTITY(1,1) NOT NULL,
	[Id_meniu] [int] NOT NULL,
	[Id_produs] [int] NOT NULL,
	[cantitate] [int] NOT NULL,
	[pret] [int] NOT NULL,
 CONSTRAINT [PK_Meniu_Produs] PRIMARY KEY CLUSTERED 
(
	[Id_meniu_produs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produs]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produs](
	[Id_produs] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
	[Pret] [float] NOT NULL,
	[Cantitate] [int] NOT NULL,
	[Cantitate_toala] [int] NOT NULL,
	[Imagine] [nvarchar](50) NOT NULL,
	[Id_categorie] [int] NOT NULL,
 CONSTRAINT [PK_Produs] PRIMARY KEY CLUSTERED 
(
	[Id_produs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produs_Alergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produs_Alergen](
	[Id_produs_alergen] [int] IDENTITY(1,1) NOT NULL,
	[Id_produs] [int] NOT NULL,
	[Id_alergen] [int] NOT NULL,
 CONSTRAINT [PK_Produs_Alergen_1] PRIMARY KEY CLUSTERED 
(
	[Id_produs_alergen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizator]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizator](
	[Id_utilizator] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
	[Prenume] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Adresa_livrare] [nvarchar](50) NULL,
	[Parola] [nvarchar](50) NOT NULL,
	[Statut] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Utilizator] PRIMARY KEY CLUSTERED 
(
	[Id_utilizator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alergen] ON 

INSERT [dbo].[Alergen] ([Id_alergen], [Nume]) VALUES (1, N'Gluten')
INSERT [dbo].[Alergen] ([Id_alergen], [Nume]) VALUES (2, N'Oua')
INSERT [dbo].[Alergen] ([Id_alergen], [Nume]) VALUES (3, N'Lapte')
INSERT [dbo].[Alergen] ([Id_alergen], [Nume]) VALUES (4, N'Mustar')
INSERT [dbo].[Alergen] ([Id_alergen], [Nume]) VALUES (5, N'Susan')
SET IDENTITY_INSERT [dbo].[Alergen] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 

INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (1, N'Mic dejun')
INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (2, N'Preparate din pui')
INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (3, N'Preparate din vita')
INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (4, N'Sosuri')
INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (5, N'Desert')
INSERT [dbo].[Categorie] ([Id_categorie], [Nume]) VALUES (6, N'Bauturi')
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda] ON 

INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (1, N'Inregistrata', 22, 0, CAST(N'2020-05-26' AS Date), CAST(N'15:33:16.8138149' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (2, N'Inregistrata', 30.6, 0, CAST(N'2020-05-26' AS Date), CAST(N'16:42:58.3130096' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (3, N'Inregistrata', 30.6, 0, CAST(N'2020-05-26' AS Date), CAST(N'16:43:44.4254359' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (4, N'Inregistrata', 31.1, 0, CAST(N'2020-05-26' AS Date), CAST(N'16:44:53.3455270' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (5, N'Inregistrata', 31.1, 0, CAST(N'2020-05-26' AS Date), CAST(N'16:46:32.1942211' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (6, N'Inregistrata', 31.1, 0, CAST(N'2020-05-26' AS Date), CAST(N'16:48:49.5463377' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (7, N'Inregistrata', 0, 5, CAST(N'2020-05-26' AS Date), CAST(N'17:07:02.5713070' AS Time), 4)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (1007, N'Inregistrata', 28.1, 0, CAST(N'2020-05-29' AS Date), CAST(N'16:24:53.9428489' AS Time), 5)
INSERT [dbo].[Comanda] ([Id_comanda], [Stare], [Cost_mancare], [Cost_transport], [Data_comanda], [Ora_livrarii], [Id_utilizator]) VALUES (1008, N'Inregistrata', 33.2, 0, CAST(N'2020-05-30' AS Date), CAST(N'14:23:32.1623679' AS Time), 5)
SET IDENTITY_INSERT [dbo].[Comanda] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda_Meniu] ON 

INSERT [dbo].[Comanda_Meniu] ([Id_comanda_meniu], [Id_comanda], [Id_meniu], [Bucati]) VALUES (1, 6, 1, 1)
INSERT [dbo].[Comanda_Meniu] ([Id_comanda_meniu], [Id_comanda], [Id_meniu], [Bucati]) VALUES (2, 1007, 1, 1)
INSERT [dbo].[Comanda_Meniu] ([Id_comanda_meniu], [Id_comanda], [Id_meniu], [Bucati]) VALUES (3, 1008, 4, 1)
SET IDENTITY_INSERT [dbo].[Comanda_Meniu] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda_Produs] ON 

INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (1, 4, 1, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (2, 4, 12, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (3, 4, 14, 2)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (4, 5, 1, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (5, 5, 12, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (6, 5, 14, 2)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (7, 6, 12, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (8, 6, 14, 2)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (9, 1007, 4, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (10, 1007, 15, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (11, 1008, 2, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (12, 1008, 16, 1)
INSERT [dbo].[Comanda_Produs] ([Id_comanda_produs], [Id_comanda], [Id_produs], [Bucati]) VALUES (13, 1008, 14, 1)
SET IDENTITY_INSERT [dbo].[Comanda_Produs] OFF
GO
SET IDENTITY_INSERT [dbo].[Meniu] ON 

INSERT [dbo].[Meniu] ([Id_meniu], [Nume], [Imagine], [Id_categorie]) VALUES (1, N'Meniu Big Mac', N'../Images/MeniuBigMac.jpg', 3)
INSERT [dbo].[Meniu] ([Id_meniu], [Nume], [Imagine], [Id_categorie]) VALUES (2, N'Meniu Cheeseburger', N'../Images/MeniuCheeseburger.jpg', 3)
INSERT [dbo].[Meniu] ([Id_meniu], [Nume], [Imagine], [Id_categorie]) VALUES (3, N'Meniu McChicken', N'../Images/MeniuMcChicken.jpg', 2)
INSERT [dbo].[Meniu] ([Id_meniu], [Nume], [Imagine], [Id_categorie]) VALUES (4, N'Meniu Aripioare', N'../Images/MeniuAripioare.jpg', 2)
SET IDENTITY_INSERT [dbo].[Meniu] OFF
GO
SET IDENTITY_INSERT [dbo].[Meniu_Produs] ON 

INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (1, 1, 8, 200, 10)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (2, 1, 3, 100, 4)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (3, 1, 17, 500, 5)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (4, 2, 9, 130, 5)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (5, 2, 3, 100, 4)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (6, 2, 17, 500, 5)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (7, 3, 5, 200, 10)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (8, 3, 3, 100, 4)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (9, 3, 17, 500, 5)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (10, 4, 6, 180, 9)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (11, 4, 3, 100, 4)
INSERT [dbo].[Meniu_Produs] ([Id_meniu_produs], [Id_meniu], [Id_produs], [cantitate], [pret]) VALUES (12, 4, 17, 500, 5)
SET IDENTITY_INSERT [dbo].[Meniu_Produs] OFF
GO
SET IDENTITY_INSERT [dbo].[Produs] ON 

INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (1, N'Omleta', 15, 200, 2000, N'../Images/Omleta.jpg', 1)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (2, N'McToast', 3, 100, 900, N'../Images/McToast.jpg', 1)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (3, N'Cartofi prajiti', 4, 100, 800, N'../Images/Cartofi.jpg', 1)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (4, N'McPuisor', 3, 100, 900, N'../Images/McPuisor.jpg', 2)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (5, N'McChicken', 10, 200, 2000, N'../Images/McChicken.jpg', 2)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (6, N'Aripioare', 9, 180, 1620, N'../Images/Aripioare.jpg', 2)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (7, N'Hamburger', 3, 100, 1000, N'../Images/Hamburger.jpg', 3)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (8, N'Big Mac', 10, 200, 1800, N'../Images/BigMac.jpg', 3)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (9, N'Cheeseburger', 5, 130, 1300, N'../Images/Cheeseburger.jpg', 3)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (10, N'Ketchup', 2, 20, 200, N'../Images/Ketchup.jpg', 4)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (11, N'Maioneza', 2, 20, 200, N'../Images/Maioneza.jpg', 4)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (12, N'Usturoi', 2, 20, 200, N'../Images/Usturoi.jpg', 4)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (13, N'Chilli', 2, 20, 200, N'../Images/Chilli.jpg', 4)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (14, N'Placinta', 6, 80, 720, N'../Images/Placinta.jpg', 5)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (15, N'Inghetata', 8, 150, 1350, N'../Images/Inghetata.jpg', 5)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (16, N'Cafea', 8, 200, 1800, N'../Images/Cafea.jpg', 6)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (17, N'Suc', 5, 500, 4000, N'../Images/Suc.jpg', 6)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (18, N'Ceai', 7, 200, 2000, N'../Images/Ceai.jpg', 6)
INSERT [dbo].[Produs] ([Id_produs], [Nume], [Pret], [Cantitate], [Cantitate_toala], [Imagine], [Id_categorie]) VALUES (19, N'Apa', 4, 500, 5000, N'../Images/Apa.jpg', 6)
SET IDENTITY_INSERT [dbo].[Produs] OFF
GO
SET IDENTITY_INSERT [dbo].[Produs_Alergen] ON 

INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (1, 1, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (2, 1, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (3, 1, 3)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (4, 2, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (5, 2, 3)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (6, 4, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (7, 4, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (8, 5, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (9, 5, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (10, 5, 4)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (11, 5, 5)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (12, 6, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (13, 6, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (14, 7, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (15, 7, 4)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (16, 8, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (17, 8, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (18, 8, 3)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (19, 8, 5)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (20, 9, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (21, 9, 3)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (22, 9, 4)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (23, 11, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (24, 11, 4)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (25, 12, 2)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (26, 14, 1)
INSERT [dbo].[Produs_Alergen] ([Id_produs_alergen], [Id_produs], [Id_alergen]) VALUES (27, 15, 3)
SET IDENTITY_INSERT [dbo].[Produs_Alergen] OFF
GO
SET IDENTITY_INSERT [dbo].[Utilizator] ON 

INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (1, N'Roiu', N'Daniel', N'dani_roiu@yahoo.com', N'0789103278', NULL, N'restaurantdani', N'angajat')
INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (3, N'popescu', N'alex', N'alex@mail', N'0768174302', N'Calea Bucuresti 6', N'1234', N'client')
INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (4, N'Roiu', N'Daniel', N'dani@mail', N'0123456789', N'Str Independentei 4', N'qwer', N'client')
INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (5, N'Popescu', N'Ana', N'ana@mail', N'0147852963', N'Str Lunga 12', N'abcd', N'client')
INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (6, N'Ionescu', N'Bogdan', N'bogdan@mail', N'0258369147', N'Str 13 Decembrie', N'zxcv', N'client')
INSERT [dbo].[Utilizator] ([Id_utilizator], [Nume], [Prenume], [Mail], [Telefon], [Adresa_livrare], [Parola], [Statut]) VALUES (7, N'Serban', N'Maria', N'maria@mail', N'0159264873', N'Str Grivitei 31', N'maria', N'client')
SET IDENTITY_INSERT [dbo].[Utilizator] OFF
GO
ALTER TABLE [dbo].[Comanda]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Utilizator] FOREIGN KEY([Id_utilizator])
REFERENCES [dbo].[Utilizator] ([Id_utilizator])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Comanda_Utilizator]
GO
ALTER TABLE [dbo].[Comanda_Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Meniu_Comanda] FOREIGN KEY([Id_comanda])
REFERENCES [dbo].[Comanda] ([Id_comanda])
GO
ALTER TABLE [dbo].[Comanda_Meniu] CHECK CONSTRAINT [FK_Comanda_Meniu_Comanda]
GO
ALTER TABLE [dbo].[Comanda_Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Meniu_Meniu] FOREIGN KEY([Id_meniu])
REFERENCES [dbo].[Meniu] ([Id_meniu])
GO
ALTER TABLE [dbo].[Comanda_Meniu] CHECK CONSTRAINT [FK_Comanda_Meniu_Meniu]
GO
ALTER TABLE [dbo].[Comanda_Produs]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Produs_Comanda] FOREIGN KEY([Id_comanda])
REFERENCES [dbo].[Comanda] ([Id_comanda])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda_Produs] CHECK CONSTRAINT [FK_Comanda_Produs_Comanda]
GO
ALTER TABLE [dbo].[Comanda_Produs]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Produs_Produs] FOREIGN KEY([Id_produs])
REFERENCES [dbo].[Produs] ([Id_produs])
GO
ALTER TABLE [dbo].[Comanda_Produs] CHECK CONSTRAINT [FK_Comanda_Produs_Produs]
GO
ALTER TABLE [dbo].[Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Categorie] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie] ([Id_categorie])
GO
ALTER TABLE [dbo].[Meniu] CHECK CONSTRAINT [FK_Meniu_Categorie]
GO
ALTER TABLE [dbo].[Meniu_Produs]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Produs_Meniu] FOREIGN KEY([Id_meniu])
REFERENCES [dbo].[Meniu] ([Id_meniu])
GO
ALTER TABLE [dbo].[Meniu_Produs] CHECK CONSTRAINT [FK_Meniu_Produs_Meniu]
GO
ALTER TABLE [dbo].[Meniu_Produs]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Produs_Produs] FOREIGN KEY([Id_produs])
REFERENCES [dbo].[Produs] ([Id_produs])
GO
ALTER TABLE [dbo].[Meniu_Produs] CHECK CONSTRAINT [FK_Meniu_Produs_Produs]
GO
ALTER TABLE [dbo].[Produs]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Categorie] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorie] ([Id_categorie])
GO
ALTER TABLE [dbo].[Produs] CHECK CONSTRAINT [FK_Produs_Categorie]
GO
ALTER TABLE [dbo].[Produs_Alergen]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Alergen_Alergen] FOREIGN KEY([Id_alergen])
REFERENCES [dbo].[Alergen] ([Id_alergen])
GO
ALTER TABLE [dbo].[Produs_Alergen] CHECK CONSTRAINT [FK_Produs_Alergen_Alergen]
GO
ALTER TABLE [dbo].[Produs_Alergen]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Alergen_Produs] FOREIGN KEY([Id_produs])
REFERENCES [dbo].[Produs] ([Id_produs])
GO
ALTER TABLE [dbo].[Produs_Alergen] CHECK CONSTRAINT [FK_Produs_Alergen_Produs]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAlergen]
	@nume nvarchar(50)
AS
BEGIN
	DELETE FROM Alergen
	WHERE Nume=@nume
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProdus]
	@nume nvarchar(50)
AS
BEGIN
	DELETE FROM Produs
	WHERE Nume=@nume
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertAlergen]
	@nume nvarchar(50),
	@id_Alergen int output
AS
BEGIN
	INSERT INTO Alergen(Nume)
	VALUES(@nume);
	SELECT @id_Alergen=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategorie]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCategorie] 
	@id_categorie int output,@nume nvarchar(50)
AS
BEGIN
	INSERT INTO Categorie(Nume)
	VALUES(@nume)
	SELECT @id_categorie=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertClient]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertClient] 
	@id_utilizator int output, @nume nvarchar(50), @prenume nvarchar(50), @mail nvarchar(50), @telefon nvarchar(50), @adresa nvarchar(50),
	@parola nvarchar(50),@statut nvarchar(50)
AS
BEGIN
	INSERT INTO Utilizator(Nume,Prenume,Mail,Telefon,Adresa_livrare,Parola,Statut)
	VALUES(@nume,@prenume,@mail,@telefon,@adresa,@parola,@statut);
	SELECT @id_utilizator=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertComanda]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertComanda]
	@id_comanda int output,@stare nvarchar(50),@cost_mancare float, @cost_transport float,@data date,@ora_livrarii time(7),@id_utilizator int
AS
BEGIN
	INSERT INTO Comanda(Stare,Cost_mancare,Cost_transport,Data_comanda,Ora_livrarii,Id_utilizator)
	VALUES(@stare,@cost_mancare,@cost_transport,@data,@ora_livrarii,@id_utilizator)
	SELECT @id_comanda=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertComandaMeniu]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertComandaMeniu]
	@id_comanda_meniu int output,@id_comanda int,@id_meniu int, @bucati int
AS
BEGIN
	INSERT INTO Comanda_Meniu(Id_comanda,Id_meniu,Bucati)
	VALUES(@id_comanda,@id_meniu,@bucati)
	SELECT @id_comanda_meniu=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertComandaProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertComandaProdus]
	@id_comanda_produs int output,@id_comanda int,@id_produs int, @bucati int
AS
BEGIN
	INSERT INTO Comanda_Produs(Id_comanda,Id_produs,Bucati)
	VALUES(@id_comanda,@id_produs,@bucati)
	SELECT @id_comanda_produs=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertMeniu]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertMeniu] 
	@id_meniu int output,@nume nvarchar(50),@imagine nvarchar(50),@id_categorie int
AS
BEGIN
	INSERT INTO Meniu(Nume,Imagine,Id_categorie)
	VALUES(@nume,@imagine,@id_categorie)
	SELECT @id_meniu=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertMeniuProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertMeniuProdus] 
	@id_meniu_produs int output,@id_meniu int,@id_produs int, @cantitate int, @pret float
AS
BEGIN
	INSERT INTO Meniu_Produs(Id_meniu,Id_produs,cantitate,pret)
	VALUES(@id_meniu,@id_produs,@cantitate,@pret)
	SELECT @id_meniu_produs=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertProdus] 
	@id_produs int output,@nume nvarchar(50),@pret float ,@cantitate int,@cantitate_totala int,@imagine nvarchar(50),@id_categorie int
AS
BEGIN
	INSERT INTO Produs(Nume,Pret,Cantitate,Cantitate_toala,Imagine,Id_categorie)
	VALUES(@nume,@pret,@cantitate,@cantitate_totala,@imagine,@id_categorie)
	SELECT @id_produs=SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAlergeniiUnuiProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAlergeniiUnuiProdus] 
	@nume nvarchar(50)
AS
BEGIN
	SELECT a.Nume FROM Produs p
	INNER JOIN Produs_Alergen pa
	ON pa.Id_produs=p.Id_produs
	INNER JOIN Alergen a
	ON a.Id_alergen=pa.Id_alergen
	WHERE p.Nume=@nume
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllMeniuri]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllMeniuri] 

AS
BEGIN
	SELECT m.Id_meniu,m.Nume,m.Imagine,c.Nume FROM Meniu m
	INNER JOIN Categorie c
	ON c.Id_categorie=m.Id_categorie
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllProducts]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllProducts]
AS
BEGIN
	SELECT p.Id_produs,p.Nume,p.Pret,p.Cantitate,p.Cantitate_toala,p.Imagine,c.Nume FROM Produs p
	INNER JOIN Categorie c
	ON c.Id_categorie=p.Id_categorie
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUtilizatori]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllUtilizatori] 
	
AS
BEGIN
	SELECT u.Id_utilizator,u.Nume,u.Prenume,u.Mail,u.Telefon,u.Adresa_livrare,u.Parola,u.Statut 
	FROM Utilizator u
END
GO
/****** Object:  StoredProcedure [dbo].[SelectComenzileUnuiClient]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectComenzileUnuiClient]
	@id_utilizator int
AS
BEGIN
	SELECT c.Id_comanda,u.Nume,u.Prenume,u.Adresa_livrare,c.Stare,c.Cost_mancare,c.Cost_transport,c.Data_comanda,c.Ora_livrarii,c.Id_utilizator FROM Comanda c
	INNER JOIN Utilizator u
	ON u.Id_utilizator=c.Id_utilizator
	WHERE c.Id_utilizator=@id_utilizator
	ORDER BY c.Data_comanda,c.Ora_livrarii desc
END
GO
/****** Object:  StoredProcedure [dbo].[SelectMeniuriCareAuAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectMeniuriCareAuAlergen]
	@nume_alergen nvarchar(50)
AS
BEGIN
	SELECT m.Id_meniu,m.Nume,m.Imagine,c.Nume FROM Meniu m
	INNER JOIN Meniu_Produs mp
	ON mp.Id_meniu=m.Id_meniu
	INNER JOIN Produs p
	ON p.Id_produs=mp.Id_produs
	INNER JOIN Produs_Alergen pa
	ON pa.Id_produs=p.Id_produs
	INNER JOIN Alergen a
	ON a.Id_alergen= pa.Id_alergen
	INNER JOIN Categorie c
	ON c.Id_categorie=m.Id_categorie
	WHERE a.Nume = @nume_alergen
END
GO
/****** Object:  StoredProcedure [dbo].[SelectMeniuriCareContinNume]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectMeniuriCareContinNume]
	@nume nvarchar(50)
AS
BEGIN
	SELECT m.Id_meniu,m.Nume,m.Imagine,c.Nume FROM Meniu m
	INNER JOIN Categorie c
	ON c.Id_categorie= m.Id_categorie
	WHERE CHARINDEX(@nume, m.Nume) > 0
END
GO
/****** Object:  StoredProcedure [dbo].[SelectMeniuriCareNuAuAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectMeniuriCareNuAuAlergen]
	@nume_alergen nvarchar(50)
AS
BEGIN
	SELECT m.Id_meniu,m.Nume,m.Imagine,c.Nume FROM Meniu m
	INNER JOIN Categorie c
	ON c.Id_categorie=m.Id_categorie
	WHERE m.Nume not in (SELECT m.Nume FROM Meniu m
	INNER JOIN Meniu_Produs mp
	ON mp.Id_meniu=m.Id_meniu
	INNER JOIN Produs p
	ON p.Id_produs=mp.Id_produs
	INNER JOIN Produs_Alergen pa
	ON pa.Id_produs=p.Id_produs
	INNER JOIN Alergen a
	ON a.Id_alergen= pa.Id_alergen
	WHERE a.Nume = @nume_alergen)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectMeniuriCareNuContinNume]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectMeniuriCareNuContinNume]
	@nume nvarchar(50)
AS
BEGIN
	SELECT m.Id_meniu,m.Nume,m.Imagine,c.Nume FROM Meniu m
	INNER JOIN Categorie c
	ON c.Id_categorie= m.Id_categorie
	WHERE CHARINDEX(@nume, m.Nume) = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SelectProduseCareAuAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectProduseCareAuAlergen] 
	@nume_alergen nvarchar(50)
AS
BEGIN
	SELECT p.Id_produs,p.Nume,p.Pret,p.Cantitate,p.Cantitate_toala,p.Imagine,c.Nume FROM Produs p
	INNER JOIN Produs_Alergen pa
	ON pa.Id_produs=p.Id_produs
	INNER JOIN Alergen a
	ON a.Id_alergen= pa.Id_alergen
	INNER JOIN Categorie c
	ON c.Id_categorie=p.Id_categorie
	WHERE a.Nume = @nume_alergen
END
GO
/****** Object:  StoredProcedure [dbo].[SelectProduseCareContinNume]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectProduseCareContinNume]
	@nume nvarchar(50)
AS
BEGIN
	SELECT prod.Id_produs,prod.Nume,prod.Pret,prod.Cantitate,prod.Cantitate_toala,prod.Imagine,c.Nume FROM Produs prod
	INNER JOIN Categorie c
	ON c.Id_categorie=prod.Id_categorie
	WHERE CHARINDEX(@nume, prod.Nume) > 0
END
GO
/****** Object:  StoredProcedure [dbo].[SelectProduseCareNuAuAlergen]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectProduseCareNuAuAlergen] 
	@nume_alergen nvarchar(50)
AS
BEGIN
	SELECT prod.Id_produs,prod.Nume,prod.Pret,prod.Cantitate,prod.Cantitate_toala,prod.Imagine,c.Nume FROM Produs prod
	INNER JOIN Categorie c
	ON c.Id_categorie=prod.Id_categorie
	WHERE prod.Nume not in (SELECT p.Nume FROM Produs p
	INNER JOIN Produs_Alergen pa
	ON pa.Id_produs=p.Id_produs
	INNER JOIN Alergen a
	ON a.Id_alergen= pa.Id_alergen
	WHERE a.Nume = @nume_alergen)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectProduseCareNuContinNume]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectProduseCareNuContinNume]
	@nume nvarchar(50)
AS
BEGIN
	SELECT prod.Id_produs,prod.Nume,prod.Pret,prod.Cantitate,prod.Cantitate_toala,prod.Imagine,c.Nume FROM Produs prod
	INNER JOIN Categorie c
	ON c.Id_categorie=prod.Id_categorie
	WHERE CHARINDEX(@nume, prod.Nume) = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SelectProdusePentruMeniu]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectProdusePentruMeniu] 
	@id_meniu int
AS
BEGIN
	SELECT mp.Id_produs,mp.pret,mp.cantitate,p.Nume,p.Imagine,p.Cantitate_toala,c.Nume FROM Meniu_Produs mp 
	INNER JOIN Produs p
	on p.Id_produs=mp.Id_produs
	INNER JOIN Categorie c
	ON c.Id_categorie=p.Id_categorie
	WHERE mp.Id_meniu=@id_meniu
END
GO
/****** Object:  StoredProcedure [dbo].[SelectToateComenzile]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectToateComenzile] 
	
AS
BEGIN
	SELECT c.Id_comanda,u.Nume,u.Prenume,u.Adresa_livrare, c.Stare,c.Cost_mancare,c.Cost_transport,c.Data_comanda,c.Ora_livrarii,c.Id_utilizator FROM Comanda c
	INNER JOIN Utilizator u
	ON u.Id_utilizator=c.Id_utilizator
	ORDER BY c.Data_comanda,c.Ora_livrarii desc
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateComanda]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateComanda]
	@id_comanda int ,@stare nvarchar(50),@cost_mancare float, @cost_transport float,@data date,@ora_livrarii time(7),@id_utilizator int
AS
BEGIN
	UPDATE Comanda
	SET Stare=@stare,Cost_mancare=@cost_mancare,Cost_transport=@cost_transport,Data_comanda=@data,Ora_livrarii=@ora_livrarii,Id_utilizator=@id_utilizator
	WHERE Id_comanda=@id_comanda
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProdus]    Script Date: 5/31/2020 1:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProdus] 
	@id int,@nume nvarchar(50),@pret float ,@cantitate int,@cantitate_totala int,@imagine nvarchar(50)
AS
BEGIN
	UPDATE Produs
	SET Nume = @nume,Pret=@pret,Cantitate=@cantitate,Cantitate_toala=@cantitate_totala,Imagine=@imagine
	WHERE Id_produs=@id;
END
GO
USE [master]
GO
ALTER DATABASE [Restaurant] SET  READ_WRITE 
GO
