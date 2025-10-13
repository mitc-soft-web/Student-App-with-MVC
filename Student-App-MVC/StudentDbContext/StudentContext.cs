using Microsoft.EntityFrameworkCore;
using Student_App_MVC.Models.Entities;

namespace Student_App_MVC.StudentDbContext;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
            
    }
        
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
}