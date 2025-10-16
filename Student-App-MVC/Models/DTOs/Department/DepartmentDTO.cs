using Student_App_MVC.Models.DTOs.Student;
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
    public string DepartmentName { get; set; }
    public string DepartmentalCode { get; set; }
}

public class UpdateDepartmentRequestModel
{
    public string DepartmentName { get; set; }
    public string DepartmentalCode { get; set; }
}