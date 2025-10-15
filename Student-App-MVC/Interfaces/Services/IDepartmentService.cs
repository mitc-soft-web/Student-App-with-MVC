using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;

namespace Student_App_MVC.Interfaces.Services;

public interface IDepartmentService
{
    public Task<BaseResponse<bool>> AddDepartment(CreateDepartmentRequestModel request); 
    public Task<BaseResponse<bool>> DeleteDepartment(int id);
    public Task<BaseResponse<DepartmentDTO>> GetDepartmentById(int id);
    Task<BaseResponse<bool>> ExistsByName(string departmentName);
    Task<List<BaseResponse<DepartmentDTO>>> GetAllDepartments();
    Task<List<BaseResponse<DepartmentDTO>>> GetAllDepartmentsAndStudents();
    Task<BaseResponse<DepartmentDTO>> UpdateDepartment(UpdateDepartmentRequestModel request);
}