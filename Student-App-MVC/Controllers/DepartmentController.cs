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
    public IActionResult GetAllDepartmentsAlongStudents()
    {
        var allDepartments = _departmentService.GetAllDepartmentsAndStudents();
        return View(allDepartments);
    }
    
    [HttpGet]
    public IActionResult CreateDepartment()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody]CreateDepartmentRequestModel model)
    {
        await _departmentService.AddDepartment(model);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDepartment([FromRoute] int id)
    {
        var department = await _departmentService.GetDepartmentById(id);
        if (department == null)
        {
            throw new Exception("Request not found!");
        }

        return View(department);
    }
        
    [HttpGet]
    public async Task<IActionResult> EditDepartment(int id)
    {

        var dept = await _departmentService.GetDepartmentById(id);
        if (dept==null)
        {
            throw new Exception("Request unsuccessful");
        }

        return View();
    }
        
    [HttpPost]
    public async Task<IActionResult> EditItem([FromRoute]int id, [FromBody]UpdateDepartmentRequestModel model)
    {

        await _departmentService.UpdateDepartment(id, model);

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var dept = await _departmentService.GetDepartmentById(id);
        if (dept == null) return NotFound();
        
       return View(dept);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _departmentService.DeleteDepartment(id);
        return RedirectToAction("Index");
    }
}