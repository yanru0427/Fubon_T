using Fubon_T.Repositories.Interfaces;
using Fubon_T.Repositories;
using Fubon_T.Services;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// �ϥ� Dapper �`�J SqlConnection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// �`�J�ۭq�A��
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

// �w�]����
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=Register}/{id?}");

app.Run();