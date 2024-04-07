using System.Net;
using Dapper;
using Domain.Models;
using Domain.Reponses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ParentServices;

public class ParentService : IParentService
{
    private readonly DapperContext _context;
    public ParentService(DapperContext context)
    {
        _context = context; 
    }
    public async Task<Response<string>> AddParentAsync(Parent parent)
    {
        try
        {
            var sql = $@"insert into parents(firstname,lastname,status,phone,email,dob,address)
                values('{parent.FirstName}','{parent.LastName}','{parent.Status}','{parent.Phone}','{parent.Email}','{parent.DOB}','{parent.Address}')";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Response<string>("Added Succesfully !");
                return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<List<Parent>>> GetParentAsync()
    {
        try
        {
            var sql = $@"select * from parents";
            var selected = await _context.Connection().QueryAsync<Parent>(sql);
            return new Response<List<Parent>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Response<List<Parent>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<Parent>> GetParentByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from parents where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Parent>(sql);
            if(selected != null) return new Response<Parent>(selected);
            return new Response<Parent>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            
            return new Response<Parent>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<string>> UpdateParentAsync(Parent parent)
    {
        try
        {
           var sql = $@"update parents set firstname = '{parent.FirstName}',lastname = '{parent.LastName}',status = '{parent.Status}',phone = '{parent.Phone}',email = '{parent.Email}',dob = '{parent.DOB}',address = '{parent.Address}' where id = {parent.Id}";

           var updated = await _context.Connection().ExecuteAsync(sql);

           if (updated > 0) return new Response<string>("Yet Updated!");
           return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<bool>> DeleteParentAsync(int id)
    {
        try
        {
           var sql = @$"delete from parents where id = {@id}";
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
