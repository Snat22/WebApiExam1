using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.GradeServices;

public class GradeService : IGradeService
{
    private readonly DapperContext _context;
    public GradeService(DapperContext context)
    {
        _context = context; 
    }
    public async Task<Response<string>> AddGradesAsync(Grade grade)
    {
        try
        {
            var sql = $@"insert into grades(name,description)
            values('{grade.Name}','{grade.Description}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully !");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Grade>>> GetGradesAsync()
    {
        try
        {
            
        var sql = $@"select * from grades";
        var selected = await _context.Connection().QueryAsync<Grade>(sql);
        return new Response<List<Grade>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Grade>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Grade>> GetGradesByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from grades where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Grade>(sql);
            if (selected != null) return new Response<Grade>(selected);
            return new Response<Grade>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<Grade>(HttpStatusCode.InternalServerError,e.Message);            
        }
    }

    public async Task<Response<string>> UpdateGradesAsync(Grade grade)
    {
        try
        {
            var sql = $@"update grades set name = '{grade.Name}',description = '{grade.Description}' where id = {grade.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if (updated > 0) return new Response<string>("Yet Updated!");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    
    public async Task<Response<bool>> DeleteGradesAsync(int id)
    {
        try
        {
            var sql = @$"delete from grades where id = {@id}";
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
