using generics_classes.Entities;
using generics_classes.Repositories;

namespace generics_classes
{
    class Program {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organisationRepo = new GenericRepository<Organisation>();
            AddOrganisations(organisationRepo);

            Console.ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            System.Console.WriteLine($"Employee with ID 2: {employee.FirstName}");
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganisations(GenericRepository<Organisation> organisationRepo)
        {
            organisationRepo.Add(new Organisation { Name = "Pluralsight" });
            organisationRepo.Add(new Organisation { Name = "TestOrg" });
            organisationRepo.Save();
        }
    }
}