namespace Student_App_MVC.Models.Entities;

public class Student : BaseEntity
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
    public string MatricNumber { get; set; }


    public string GenerateMatricNumber()
    {
        return "MITC" + Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "").Trim();
    }
}