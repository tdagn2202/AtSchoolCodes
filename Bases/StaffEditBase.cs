
using BlazorStaff.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorStaff.Components.Pages;

public class StaffEditBase : ComponentBase {

    [Inject]
    public IStaffService apiCalling  { get; set; }
    
    [Parameter]
    public String id { get; set; }

    [Inject]
    NavigationManager  navigationManager { get; set; }

    public Employee employee { get; set; } = new Employee();
    
    protected override async Task OnInitializedAsync() {
        employee = await apiCalling.GetStaff(int.Parse(id));
        Console.WriteLine($"{employee.FirstName} - {employee.LastName} - {employee.Email}");
    }

    public async Task update() {
        await apiCalling.UpdateStaff(employee);
        Console.WriteLine($"Staff updated successfully: {employee.FirstName} - {employee.LastName} - {employee.Email}");
        navigationManager.NavigateTo("/stafflist");
    }

}