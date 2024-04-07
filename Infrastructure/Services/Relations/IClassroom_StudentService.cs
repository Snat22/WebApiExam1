using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.Relations;

public interface IClassroom_StudentService
{
    Task<Response<List<Classroom_Student>>> GetClassroomStudentsAsync();
    Task<Response<Classroom_Student>> GetClassroomStudentsByIdAsync(int id);
    Task<Response<string>> AddClassroomStudentAsync(Classroom_Student add);
    Task<Response<string>> UpdateClassroomStudentAsync(Classroom_Student upd);
    Task<Response<bool>> DeleteClassroomStudentAsync(int id);
}
