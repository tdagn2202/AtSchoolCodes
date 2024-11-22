using BlazorStaff.Models;

public interface IStaffService {
    Task<IEnumerable<Employee>> GetAllStaff();
    Task<Employee> GetStaff(int id);
    Task<Employee> UpdateStaff(Employee employee);
    Task DeleteStaff(Employee employee);
}