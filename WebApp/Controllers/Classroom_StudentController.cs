using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.Relations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Classroom_Student")]
[ApiController]
public class Classroom_StudentController(IClassroom_StudentService classroom_StudentService):ControllerBase
{
    private readonly IClassroom_StudentService _classroom_StudentService = classroom_StudentService;

    [HttpGet]

    public async Task<Response<List<Classroom_Student>>> GetClassroomStudents()
    {
        return await _classroom_StudentService.GetClassroomStudentsAsync();
    }

    [HttpGet("classroomStudentdId:int")]

    public async Task<Response<Classroom_Student>> GetClassroomStudentsByIdAsync(int classroomStudentdId)
    {
        return await _classroom_StudentService.GetClassroomStudentsByIdAsync(classroomStudentdId);
    }

    [HttpPost]
    public async Task<Response<string>> AddClassroomStudents(Classroom_Student add)
    {
        return await _classroom_StudentService.AddClassroomStudentAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateClassroomStudent(Classroom_Student upd)
    {
        return await _classroom_StudentService.UpdateClassroomStudentAsync(upd);
    }

    [HttpDelete("classroomStudentId:int")]

    public async Task<Response<bool>> DeleteClassroomStudent(int classroomStudentdId)
    {
        return await _classroom_StudentService.DeleteClassroomStudentAsync(classroomStudentdId);
    }
}
