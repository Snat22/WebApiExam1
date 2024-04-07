using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.GradeServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Grade")]
[ApiController]
public class GradeController(IGradeService gradeService): ControllerBase
{
    private readonly IGradeService _gradeService = gradeService;

    [HttpGet]
    public async Task<Response<List<Grade>>> GetGrades()
    {
        return await _gradeService.GetGradesAsync();
    }

    [HttpGet("gradeId:int")]

    public async Task<Response<Grade>> GetGradeById(int gradeId)
    {
        return await _gradeService.GetGradesByIdAsync(gradeId);
    }

    [HttpPost]
    public async Task<Response<string>> AddGrade(Grade grade)
    {
        return await _gradeService.AddGradesAsync(grade);
    }
    
    [HttpPut]

    public async Task<Response<string>> UpdateGrade(Grade grade)
    {
        return await _gradeService.UpdateGradesAsync(grade);
    }

    [HttpDelete("gradeId:int")]
    public async Task<Response<bool>> DeleteGrade(int gradeId)
    {
        return await _gradeService.DeleteGradesAsync(gradeId);
    }

}
