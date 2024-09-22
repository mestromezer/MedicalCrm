using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using MedicalCrmLib;
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using MedicalCrmLib.Repositories;
using Microsoft.EntityFrameworkCore;
using MrdicalCrmWebClient.Components;
using MrdicalCrmWebClient.Srvices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConnectionString = "Server=localhost; User ID=root; Password=1; Database=mydb";

builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

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
builder.Services.AddTransient<IRepository<Service, int>, ServiceRepository>();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

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
