using StaffServices.Models;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly StaffsContext appDbContext;

    public DepartmentRepository(StaffsContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public Department GetDepartment(int departmentId)
    {
        return appDbContext.Departments
            .FirstOrDefault(d => d.DepartmentId == departmentId);
    }

    public IEnumerable<Department> GetDepartments()
    {
        return appDbContext.Departments;
    }
}