using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.AtendanceServices;

public interface IAtendanceService
{
    Task<Response<List<Atendance>>> GetAtendanceAsync();
    Task<Response<Atendance>> GetAtendanceById(int id);
    Task<Response<string>> AddAtendanceAsync(Atendance add);
    Task<Response<string>> UpdateAtendanceAsync(Atendance upd);
    Task<Response<bool>> DeleteAtendanceAsync(int id);
}
