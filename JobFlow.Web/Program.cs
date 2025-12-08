using JobFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using JobFlow.Application.Services;
using JobFlow.Infrastructure.Services;
using JobFlow.Application.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JobFlowDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? "Data Source=jobflow.db";

    options.UseSqlite(cs);
});

builder.Services.AddScoped<IJobExportService, JobExportService>();

builder.Services.AddScoped<IJobCompatibilityService, JobCompatibilityService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
