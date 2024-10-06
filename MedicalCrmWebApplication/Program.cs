using AltairCA.Blazor.WebAssembly.Cookie.Framework;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using MedicalCrmLib;
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using MedicalCrmLib.Repositories;
using MedicalCrmWebApplication.Components;
using MedicalCrmWebApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

const string connectionString = "Server=localhost; User ID=root; Password=1; Database=mydb";

builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<IRepository<Account, string>, AccountRepository>();
builder.Services.AddTransient<IRepository<Analysis, int>, AnalysisRepository>();
builder.Services.AddTransient<IRepository<AnalysisResult, (int MeasuredSubstanceId, int AnalysisCode, int EmployeeId)>, AnalysisResultRepository>();
builder.Services.AddTransient<IRepository<CleaningSchedule, (int RoomNumber, DateTime CleaningDate)>, CleaningScheduleRepository>();
builder.Services.AddTransient<IRepository<Client, int>, ClientRepository>();
builder.Services.AddTransient<IRepository<Contract, int>, ContractRepository>();
builder.Services.AddTransient<IRepository<Employee, int>, EmployeeRepository>();
builder.Services.AddTransient<IRepository<Journal, (int JournalId, DateTime Date)>, JournalRepository>();
builder.Services.AddTransient<IRepository<Laboratory, string>, LaboratoryRepository>();
builder.Services.AddTransient<IRepository<MeasuredSubstance, int>, MeasuredSubstanceRepository>();
builder.Services.AddTransient<IRepository<Order, int>, OrderRepository>();
builder.Services.AddTransient<IRepository<OrderService, int>, OrderServiceRepository>();
builder.Services.AddTransient<IRepository<ProtectiveEquipmentJournal, (string EquipmentName, int EmployeeId)>, ProtectiveEquipmentJournalRepository>();
builder.Services.AddTransient<IRepository<ServiceList, int>, ServiceListRepository>();
builder.Services.AddTransient<IJwtServiceWithRoles, JwtService>();
builder.Services.AddTransient<ISecurityService, SecurityService>();

builder.Services.AddAltairCACookieService(options =>
{
    options.DefaultExpire = TimeSpan.FromMinutes(15);
});


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
    app.UseHsts();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
