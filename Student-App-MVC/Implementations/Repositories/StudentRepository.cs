using Microsoft.EntityFrameworkCore;
using Student_App_MVC.Interfaces.Repositories;
using Student_App_MVC.Models.Entities;
using Student_App_MVC.StudentDbContext;

namespace Student_App_MVC.Implementations.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository(StudentContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Student> AddStudent(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<bool> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        _context.Students.Remove(student);
        return await _context.SaveChangesAsync() > 0;
        
    }

    public async Task<Student> GetStudentById(int id)
    {
        var student = await _context.Students.FindAsync(id);
        return student;
    }

    public async Task<bool> ExistsEmail(string email)
    {
        return await _context.Students.AnyAsync(std => std.Email == email);
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }
}