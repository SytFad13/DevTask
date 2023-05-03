USE [master]
GO

/****** Object:  Database [EmployeesDb]    Script Date: 5/3/2023 4:47:37 PM ******/
CREATE DATABASE [EmployeesDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeesDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeesDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeesDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeesDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EmployeesDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EmployeesDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EmployeesDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EmployeesDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EmployeesDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [EmployeesDb] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [EmployeesDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EmployeesDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EmployeesDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EmployeesDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EmployeesDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EmployeesDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EmployeesDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EmployeesDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EmployeesDb] SET  ENABLE_BROKER 
GO

ALTER DATABASE [EmployeesDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EmployeesDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EmployeesDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EmployeesDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EmployeesDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EmployeesDb] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [EmployeesDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EmployeesDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EmployeesDb] SET  MULTI_USER 
GO

ALTER DATABASE [EmployeesDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EmployeesDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EmployeesDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EmployeesDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [EmployeesDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EmployeesDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [EmployeesDb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [EmployeesDb] SET  READ_WRITE 
GO

