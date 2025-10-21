using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_App_MVC.Interfaces.Services;
using Student_App_MVC.Models.DTOs;
using Student_App_MVC.Models.DTOs.Department;
using Student_App_MVC.Models.DTOs.Student;

namespace Student_App_MVC.Controllers;

public class StudentController : Controller
{
    private readonly IDepartmentService _departmentService;

    private readonly IStudentService _studentService;

    public StudentController(IDepartmentService departmentService, IStudentService studentService)
    {
        _departmentService = departmentService ?? throw new NullReferenceException(nameof(departmentService));
        _studentService = studentService ?? throw new NullReferenceException(nameof(studentService));
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return View(students.Data);
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateStudent()
    {
        var departments =  await _departmentService.GetAllDepartmentsAsync();
        ViewData["Departments"] = new SelectList(departments.Data, "Id", "DepartmentName");
            
        return View();

    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentRequestModel model)
    {
        await _studentService.AddStudentAsync(model);
        return RedirectToAction(nameof(CreateStudent));
    }
}