using System.Text.Json;

namespace AdTech_task
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHour { get; set; }
    }
    class EmployeeManager
    {
        private readonly string _filePath;

        public EmployeeManager(string filePath)
        {
            _filePath = filePath;
        }

        public void AddEmployee(string firstName, string lastName, decimal salaryPerHour)
        {
            var employees = ReadEmployees();
            var newId = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            var newEmployee = new Employee
            {
                Id = newId,
                FirstName = firstName,
                LastName = lastName,
                SalaryPerHour = salaryPerHour
            };
            employees.Add(newEmployee);
            WriteEmployees(employees);
        }

        public bool UpdateEmployee(int id, string firstName, string lastName, decimal? salaryPerHour)
        {
            var employees = ReadEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                if (!string.IsNullOrEmpty(firstName)) employee.FirstName = firstName;
                if (!string.IsNullOrEmpty(lastName)) employee.LastName = lastName;
                if (salaryPerHour.HasValue) employee.SalaryPerHour = salaryPerHour.Value;
                WriteEmployees(employees);
                return true;
            }
            return false;
        }

        public Employee GetEmployee(int id)
        {
            var employees = ReadEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public bool DeleteEmployee(int id)
        {
            var employees = ReadEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                WriteEmployees(employees);
                return true;
            }
            return false;
        }

        public List<Employee> GetAllEmployees()
        {
            return ReadEmployees();
        }

        private List<Employee> ReadEmployees()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Employee>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        private void WriteEmployees(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
