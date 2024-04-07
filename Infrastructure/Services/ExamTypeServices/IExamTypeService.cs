using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.ExamTypeServices;

public interface IExamTypeService
{
    Task<Response<List<ExamType>>> GetExamTypeAsync();
    Task<Response<ExamType>> GetExamTypeByIdAsync(int id);
    Task<Response<string>> AddExamTypeAsync(ExamType add);
    Task<Response<string>> UpdateExamTypeAsync(ExamType upd);
    Task<Response<bool>> DeleteExamTypeAsync(int id);
}
