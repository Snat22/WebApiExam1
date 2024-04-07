using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.StudentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Student")]
[ApiController]
public class StudentController(IStudentService studentService): ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet]
    public async Task<Response<List<Student>>> GetStudents()
    {
        return await _studentService.GetStudentsAsync();
    }

    [HttpGet("studentId:int")]
    public async Task<Response<Student>> GetStudentsById(int studentId)
    {
        return await _studentService.GetStudentByIdAsync(studentId);
    }
    [HttpPost]
    public async Task<Response<string>> AddStudents(Student student)
    {
        return await _studentService.AddStudentAsync(student);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudent( Student upd)
    {
        return await _studentService.UpdateStudentAsync(upd) ;
    }
    [HttpDelete("studentId:int")]
    
    public async Task<Response<bool>> DeleteStudent(int studentId)
    {
        return await _studentService.DeleteStudentAsync(studentId);
    }
}
