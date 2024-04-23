using Giveaway.BusinessLogic.GiveawayEntrySources;
using Giveaway.BusinessLogic.PrizeSource;
using Giveaway.Components;
using MudBlazor.Services;
using NReco.Logging.File;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddSingleton<IGiveawayEntriesProvider>(_ =>
    new GoogleFormsGiveawayEntryProvider(
        builder.Configuration["Google:ClientId"]!,
        builder.Configuration["Google:ClientSecret"]!,
        "18bp-jHCOMd3RdS9fJj6kZVN-rZ7w27gNE88nkGm3vR8"
    ));

builder.Services.AddLogging(loggingBuilder => {
    var loggingSection = builder.Configuration.GetSection("Logging");
    loggingBuilder.AddFile(loggingSection);
});

builder.Services.AddTransient<IPrizeProvider, InMemoryPrizeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();