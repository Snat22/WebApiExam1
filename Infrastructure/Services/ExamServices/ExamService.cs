using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ExamServices;

public class ExamService : IExamService
{
    private readonly DapperContext _context;
    public ExamService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddExamAsync(Exam exam)
    {
        try
        {
            var sql = $@"insert into exams(examtype_id,name,start_date)
            values({exam.Examtype_Id},'{exam.Name}','{exam.StartDate}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully! ");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Exam>> GetExamByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from exams where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Exam>(sql);
            if(selected != null) return new Response<Exam>(selected);
            return new Response<Exam>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            
            return new Response<Exam>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Exam>>> GetExamsAsync()
    {
        try
        {
            var sql = $@"select * from exams";
            var selected = await _context.Connection().QueryAsync<Exam>(sql);
            return new Response<List<Exam>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return  new Response<List<Exam>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateExamAsync(Exam exam)
    {
        try
        {
           var sql = $@"update exams set examtype_id = {exam.Examtype_Id},name = '{exam.Name}',start_date = '{exam.StartDate}' where id = {exam.Id}";
           var updated = await _context.Connection().ExecuteAsync(sql);
           if(updated > 0) return new Response<string>("Yet Updated! ");
           return new Response<string>(HttpStatusCode.BadRequest,"Error"); 
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExamAsync(int id)
    {
        try
        {
            var sql = @$"delete from exams where id = {@id}";
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
