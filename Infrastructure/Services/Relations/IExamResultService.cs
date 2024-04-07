using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.Relations;

public interface IExamResultService
{
    Task<Response<List<ExamResult>>> GetExamResultAsync();
    Task<Response<ExamResult>> GetExamResultByIdAsync(int id);
    Task<Response<string>> AddExamResultAsync(ExamResult add);
    Task<Response<string>> UpdateExamResultAsync(ExamResult upd);
    Task<Response<bool>> DeleteExamResultAsync(int id);
    }
