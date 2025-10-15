using Microsoft.EntityFrameworkCore;
using Student_App_MVC.Interfaces.Repositories;
using Student_App_MVC.Models.Entities;
using Student_App_MVC.StudentDbContext;

namespace Student_App_MVC.Implementations.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly StudentContext _context;

    public DepartmentRepository(StudentContext context)
    {
        _context = context;
    }
    public async Task<Department> AddDepartment(Department department)
    {
         await _context.AddAsync(department);
         await _context.SaveChangesAsync();
         return department;
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
        
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        return department;
    }

    public async Task<bool> ExistsByName(string departmentName)
    {
        await _context.Departments.AnyAsync(dpt => dpt.DepartmentName == departmentName);
        return true;

    }

    public async Task<List<Department>> GetAllDepartments()
    {
        var departments = await _context.Departments.ToListAsync();
        return departments;
    }

    public async Task<List<Department>> GetAllDepartmentsAndStudents()
    {
        var departments = await _context.Departments
            .Include(std => std.Students)
            .AsNoTracking()
            .ToListAsync();
        
        return departments;
    }

    public async Task<Department> UpdateDepartment(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return department;
    }
}