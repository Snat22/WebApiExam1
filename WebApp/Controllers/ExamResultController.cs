using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.Relations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/ExamResult")]
[ApiController]
public class ExamResultController(IExamResultService examResultService): ControllerBase
{
    private readonly IExamResultService _examResultService = examResultService;

    [HttpGet]
    public async Task<Response<List<ExamResult>>> GetExamResult()
    {
        return await _examResultService.GetExamResultAsync();
    }

    [HttpGet("examresultId:int")]

    public async Task<Response<ExamResult>> GetExamResultById(int examresultId)
    {

        return await _examResultService.GetExamResultByIdAsync(examresultId);
    }

    [HttpPost]
    public async Task<Response<string>> AddExamResult(ExamResult add)
    {
        return await _examResultService.AddExamResultAsync(add);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateExamResult(ExamResult upd)
    {
        return await _examResultService.UpdateExamResultAsync(upd);
    }

    [HttpDelete("examresultId:int")]

    private async Task<Response<bool>> DeleteExamResult(int examresultId)
    {
        return await _examResultService.DeleteExamResultAsync(examresultId);
    }
}
