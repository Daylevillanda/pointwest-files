
# Enable secrets

1. Open powershell Tools>Command Line>Power Shell then execute

```
dotnet user-secrets init
```

2. Set secret or right-click on the project [Manage User Secrets]

  - File system location -> C:\Users\GUEVARRA\AppData\Roaming\Microsoft\UserSecrets
```
dotnet user-secrets set "PaymentGateway:ApiKey" "12345"

dotnet user-secrets set "PaymentGateway:ApiKey" "12345" --project "C:\apps\WebApp1\src\WebApp1"
```

```json
{
  "PaymentGateway": {
    "ApiKey": "12345"
  }
}
```

2. Modify Program.cs to add the user secrets

```
public class Program {
     public static void Main(string[] args) {
         CreateHostBuilder(args).Build().Run();
     }

     public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((hostContext, builder) => {
             if (hostContext.HostingEnvironment.IsDevelopment()) {
                 builder.AddUserSecrets < Program > ();
             }
         })
         .ConfigureWebHostDefaults(webBuilder => {
             webBuilder.UseStartup < Startup > ();
         });
 }
```