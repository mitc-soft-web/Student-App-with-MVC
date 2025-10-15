namespace Student_App_MVC.Models.DTOs;

public class BaseResponse<T>
{
    public string Message { get; set; }
        
    public bool Status { get; set; }
    
    public T Data { get; set; }
}