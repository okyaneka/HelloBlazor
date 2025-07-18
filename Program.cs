using DotNetEnv;
using HelloBlazor.App;
using HelloBlazor.App.Extensions;
using HelloBlazor.App.Features;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "/";

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddServiceExtension(baseUrl);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseStatusCodePagesWithRedirects("/404");

app.Run();
