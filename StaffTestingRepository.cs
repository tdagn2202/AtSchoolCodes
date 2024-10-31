using Moq;
using StaffServices.Models;
using Xunit;

namespace StaffTesting;

public class StaffTestingRepository
{
    Mock<IEmployeeRepository> mock;
    StaffsContext staffsContext;
    IEmployeeRepository staffRepository;
    public static List<Employee> expectedList { get; set; }

    public StaffTestingRepository()
    {
        mock = new Mock<IEmployeeRepository>();
        staffsContext = new StaffsContext();
        staffRepository = new EmployeeRepository(staffsContext);
        expectedList = new List<Employee>();

        expectedList.Add(new Employee()
        {
            EmployeeId = 1,
            FirstName = "John",
            LastName = "Cole",
            StartingDate = new DateTime(2014, 10, 10),
            DepartmentId = 1,
            GenderId = 1,
            Email = "john@abcdef.com"
        });

        expectedList.Add(new Employee()
        {
            EmployeeId = 2,
            FirstName = "Kim",
            LastName = "Therese",
            StartingDate = new DateTime(2016, 10, 10),
            DepartmentId = 2,
            GenderId = 2,
            Email = "kim@abcdef.com"
        });
    }

    [Fact]
    public async void GetStaff()
    {
        // Expected staff
        var staff = from emp in expectedList
                    where emp.EmployeeId == 2
                    select emp;
        var expectedStaff = (staff == null) ? null : staff.FirstOrDefault();

        mock.Setup(x => x.GetEmployeeById(2)).ReturnsAsync(expectedStaff);
        var result = await staffRepository.GetEmployeeById(2); // Revoke the method

        // Assertion
        Assert.Equal(expectedStaff.EmployeeId, result.EmployeeId);
    }

    [Fact]

    public async void AddStaff(){
        //Expected new-added Staff
        Employee employee = new Employee();
            employee.FirstName = "Tran Hai";
            employee.LastName = "Dang";
            employee.Email = "tdang.2202x@gmail.com";
            employee.DepartmentId = 1;
            employee.GenderId = 1;
        
        mock.Setup(employeeInstance => employeeInstance.AddEmployee(employee)).ReturnsAsync(employee);
        var result = await staffRepository.AddEmployee(employee);

        Assert.Equal(employee, result);
        
    }
}