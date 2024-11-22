using System.Runtime.InteropServices;
using BlazorStaff.Models;
using Microsoft.AspNetCore.Components;


namespace BlazorStaff.Components.Pages;
public class StaffDeleteBase : ComponentBase {
    [Inject]
    public IStaffService apiCalling { get; set; }

    [Parameter]
    public string id { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public Employee employee { get; set; } = new Employee();

    protected async override Task OnInitializedAsync(){
        employee = await apiCalling.GetStaff(int.Parse(id));
    }

    public async Task deleteEmployee(){
        await apiCalling.DeleteStaff(employee);
        navigationManager.NavigateTo("/stafflist");
    }
}