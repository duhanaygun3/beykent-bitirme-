Create Database [RadarSysDb]



USE [RadarSysDb]

GO
/****** Object:  Table [dbo].[Class]    Script Date: 20/09/2021 9:10:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[SurName] [varchar](50) NULL,
	[IdentityNo] [varchar](11) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Phone] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[IsAdmin] [varchar](20) NULL,
	[CreationDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demands](
	[DemandId] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DemandDate] [date] NULL,
	[Amount] [int] NULL,
	[CompanyName] [varchar](50) NULL,
	[CompanyAdress] [varchar](max) NULL,
	[DemandDesc] [varchar](max) NULL,
	[DemandStatus] [varchar](20) NULL,
	[CreationDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdateDate] [date] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE DemandStatusDesc (
    StatusID int,
    StatusDesc varchar
);

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftAndCoupons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
    [Owner] [int] NOT NULL,
	[DemandId] [int] NOT NULL,
	[Amount] [int] NULL,
	[CreationDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
);
GO

USE [RadarSysDb]
GO
/****** Object:  StoredProcedure [dbo].[UserProfileUpdate]    Script Date: 22.05.2024 13:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserSignUp]
    @Name varchar(50),
	@Surname varchar(50),
    @Identitiy varchar(11),
	@Password varchar(50),
	@Email varchar(50)
AS
BEGIN

INSERT INTO Users(Name,SurName,IdentityNo,Password,Email,CreationDate,IsAdmin)
VALUES(@Name,@Surname,@Identitiy,@Password,@Email,CONVERT(VARCHAR(10), GETDATE(), 120),0)
END

USE [RadarSysDb]
GO
/****** Object:  StoredProcedure [dbo].[UserProfileUpdate]    Script Date: 22.05.2024 13:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateDemand]
    @UserID int,
	@DemandDate date,
    @Amount float,
	@CompanyName varchar(50),
	@CompanyAdress varchar(50),
	@DemandDesc varchar(MAX)
AS
BEGIN

INSERT INTO Demands(UserID,DemandDate,Amount,CompanyName,CompanyAdress,DemandDesc,DemandStatus,CreationDate,CreatedBy)
VALUES(@UserID,@DemandDate,@Amount,@CompanyName,@CompanyAdress,@DemandDesc,1,CONVERT(VARCHAR(10), GETDATE(), 120),@UserID)
END


USE [RadarSysDb]
GO
/****** Object:  StoredProcedure [dbo].[DemandStatusUpdate]    Script Date: 22.05.2024 13:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DemandStatusUpdate]
    @DemandID int,
    @DemandStatus varchar(50),
	@UserID int
AS
BEGIN

Update Demands 
SET DemandStatus = @DemandStatus, UpdateDate = CONVERT(VARCHAR(10), GETDATE(), 120), UpdatedBy = @UserID
WHERE DemandId = @DemandID

IF @DemandStatus = 3
BEGIN
   DECLARE @GiftAndCouponsAmount float
   DECLARE @Amount float
    SELECT @Amount = Amount FROM Demands WHERE DemandId = @DemandID;


IF(@Amount<=3000.00)
SET @GiftAndCouponsAmount = @Amount *0.05
ELSE IF ((@Amount>3000.00) AND (@Amount<=10000.00))
SET @GiftAndCouponsAmount = @Amount *0.03
ELSE IF (@Amount>10000.00)
SET @GiftAndCouponsAmount = @Amount *0.01


DECLARE @Owner INT;
    SELECT @Owner = UserID FROM Demands WHERE DemandId = @DemandID;

INSERT INTO GiftAndCoupons(Owner,DemandID,Amount,CreationDate,CreatedBy,UpdateDate,UpdatedBy)
VALUES (@Owner,@DemandID,@GiftAndCouponsAmount,CONVERT(VARCHAR(10), GETDATE(), 120),@UserID,CONVERT(VARCHAR(10), GETDATE(), 120),@UserID)
END

    
END


USE [RadarSysDb]
GO
/****** Object:  StoredProcedure [dbo].[UserProfileUpdate]    Script Date: 22.05.2024 13:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserProfileUpdate]
    @Email varchar(50),
    @MobileNumber varchar(50),
	@Adress varchar(50),
	@UserID int
AS
BEGIN

Update Users 
SET Email = @Email,Phone=@MobileNumber,Address=@Adress, UpdateDate = CONVERT(VARCHAR(10), GETDATE(), 120), UpdatedBy = @UserID
WHERE UserID = @UserID

    
END


