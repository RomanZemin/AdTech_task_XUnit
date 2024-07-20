namespace AdTech_task
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments provided.");
                return;
            }

            string filePath = "employees.json";
            var employeeManager = new EmployeeManager(filePath);

            switch (args[0])
            {
                case "-add":
                    var firstName = GetArgumentValue(args, "FirstName");
                    var lastName = GetArgumentValue(args, "LastName");
                    var salaryStr = GetArgumentValue(args, "Salary");
                    if (decimal.TryParse(salaryStr, out var salary))
                    {
                        employeeManager.AddEmployee(firstName, lastName, salary);
                        Console.WriteLine("Employee added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary value.");
                    }
                    break;

                case "-update":
                    var idStr = GetArgumentValue(args, "Id");
                    if (int.TryParse(idStr, out var id))
                    {
                        var updatedFirstName = GetArgumentValue(args, "FirstName");
                        var updatedLastName = GetArgumentValue(args, "LastName");
                        var updatedSalaryStr = GetArgumentValue(args, "Salary");
                        decimal? updatedSalary = null;
                        if (!string.IsNullOrEmpty(updatedSalaryStr) && decimal.TryParse(updatedSalaryStr, out var newSalary))
                        {
                            updatedSalary = newSalary;
                        }

                        if (employeeManager.UpdateEmployee(id, updatedFirstName, updatedLastName, updatedSalary))
                        {
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with Id={id} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id value.");
                    }
                    break;

                case "-get":
                    idStr = GetArgumentValue(args, "Id");
                    if (int.TryParse(idStr, out id))
                    {
                        var employee = employeeManager.GetEmployee(id);
                        if (employee != null)
                        {
                            Console.WriteLine($"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, SalaryPerHour = {employee.SalaryPerHour}");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with Id={id} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id value.");
                    }
                    break;

                case "-delete":
                    idStr = GetArgumentValue(args, "Id");
                    if (int.TryParse(idStr, out id))
                    {
                        if (employeeManager.DeleteEmployee(id))
                        {
                            Console.WriteLine("Employee deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with Id={id} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id value.");
                    }
                    break;

                case "-getall":
                    var employees = employeeManager.GetAllEmployees();
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, SalaryPerHour = {employee.SalaryPerHour}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }

        static string GetArgumentValue(string[] args, string argumentName)
        {
            foreach (var arg in args)
            {
                var parts = arg.Split(':');
                if (parts.Length == 2 && parts[0].Equals(argumentName, StringComparison.OrdinalIgnoreCase))
                {
                    return parts[1];
                }
            }
            return "";
        }
    }
}