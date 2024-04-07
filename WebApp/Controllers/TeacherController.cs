using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.TeacherServices;
using Microsoft.AspNetCore.Mvc;
namespace WebApp.Controllers;
[Route("/api/Teacher")]
[ApiController]
public class TeacherController(ITeacherService teacherService) : ControllerBase
{
    private readonly ITeacherService _services = teacherService;

    [HttpGet]
    public async Task<Response<List<Teacher>>> GetTeachers()
    {
        return await _services.GetTeacherAsync();
    }
    [HttpGet("teacherId:int")]
    public async Task<Response<Teacher>> GetTeachersById(int teacherId)
    {
        return await _services.GetTeacherById(teacherId);
    }

    [HttpPost]
    public async Task<Response<string>> AddTeachers(Teacher add)
    {
        return await _services.AddTeacherAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateTeacher(Teacher upd)
    {
        return await _services.UpdateTeacherAsync(upd);
    }
    [HttpDelete("teacherId:int")]
    public async Task<Response<bool>> DeleteTeachers(int teacherId)
    {
        return  await _services.DeleteTeacherAsync(teacherId);
    }
}

