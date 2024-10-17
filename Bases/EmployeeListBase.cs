using EmployeeInfo.Models;

using Microsoft.AspNetCore.Components;
namespace EmployeeInfo.Models;
public class EmployeeListBase: ComponentBase
{
    [Inject]
    public IEmployeeRepository employeeRepository { get; set; }
    public IEnumerable<Employee> employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        employees = await employeeRepository.GetAllEmployees();
    }
}