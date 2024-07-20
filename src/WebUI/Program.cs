using CentroEspecialidadesDentales.Application.Common.Interfaces;
using CentroEspecialidadesDentales.Application.Services;
using CentroEspecialidadesDentales.Infrastructure.Persistence;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using WebUI.Components;
using WebUI.Components.Pages;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();
//builder.Services.AddServerSideBlazor();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEmailService, SmtpEmailService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<AppointmentService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseHealthChecks("/health");

//app.UseSwaggerUi3(settings =>
//{
//    settings.Path = "/api";
//    settings.DocumentPath = "/api/specification.json";
//});

app.UseRouting();
app.UseAntiforgery();

app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

//app.MapFallbackToFile("index.html");

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

app.Run();
