using ContosoUniversityHW.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UniversityContextHW>
	(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"))
	);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

IServiceScope scope = app.Services.CreateScope();
IServiceProvider services = scope.ServiceProvider;

UniversityContextHW context = services.GetRequiredService<UniversityContextHW>();
DbInitializer.Initialize(context);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
