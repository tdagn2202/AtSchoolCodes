using BlazorStaff.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorStaff.Components.Pages;

public class AddStaffBase : ComponentBase {

    [Inject]
    public IStaffService apiCalling { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public Employee employee { get; set; } = new Employee();

    public async Task AddNewEmployee(){
        await apiCalling.AddStaff(employee);
        navigationManager.NavigateTo("/stafflist");
    }
}