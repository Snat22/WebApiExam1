using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Course")]
[ApiController]
public class CourseController(ICourseService courseService) : ControllerBase

{
    private readonly ICourseService _courseService = courseService;

    [HttpGet]
    public async Task<Response<List<Course>>> GetCourses()
    {
        return await _courseService.GetCoursesAsync();
    }

    [HttpGet("courseId:int")]

    public async Task<Response<Course>> GetCourseById(int courseId)
    {
        return await _courseService.GetCourseByIdAsync(courseId);
    }

    [HttpPost]
    public async Task<Response<string>> AddCourse(Course course)
    {
        return await _courseService.AddCourseAsync(course);
    }

    [HttpPut]

        public async Task<Response<string>> UpdateCourse(Course course)
        {
            return await _courseService.UpdateCourseAsync(course);
        }

        [HttpDelete("courseId:int")]

        public async Task<Response<bool>> DeleteCourse(int courseId)
        {
            return await _courseService.DeleteCourseAsync(courseId);
        }
}
