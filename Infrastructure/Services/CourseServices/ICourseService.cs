using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.CourseServices;

public interface ICourseService
{
    Task<Response<List<Course>>> GetCoursesAsync();
    Task<Response<Course>> GetCourseByIdAsync(int id);
    Task<Response<string>> AddCourseAsync(Course course);
    Task<Response<string>> UpdateCourseAsync(Course course);
    Task<Response<bool>> DeleteCourseAsync(int id); 
}
