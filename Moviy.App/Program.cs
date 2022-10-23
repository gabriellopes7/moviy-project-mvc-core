using Microsoft.EntityFrameworkCore;
using Moviy.App.Configurations;
using Moviy.Data.Context;

var builder = WebApplication.CreateBuilder(args);


//Configuração de ambiente
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddIdentityConfiguration(builder.Configuration);

//Adicionando meu contexto
builder.Services.AddDbContext<MoviyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.ResolveDependencies();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
