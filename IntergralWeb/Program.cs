using Microsoft.Extensions.FileProviders;
using System.Linq;

var builder = WebApplication.CreateBuilder(args); // Pass args here.

var portArg = builder.Configuration.GetValue<string>("port"); // Get the port argument value.

// If no port argument provided, use a default port.
var port = int.Parse(string.IsNullOrWhiteSpace(portArg) ? "5000" : portArg);

builder.WebHost.UseUrls($"http://*:{port}");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
app.UseRouting();
var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
// Serve CSS files at the root level
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "wwwroot/css")),
    RequestPath = ""
});

// Serve JS files at the root level
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "wwwroot/js")),
    RequestPath = ""
});

app.UseRouting();
app.MapControllers();
app.UseStaticFiles();
app.Run();

//using System;
//using System.Web.Http;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Hosting;

//var builder = WebApplication.CreateBuilder();

//// Add services to the container.
//builder.Services.AddRazorPages();
//var app = builder.Build();

//Console.Write("Enter the desired port number: ");
//var portInput = Console.ReadLine();
//if (!int.TryParse(portInput, out int portNumber))
//{
//    Console.WriteLine("Invalid port number. Exiting...");
//    return;
//}

//app.Urls.Clear();
//app.Urls.Add($"http://localhost:{portNumber}");

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.MapRazorPages();

//app.Run();
