using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLI.Data;
using SQLI.Models;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<SQLIContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLIContext") ?? throw new InvalidOperationException("Connection string 'SQLIContext' not found.")));

//builder.Services.AddDbContext<SQLIContext>(options =>
//        options.UseInMemoryDatabase(databaseName: "SQLI-db"));
builder.Services.AddDbContext<SQLIContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SQLIContext>();

    // Initialize database with sample data
    if (dbContext.Users.Count() == 0)
    {
        SeedData.Initialize(dbContext);
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
