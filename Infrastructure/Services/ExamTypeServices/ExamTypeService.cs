using System.ComponentModel;
using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ExamTypeServices;

public class ExamTypeService : IExamTypeService
{
    private readonly DapperContext _context;
    public ExamTypeService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddExamTypeAsync(ExamType add)
    {
        try
        {
            var sql = $@"insert into examtypes(name,description)
            values('{add.Name}','{add.Description}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Successfully!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
            
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<ExamType>>> GetExamTypeAsync()
    {
        try
        {
            var sql = $@"select * from examtypes";
            var selected = await _context.Connection().QueryAsync<ExamType>(sql);
            return new Response<List<ExamType>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<ExamType>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<ExamType>> GetExamTypeByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from examtypes where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<ExamType>(sql);
            if(selected != null) return new Response<ExamType>(selected);
            return new Response<ExamType>(HttpStatusCode.BadRequest,"Not Found");
        }
        catch (System.Exception e)
        {
            
            return new Response<ExamType>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateExamTypeAsync(ExamType upd)
    {
        try
        {
            var sql = $@"update examtypes set name ='{upd.Name}',description = '{upd.Description}' where id = {upd.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Response<string>("Yet Updated! ");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExamTypeAsync(int id)
    {
        try
        {
            var sql = @$"delete from examtypes where id = {@id}";
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
