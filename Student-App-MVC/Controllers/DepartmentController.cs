using Microsoft.AspNetCore.Mvc;
using Student_App_MVC.Interfaces.Repositories;
using Student_App_MVC.Interfaces.Services;
using Student_App_MVC.Models.DTOs.Department;

namespace Student_App_MVC.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    // GET
    public IActionResult Index()
    {
        var allDepartments = _departmentService.GetAllDepartments();
        return View(allDepartments);
    }
    
    [HttpGet]
    public IActionResult CreateDepartment()
    {
        return View();
    }
    
    [HttpPut]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentRequestModel model)
    {
        await _departmentService.AddDepartment(model);
        
        return RedirectToAction("Index");
    }
}