using EmployeeInfo.Models;

public interface IEmployeeRepository {
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int id);
}