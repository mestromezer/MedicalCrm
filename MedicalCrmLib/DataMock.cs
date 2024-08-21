using MedicalCrmLib.Model;

namespace MedicalCrmLib;

public class DataMock
{
    public List<CleaningRecord> CleaningRecords { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
    public List<LampJournal> LampJournalRecords { get; set; } = new();
    public List<Ppe> PersonlaProtectiveEquipment { get; set; } = new();
    public List<Analysis> Analusises { get; set; } = new();
    public List<AnalysisResult> AnalysisesResults { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Service> Services { get; set; } = new();
    public List<Client> Clients { get; set; } = new();

    public DataMock()
    {
        InitClients();
        InitEmployees();
        InitCleaningLog();
        InitLampJournal();
        InitPpes();
        InitAnalysises();
        InitAnalysisResults();
        InitOrders();
        InitServices();
        InitClients();
    }

    private void InitEmployees()
    {
        Employees.Add(new Employee
        {
            Id = 1,
            FullName = "John Doe",
            DateBirth = new DateTime(1985, 5, 15),
            PhoneNumber = "123-456-7890",
            Position = CompanyPositions.HeadOfLaboratory,
            LaboratoryName = "testlab1",
            Login = "jdoe"
        });

        Employees.Add(new Employee
        {
            Id = 2,
            FullName = "Alice Smith",
            DateBirth = new DateTime(1990, 7, 22),
            PhoneNumber = "987-654-3210",
            Position = CompanyPositions.SeniorMedicalAssistant,
            LaboratoryName = "testlab1",
            Login = "asmith"
        });

        Employees.Add(new Employee
        {
            Id = 3,
            FullName = "Michael Johnson",
            DateBirth = new DateTime(1978, 3, 10),
            PhoneNumber = "555-123-4567",
            Position = CompanyPositions.MedicalAssistant,
            LaboratoryName = "testlab1",
            Login = "mjohnson"
        });

        Employees.Add(new Employee
        {
            Id = 4,
            FullName = "Karen Larsen",
            DateBirth = new DateTime(1988, 11, 5),
            PhoneNumber = "321-654-0987",
            Position = CompanyPositions.MedicalAssistant,
            LaboratoryName = "testlab1",
            Login = "klarsen"
        });

        Employees.Add(new Employee
        {
            Id = 5,
            FullName = "David Garcia",
            DateBirth = new DateTime(1992, 9, 17),
            PhoneNumber = "654-321-1234",
            Position = CompanyPositions.Receptionist,
            LaboratoryName = "testlab1",
            Login = "dgarcia"
        });
    }

    private void InitCleaningLog()
    {
        CleaningRecords.Add(new CleaningRecord { Id = 1, Cabinet = 101, EmployeeId = 2 });
        CleaningRecords.Add(new CleaningRecord { Id = 2, Cabinet = 102, EmployeeId = 2 });
        CleaningRecords.Add(new CleaningRecord { Id = 3, Cabinet = 103, EmployeeId = 2 });
        CleaningRecords.Add(new CleaningRecord { Id = 4, Cabinet = 104, EmployeeId = 2 });
        CleaningRecords.Add(new CleaningRecord { Id = 5, Cabinet = 105, EmployeeId = 2 });
    }

    private void InitLampJournal()
    {
        LampJournalRecords.Add(new LampJournal
        {
            Id = 1,
            RecordDateTime = DateTime.Now,
            EmployeeId = 2,
            Cabinet = 101,
            ProductionTime = new DateTime(2024, 8, 20, 8, 0, 0),
            BestBeforeDate = new DateTime(2025, 8, 20)
        });

        LampJournalRecords.Add(new LampJournal
        {
            Id = 2,
            RecordDateTime = DateTime.Now.AddMinutes(-30),
            EmployeeId = 2,
            Cabinet = 102,
            ProductionTime = new DateTime(2024, 8, 20, 9, 0, 0),
            BestBeforeDate = new DateTime(2025, 8, 21)
        });

        LampJournalRecords.Add(new LampJournal
        {
            Id = 3,
            RecordDateTime = DateTime.Now.AddHours(-1),
            EmployeeId = 2,
            Cabinet = 103,
            ProductionTime = new DateTime(2024, 8, 19, 10, 0, 0),
            BestBeforeDate = new DateTime(2025, 8, 19)
        });

        LampJournalRecords.Add(new LampJournal
        {
            Id = 4,
            RecordDateTime = DateTime.Now.AddHours(-2),
            EmployeeId = 2,
            Cabinet = 104,
            ProductionTime = new DateTime(2024, 8, 21, 11, 0, 0),
            BestBeforeDate = new DateTime(2025, 8, 22)
        });

        LampJournalRecords.Add(new LampJournal
        {
            Id = 5,
            RecordDateTime = DateTime.Now.AddHours(-3),
            EmployeeId = 2,
            Cabinet = 105,
            ProductionTime = new DateTime(2024, 8, 21, 12, 0, 0),
            BestBeforeDate = new DateTime(2025, 8, 23)
        });
    }

    private void InitPpes()
    {
        PersonlaProtectiveEquipment.Add(new Ppe
        {
            Name = "Safety Gloves",
            EmployeeId = 2,
            Quantity = 10,
            RequiredQuantity = 15
        });

        PersonlaProtectiveEquipment.Add(new Ppe
        {
            Name = "Safety Goggles",
            EmployeeId = 2,
            Quantity = 5,
            RequiredQuantity = 5
        });

        PersonlaProtectiveEquipment.Add(new Ppe
        {
            Name = "Respirator Mask",
            EmployeeId = 2,
            Quantity = 12,
            RequiredQuantity = 12
        });

        PersonlaProtectiveEquipment.Add(new Ppe
        {
            Name = "Ear Protection",
            EmployeeId = 2,
            Quantity = 4,
            RequiredQuantity = 6
        });
    }

    private void InitAnalysises()
    {
        Analusises.Add(new Analysis
        {
            Id = 1,
            DateOfSample = new DateTime(2024, 8, 10),
            BioMaterialType = BioMaterials.Blood,
            OrderId = 1
        });

        Analusises.Add(new Analysis
        {
            Id = 2,
            DateOfSample = new DateTime(2024, 8, 12),
            BioMaterialType = BioMaterials.Urine,
            OrderId = 2
        });

        Analusises.Add(new Analysis
        {
            Id = 3,
            DateOfSample = new DateTime(2024, 8, 14),
            BioMaterialType = BioMaterials.Saliva,
            OrderId = 3
        });

        Analusises.Add(new Analysis
        {
            Id = 4,
            DateOfSample = new DateTime(2024, 8, 16),
            BioMaterialType = BioMaterials.Tissue,
            OrderId = 4
        });

        Analusises.Add(new Analysis
        {
            Id = 5,
            DateOfSample = new DateTime(2024, 8, 18),
            BioMaterialType = BioMaterials.Blood,
            OrderId = 5
        });
    }

    private void InitAnalysisResults()
    {
        AnalysisesResults.Add(new AnalysisResult
        {
            Id = 1,
            AnalysisId = 1,
            EmployeeId = 3,
            Report = "Substance A shows positive reaction.",
            Comments = "Requires further testing."
        });

        AnalysisesResults.Add(new AnalysisResult
        {
            Id = 2,
            AnalysisId = 2,
            EmployeeId = 4,
            Report = "Substance B is stable under conditions.",
            Comments = "No issues detected."
        });

        AnalysisesResults.Add(new AnalysisResult
        {
            Id = 3,
            AnalysisId = 3,
            EmployeeId = 4,
            Report = "Substance C shows signs of degradation.",
            Comments = "Recommend immediate action."
        });

        AnalysisesResults.Add(new AnalysisResult
        {
            Id = 4,
            AnalysisId = 4,
            EmployeeId = 3,
            Report = "Substance D is within acceptable parameters.",
            Comments = "Monitor over time."
        });

        AnalysisesResults.Add(new AnalysisResult
        {
            Id = 5,
            AnalysisId = 5,
            EmployeeId = 4,
            Report = "Substance E has unusual properties.",
            Comments = "Further analysis needed."
        });
    }

    private void InitOrders()
    {
        Orders.Add(new Order
        {
            Id = 1,
            CreatedDate = new DateTime(2024, 8, 10),
            Cost = 1500,
            NumOfServices = 3,
            EmployeeId = 5,
            ClientId = 1
        });

        Orders.Add(new Order
        {
            Id = 2,
            CreatedDate = new DateTime(2024, 8, 12),
            Cost = 2500,
            NumOfServices = 5,
            EmployeeId = 5,
            ClientId = 2
        });

        Orders.Add(new Order
        {
            Id = 3,
            CreatedDate = new DateTime(2024, 8, 14),
            Cost = 1800,
            NumOfServices = 4,
            EmployeeId = 5,
            ClientId = 3
        });

        Orders.Add(new Order
        {
            Id = 4,
            CreatedDate = new DateTime(2024, 8, 16),
            Cost = 2200,
            NumOfServices = 6,
            EmployeeId = 5,
            ClientId = 4
        });

        Orders.Add(new Order
        {
            Id = 5,
            CreatedDate = new DateTime(2024, 8, 18),
            Cost = 2000,
            NumOfServices = 2,
            EmployeeId = 5,
            ClientId = 5
        });
    }

    private void InitServices()
    {
        Services.Add(new Service
        {
            Id = 1,
            Name = ServicesNames.BloodTest,
            Cost = 500,
            LaboratoryName = "testlab1"
        });

        Services.Add(new Service
        {
            Id = 2,
            Name = ServicesNames.UrineAnalysis,
            Cost = 300,
            LaboratoryName = "testlab1"
        });

        Services.Add(new Service
        {
            Id = 3,
            Name = ServicesNames.MriScan,
            Cost = 1500,
            LaboratoryName = "testlab1"
        });

        Services.Add(new Service
        {
            Id = 4,
            Name = ServicesNames.Xray,
            Cost = 700,
            LaboratoryName = "testlab1"
        });

        Services.Add(new Service
        {
            Id = 5,
            Name = ServicesNames.DnaSequencing,
            Cost = 2500,
            LaboratoryName = "testlab1"
        });
    }

    private void InitClients()
    {
        Clients.Add(new Client
        {
            Id = 1,
            FullName = "Иванов Иван Иванович",
            Address = "ул. Пушкина, д. 10, кв. 5",
            PhoneNumber = "+7 123 456-78-90",
            Email = "ivanov@example.com",
            BirthDate = new DateTime(1985, 5, 12),
            Gender = "М",
            Company = "ООО Ромашка"
        });

        Clients.Add(new Client
        {
            Id = 2,
            FullName = "Петров Петр Петрович",
            Address = "ул. Лермонтова, д. 20, кв. 8",
            PhoneNumber = "+7 987 654-32-10",
            Email = "petrov@example.com",
            BirthDate = new DateTime(1990, 8, 25),
            Gender = "М",
            Company = "АО Лилия"
        });

        Clients.Add(new Client
        {
            Id = 3,
            FullName = "Сидорова Анна Андреевна",
            Address = "ул. Чехова, д. 15, кв. 12",
            PhoneNumber = "+7 345 678-90-12",
            Email = "sidorova@example.com",
            BirthDate = new DateTime(1992, 11, 4),
            Gender = "Ж",
            Company = "ЗАО Снежинка"
        });

        Clients.Add(new Client
        {
            Id = 4,
            FullName = "Кузнецов Алексей Валерьевич",
            Address = "ул. Гоголя, д. 30, кв. 3",
            PhoneNumber = "+7 567 890-12-34",
            Email = "kuznetsov@example.com",
            BirthDate = new DateTime(1988, 3, 22),
            Gender = "М",
            Company = "ООО Сатурн"
        });

        Clients.Add(new Client
        {
            Id = 5,
            FullName = "Максимова Ольга Васильевна",
            Address = "ул. Суворова, д. 50, кв. 7",
            PhoneNumber = "+7 234 567-89-01",
            Email = "maksimova@example.com",
            BirthDate = new DateTime(1983, 7, 19),
            Gender = "Ж",
            Company = "ИП Звезда"
        });
    }
}
