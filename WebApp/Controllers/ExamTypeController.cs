using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.ExamTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/ExamType")]
public class ExamTypeController(IExamTypeService examTypeService) : ControllerBase
{
    private readonly IExamTypeService _examTypeService = examTypeService;

    [HttpGet]
    public async Task<Response<List<ExamType>>> GetExamType()
    {
        return await _examTypeService.GetExamTypeAsync();
    }

    [HttpGet("examtypeId:int")]

    public async Task<Response<ExamType>> GetExamTypeById(int examtypeId)
    {
        return await _examTypeService.GetExamTypeByIdAsync(examtypeId);
    }

    [HttpPost]
    public async Task<Response<string>> AddExamType(ExamType examType)
    {
        return await examTypeService.AddExamTypeAsync(examType);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateExamType( ExamType examType)
    {
        return await _examTypeService.UpdateExamTypeAsync(examType);
    }

    [HttpDelete("examtypeId:int")]
    public async Task<Response<bool>> DeleteExamType(int examtypeId)
    {
        return await examTypeService.DeleteExamTypeAsync(examtypeId);
    }
}
