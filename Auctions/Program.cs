using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Auctions.Data;
using Auctions.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// Add Razor Pages services
builder.Services.AddRazorPages();

// Add custom services
builder.Services.AddScoped<IListingsService, ListingsService>();
builder.Services.AddScoped<IBidsService, BidsService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // The default HSTS value is 30 days. Consider changing this for production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Listings}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
