using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.StudentServices;

public class StudentService : IStudentService
{
    private readonly DapperContext _context;
    public StudentService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddStudentAsync(Student student)
    {
        try
        {
            var sql = $@"insert into students(firstname,lastname,dob,phone,parent_id,email,address)
                values('{student.FirstName}','{student.LastName}','{student.DOB}','{student.Phone}',{student.Parent_Id},'{student.Email}','{student.Address}')";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Response<string>("Added Succesfully!");
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Student>> GetStudentByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from students where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Student>(sql);
            if (selected != null) return new Response<Student>(selected);
            return new Response<Student>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            
            return new Response<Student>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Student>>> GetStudentsAsync()
    {
        try
        {
            var sql = $@"select *  from students";
            var selected = await _context.Connection().QueryAsync<Student>(sql);
            return new Response<List<Student>>(selected.ToList()); 
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Student>>(HttpStatusCode.InternalServerError,e.Message); 
        }
    }

    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        try
        {
            var sql = $@"update students set firstname = '{student.FirstName}',lastname='{student.LastName}',dob = '{student.DOB}',phone ='{student.Phone}',parent_id = {student.Parent_Id},email = '{student.Email}',address = '{student.Address}' where id = {student.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet Updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error!");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

        public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        try
        {
            var sql = @$"delete from students where id = {@id}";
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
