using Student_App_MVC.Implementations.Repositories;
using Student_App_MVC.Interfaces.Repositories;
using Student_App_MVC.Interfaces.Services;
using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;
using Student_App_MVC.Models.DTOs.Student;
using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.Implementations.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILogger<DepartmentService> _logger;

    public DepartmentService(IDepartmentRepository departmentRepository, 
        ILogger<DepartmentService> logger)
    {
        _departmentRepository = departmentRepository;
        _logger = logger;
    }
    public async Task<BaseResponse<bool>> AddDepartment(CreateDepartmentRequestModel request)
    {
        if (request == null)
        {
            return new BaseResponse<bool>
            {
                Message = "Fields cannot be empty",
                Status = false,
            };
        }
        var departmentExists = await _departmentRepository.ExistsByName(request.DepartmentName);
        if (departmentExists)
        {
            _logger.LogError("Department already exists");
            return new BaseResponse<bool>
            {
                Message = $"Department with name {request.DepartmentName} already exists",
                Status = false
            };
        }

        var newDepartment = new Department
        {
            DepartmentName = request.DepartmentName,
            DepartmentalCode = request.DepartmentalCode,
            CreatedDate = DateTime.UtcNow
        };
        var createDepartment = await _departmentRepository.AddDepartment(newDepartment);
        if (createDepartment == null)
        {
            _logger.LogError("Create Department Failed");
            return new BaseResponse<bool>
            {
                Message = "Create Department Failed",
                Status = false
            };
        }
        _logger.LogInformation("Create Department Success");
        return new BaseResponse<bool>
        {
            Message = "Create Department Success",
            Status = true,

        };
    }

    public async Task<BaseResponse<bool>> DeleteDepartment(int id)
    {
        var getDepartment = await _departmentRepository.GetDepartmentById(id);
        if (getDepartment == null)
        {
            _logger.LogError($"Department with id {id} not found");
            return new BaseResponse<bool>
            {
                Message = $"Department with id {id} not found",
                Status = false
            };
        }
        
        var deleteDepartment = await _departmentRepository.DeleteDepartment(id);
        if (deleteDepartment)
        {
            _logger.LogInformation("Delete Department Success");
            return new BaseResponse<bool>
            {
                Message = "Delete Department Success",
                Status = true
            };
        }
        _logger.LogError("Delete Department Failed");
        return new BaseResponse<bool>
        {
            Message = "Delete Department Failed",
            Status = false
        };

    }

    public async Task<BaseResponse<DepartmentDTO>> GetDepartmentById(int id)
    {
        var getDepartment = await _departmentRepository.GetDepartmentById(id);
        if (getDepartment == null)
        {
            _logger.LogError($"Department with id {id} not found");
            return new BaseResponse<DepartmentDTO>
            {
                Message = $"Department with id {id} not found",
                Status = false,
            };
        }
        _logger.LogInformation("Department fetched successfully");
        return new BaseResponse<DepartmentDTO>
        {
            Message = "Department fetched successfully",
            Status = true,
            Data = new DepartmentDTO
            {
                Id = getDepartment.Id,
                DepartmentName = getDepartment.DepartmentName,
                DepartmentalCode = getDepartment.DepartmentalCode,
                CreatedDate = getDepartment.CreatedDate,
            }
        };

    }

    // public async Task<BaseResponse<bool>> ExistsByName(string departmentName)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<BaseResponse<List<DepartmentDTO>>> GetAllDepartments()
    {
        var getAllDepartments = await _departmentRepository.GetAllDepartments();
        if (!getAllDepartments.Any())
        {
            _logger.LogError($"No department found");
            return new BaseResponse<List<DepartmentDTO>>
            {
                Message = $"No department found",
                Status = false,
            };
        }
        _logger.LogInformation("All departments fetched successfully");
        return new BaseResponse<List<DepartmentDTO>>
        {
            Message = "All departments fetched successfully",
            Status = true,
            Data = getAllDepartments.Select(dpt => new DepartmentDTO
            {
                Id = dpt.Id,
                DepartmentName = dpt.DepartmentName,
                DepartmentalCode = dpt.DepartmentalCode,
                CreatedDate = dpt.CreatedDate,
            }).ToList()
        };
    }

    public async Task<BaseResponse<List<DepartmentDTO>>> GetAllDepartmentsAndStudents()
    {
        var getAllDepartmentsAndStudents = await _departmentRepository.GetAllDepartmentsAndStudents();
        if (!getAllDepartmentsAndStudents.Any())
        {
            _logger.LogError($"No department found");
            return new BaseResponse<List<DepartmentDTO>>
            {
                Message = $"No department found",
                Status = false,
            };
        }
        _logger.LogInformation("All departments along their students fetched successfully");
        return new BaseResponse<List<DepartmentDTO>>
        {
            Message = "All departments along their students fetched successfully",
            Status = true,
            Data = getAllDepartmentsAndStudents.Select(dpt => new DepartmentDTO
            {
                Id = dpt.Id,
                DepartmentName = dpt.DepartmentName,
                DepartmentalCode = dpt.DepartmentalCode,
                CreatedDate = dpt.CreatedDate,
                ModifiedDate = dpt.ModifiedDate,
                Students = dpt.Students.Select(std => new StudentDTO()
                {
                   Id = std.Id,
                   FirstName = std.FirstName,
                   LastName = std.LastName,
                   Email = std.Email,
                   PhoneNumber = std.PhoneNumber,
                   CreatedDate = std.CreatedDate,
                   ModifiedDate = std.ModifiedDate,
                   Address = std.Address,
                   Age = std.Age,
                   StateOfOrigin = std.StateOfOrigin,
                   MatricNumber = std.MatricNumber,
                   Gender = std.Gender,
                   DepartmentId = std.DepartmentId
                   
                }).ToList()
                
            }).ToList()
        };
    }

    public async Task<BaseResponse<DepartmentDTO>> UpdateDepartment(int id, UpdateDepartmentRequestModel request)
    {
        var getDepartment = await _departmentRepository.GetDepartmentById(id);
        if (getDepartment == null)
        {
            _logger.LogError($"Department with id {id} not found");
            return new BaseResponse<DepartmentDTO>
            {
                Message = $"Department with id {id} not found",
                Status = false,
            };
        }
        if (request == null)
        {
            return new BaseResponse<DepartmentDTO>
            {
                Message = "Fields cannot be empty",
                Status = false,
            };
        }
        getDepartment.DepartmentalCode = request.DepartmentalCode;
        getDepartment.DepartmentName = request.DepartmentName;
        getDepartment.ModifiedDate = DateTime.UtcNow;
        
        var updateDepartment = await _departmentRepository.UpdateDepartment(getDepartment);
        if (updateDepartment == null)
        {
            _logger.LogError($"Department update unsuccessful");
            return new BaseResponse<DepartmentDTO>
            {
                Message = "Department update unsuccessful",
                Status = false,

            };
        }
        _logger.LogInformation("Department update successfully");
        return new BaseResponse<DepartmentDTO>
        {
            Message = "Department update successfully",
            Status = true,
            Data = new DepartmentDTO
            {
                Id = updateDepartment.Id,
                DepartmentName = updateDepartment.DepartmentName,
                DepartmentalCode = updateDepartment.DepartmentalCode,
                ModifiedDate = updateDepartment.ModifiedDate,
            }
        };

    }
}