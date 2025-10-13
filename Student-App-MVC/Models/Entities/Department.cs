namespace Student_App_MVC.Models.Entities;

public class Department : BaseEntity
{
    public string DepartmentName { get; set; }
    public string DepartmentalCode { get; set; }

    public IList<Student> Students { get; set; }
}