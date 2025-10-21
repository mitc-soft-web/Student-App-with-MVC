using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.Interfaces.Repositories;

public interface IStudentRepository
{
    public Task<Student> AddStudent(Student student); 
    public Task<bool> DeleteStudent(int id);
    public Task<Student> GetStudentById(int id);
    Task<bool> ExistsEmail(string email);
    Task<List<Student>> GetAllStudents();
    Task<Student> UpdateStudent(Student student);
}