using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.TeacherServices;

public interface ITeacherService
{
    Task<Response<List<Teacher>>> GetTeacherAsync();
    Task<Response<Teacher>> GetTeacherById(int id);
    Task<Response<string>> AddTeacherAsync(Teacher add);
    Task<Response<string>> UpdateTeacherAsync(Teacher teacher);
    Task<Response<bool>> DeleteTeacherAsync(int id);
}
