using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SaveMyFridge.Services;
using SaveMyFridge;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Set up HttpClient with the proper API URL
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5106")
});

// Register your services
builder.Services.AddScoped<IIngredientService, IngredientService>();

await builder.Build().RunAsync();