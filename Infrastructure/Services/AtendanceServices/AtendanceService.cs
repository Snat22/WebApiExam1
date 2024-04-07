using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.AtendanceServices;

public class AtendanceService : IAtendanceService
{
    private readonly DapperContext _context;
    public AtendanceService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Response<string>> AddAtendanceAsync(Atendance add)
    {
        try
        {
            var sql = $@"insert into atendances(dates,student_id)
                values('{add.Dates}',{add.Student_Id})" ;
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Response<string>("Added Succesfully! ");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Atendance>> GetAtendanceById(int id)
    {
        try
        {
            var sql = $@"select * from atendances where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Atendance>(sql);
            if(selected != null) return new Response<Atendance>(selected);
            return new Response<Atendance>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            
            return new Response<Atendance>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<Atendance>>> GetAtendanceAsync()
    {
        try
        {
            var sql = $@"select * from atendances";
            var selected = await _context.Connection().QueryAsync<Atendance>(sql);
            return new Response<List<Atendance>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return  new Response<List<Atendance>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateAtendanceAsync(Atendance upd)
    {
        try
        {
           var sql = $@"update atendances set dates = '{upd.Dates}',student_id = {upd.Student_Id} where id = {upd.Id}";
           var updated = await _context.Connection().ExecuteAsync(sql);
           if(updated > 0) return new Response<string>("Yet Updated! ");
           return new Response<string>(HttpStatusCode.BadRequest,"Error"); 
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteAtendanceAsync(int id)
    {
        try
        {
            var sql = @$"delete from atendances where id = {@id}";
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
