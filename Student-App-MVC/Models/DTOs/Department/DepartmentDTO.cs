using Student_App_MVC.Models.DTOs.Student;
using System.ComponentModel.DataAnnotations;
using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.Models.DTOs.Department;

public class DepartmentDTO
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentalCode { get; set; }
    public List<StudentDTO> Students { get; set; }
}

public class CreateDepartmentRequestModel
{
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 3)]
    public string DepartmentName { get; set; }
    
    [Required]
    [StringLength(maximumLength: 5, MinimumLength = 3)]
    public string DepartmentalCode { get; set; }
}

public class UpdateDepartmentRequestModel
{
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 3)]
    public string DepartmentName { get; set; }
    public string DepartmentalCode { get; set; }
}