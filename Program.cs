using System.Data;
using DbUp;
using MySqlConnector;
//default builder ho
var builder = WebApplication.CreateBuilder(args);
//to take connection from json make configuration
var configuration= builder.Configuration;
// end points expose gareko
builder.Services.AddEndpointsApiExplorer();
//generate swagger documenatation
builder.Services.AddSwaggerGen();
//controller ko lagi
builder.Services.AddControllers();

builder.Services.AddScoped<AddCategoryService>();

builder.Services.AddScoped<GetCategoryListService>();

builder.Services.AddScoped<AddProductService>();
builder.Services.AddScoped<GetProductListService>();

//db connection throughout application ko lagi
builder.Services.AddScoped<IDbConnection>(db => new MySqlConnection(configuration.GetConnectionString("MysqlConnection")));

//builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Example, use the appropriate lifetime for your application

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<UpdateProductService>();
//builder.Services.AddScoped<IUpdateProductRepository, UpdateProductRepository>();

//ensuring if db exist garcha ki gardaina
EnsureDatabase.For.MySqlDatabase(configuration.GetConnectionString("MysqlConnection"));

//sabai database scripts lai folder dekhi db ani log to console deploy
var migrator= DeployChanges.To.MySqlDatabase(configuration.GetConnectionString("MysqlConnection"))
.WithScriptsFromFileSystem("../product-management-api/Migration")
.LogToConsole().Build();

//build migrator
var result= migrator.PerformUpgrade();
if(!result.Successful){
    Console.WriteLine(result.Error);
}




var app = builder.Build();
//use swagger
app.UseSwagger();
//use swagger ui
app.UseSwaggerUI(ui =>{
    ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API");
    ui.DocumentTitle="Product Management API";
});
app.MapGet("/hello", () => "Hello World");
app.MapPost("/setName", (string name) => $"Hello {name}");

//for controllers to work as defined
app.UseRouting();
app.MapControllers();
app.Run();
