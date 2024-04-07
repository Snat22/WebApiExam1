using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.TeacherServices;

public class TeacherService : ITeacherService
{
    private readonly DapperContext _context;
    public TeacherService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddTeacherAsync(Teacher add)
    {
        try
        {
            var sql = $@"insert into teachers(firstname,lastname,phone,email,address,dob)
            values('{add.FirstName}','{add.LastName}','{add.Phone}','{add.Email}','{add.Address}','{add.DOB}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return  new Response<string>("Added Succesfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }

    }


    public async Task<Response<List<Teacher>>> GetTeacherAsync()
    {
        try
        {
            var sql = $@"select * from teachers";
            var selected = await _context.Connection().QueryAsync<Teacher>(sql);
            return new Response<List<Teacher>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Teacher>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Teacher>> GetTeacherById(int id)
    {
        try
        {
            var sql = $@"select * from teachers where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Teacher>(sql);
            if(selected != null) return new Response<Teacher>(selected);
            return new Response<Teacher>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            
            return new Response<Teacher>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateTeacherAsync(Teacher teacher)
    {
        try
        {
            var sql = $@"update teachers set firstname = '{teacher.FirstName}',lastname = '{teacher.LastName}',phone = '{teacher.Phone}',email = '{teacher.Email}',address='{teacher.Address}',dob='{teacher.DOB}' where id = {teacher.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if( updated > 0) return new Response<string>("Yet Updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

        public async Task<Response<bool>> DeleteTeacherAsync(int id)
    {
        try
        {
            var sql = @$"delete from teachers where id = {@id}";
            var deleted = await _context.Connection().ExecuteAsync(sql);
            if( deleted > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


}
