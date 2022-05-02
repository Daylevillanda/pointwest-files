# ASP .NET Core Web API Demo 1 - First Web API

- Create a new ASP .NET Core Web API Project

    **Folders and Files in ASP.NET Core Web API:**

    https://dotnettutorials.net/lesson/asp-net-core-web-api-files-and-folders/   

### Endpoints

``` Startup.cs
public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
    ...

    app.UseEndpoints(endpoints => {
        endpoints.MapGet("/", async context => {
            await context.Response.WriteAsync("Hello From ASP.NET Core Web API");
        });
        endpoints.MapGet("/Resource1", async context => {
            await context.Response.WriteAsync("Hello From ASP.NET Core Web API Resource1");
        });
    });

    ...
}
```

### Configuration

- Create Settings.cs. Best practice is to make the setter private

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Settings
{
    public class EmailSettings
    {
        public string SMTPEmail { get; set; }
        public string SMTPPassword { get; set; }
        public int SMTPPort { get; set; }
        public string SMTPHostname { get; set; }
    }

    public class EmailSettings
    {
        public string SMTPEmail { get; private set; }
        public string SMTPPassword { get; private set; }
        public int SMTPPort { get; private set; }
        public string SMTPHostname { get; private set; }
    }
}
```

- Reading properties

```
// Startup.cs
var emailSettings = this.Configuration.GetSection("EmailSettings").Get<EmailSettings>(); // public setter
var emailSettings = this.Configuration.GetSection("EmailSettings").Get<EmailSettings>(o => o.BindNonPublicProperties = true); // private setter
services.Add(new ServiceDescriptor(typeof(EmailSettings), emailSettings)); // dependency injection

public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, EmailSettings emailSettings)
{
    _logger = logger;
    connectionString = configuration.GetValue<string>("ConnectionString");
    var _smtpPassword = emailSettings.SMTPPassword;
    var _smtpEmail = emailSettings.SMTPEmail;
}
```



### Launch Options

- Production is the default value if ASPNETCORE_ENVIRONMENT has not been set. Apps deployed to azure are Production by default.

- The following launch command uses launchSettings.json

```cmd_powershell_
# ONLY Kerstel is supported at the command line
dotnet run --launch-profile "Kerstel"
```

- The following codes use appsettings.<profile>.json

```cmd
set ASPNETCORE_ENVIRONMENT=Staging
dotnet run --no-launch-profile
```

```powershell
$Env:ASPNETCORE_ENVIRONMENT = "Staging"
dotnet run --no-launch-profile
```

- Startup environment

```
public class Startup
{
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_env.IsDevelopment())
            {
                Console.WriteLine(_env.EnvironmentName);
            }
            else if (_env.IsStaging())
            {
                Console.WriteLine(_env.EnvironmentName);
            }
            else
            {
                Console.WriteLine("Not dev or staging");
            }

            ...
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstWebApi v1"));
            }
            ...
        }

}
```

- Controller

```
public WeatherForecastController(ILogger < WeatherForecastController > logger, IConfiguration configuration, EmailSettings emailSettings) {
    _logger = logger;
    version = configuration.GetValue < string > ("ConnectionString");
    var _smtpPassword = emailSettings.SMTPPassword;
    var _smtpEmail = emailSettings.SMTPEmail;
}
```

### Controllers

Differences between AddMvc, AddControllers, AddRazorPages, and AddControllersWithViews:

- AddControllers: The AddControllers method is used only for Web APIs. That means if you want to create a Web API Application where there are no views, then you need to use the AddController extension method.
- AddControllersWithViews: The AddControllersWithViews method is used to support MVC Based Applications. That means If you want to develop a Model View Controller (i.e. MVC) application then you need to use AddControllersWithViews() extension method.
- AddRazorPages: The AddRazorPages method is used for the Razor Pages application. That means if you want to work with the Razor Page application, then you need to use the AddRazorPages() extension method
- AddMvc: The AddMvc method adds all the services that are required for developing any type of application. That means we can say if we are using the AddMvc method, then we can develop Web API, MVC, and Razor Pages applications.

https://dotnet.microsoft.com/download/dotnet