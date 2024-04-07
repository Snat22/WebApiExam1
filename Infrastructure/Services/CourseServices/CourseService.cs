using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CourseServices;

public class CourseService: ICourseService
{
    
    private readonly DapperContext _context;
    public CourseService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddCourseAsync(Course course)
    {
        try
        {
            var sql = $@"insert into courses(name,description,grade_id)
            values('{course.Name}','{course.Description}',{course.Grade_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully! ");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Course>> GetCourseByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from courses where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Course>(sql);
            if(selected != null) return new Response<Course>(selected);
            return new Response<Course>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            
            return new Response<Course>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Course>>> GetCoursesAsync()
    {
        try
        {
            var sql = $@"select * from courses";
            var selected = await _context.Connection().QueryAsync<Course>(sql);
            return new Response<List<Course>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return  new Response<List<Course>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateCourseAsync(Course course)
    {
        try
        {
           var sql = $@"update Courses set name = '{course.Name}',description = '{course.Description}',grade_id = {course.Grade_Id} where id = {course.Id}";
           var updated = await _context.Connection().ExecuteAsync(sql);
           if(updated > 0) return new Response<string>("Yet Updated! ");
           return new Response<string>(HttpStatusCode.BadRequest,"Error"); 
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        try
        {
            var sql = @$"delete from courses where id = {@id}";
            var deleted = await _context.Connection().ExecuteAsync(sql);
            if(deleted > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
}
