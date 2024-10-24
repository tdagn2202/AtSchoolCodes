using StaffServices.Models;

public interface IEmployeeRepository {
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int id);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<Employee> DeleteEmployee(int employeeId);

}