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