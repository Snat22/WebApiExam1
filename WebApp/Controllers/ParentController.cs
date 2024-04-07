using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.ParentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Parent")]
[ApiController]
public class ParentController(IParentService parentService) : ControllerBase
{
    private readonly IParentService _parentService = parentService;

    [HttpGet]
    public async Task<Response<List<Parent>>> GetParents()
    {
        return await _parentService.GetParentAsync();
    }

    [HttpGet("parentId:int")]
    public async Task<Response<Parent>> GetParentById(int parentId)
    {
        return await _parentService.GetParentByIdAsync(parentId);
    }

    [HttpPost]
    public async Task<Response<string>> AddParent(Parent add)
    {
        return await _parentService.AddParentAsync(add);
    }

    [HttpPut]
    
    public async Task<Response<string>> UpdateParent(Parent upd)
    {
        return await _parentService.UpdateParentAsync(upd);
    }

    [HttpDelete("parentId:int")]
    public async Task<Response<bool>> DeleteParent(int parentId)
    {
        return await _parentService.DeleteParentAsync(parentId);
    }
}
