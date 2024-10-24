using Microsoft.AspNetCore.Mvc;
using StaffServices.Models;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var employees = await employeeRepository.GetAllEmployees();
            return Ok(employees);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        try
        {
            var result = await employeeRepository.GetEmployeeById(id);
            if (result == null)
                return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        try
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var createdEmployee = await employeeRepository.AddEmployee(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
    {
        try
        {
            if (id != employee.EmployeeId)
                return BadRequest("Employee ID mismatch");

            var employeeToUpdate = await employeeRepository.GetEmployeeById(id);

            if (employeeToUpdate == null)
                return NotFound($"Employee with Id = {id} not found");

            return await employeeRepository.UpdateEmployee(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error updating data");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Employee>> DeleteEmployee(int id)
    {
        try
        {
            var employeeToDelete = await employeeRepository.GetEmployeeById(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await employeeRepository.DeleteEmployee(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error deleting data");
        }
    }

}
