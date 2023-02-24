USE [master]
GO
/****** Object:  Database [New_Course_ITDB_2023]    Script Date: 11/12/2022 1:54:13 PM ******/
CREATE DATABASE [New_Course_ITDB_2023]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'New_Course_ITDB_2023', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\New_Course_ITDB_2023.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'New_Course_ITDB_2023_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\New_Course_ITDB_2023_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [New_Course_ITDB_2023] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [New_Course_ITDB_2023].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ARITHABORT OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET  DISABLE_BROKER 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET RECOVERY FULL 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET  MULTI_USER 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [New_Course_ITDB_2023] SET DB_CHAINING OFF 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [New_Course_ITDB_2023] SET QUERY_STORE = OFF
GO
USE [New_Course_ITDB_2023]
GO
/****** Object:  Table [dbo].[bindPaper]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bindPaper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Paper_Id] [nvarchar](50) NULL,
 CONSTRAINT [PK_bindPaper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Admin]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Index_No] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_AllAns]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_AllAns](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TID] [nvarchar](50) NULL,
	[Stream] [nvarchar](max) NULL,
	[DivisionCode] [nvarchar](max) NULL,
	[PStatus] [varchar](50) NULL,
	[IndexNo] [nvarchar](50) NULL,
	[Seat_No] [nvarchar](50) NULL,
	[DateTime] [smalldatetime] NULL,
	[IP] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Batch] [nvarchar](50) NULL,
	[OS] [nvarchar](50) NULL,
	[Q1Ans1] [nvarchar](max) NULL,
	[Q1Ans2] [nvarchar](max) NULL,
	[Q1Ans3] [nvarchar](max) NULL,
	[Q1Ans4] [nvarchar](max) NULL,
	[Q1Ans5] [nvarchar](max) NULL,
	[Q1Ans6] [nvarchar](max) NULL,
	[Q1Ans7] [nvarchar](max) NULL,
	[Q1Ans8] [nvarchar](max) NULL,
	[Q1Ans9] [nvarchar](max) NULL,
	[Q1Ans10] [nvarchar](max) NULL,
	[Q7Ans1] [nvarchar](max) NULL,
	[Q7Ans2] [nvarchar](max) NULL,
	[Q7Ans3] [nvarchar](max) NULL,
	[Q7Ans4] [nvarchar](max) NULL,
	[Q7Ans5] [nvarchar](max) NULL,
	[Q7Ans6] [nvarchar](max) NULL,
	[Q7Ans7] [nvarchar](max) NULL,
	[Q7Ans8] [nvarchar](max) NULL,
	[Q8Ans1] [nvarchar](max) NULL,
	[Q8Ans2] [nvarchar](max) NULL,
	[Q8Ans3] [nvarchar](max) NULL,
	[Q8Ans4] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_AllAns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Code_Master]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Code_Master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[division_code] [nvarchar](max) NULL,
	[division_name] [nvarchar](max) NULL,
	[district_code] [nvarchar](max) NULL,
	[district_name] [nvarchar](max) NULL,
	[taluka_code] [nvarchar](max) NULL,
	[taluka_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Code_Master] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CollgeLogin]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CollgeLogin](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[IndexNo] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_CollgeLogin] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Coordinator]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Coordinator](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[IndexNo] [nvarchar](50) NULL,
	[Name] [varchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Coordinator] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Decoded_Answer_Sheets]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Decoded_Answer_Sheets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Seat_No] [nvarchar](50) NULL,
	[Login_Status] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Exam_Time] [nvarchar](max) NULL,
	[Q1ANS1] [nvarchar](max) NULL,
	[Q1ANS2] [nvarchar](max) NULL,
	[Q1ANS3] [nvarchar](max) NULL,
	[Q1ANS4] [nvarchar](max) NULL,
	[Q1ANS5] [nvarchar](max) NULL,
	[Q1ANS6] [nvarchar](max) NULL,
	[Q1ANS7] [nvarchar](max) NULL,
	[Q1ANS8] [nvarchar](max) NULL,
	[Q1ANS9] [nvarchar](max) NULL,
	[Q1ANS10] [nvarchar](max) NULL,
	[Q1ANSWERTIME] [nvarchar](max) NULL,
	[Q2ANS1] [nvarchar](max) NULL,
	[Q2ANS2] [nvarchar](max) NULL,
	[Q2ANS3] [nvarchar](max) NULL,
	[Q2ANS4] [nvarchar](max) NULL,
	[Q2ANS5] [nvarchar](max) NULL,
	[Q2ANS6] [nvarchar](max) NULL,
	[Q2ANS7] [nvarchar](max) NULL,
	[Q2ANS8] [nvarchar](max) NULL,
	[Q2ANS9] [nvarchar](max) NULL,
	[Q2ANS10] [nvarchar](max) NULL,
	[Q2ANSWERTIME] [nvarchar](max) NULL,
	[Q3ANS1] [nvarchar](max) NULL,
	[Q3ANS2] [nvarchar](max) NULL,
	[Q3ANS3] [nvarchar](max) NULL,
	[Q3ANS4] [nvarchar](max) NULL,
	[Q3ANS5] [nvarchar](max) NULL,
	[Q3ANS6] [nvarchar](max) NULL,
	[Q3ANS7] [nvarchar](max) NULL,
	[Q3ANS8] [nvarchar](max) NULL,
	[Q3ANS9] [nvarchar](max) NULL,
	[Q3ANS10] [nvarchar](max) NULL,
	[Q3ANSWERTIME] [nvarchar](max) NULL,
	[Q4ANS1] [nvarchar](max) NULL,
	[Q4ANS2] [nvarchar](max) NULL,
	[Q4ANS3] [nvarchar](max) NULL,
	[Q4ANS4] [nvarchar](max) NULL,
	[Q4ANS5] [nvarchar](max) NULL,
	[Q4ANS6] [nvarchar](max) NULL,
	[Q4ANS7] [nvarchar](max) NULL,
	[Q4ANS8] [nvarchar](max) NULL,
	[Q4ANS9] [nvarchar](max) NULL,
	[Q4ANS10] [nvarchar](max) NULL,
	[Q4ANSWERTIME] [nvarchar](max) NULL,
	[Q5ANS1] [nvarchar](max) NULL,
	[Q5ANS2] [nvarchar](max) NULL,
	[Q5ANSWERTIME] [nvarchar](max) NULL,
	[Q6ANS1] [nvarchar](max) NULL,
	[Q6ANSWERTIME] [nvarchar](max) NULL,
	[Q7ANS1] [nvarchar](max) NULL,
	[Q7ANS2] [nvarchar](max) NULL,
	[Q7ANS3] [nvarchar](max) NULL,
	[Q7ANS4] [nvarchar](max) NULL,
	[Q7ANS5] [nvarchar](max) NULL,
	[Q7ANS6] [nvarchar](max) NULL,
	[Q7ANS7] [nvarchar](max) NULL,
	[Q7ANS8] [nvarchar](max) NULL,
	[Q7ANSWERTIME] [nvarchar](max) NULL,
	[Q8ANS1] [nvarchar](max) NULL,
	[Q8ANS2] [nvarchar](max) NULL,
	[Q8ANS3] [nvarchar](max) NULL,
	[Q8ANS4] [nvarchar](max) NULL,
	[Q8ANSWERTIME] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Decoded_Answer_Sheets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Final_Ans]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Final_Ans](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[cstate] [nvarchar](50) NULL,
	[seat_no] [nvarchar](50) NOT NULL,
	[AssignedDatetime] [smalldatetime] NOT NULL,
	[ip] [nvarchar](max) NULL,
	[Paper_ID] [nvarchar](max) NULL,
	[Q1Ans1] [nvarchar](max) NULL,
	[Q1Ans2] [nvarchar](max) NULL,
	[Q1Ans3] [nvarchar](max) NULL,
	[Q1Ans4] [nvarchar](max) NULL,
	[Q1Ans5] [nvarchar](max) NULL,
	[Q1Ans6] [nvarchar](max) NULL,
	[Q1Ans7] [nvarchar](max) NULL,
	[Q1Ans8] [nvarchar](max) NULL,
	[Q1Ans9] [nvarchar](max) NULL,
	[Q1Ans10] [nvarchar](max) NULL,
	[Q2Ans1] [nvarchar](max) NULL,
	[Q2Ans2] [nvarchar](max) NULL,
	[Q2Ans3] [nvarchar](max) NULL,
	[Q2Ans4] [nvarchar](max) NULL,
	[Q2Ans5] [nvarchar](max) NULL,
	[Q2Ans6] [nvarchar](max) NULL,
	[Q2Ans7] [nvarchar](max) NULL,
	[Q2Ans8] [nvarchar](max) NULL,
	[Q2Ans9] [nvarchar](max) NULL,
	[Q2Ans10] [nvarchar](max) NULL,
	[Q3AAns1] [nvarchar](max) NULL,
	[Q3AAns2] [nvarchar](max) NULL,
	[Q3AAns3] [nvarchar](max) NULL,
	[Q3AAns4] [nvarchar](max) NULL,
	[Q3AAns5] [nvarchar](max) NULL,
	[Q3AAns6] [nvarchar](max) NULL,
	[Q3AAns7] [nvarchar](max) NULL,
	[Q3AAns8] [nvarchar](max) NULL,
	[Q3AAns9] [nvarchar](max) NULL,
	[Q3AAns10] [nvarchar](max) NULL,
	[Q3BAns11] [nvarchar](max) NULL,
	[Q3BAns12] [nvarchar](max) NULL,
	[Q3BAns13] [nvarchar](max) NULL,
	[Q3BAns14] [nvarchar](max) NULL,
	[Q3BAns15] [nvarchar](max) NULL,
	[Q3BAns16] [nvarchar](max) NULL,
	[Q3BAns17] [nvarchar](max) NULL,
	[Q3BAns18] [nvarchar](max) NULL,
	[Q3BAns19] [nvarchar](max) NULL,
	[Q3BAns20] [nvarchar](max) NULL,
	[Q4Ans1] [nvarchar](max) NULL,
	[Q4Ans2] [nvarchar](max) NULL,
	[Q4Ans3] [nvarchar](max) NULL,
	[Q4Ans4] [nvarchar](max) NULL,
	[Q4Ans5] [nvarchar](max) NULL,
	[Q5Ans1] [nvarchar](max) NULL,
	[Q5Ans2] [nvarchar](max) NULL,
	[Q6Ans1] [nvarchar](max) NULL,
	[Q6Ans2] [nvarchar](max) NULL,
	[Q7Ans1] [nvarchar](max) NULL,
	[Q7Ans2] [nvarchar](max) NULL,
	[Q7Ans3] [nvarchar](max) NULL,
	[Q7Ans4] [nvarchar](max) NULL,
	[Q7Ans5] [nvarchar](max) NULL,
	[Q7Ans6] [nvarchar](max) NULL,
	[Q7Ans7] [nvarchar](max) NULL,
	[Q7Ans8] [nvarchar](max) NULL,
	[Q8Ans1] [nvarchar](max) NULL,
	[Q8Ans2] [nvarchar](max) NULL,
	[Q8Ans3] [nvarchar](max) NULL,
	[Q8Ans4] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Final_Ans] PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Marks]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Marks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Seat_No] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Q1] [int] NULL,
	[Q7] [int] NULL,
	[Q8] [int] NULL,
	[Total] [int] NULL,
	[Q1Ans1] [float] NULL,
	[Q1Ans2] [float] NULL,
	[Q1Ans3] [float] NULL,
	[Q1Ans4] [float] NULL,
	[Q1Ans5] [float] NULL,
	[Q1Ans6] [float] NULL,
	[Q1Ans7] [float] NULL,
	[Q1Ans8] [float] NULL,
	[Q1Ans9] [float] NULL,
	[Q1Ans10] [float] NULL,
	[Q7Ans1] [float] NULL,
	[Q7Ans2] [float] NULL,
	[Q7Ans3] [float] NULL,
	[Q7Ans4] [float] NULL,
	[Q7Ans5] [float] NULL,
	[Q7Ans6] [float] NULL,
	[Q7Ans7] [float] NULL,
	[Q7Ans8] [float] NULL,
	[Q8Ans1] [float] NULL,
	[Q8Ans2] [float] NULL,
	[Q8Ans3] [float] NULL,
	[Q8Ans4] [float] NULL,
 CONSTRAINT [PK_Tbl_Marks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Model_Ans_New]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Model_Ans_New](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Paper_ID] [nvarchar](max) NULL,
	[Question_No] [nvarchar](max) NULL,
	[Sub_Question] [nvarchar](max) NULL,
	[Question] [nvarchar](max) NULL,
	[Model_Ans] [nvarchar](max) NULL,
	[Papers_Path] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Moderator]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Moderator](
	[ID] [int] NOT NULL,
	[IndexNo] [nvarchar](max) NULL,
	[DivisionCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Moderator_Marks]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Moderator_Marks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Moderator_Index_No] [nvarchar](50) NULL,
	[Div_Code] [nvarchar](50) NULL,
	[Seat_No] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Q1] [int] NULL,
	[Q7] [int] NULL,
	[Q8] [int] NULL,
	[Total] [int] NULL,
	[Q1Ans1] [float] NULL,
	[Q1Ans2] [float] NULL,
	[Q1Ans3] [float] NULL,
	[Q1Ans4] [float] NULL,
	[Q1Ans5] [float] NULL,
	[Q1Ans6] [float] NULL,
	[Q1Ans7] [float] NULL,
	[Q1Ans8] [float] NULL,
	[Q1Ans9] [float] NULL,
	[Q1Ans10] [float] NULL,
	[Q7Ans1] [float] NULL,
	[Q7Ans2] [float] NULL,
	[Q7Ans3] [float] NULL,
	[Q7Ans4] [float] NULL,
	[Q7Ans5] [float] NULL,
	[Q7Ans6] [float] NULL,
	[Q7Ans7] [float] NULL,
	[Q7Ans8] [float] NULL,
	[Q8Ans1] [float] NULL,
	[Q8Ans2] [float] NULL,
	[Q8Ans3] [float] NULL,
	[Q8Ans4] [float] NULL,
	[Submission_Time] [smalldatetime] NULL,
 CONSTRAINT [PK_Tbl_Moderator_Marks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Teacher]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IndexNo] [nvarchar](max) NULL,
	[DivisionCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblAllAns_Bk]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAllAns_Bk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TID] [nvarchar](50) NULL,
	[Stream] [nvarchar](max) NULL,
	[DivisionCode] [nvarchar](max) NULL,
	[PStatus] [varchar](50) NULL,
	[IndexNo] [nvarchar](50) NULL,
	[Seat_No] [nvarchar](50) NULL,
	[DateTime] [smalldatetime] NULL,
	[IP] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Batch] [nvarchar](50) NULL,
	[OS] [nvarchar](50) NULL,
	[Q1Ans1] [nvarchar](max) NULL,
	[Q1Ans2] [nvarchar](max) NULL,
	[Q1Ans3] [nvarchar](max) NULL,
	[Q1Ans4] [nvarchar](max) NULL,
	[Q1Ans5] [nvarchar](max) NULL,
	[Q1Ans6] [nvarchar](max) NULL,
	[Q1Ans7] [nvarchar](max) NULL,
	[Q1Ans8] [nvarchar](max) NULL,
	[Q1Ans9] [nvarchar](max) NULL,
	[Q1Ans10] [nvarchar](max) NULL,
	[Q7Ans1] [nvarchar](max) NULL,
	[Q7Ans2] [nvarchar](max) NULL,
	[Q7Ans3] [nvarchar](max) NULL,
	[Q7Ans4] [nvarchar](max) NULL,
	[Q7Ans5] [nvarchar](max) NULL,
	[Q7Ans6] [nvarchar](max) NULL,
	[Q7Ans7] [nvarchar](max) NULL,
	[Q7Ans8] [nvarchar](max) NULL,
	[Q8Ans1] [nvarchar](max) NULL,
	[Q8Ans2] [nvarchar](max) NULL,
	[Q8Ans3] [nvarchar](max) NULL,
	[Q8Ans4] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMarksBK]    Script Date: 11/12/2022 1:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMarksBK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Seat_No] [nvarchar](50) NULL,
	[Paper_ID] [nvarchar](50) NULL,
	[Q1] [int] NULL,
	[Q7] [int] NULL,
	[Q8] [int] NULL,
	[Total] [int] NULL,
	[Q1Ans1] [float] NULL,
	[Q1Ans2] [float] NULL,
	[Q1Ans3] [float] NULL,
	[Q1Ans4] [float] NULL,
	[Q1Ans5] [float] NULL,
	[Q1Ans6] [float] NULL,
	[Q1Ans7] [float] NULL,
	[Q1Ans8] [float] NULL,
	[Q1Ans9] [float] NULL,
	[Q1Ans10] [float] NULL,
	[Q7Ans1] [float] NULL,
	[Q7Ans2] [float] NULL,
	[Q7Ans3] [float] NULL,
	[Q7Ans4] [float] NULL,
	[Q7Ans5] [float] NULL,
	[Q7Ans6] [float] NULL,
	[Q7Ans7] [float] NULL,
	[Q7Ans8] [float] NULL,
	[Q8Ans1] [float] NULL,
	[Q8Ans2] [float] NULL,
	[Q8Ans3] [float] NULL,
	[Q8Ans4] [float] NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [New_Course_ITDB_2023] SET  READ_WRITE 
GO
