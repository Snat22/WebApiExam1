using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.Relations;

public class Classroom_StudentService : IClassroom_StudentService
{
    private readonly DapperContext _context;
    public Classroom_StudentService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddClassroomStudentAsync(Classroom_Student add)
    {
        try
        {
            var sql = $@"insert into classroom_students(classroom_id,student_id)
            values({add.Classroom_Id},{add.Student_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<List<Classroom_Student>>> GetClassroomStudentsAsync()
    {
        try
        {
            var sql = $@"select * from classroom_studnets";
            var selected = await _context.Connection().QueryAsync<Classroom_Student>(sql);
            return new Response<List<Classroom_Student>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Classroom_Student>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Classroom_Student>> GetClassroomStudentsByIdAsync(int id)
    {
        try
        {
           var sql = $@"select * from classroom_students where id = {@id}";
           var selected = await _context.Connection().QueryFirstOrDefaultAsync<Classroom_Student>(sql);
           if(selected != null) return new Response<Classroom_Student>(selected);
           return new Response<Classroom_Student>(HttpStatusCode.BadRequest,"Bot Found"); 
        }
        catch (System.Exception e)
        {
            
            return new Response<Classroom_Student>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateClassroomStudentAsync(Classroom_Student upd)
    {
        try
        {
            var sql = $@"update classroom_students set classroom_id = {upd.Classroom_Id},student_id = {upd.Student_Id} where id = {upd.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteClassroomStudentAsync(int id)
    {
        try
        {
            
        var sql = @$"delete from classroom_students where id = {@id}";
        var deleted = await _context.Connection().ExecuteAsync(sql);
        if (deleted > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
