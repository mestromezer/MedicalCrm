using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using MedicalCrmLib;
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using MedicalCrmLib.Repositories;
using MrdicalCrmWebClient.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<DataMock>();
builder.Services.AddScoped<IRepository<CleaningRecord, int>, CleaningRecordsRepository>();
builder.Services.AddScoped<IRepository<Ppe, string>, PpeRepository>();
builder.Services.AddScoped<IRepository<LampJournal, int>, LampJournalRepository>();
builder.Services.AddScoped<IRepository<AnalysisResult, int>, AnalysisResultRpository>();
builder.Services.AddScoped<IRepository<Service, int>, ServiceRepository>();
builder.Services.AddScoped<IRepository<Order, int>, OrdersRepository>();
builder.Services.AddScoped<IRepository<Client, int>, ClientRepostiory>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

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
