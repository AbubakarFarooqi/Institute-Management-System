USE [master]
GO
/****** Object:  Database [Institution]    Script Date: 11/27/2023 7:07:53 PM ******/
CREATE DATABASE [Institution]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Institution', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Institution.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Institution_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Institution_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Institution] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Institution].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Institution] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Institution] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Institution] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Institution] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Institution] SET ARITHABORT OFF 
GO
ALTER DATABASE [Institution] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Institution] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Institution] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Institution] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Institution] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Institution] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Institution] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Institution] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Institution] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Institution] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Institution] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Institution] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Institution] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Institution] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Institution] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Institution] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Institution] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Institution] SET RECOVERY FULL 
GO
ALTER DATABASE [Institution] SET  MULTI_USER 
GO
ALTER DATABASE [Institution] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Institution] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Institution] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Institution] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Institution] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Institution] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Institution', N'ON'
GO
ALTER DATABASE [Institution] SET QUERY_STORE = ON
GO
ALTER DATABASE [Institution] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Institution]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[CreditHrs] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK__Course__C92D71A7ABE0A4F3] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursetoTeac]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursetoTeac](
	[CourseId] [int] NOT NULL,
	[TecId] [int] NOT NULL,
	[TeacName] [nchar](10) NOT NULL,
	[CourseName] [nchar](10) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[ID] [int] NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK_CoursetoTeac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edit-Course]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edit-Course](
	[CourseId] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[CreditHrs] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[NewName] [nchar](10) NOT NULL,
	[NewCreditHrs] [int] NOT NULL,
	[NewStatus] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edit-Fee]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edit-Fee](
	[StdId] [int] NOT NULL,
	[StdName] [nchar](10) NOT NULL,
	[Fee] [nchar](10) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[NewStdName] [nchar](10) NOT NULL,
	[NewFee] [nchar](10) NOT NULL,
	[NewStatus] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edit-Student]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edit-Student](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[grade] [varchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NewName] [varchar](50) NOT NULL,
	[NewGender] [varchar](50) NOT NULL,
	[NewAddress] [nvarchar](50) NOT NULL,
	[NewGrade] [varchar](50) NOT NULL,
	[NewPhone] [nvarchar](50) NOT NULL,
	[NewStatus] [nchar](10) NOT NULL,
	[NewEmail] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[CourseId] [int] NOT NULL,
	[StdId] [int] NOT NULL,
	[Time1] [datetime] NOT NULL,
	[CourseName] [nchar](10) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[EvaId] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Syllabus] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[TotalWg] [int] NOT NULL,
	[Subject] [nchar](10) NOT NULL,
	[class] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[EvaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fee]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee](
	[StdId] [int] NOT NULL,
	[StdName] [nchar](10) NOT NULL,
	[Fee] [nchar](10) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Management]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Management](
	[ID] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Gender] [nchar](10) NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Category] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[grade] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK_Management] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManAtt]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManAtt](
	[ManId] [int] NOT NULL,
	[ManName] [nchar](10) NOT NULL,
	[Attendence] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mischallanoues_Expenses]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mischallanoues_Expenses](
	[Electricity] [int] NOT NULL,
	[Gas] [int] NOT NULL,
	[Water] [int] NOT NULL,
	[Month_bill] [int] NOT NULL,
	[ManId] [int] NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SignUp]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignUp](
	[Name] [nchar](10) NULL,
	[Phone] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ID] [int] NOT NULL,
	[Creatd-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK_SignUp] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StdAtt]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StdAtt](
	[StdId] [int] NOT NULL,
	[StdName] [nchar](10) NOT NULL,
	[Attendence] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StdEvaluation]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StdEvaluation](
	[EvaId] [int] NOT NULL,
	[StdId] [int] NOT NULL,
	[ObtWg] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[grade] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Gender] [nchar](10) NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[AccountNo] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[salary] [int] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Editted] [datetime] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TecAtt]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TecAtt](
	[TecId] [int] NOT NULL,
	[TecName] [nchar](10) NOT NULL,
	[Attendence] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 11/27/2023 7:07:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Marks] [int] NOT NULL,
	[Syllabus] [nvarchar](50) NOT NULL,
	[TestTime] [datetime] NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[Created-On] [datetime] NOT NULL,
	[Editted-On] [datetime] NULL,
 CONSTRAINT [PK__Test__8CC331607499737D] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [Name], [Gender], [Address], [grade], [Phone], [Status], [Email], [Created-On], [Editted-On]) VALUES (2, N'bnm       ', N'dftyu     ', N'db', 89, N'dtyu', N'1         ', N'uik       ', CAST(N'2023-11-27T14:53:14.087' AS DateTime), NULL)
