using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.ExamServices;

public interface IExamService
{
    Task<Response<List<Exam>>> GetExamsAsync();
    Task<Response<Exam>> GetExamByIdAsync(int id);
    Task<Response<string>> AddExamAsync(Exam exam);
    Task<Response<string>> UpdateExamAsync(Exam exam);
    Task<Response<bool>> DeleteExamAsync(int id);
}
