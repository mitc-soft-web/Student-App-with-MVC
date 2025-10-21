using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;
using Student_App_MVC.Models.DTOs.Student;

namespace Student_App_MVC.Interfaces.Services;

public interface IStudentService
{
    public Task<BaseResponse<bool>> AddStudentAsync(CreateStudentRequestModel request); 
    public Task<BaseResponse<bool>> DeleteStudentAsync(int id);
    public Task<BaseResponse<StudentDTO>> GetStudentByIdAsync(int id);
    Task<BaseResponse<bool>> ExistsByEmailAsync(string email);
    Task<BaseResponse<List<StudentDTO>>> GetAllStudentsAsync();
    Task<BaseResponse<DepartmentDTO>> UpdateStudentAsyn(int id, UpdateStudentRequestModel request);
}