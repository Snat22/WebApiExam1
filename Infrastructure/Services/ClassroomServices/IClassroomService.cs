using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.ClassroomServices;

public interface IClassroomService
{
    Task<Response<List<Classroom>>> GetClassroomAsync();
    Task<Response<Classroom>> GetClassroomById(int id);
    Task<Response<string>> AddClassroomAsync(Classroom add);
    Task<Response<string>> UpdateClassroomAsync(Classroom upd);
    Task<Response<bool>> DeleteClassroomAsync(int id);
}