INSERT [dbo].[Student] ([ID], [Name], [Gender], [Address], [grade], [Phone], [Status], [Email], [Created-On], [Editted-On]) VALUES (3, N'fgh       ', N'rtu       ', N'rtyui', 456, N'56gb', N'1         ', N'fgh       ', CAST(N'2023-11-27T15:15:12.723' AS DateTime), CAST(N'2023-11-27T15:15:12.723' AS DateTime))
INSERT [dbo].[Student] ([ID], [Name], [Gender], [Address], [grade], [Phone], [Status], [Email], [Created-On], [Editted-On]) VALUES (4, N'yuj       ', N'fgh       ', N'dfgh', 89, N'567', N'1         ', N'y@gmail.com', CAST(N'2023-11-27T15:29:17.693' AS DateTime), CAST(N'2023-11-27T15:29:17.693' AS DateTime))
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
/****** Object:  Index [UQ__Evaluati__D17BC9421C2F7A26]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Evaluation] ADD  CONSTRAINT [UQ__Evaluati__D17BC9421C2F7A26] UNIQUE NONCLUSTERED 
(
	[EvaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Manageme__3399D668D69A273E]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Management] ADD  CONSTRAINT [UQ__Manageme__3399D668D69A273E] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Manageme__A9D10534C7C4672F]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Management] ADD  CONSTRAINT [UQ__Manageme__A9D10534C7C4672F] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [unique_constraint_name]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[SignUp] ADD  CONSTRAINT [unique_constraint_name] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_constraint_name1]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[SignUp] ADD  CONSTRAINT [unique_constraint_name1] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__StdEvalu__55DCAE1E43C295D2]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[StdEvaluation] ADD  CONSTRAINT [UQ__StdEvalu__55DCAE1E43C295D2] UNIQUE NONCLUSTERED 
(
	[StdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__StdEvalu__D17BC942FBA0C4F1]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[StdEvaluation] ADD  CONSTRAINT [UQ__StdEvalu__D17BC942FBA0C4F1] UNIQUE NONCLUSTERED 
(
	[EvaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Student__55DCAE1E42FC4D19]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ__Student__55DCAE1E42FC4D19] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Teacher__349D9DFC650D5800]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [UQ__Teacher__349D9DFC650D5800] UNIQUE NONCLUSTERED 
(
	[AccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Teacher__5FD2029861E9D95C]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [UQ__Teacher__5FD2029861E9D95C] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Teacher__A9D105344AFE2D76]    Script Date: 11/27/2023 7:07:54 PM ******/
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [UQ__Teacher__A9D105344AFE2D76] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CoursetoTeac]  WITH CHECK ADD  CONSTRAINT [FK__CoursetoT__Cours__5DCAEF64] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CoursetoTeac] CHECK CONSTRAINT [FK__CoursetoT__Cours__5DCAEF64]
GO
ALTER TABLE [dbo].[CoursetoTeac]  WITH CHECK ADD  CONSTRAINT [FK__CoursetoT__TecId__5EBF139D] FOREIGN KEY([TecId])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[CoursetoTeac] CHECK CONSTRAINT [FK__CoursetoT__TecId__5EBF139D]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK__Enrollmen__Cours__5AEE82B9] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK__Enrollmen__Cours__5AEE82B9]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK__Enrollmen__StdId__5BE2A6F2] FOREIGN KEY([StdId])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK__Enrollmen__StdId__5BE2A6F2]
GO
ALTER TABLE [dbo].[Fee]  WITH CHECK ADD  CONSTRAINT [FK__Fee__StdId__05D8E0BE] FOREIGN KEY([StdId])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Fee] CHECK CONSTRAINT [FK__Fee__StdId__05D8E0BE]
GO
ALTER TABLE [dbo].[ManAtt]  WITH CHECK ADD  CONSTRAINT [FK__ManAtt__ManId__0F624AF8] FOREIGN KEY([ManId])
REFERENCES [dbo].[Management] ([ID])
GO
ALTER TABLE [dbo].[ManAtt] CHECK CONSTRAINT [FK__ManAtt__ManId__0F624AF8]
GO
ALTER TABLE [dbo].[Mischallanoues_Expenses]  WITH CHECK ADD  CONSTRAINT [FK__Mischalla__ManId__208CD6FA] FOREIGN KEY([ManId])
REFERENCES [dbo].[Management] ([ID])
GO
ALTER TABLE [dbo].[Mischallanoues_Expenses] CHECK CONSTRAINT [FK__Mischalla__ManId__208CD6FA]
GO
ALTER TABLE [dbo].[StdAtt]  WITH CHECK ADD  CONSTRAINT [FK__StdAtt__StdId__0B91BA14] FOREIGN KEY([StdId])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StdAtt] CHECK CONSTRAINT [FK__StdAtt__StdId__0B91BA14]
GO
ALTER TABLE [dbo].[StdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK__StdEvalua__EvaId__5165187F] FOREIGN KEY([EvaId])
REFERENCES [dbo].[Evaluation] ([EvaId])
GO
ALTER TABLE [dbo].[StdEvaluation] CHECK CONSTRAINT [FK__StdEvalua__EvaId__5165187F]
GO
ALTER TABLE [dbo].[StdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK__StdEvalua__StdId__52593CB8] FOREIGN KEY([StdId])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StdEvaluation] CHECK CONSTRAINT [FK__StdEvalua__StdId__52593CB8]
GO
ALTER TABLE [dbo].[TecAtt]  WITH CHECK ADD  CONSTRAINT [FK__TecAtt__TecId__0D7A0286] FOREIGN KEY([TecId])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[TecAtt] CHECK CONSTRAINT [FK__TecAtt__TecId__0D7A0286]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK__Test__CourseId__59063A47] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK__Test__CourseId__59063A47]
GO
USE [master]
GO
ALTER DATABASE [Institution] SET  READ_WRITE 
GO
