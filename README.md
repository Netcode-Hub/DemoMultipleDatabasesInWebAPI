# Break Free from Single DB Limits! 🙌 Connect SQLite & SQL Server in Your .NET 8 Web API Like a Pro!🚀🔥
Imagine having the flexibility to use both SQLite and SQL Server in your applications—sounds amazing, right? Whether you're looking to leverage SQLite for lightweight, local storage or SQL Server for robust, enterprise-level data management, we've got you covered. In this video, we'll walk you through the step-by-step process of integrating both databases into your .NET Web API. Let's get started! 🎉

# Install Packages
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="x.x.x" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="x.x.x" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="x.x.x" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="x.x.x"/>

# Create Multiple Connection Strings
     "ConnectionStrings": {
       "SqlServerConnection": "Server=(local); Database=Products; Trusted_Connection=true; Trust Server Certificate=true;",
       "SqliteConnection": "Data source = UsersDb.db"
     }

  # Create your Multiple Models
     public class User
     {
         public int Id { get; set; }
         public string? Name { get; set; }
         public string? Email { get; set; }
     }

     public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }

# Create Database Context class
     public class ProductDbContext: DbContext
     {
         public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
         {
         }
         public DbSet<Product> Products { get; set; }
     }

     
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
     
# Register Your Connections
    builder.Services.AddDbContext<UserDbContext>
        (o => o.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
    
    builder.Services.AddDbContext<ProductDbContext>
        (o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

# Perform Migration
    //add
    add-migration ProductDb -context ProductDvContext
    add-migration UserDb -context UserDbContext
    
    //update
    update-database -context ProductDvContext
    update-database -context UserDbContext

# Create Composite Database Context Class
     public class CompositeDbContext
     {
         public readonly ProductDbContext ProductDbContext;
         public readonly UserDbContext UserDbContext;
    
         public CompositeDbContext(ProductDbContext productDbContext, UserDbContext userDbContext)
         {
             ProductDbContext = productDbContext;
             UserDbContext = userDbContext;
         }
     }

  # Register Composite Context Class
    builder.Services.AddScoped<CompositeDbContext>();

# Use Composite Context in Controller or Service
     [ApiController]
     [Route("[controller]")]
     public class DataController(CompositeDbContext compositeDbContext) : ControllerBase
     {
         [HttpGet("product/get")]
         public async Task<IActionResult> GetProducts() =>
             Ok(await compositeDbContext.ProductDbContext!.Products.ToListAsync());
    
         [HttpGet("user/get")]
         public async Task<IActionResult> GetUsers() =>
             Ok(await compositeDbContext.UserDbContext!.Users.ToListAsync());
    
         [HttpPost("product/add")]
         public async Task<IActionResult> AddProduct(Product product)
         {
             compositeDbContext.ProductDbContext!.Products.Add(product);
             await compositeDbContext.ProductDbContext.SaveChangesAsync();
             return Created();
         }
    
         [HttpPost("user/add")]
         public async Task<IActionResult> AddUser(User user)
         {
             compositeDbContext.UserDbContext!.Users.Add(user);
             await compositeDbContext.UserDbContext.SaveChangesAsync();
             return Created();
         }
     }

# Overview
   ![Screenshot 2024-07-01 055611](https://github.com/Netcode-Hub/DemoMultipleDatabasesInWebAPI/assets/110794348/133186ed-e49c-496a-9292-353f5ccb1096)
  
# Summary
In this tutorial, we've explored the dynamic duo of SQLite and SQL Server in a single Web API project. Here's a quick recap of what we've covered:
Setting Up the Databases: We showed you how to configure both SQLite and SQL Server in your development environment.
1. Configuring Your Web API: We walked through the essential steps to set up your Web API to connect to both databases seamlessly.
2. Database Contexts: We demonstrated how to create separate DbContexts for SQLite and SQL Server, ensuring smooth operations and data management.
3. CRUD Operations: We implemented basic CRUD operations to see both databases in action within our Web API.
4. Testing: We tested our API endpoints to confirm that data operations work flawlessly across both databases.

# Conclusion
Thank you for sticking with us through this journey of connecting multiple databases to your Web API! 🌟 We hope you found this tutorial insightful and practical for your development needs.

# Here's a follow-up section to encourage engagement and support for Netcode-Hub:
🌟 Get in touch with Netcode-Hub! 📫
1. GitHub: [Explore Repositories](https://github.com/Netcode-Hub/Netcode-Hub) 🌐
2. Twitter: [Stay Updated](https://twitter.com/NetcodeHub) 🐦
3. Facebook: [Connect Here](https://web.facebook.com/NetcodeHub) 📘
4. LinkedIn: [Professional Network](https://www.linkedin.com/in/netcode-hub-90b188258/) 🔗
5. Email: Email: [business.netcodehub@gmail.com](mailto:business.netcodehub@gmail.com) 📧
   
# ☕️ If you've found value in Netcode-Hub's work, consider supporting the channel with a coffee!
1. Buy Me a Coffee: [Support Netcode-Hub](https://www.buymeacoffee.com/NetcodeHub) ☕️
