using Folders.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FoldersContext>(options =>
    options.UseSqlServer("workstation id=DBForTest.mssql.somee.com;packet size=4096;user id=MykolaOlizarenko_SQLLogin_1;pwd=h64vlbsytm;data source=DBForTest.mssql.somee.com;persist security info=False;initial catalog=DBForTest"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<FoldersContext>();

    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
