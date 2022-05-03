using generic_classes.Entities;
using generics_classes.Data;
using generics_classes.Entities;
using generics_classes.Repositories;

namespace generics_classes
{
    class Program {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organisationRepo = new ListRepository<Organisation>();
            AddOrganisations(organisationRepo);
            WriteAllToConsole(organisationRepo);

            Console.ReadLine();
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager {FirstName = "Sara"});
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
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganisations(IRepository<Organisation> organisationRepo)
        {
            organisationRepo.Add(new Organisation { Name = "Pluralsight" });
            organisationRepo.Add(new Organisation { Name = "TestOrg" });
            organisationRepo.Save();
        }
    }
}