USE [master]
GO
/****** Object:  Database [FileStorage]    Script Date: 25.10.2014 г. 11:37:56 ******/
CREATE DATABASE [FileStorage]
GO
ALTER DATABASE [FileStorage] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FileStorage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FileStorage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FileStorage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FileStorage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FileStorage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FileStorage] SET ARITHABORT OFF 
GO
ALTER DATABASE [FileStorage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FileStorage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FileStorage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FileStorage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FileStorage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FileStorage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FileStorage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FileStorage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FileStorage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FileStorage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FileStorage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FileStorage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FileStorage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FileStorage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FileStorage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FileStorage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FileStorage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FileStorage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FileStorage] SET  MULTI_USER 
GO
ALTER DATABASE [FileStorage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FileStorage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FileStorage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FileStorage] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FileStorage] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FileStorage]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 25.10.2014 г. 11:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Content] [text] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [FileStorage] SET  READ_WRITE 
GO
