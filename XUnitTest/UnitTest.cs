using AdTech_task;

namespace EmployeeManagerTests
{
    public class EmployeeManagerTests : IDisposable
    {
        private const string TestFilePath = "test_employees.json";
        private readonly EmployeeManager _employeeManager;

        public EmployeeManagerTests()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
            _employeeManager = new EmployeeManager(TestFilePath);
        }

        public void Dispose()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [Fact]
        public void AddEmployee_ShouldAddNewEmployee()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var salary = 100.50m;

            // Act
            _employeeManager.AddEmployee(firstName, lastName, salary);
            var employees = _employeeManager.GetAllEmployees();

            // Assert
            Assert.Single(employees);
            var employee = employees.First();
            Assert.Equal(1, employee.Id);
            Assert.Equal(firstName, employee.FirstName);
            Assert.Equal(lastName, employee.LastName);
            Assert.Equal(salary, employee.SalaryPerHour);
        }

        [Fact]
        public void UpdateEmployee_ShouldUpdateExistingEmployee()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var salary = 100.50m;
            _employeeManager.AddEmployee(firstName, lastName, salary);

            var newFirstName = "Jane";
            var newLastName = "Smith";
            var newSalary = 150.75m;

            // Act
            var employee = _employeeManager.GetAllEmployees().First();
            _employeeManager.UpdateEmployee(employee.Id, newFirstName, newLastName, newSalary);

            // Assert
            var updatedEmployee = _employeeManager.GetEmployee(employee.Id);
            Assert.Equal(newFirstName, updatedEmployee.FirstName);
            Assert.Equal(newLastName, updatedEmployee.LastName);
            Assert.Equal(newSalary, updatedEmployee.SalaryPerHour);
        }

        [Fact]
        public void GetEmployee_ShouldReturnCorrectEmployee()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var salary = 100.50m;
            _employeeManager.AddEmployee(firstName, lastName, salary);

            // Act
            var employee = _employeeManager.GetAllEmployees().First();
            var fetchedEmployee = _employeeManager.GetEmployee(employee.Id);

            // Assert
            Assert.NotNull(fetchedEmployee);
            Assert.Equal(employee.Id, fetchedEmployee.Id);
            Assert.Equal(employee.FirstName, fetchedEmployee.FirstName);
            Assert.Equal(employee.LastName, fetchedEmployee.LastName);
            Assert.Equal(employee.SalaryPerHour, fetchedEmployee.SalaryPerHour);
        }

        [Fact]
        public void DeleteEmployee_ShouldRemoveEmployee()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var salary = 100.50m;
            _employeeManager.AddEmployee(firstName, lastName, salary);

            // Act
            var employee = _employeeManager.GetAllEmployees().First();
            _employeeManager.DeleteEmployee(employee.Id);

            // Assert
            var employees = _employeeManager.GetAllEmployees();
            Assert.Empty(employees);
        }

        [Fact]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            // Arrange
            _employeeManager.AddEmployee("John", "Doe", 100.50m);
            _employeeManager.AddEmployee("Jane", "Smith", 150.75m);

            // Act
            var employees = _employeeManager.GetAllEmployees();

            // Assert
            Assert.Equal(2, employees.Count());
        }
    }
}


