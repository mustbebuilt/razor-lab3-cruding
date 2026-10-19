using System.Globalization;

// Set default culture to en-GB so currency and date formatting match the lab tutorial (£)
var cultureInfo = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// -----------------------------------------------------------------------------
// LAB 2 - STEP 01: Database Connection Setup
// -----------------------------------------------------------------------------
// Once you complete Step 01 of the tutorial, you will:
// 1. Install the NuGet package:
//    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// 2. Create Models/Staff.cs and Data/ApplicationDbContext.cs
// 3. Uncomment the following lines to register ApplicationDbContext:
//
// using Microsoft.EntityFrameworkCore;
// using MyRazorApp.Data;
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// -----------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
