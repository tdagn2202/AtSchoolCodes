using BlazorStaff.Models;

public interface IStaffRepository
{
    Task<IEnumerable<Employee>> GetAllStaff();
    Task <Employee> GetStaff(int id);
}