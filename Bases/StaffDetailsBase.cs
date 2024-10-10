using System.Configuration;
using BlazorStaff.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BlazorStaff.Components.Pages;

public class StaffDetailsBase : ComponentBase
{
    public Employee staff { get; set; } = new Employee();
    [Inject]
    public IStaffRepository staffRepository { get; set; }

    [Parameter]
    public string Id {get; set; }

    protected async override Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        staff = await staffRepository.GetStaff(int.Parse(Id));
    }
}