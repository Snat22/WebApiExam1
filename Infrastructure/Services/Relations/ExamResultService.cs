using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.Relations;

public class ExamResultService : IExamResultService
{
    private readonly DapperContext _context;
    public ExamResultService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddExamResultAsync(ExamResult add)
    {
        try
        {
            var sql = $@"insert into exam_results(exam_id,student_id,course_id)
            values({add.Exam_Id},{add.Student_Id},{add.Course_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully !");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<ExamResult>>> GetExamResultAsync()
    {
        try
        {
            var sql = $@"select * from exam_results";
            var selected = await _context.Connection().QueryAsync<ExamResult>(sql);
            return new Response<List<ExamResult>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<ExamResult>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<ExamResult>> GetExamResultByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from exam_results where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<ExamResult>(sql);
            if(selected != null) return new Response<ExamResult>(selected);
            return new Response<ExamResult>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            
            return new Response<ExamResult>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateExamResultAsync(ExamResult upd)
    {
        try
        {
            var sql = $@"update exam_results set exam_id = {upd.Exam_Id},student_id = {upd.Student_Id},course_id = {upd.Course_Id} where id = {upd.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet Update!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExamResultAsync(int id)
    {
        try
        {
            var sql = @$"delete from exam_results where id = {@id}";
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
