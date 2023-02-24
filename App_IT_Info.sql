USE [ITDb1]
GO
/****** Object:  Table [dbo].[Tbl_AllAns]    Script Date: 01/11/2021 11:09:37 AM ******/
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
	[DateTime] [datetime] NULL,
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
/****** Object:  Table [dbo].[Tbl_Code_Master]    Script Date: 01/11/2021 11:09:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Code_Master](
	[ID] [int] NOT NULL,
	[DIVISION_CODE] [nvarchar](20) NULL,
	[DIVISION_NAME] [nvarchar](255) NULL,
	[DISTRICT_CODE] [nvarchar](255) NULL,
	[DISTRICT_NAME] [nvarchar](255) NULL,
	[TALUKA_CODE] [nvarchar](255) NULL,
	[TALUKA_NAME] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CollgeLogin]    Script Date: 01/11/2021 11:09:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CollgeLogin](
	[CID] [int] NOT NULL,
	[IndexNo] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Coordinator]    Script Date: 01/11/2021 11:09:37 AM ******/
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
/****** Object:  Table [dbo].[Tbl_Marks]    Script Date: 01/11/2021 11:09:37 AM ******/
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
/****** Object:  Table [dbo].[Tbl_Model_Ans]    Script Date: 01/11/2021 11:09:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Model_Ans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Paper_ID] [nvarchar](max) NULL,
	[Question_No] [nvarchar](max) NULL,
	[Sub_Question] [nvarchar](max) NULL,
	[Question] [nvarchar](max) NULL,
	[Model_Ans] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Model_Ans] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Teacher]    Script Date: 01/11/2021 11:09:37 AM ******/
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
