using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Student_App_MVC.Interfaces.Repositories;
using Student_App_MVC.Interfaces.Services;
using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;
using Student_App_MVC.Models.DTOs.Student;
using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.Implementations.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IStudentRepository studentRepository, 
        IDepartmentRepository departmentRepository,
        ILogger<StudentService> logger)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<BaseResponse<bool>> AddStudentAsync(CreateStudentRequestModel request)
    {
        var dept = await _departmentRepository.GetDepartmentById(request.DepartmentId);
        if (dept == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Department doesn't exist",
                Status = false,
            };
        }

        if (request == null)
        {
            return new BaseResponse<bool>
            {
                Message = "All fields are required",
                Status = false,
            };
        }

        var studentExists = await _studentRepository.ExistsEmail(request.Email);
        if(studentExists) return new BaseResponse<bool>{Message = "Email already exists", Status = false };

        var newStudent = new Student
        {
            DepartmentId = dept.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            Gender = request.Gender,
            Age = request.Age,
            StateOfOrigin = request.StateOfOrigin,
            MatricNumber = GenerateMatricNumber(dept.DepartmentalCode),
            CreatedDate = DateTime.UtcNow,
        };

        var createStudent = await _studentRepository.AddStudent(newStudent);
        if (createStudent == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Student unable to create",
                Status = false,
            };
        }
        return new BaseResponse<bool>
        {
            Message = "Student created successfully", 
            Status = true
        };

    }

    public async Task<BaseResponse<bool>> DeleteStudentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudentDTO>> GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<bool>> ExistsByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<StudentDTO>>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllStudents();
        if (!students.Any())
        {
            return new BaseResponse<List<StudentDTO>>
            {
                Message = "No students found",
                Status = false,
            };
        }

        return new BaseResponse<List<StudentDTO>>
        {
            Data = students.Select(std => new StudentDTO
            {
                Id = std.Id,
                FirstName = std.FirstName,
                LastName = std.LastName,
                Email = std.Email,
                PhoneNumber = std.PhoneNumber,
                Address = std.Address,
                Gender = std.Gender,
                Age = std.Age,
                StateOfOrigin = std.StateOfOrigin,
                MatricNumber = std.MatricNumber,
                CreatedDate = std.CreatedDate,
                ModifiedDate = std.ModifiedDate

            }).ToList()
        };
    }

    public async Task<BaseResponse<DepartmentDTO>> UpdateStudentAsyn(int id, UpdateStudentRequestModel request)
    {
        throw new NotImplementedException();
    }
    
    private static string GenerateMatricNumber(string deptCode)
    {
        return $"MITC/{deptCode}" + Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim();
    }
}