using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ClassroomServices;

public class ClassroomService :IClassroomService
{
    
    private readonly DapperContext _context;
    public ClassroomService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddClassroomAsync(Classroom add)
    {
        try
        {
            var sql = $@"insert into classrooms(grade_id,sections,teacher_id)
            values({add.Grade_Id},'{add.Section}',{add.Teacher_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully! ");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Classroom>> GetClassroomById(int id)
    {
        try
        {
            var sql = $@"select * from classrooms where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Classroom>(sql);
            if(selected != null) return new Response<Classroom>(selected);
            return new Response<Classroom>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            
            return new Response<Classroom>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Classroom>>> GetClassroomAsync()
    {
        try
        {
            var sql = $@"select * from classrooms";
            var selected = await _context.Connection().QueryAsync<Classroom>(sql);
            return new Response<List<Classroom>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return  new Response<List<Classroom>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateClassroomAsync(Classroom upd)
    {
        try
        {
           var sql = $@"update classrooms set grade_id = {upd.Grade_Id},sections = '{upd.Section}',teacher_id = '{upd.Teacher_Id}' where id = {upd.Id}";
           var updated = await _context.Connection().ExecuteAsync(sql);
           if(updated > 0) return new Response<string>("Yet Updated! ");
           return new Response<string>(HttpStatusCode.BadRequest,"Error"); 
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteClassroomAsync(int id)
    {
        try
        {
            var sql = @$"delete from classrooms where id = {@id}";
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
