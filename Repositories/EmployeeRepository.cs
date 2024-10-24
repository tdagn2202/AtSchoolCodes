using Microsoft.EntityFrameworkCore;
using StaffServices.Models;

public partial class EmployeeRepository : IEmployeeRepository {
    StaffsContext employeesContext;

    public EmployeeRepository(StaffsContext employeesContext){
        this.employeesContext = employeesContext;
    }

    int Id;
    public async Task<Employee> GetEmployeeById(int id){
        return (from employee in employeesContext.Employees
        where employee.EmployeeId == id
        select employee).First();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees(){
        return employeesContext.Employees;
    }

    public async Task<Employee> AddEmployee(Employee employee){
        var result = await employeesContext.Employees.AddAsync(employee);
        await employeesContext.SaveChangesAsync ();
        return result.Entity;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
{
    var result = await employeesContext.Employees
        .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

    if (result != null)
    {
        result.FirstName = employee.FirstName;
        result.LastName = employee.LastName;
        result.Email = employee.Email;
        result.StartingDate = employee.StartingDate;
        result.Gender = employee.Gender;
        result.DepartmentId = employee.DepartmentId;
        // result.PhotoPath = employee.PhotoPath;
        await employeesContext.SaveChangesAsync();
        return result;
    }

    return null;
}

public async Task<Employee> DeleteEmployee(int employeeId)
{
    var result = await employeesContext.Employees
        .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

    if (result != null)
    {
        employeesContext.Employees.Remove(result);
        await employeesContext.SaveChangesAsync();
        return result;
    }

    return null;
}


}