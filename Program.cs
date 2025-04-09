using Fubon_T.Repositories.Interfaces;
using Fubon_T.Repositories;
using Fubon_T.Services;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// 使用 Dapper 注入 SqlConnection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// 注入自訂服務
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 預設路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=Register}/{id?}");

app.Run();