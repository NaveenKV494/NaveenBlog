using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NaveenBlogUI;
using MudBlazor;
using MudBlazor.Services;
using NaveenBlogUI.Services;
using NaveenBlogUI.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5052/") });
builder.Services.AddScoped<BookReviewService>();
builder.Services.AddScoped<BookRecomService>();
builder.Services.AddScoped<WritingService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
