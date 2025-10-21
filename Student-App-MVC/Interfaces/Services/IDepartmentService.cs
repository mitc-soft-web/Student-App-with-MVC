using Microsoft.AspNetCore.Mvc.Rendering;
using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;

namespace Student_App_MVC.Interfaces.Services;

public interface IDepartmentService
{
    public Task<BaseResponse<bool>> AddDepartment(CreateDepartmentRequestModel request); 
    public Task<BaseResponse<bool>> DeleteDepartment(int id);
    public Task<BaseResponse<DepartmentDTO>> GetDepartmentById(int id);
    //Task<BaseResponse<bool>> ExistsByName(string departmentName);
    Task<BaseResponse<IEnumerable<DepartmentDTO>>> GetAllDepartmentsAsync();
    Task<IEnumerable<SelectListItem>> GetDepartmentsSelectList();
    Task<BaseResponse<List<DepartmentDTO>>> GetAllDepartmentsAndStudents();
    Task<BaseResponse<DepartmentDTO>> UpdateDepartment(int id, UpdateDepartmentRequestModel request);
}