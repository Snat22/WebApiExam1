using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Classroom")]
[ApiController]
public class ClassroomController(IClassroomService classroomService):ControllerBase

{
    private readonly IClassroomService _classroomService = classroomService;

    [HttpGet]
    public async Task<Response<List<Classroom>>> GetClassrooms()
    {

        return await _classroomService.GetClassroomAsync();
    }

    [HttpGet("classroomId:int")]

    public async Task<Response<Classroom>> GetClassroomById(int classroomId)
    {
        return await _classroomService.GetClassroomById(classroomId);
    }

    [HttpPost]
    public async Task<Response<string>> AddClassroom( Classroom add)
    {
        return await _classroomService.AddClassroomAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateClassroom(Classroom upd)
    {
        return await _classroomService.UpdateClassroomAsync(upd);
    }

    [HttpDelete("classroomId:int")]
    public async Task<Response<bool>> DeleteClassroom(int classroomId)
    {
        return await _classroomService.DeleteClassroomAsync(classroomId);
    }
}
