# Post-API
This project is created to learn asp.net core web api <br />
There is tutorial to create database for this project. If you want to skip, you can use database in PostAPI.Database folder.

The following is tutorial on how to create ASP.NET Wep API
#### Creating Web API Project
1.	Open Visual Studio
2.	Click File -> New -> Project <br/>
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/1%20Create%20Web%20API%20Project.png?raw=true)

3.	Click **ASP .Net Core Web Application** on New Project dialog
4.	Specify **Name** and **Location** of the project then click **Ok** <br/>
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/2%20Create%20Web%20API%20Project.png?raw=true)

5. Select **ASP .Net Core 2.2.** If you don’t see the option, you may need to download .Net Core SDK 2.2 first. Download link : [https://dotnet.microsoft.com/download/dotnet-core/2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
6. Click **Web API** then click **Ok** <br/>
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/3%20Create%20Web%20API%20Project.png?raw=true)


#### Creating database
7. Open **SQL Server Management Studio** <br/>
Run this script to create the database <br/>
```sql
CREATE DATABASE Post

USE [Post]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 6/17/2019 6:04:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
```

8. Check if the database is created.  
You can check the design of created table **Post** by **right click on table Post** then click **design** <br/>  
![Creating Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/4%20Create%20Database.png?raw=true)

