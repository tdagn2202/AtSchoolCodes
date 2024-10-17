using Microsoft.AspNetCore.Components;

namespace EmployeeInfo.Models;

public class EmployeeDetailsBase : ComponentBase {
    
    public Employee employees { get; set; } = new Employee();
    [Inject]
    public IEmployeeRepository employeeRepository { get; set; }

    [Parameter]
    public string Id {get; set; }

    protected async override Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        employees = await employeeRepository.GetEmployeeById(int.Parse(Id));
    }
}