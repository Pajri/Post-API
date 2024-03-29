# Post-API
This project is created to learn asp.net core web api <br />
There is tutorial to create database for this project. If you want to skip, you can use database in PostAPI.Database folder.

The following is tutorial on how to create ASP.NET Wep API
#### Create Web API Project
1.	Open Visual Studio
2.	Click File -> New -> Project <br/>
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


#### Create Controller
17. Remove the generated **ValuesController.cs** if any as we will not need it.<br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/12%20Create%20Controller.png?raw=true)

18. Right click on **Controllers** folder -> click **Add** -> click **New Item**   <br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/13%20Create%20Controller.png?raw=true)

19. Select WebAPI Controller class -> name it **PostController** -> click **Add.** You can use filter to search Web API Controller Class menu item.  <br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/14%20Create%20Controller.png?raw=true)

20. You will see the generated codes. We will use that as our base to create post api. <br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/15%20Create%20Controller.png?raw=true)

21. Decorate **PostController** with **[ApiController]** attribute (see screenshot). It will enable API-Specific behavior :  
	- Attribute routing requirement  
	- Automatic HTTP 400 responses  
	- Binding source parameter inference  
	- Multipart/form-data request inference  
	- Problem details for error status codes  
	You can visit this link for more information : [https://docs.microsoft.com/en-us/aspnet/core/web-api/index?view=aspnetcore-2.2#apicontroller-attribute](https://docs.microsoft.com/en-us/aspnet/core/web-api/index?view=aspnetcore-2.2#apicontroller-attribute) <br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/16%20Create%20Controller.png?raw=true)

22. Change **PostController** class inheritance to derive from **ControllerBase** class. **Controller** derives from **ControllerBase** and adds support for views, so it's for handling web pages, not web API requests. The **ControllerBase** class provides many properties and methods that are useful for handling HTTP requests. For example, **ControllerBase**.**CreatedAtAction** returns a 201 status code. <br/>
![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/17%20Create%20Controller.png?raw=true)
	Source : [https://docs.microsoft.com/en-us/aspnet/core/web-api/index?view=aspnetcore-2.2#controllerbase-class]<br/>
	(https://docs.microsoft.com/en-us/aspnet/core/web-api/index?view=aspnetcore-2.2#controllerbase-class)  
	
23. Add post context to post controller. Add this following code.
	```c#
	private PostContext _context;
	public PostController(PostContext context)
	{
	        _context = context;
	}
	```
	![Create Controller](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/17%20Create%20Controller.png?raw=true) <br/>
	

#### Add Create Post Method

24. We will use the generated method  **public void Post([FromBody]string value)** decorated with [HttpPost] attribute <br/>
![Add Create Post Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/19%20Create%20Post%20Method.png?raw=true)<br/>
 This method will **receive** Post value and **return** 201 status code, location header, and post data that is stored to database. HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server in tis case new post data stored to database. The location header specify the url of the new created post data.  
Update Post method with this code  
	```c#
    public ActionResult<Posts> Post([FromBody]Posts postItem)
    {
            _context.Posts.Add(postItem);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(Get), new { id = postItem.Id }, postItem);
    }
	```
	![Add Create Post Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/20%20Create%20Post%20Method.png?raw=true)<br/>
	The CreatedAtAction method will return status code 201. The parameters are used to generate url to the newly stored data and to generate json of newly stored data. **nameof(Get)** is the method to get single post item (we will create this method later) and **new {id = postItem.id}** is the parameter to get the post item.  
	
25. We are going to test the method. Build and run the project.
To test the api, you can use tools like Postman ([https://www.getpostman.com/downloads/](https://www.getpostman.com/downloads/)) or Advanced Rest Client ([https://chrome.google.com/webstore/detail/advanced-rest-client/hgmloofddffdnphfgcellkdfbfbjeloo](https://chrome.google.com/webstore/detail/advanced-rest-client/hgmloofddffdnphfgcellkdfbfbjeloo)).

	Details of the request : <br/>
	```
	**Url**             :<hostname>/api/post <br/>
	**Method**          :POST <br/>
	**Content-Type**    :application/json <br/>
	**Body**            :{"Id":"b67c7014-9d5b-4800-bda8-f0aa3523bc86","Title":"My First Post","Content":"Hello World !"} <br/>
	```
	![Add Create Post Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/21%20Create%20Post%20Method.png?raw=true)
	
	![Add Create Post Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/22%20Create%20Post%20Method.png?raw=true)
	
	The response should be like this 
	
	![Add Create Post Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/23%20Create%20Post%20Method.png?raw=true)<br/>
	
	
#### Add Get Posts Method
27. We are going to use method **public IEnumerable<string> Get()** to create method to retrieve all posts and method **public string Get(int id)**  to create method to retrieve one post.
	
28. Update method **IEnumerable<string> Get()** using the following codes : 
	```c#
	public ActionResult<IEnumerable<Posts>> Get()
	{
        	return _context.Posts;
	}
	```
	
	![Add Get Posts Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/24%20Get%20Post%20Method.png?raw=true)
	
	The method will return all post data. It will be in array of json object format. We will see what the json will be when we test the method.
	
29. Update method method public string Get(int id) using the following codes :
	```c#
	public ActionResult<Posts> Get(string id)
	{
	    Guid postGuid = new Guid();
	    if (!Guid.TryParse(id,out postGuid)) return BadRequest();

	    var postItem = _context.Posts.Where(p => p.Id == postGuid);
	    if (postItem.Count() == 0) return NotFound();
	    return postItem.SingleOrDefault();
	}
	```
	
	![Add Get Posts Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/25%20Get%20Post%20Method.png?raw=true)
	
	This method will accept id as parameter. The expected parameter is guid. If not guid, this method will return bad request. If it’s guid, the method will return post item.  
	
30. Build and run the project.

31. Now we are going to post both methods.<br/>
	**Testing Get Posts method (without parameter)** <br/>
	Details of the request :
	```
	Url 		: <hostname>/api/post
	Method 		: GET
	Content-Type 	: application/json
	```
	The result should be like this. I’ve added few more items before. <br/>
	![Add Get Posts Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/26%20Get%20Post%20Method.png?raw=true)
	
32. **Testing Get Posts method (with parameter)**<br/>
	Details of the request:
	```
	Url 		: <hostname>/api/post/<post id>
	Method 		: GET
	Content-Type 	: application/json
	```
	
	The response should be like this <br/>
	![Add Get Posts Method](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/27%20Get%20Post%20Method.png?raw=true)
	
	
#### Create Method to Update Post

33. To create method to update post, we will use method public void Put(int id, [FromBody]string value). This method uses HTTP PUT. The response is 204 (No Content). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use HTTP PATCH.
34. Update method void Put(int id, [FromBody]string value) using this following code :
    ```c#
    public ActionResult Put(string id, [FromBody]Posts postItem)
    {
        Guid postGuid = new Guid();
        if (!Guid.TryParse(id, out postGuid)) return BadRequest();
        if (postGuid != postItem.Id) return BadRequest();
        
        _context.Entry(postItem).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }
    ```
    ![Create Method to Update Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/27%20Update%20Post%20Method.png?raw=true)

35.	Build the project.
36.	Now we test the method.

	Details of the request:
	```
	Url 		: <hostname>/api/post/e17a4da3-5cc3-4da7-a567-3ece2b3e4962
	Method 		: PUT
	Content-Type 	: application/json
	Body 		: {
			     "id": "e17a4da3-5cc3-4da7-a567-3ece2b3e4962",
    			     "title": "Emergency Exit is Gone !!!!",
    			     "content": "Apparently no one where it goes.”
			  }
	```
	
	![Create Method to Update Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/28%20Update%20Post%20Method.png?raw=true)

	If you check again using get post method, you will see that the content has been changed

	![Create Method to Update Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/29%20Update%20Post%20Method.png?raw=true)


### Create Method to Delete Post
37. We use HTTP DELETE to delete post. It will return 204 No Content. 
We use method `public void Delete(int id)` to create delete post method.

38. Update method public void Delete(int id) using the following code :
	```c#
	public ActionResult Delete(string id)
	{
	    Guid postGuid = new Guid();
	    if (!Guid.TryParse(id, out postGuid)) return BadRequest();

	    var queryPostItem = _context.Posts.Where(p => p.Id == postGuid);
	    if (queryPostItem.Count() == 0) return NotFound()
	    var postItem = queryPostItem.SingleOrDefault();
	    _context.Posts.Remove(postItem);
	    _context.SaveChanges();

	    return NoContent();
	}
	```
	![Create Method to Delete Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/30%20Delete%20Post%20Method.png?raw=true)

39. Build and run the project

40. Now we test the method. <br/>
	Details of the request:
	```
	Url 		: <hostname>/api/post/e17a4da3-5cc3-4da7-a567-3ece2b3e4962
	Method		: DELETE
	Content-Type	: application/json

	```
	
	![Create Method to Delete Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/31%20Delete%20Post%20Method.png?raw=true)

	If you get all post data, you will see that the item does not in the list
	
	![Create Method to Delete Post
](https://github.com/Pajri/Post-API/blob/master/Readme%20Assets/32%20Delete%20Post%20Method.png?raw=true)


