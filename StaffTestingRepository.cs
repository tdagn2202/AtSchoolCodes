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
        
        //create a new expected employee, then run addEmployee method to check whether the employee has been added correct or not
        mock.Setup(employeeInstance => employeeInstance.AddEmployee(employee)).ReturnsAsync(employee);
        var result = await staffRepository.AddEmployee(employee);

        Assert.Equal(employee, result);
        
    }


    [Fact]
    public async void GetAllStaff(){
        mock.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(expectedList);
        var result = (await mock.Object.GetAllEmployees()).ToList();


        // check for the number of employees that returned from getAllStaff method, and check for single employee attribues
        Assert.Equal(expectedList.Count, result.Count);
        for (int i = 0; i < expectedList.Count ; i++)
        {
            Assert.Equal(expectedList[i].EmployeeId, result[i].EmployeeId);
            Assert.Equal(expectedList[i].FirstName, result[i].FirstName);
            Assert.Equal(expectedList[i].LastName, result[i].LastName);
            Assert.Equal(expectedList[i].Email, result[i].Email);
            Assert.Equal(expectedList[i].DepartmentId, result[i].DepartmentId);
            Assert.Equal(expectedList[i].GenderId, result[i].GenderId);
        }
    }

    [Fact]
    public async void UpdateStaff(){
        Employee employee = new Employee();
        employee.EmployeeId = 2;
        employee.FirstName = "Trinh Tran Phuong";
        employee.LastName = "Tuan";
        employee.StartingDate = new DateTime(2016, 10, 10);
        employee.DepartmentId = 2;
        employee.GenderId = 2;
        employee.Email = "J97@fivemilions.com";



        //create an expected employee which will be modified if the Update is successful, and the compare to the wanna-tested method 
        mock.Setup(value => value.UpdateEmployee(employee)).ReturnsAsync(employee);
        var result = await staffRepository.UpdateEmployee(employee);

        // Assert.Equal(employee, result);
        Assert.Equal(employee.EmployeeId, result.EmployeeId);
        Assert.Equal(employee.FirstName, result.FirstName);
        Assert.Equal(employee.LastName, result.LastName);
        Assert.Equal(employee.StartingDate, result.StartingDate);
        Assert.Equal(employee.DepartmentId, result.DepartmentId);
        Assert.Equal(employee.GenderId, result.GenderId);
        Assert.Equal(employee.Email, result.Email);
    }

        [Fact]
        public async Task DeleteStaff()
        {
            // Arrange: Initial list of employees
            var initialList = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Cole",
                    StartingDate = new DateTime(2014, 10, 10),
                    DepartmentId = 1,
                    GenderId = 1,
                    Email = "john@abcdef.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Kim",
                    LastName = "Therese",
                    StartingDate = new DateTime(2016, 10, 10),
                    DepartmentId = 2,
                    GenderId = 2,
                    Email = "kim@abcdef.com"
                }
            };


            var deletedEmployee = new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Kim",
                    LastName = "Therese",
                    StartingDate = new DateTime(2016, 10, 10),
                    DepartmentId = 2,
                    GenderId = 2,
                    Email = "kim@abcdef.com"
                };

            var afterDeletionList = initialList.Where(x => x.EmployeeId != 2).ToList();
            var expectedListAfterDeletion = initialList.Where(e => e.EmployeeId != 2).ToList();
            mock.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(initialList);
            mock.Setup(repo => repo.DeleteEmployee(2)).ReturnsAsync(deletedEmployee);
            mock.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(afterDeletionList);

            var deleteResult = await mock.Object.DeleteEmployee(2);
            var resultAfterDeletion = await mock.Object.GetAllEmployees();

            Assert.Equal(expectedListAfterDeletion.Count(), resultAfterDeletion.Count());
            Assert.DoesNotContain(resultAfterDeletion, e => e.EmployeeId == 2);
        }


}