using BlazorStaff.Models;

public class StaffRepository : IStaffRepository{
    public StaffsContext staffsContext;
    public StaffRepository(StaffsContext staffsContext){
        this.staffsContext = staffsContext;
    }

    public async Task<Employee> GetStaff(int id){
        return (from staff in staffsContext.Employees
        where staff.EmployeeId == id
        select staff).First();
    }

    public async Task<IEnumerable<Employee>> GetAllStaff(){
        return staffsContext.Employees;
    }


}