using generic_classes.Entities;
using generics_classes.Data;
using generics_classes.Entities;
using generics_classes.Repositories;

namespace generics_classes
{
    class Program {
        static void Main(string[] args)
        {
            // ItemAdded<Employee> itemAdded = new ItemAdded<Employee>(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;

            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organisationRepo = new ListRepository<Organisation>();
            AddOrganisations(organisationRepo);
            WriteAllToConsole(organisationRepo);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee employee)
        {
            Console.WriteLine($"Employee added => {employee.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if (saraManagerCopy is not null) {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

            managerRepository.Add(new Manager {FirstName = "Henry"});
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items) {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            System.Console.WriteLine($"Employee with ID 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Julia" },
                new Employee { FirstName = "Anna" },
                new Employee { FirstName = "Thomas" }
            };
            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganisations(IRepository<Organisation> organisationRepo)
        {
            var organisations = new[]
            {
                new Organisation { Name = "Pluralsight" },
                new Organisation { Name = "TestOrg" }
            };
            organisationRepo.AddBatch(organisations);
        }
    }
}