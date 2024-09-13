using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

public abstract class CrmDbContext : DbContext
{
    private const string ConnectionString = "Server=localhost; User ID=root; Password=1; Database=mydb";

    // DbSet для всех таблиц базы данных
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Analysis> Analyses { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CleaningSchedule> CleaningSchedules { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<ProtectiveEquipmentJournal> ProtectiveEquipmentJournals { get; set; }
    public DbSet<MeasuredSubstance> MeasuredSubstances { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Laboratory> Laboratories { get; set; }
    public DbSet<AnalysisResult> AnalysisResults { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ServiceList> ServiceListRecords { get; set; }
    public DbSet<OrderService> OrderServices { get; set; }

    // Настройка подключения к базе данных
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account) 
            .WithMany()
            .HasForeignKey(e => e.AccountLogin)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
