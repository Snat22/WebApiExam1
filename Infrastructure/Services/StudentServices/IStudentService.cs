using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.StudentServices;

public interface IStudentService
{
   Task<Response<List<Student>>> GetStudentsAsync();
   Task<Response<Student>> GetStudentByIdAsync(int id);
   Task<Response<string>> AddStudentAsync(Student student);
   Task<Response<string>> UpdateStudentAsync(Student student);
   Task<Response<bool>> DeleteStudentAsync(int id);
}
