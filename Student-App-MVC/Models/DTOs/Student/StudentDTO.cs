using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Student_App_MVC.Models.DTOs.Student;

public class StudentDTO
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string StateOfOrigin { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string MatricNumber { get; set; }
}

public class CreateStudentRequestModel
{
    [Required]
    [DisplayName("Department")]
    public int DepartmentId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string StateOfOrigin { get; set; }
    public IList<int> Departments { get; set; } = new List<int>();
    public IEnumerable<SelectListItem> DepartmentsSelectListItems { get; set; } 
    
}

public class UpdateStudentRequestModel
{
    public int DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string StateOfOrigin { get; set; }
}