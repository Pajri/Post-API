# Post-API
This project is created to learn asp.net core web api <br />
There is tutorial to create database for this project. If you want to skip, you can use database in PostAPI.Database folder.

The following is tutorial on how to create ASP.NET Wep API
#### Create Web API Project
1.	Open Visual Studio
2.	Click File -> New -> Project
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/1%20Create%20Web%20API%20Project.png?raw=true)

3.	Click **ASP .Net Core Web Application** on New Project dialog
4.	Specify **Name** and **Location** of the project then click **Ok**
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/2%20Create%20Web%20API%20Project.png?raw=true)

5. Select **ASP .Net Core 2.2.** If you don’t see the option, you may need to download .Net Core SDK 2.2 first. Download link : [https://dotnet.microsoft.com/download/dotnet-core/2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
6. Click **Web API** then click **Ok**
![Creating Web API Project](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/3%20Create%20Web%20API%20Project.png?raw=true)


#### Create Database
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
You can check the design of created table **Post** by **right click on table Post** then click **design**  
![Creating Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/4%20Create%20Database.png?raw=true)

#### Generate Model From Database
9. Click **Tools** -> **NuGet Package Manager** -> **Package Manager Console**  
![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/5%20Generate%20Model%20From%20Database.png?raw=true)

10. Run the following command
	``` powershell
	Scaffold-DbContext "Server=localhost;Database=Post;User Id=<user id>;Password=<password> " Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
	```
	The command is used to generate database context and class model. The following is explanation of the command.
	
	**`Server=localhost;Database=Post;User Id=<user id>;Password=<;password>`**<br/>
	This is connection string to connect to database. You can read more about connection string here [https://www.connectionstrings.com/sql-server/](https://www.connectionstrings.com/sql-server/). You can use user id and password that is used to login to sql server.
	
	**`Microsoft.EntityFrameworkCore.SqlServer`**<br/>
	This is database provider. This is library that is used to connect to database and generate class model. You can read more about class model here :  [https://docs.microsoft.com/en-us/ef/core/providers/index](https://docs.microsoft.com/en-us/ef/core/providers/index)
	
	**`OutputDir Models`**<br/>
	Output directory where the database context and class model are generated.

11. The classes should be generated here<br/>
![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/6%20Generate%20Model%20From%20Database.png?raw=true)

12. Open **PostContext.cs** then remove method **OnConfiguring. 
![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/7%20Generate%20Model%20From%20Database.png?raw=true)
We are going to add connection string configuration  at **Startup.cs**

13. Open **Startup.cs**<br/>
![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/8%20Generate%20Model%20From%20Database.png?raw=true)

14. To make the database context available to MVC controller, you have to register it first. Add this code to **ConfigureServices** method to register it.
	```c#
	services.AddDbContext<Models.PostContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
	```
	![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/9%20Generate%20Model%20From%20Database.png?raw=true)

15. At the previous step, there is method to get connection strings **DefaultConnection**. We must add the connection string from **appsettings.json.** Open appsettings.json then add the connectionstring.
![Generate Model From Database](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/10%20Generate%20Model%20From%20Database.png?raw=true)

16. Build the project. Make sure it successfully built.
