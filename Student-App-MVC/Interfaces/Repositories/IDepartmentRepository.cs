using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.Interfaces.Repositories;

public interface IDepartmentRepository
{
    public Task<Department> AddDepartment(Department department); 
    public Task<bool> DeleteDepartment(int id);
    public Task<Department> GetDepartmentById(int id);
    Task<bool> ExistsByName(string departmentName);
    Task<List<Department>> GetAllDepartments();
    Task<List<Department>> GetAllDepartmentsAndStudents();
    Task<Department> UpdateDepartment(Department department);
}