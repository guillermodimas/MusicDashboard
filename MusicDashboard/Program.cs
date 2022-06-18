using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MusicDashboard.Services;
using Syncfusion.Blazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices(); //Registering MudBlazor Component Library Service
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; }); //Register Syncfusion component used to render the Histogram

//Register ItunesAPI along with a HTTPClient
builder.Services.AddHttpClient<InterfaceItunesAPIService, ItunesAPIService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ItunesAPI_URI"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Register Syncfusion License (Personal Community License)
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjU4MzY3QDMyMzAyZTMxMmUzMGVzd25YdmdwVEVJT2Fiak45Sm45Sm1qb2lyTldFT0FuVFVabkJId0hrOHM9");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

