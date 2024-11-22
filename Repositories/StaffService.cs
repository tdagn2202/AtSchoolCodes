using System.ComponentModel;
using System.Runtime.Serialization;
using BlazorStaff.Models;

public class StaffService : IStaffService {
    private readonly HttpClient httpClient;

    public StaffService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetAllStaff(){
        return await httpClient.GetFromJsonAsync<Employee[]>("api/employee");
    }

    public async Task<Employee> GetStaff(int id){
        return await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
    }

    public async Task<Employee> UpdateStaff(Employee employee){
        var res =  await httpClient.PutAsJsonAsync($"api/Employee/{employee.EmployeeId}", employee);
        res.EnsureSuccessStatusCode();
        return await res.Content.ReadFromJsonAsync<Employee>();
    }

    public async Task DeleteStaff(Employee employee){
        await httpClient.DeleteAsync($"api/Employee/{employee.EmployeeId}");
    }

    public async Task AddStaff(Employee employee){
        await httpClient.PostAsJsonAsync("api/Employee", employee);
    }
}