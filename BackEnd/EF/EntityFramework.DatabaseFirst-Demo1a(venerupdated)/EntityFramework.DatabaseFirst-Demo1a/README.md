// Windows Authentication
Scaffold-DbContext "Server=EC2AMAZ-IBUFRCP\SQLEXPRESS;Database=OnlineShop;User Id=sa;Password=password" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context OnlineShopContext -ContextDir Data

// Trusted MSSQL Server Connection
Scaffold-DbContext "Server=EC2AMAZ-IBUFRCP\SQLEXPRESS;Database=ToyUniverse;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ToyUniverseContext -ContextDir Data

// Annotation
Scaffold-DbContext "Server=EC2AMAZ-IBUFRCP\SQLEXPRESS;Database=ToyUniverse;User Id=sa;Password=password" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ToyUniverseContext -ContextDir Data -DataAnnotations