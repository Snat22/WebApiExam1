using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.ExamServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Exam")]
[ApiController]
public class ExamController(IExamService examService):ControllerBase
{
    private readonly IExamService _examService = examService;

    [HttpGet]
    public async Task<Response<List<Exam>>> GetExams()
    {
        return await _examService.GetExamsAsync();
    }

    [HttpGet("examId:Int")]
    public async Task<Response<Exam>> GetExamById(int examId)
    {
        return await _examService.GetExamByIdAsync(examId);
    }

    [HttpPost]
    public async Task<Response<string>> AddExam(Exam exam)
    {
        return await examService.AddExamAsync(exam);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateExam(Exam exam)
    {
        return await _examService.UpdateExamAsync(exam);
    }

    [HttpDelete("examId:int")]

    private async Task<Response<bool>> DeleteExam(int examId)
    {
        return await _examService.DeleteExamAsync(examId);
    }
}
