using EmployeeInfo.Models;

public partial class EmployeeRepository : IEmployeeRepository {
    EmployeesContext employeesContext;

    public EmployeeRepository(EmployeesContext employeesContext){
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


}