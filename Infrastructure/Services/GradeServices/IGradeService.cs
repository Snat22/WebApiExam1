using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.GradeServices;

public interface IGradeService
{
    Task<Response<List<Grade>>> GetGradesAsync();
    Task<Response<Grade>> GetGradesByIdAsync(int id);
    Task<Response<string>> AddGradesAsync(Grade grade);
    Task<Response<string>> UpdateGradesAsync(Grade grade);
    Task<Response<bool>> DeleteGradesAsync(int id); 
}
