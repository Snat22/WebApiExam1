using Domain.Models;
using Domain.Reponses;
using Infrastructure.Services.AtendanceServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Atendance")]
[ApiController]
public class AtendanceController(IAtendanceService atendanceService):ControllerBase
{
    private readonly IAtendanceService _attendeesService = atendanceService;

    [HttpGet]
    public async Task<Response<List<Atendance>>> GetAtendance()
    {
        return await _attendeesService.GetAtendanceAsync();
    }

    [HttpGet("atendanceId:int")]
    public async Task<Response<Atendance>> GetAtendanceById(int atendanceId)
    {
        return await _attendeesService.GetAtendanceById(atendanceId);
    }

    [HttpPost]

    public async Task<Response<string>> AddAtendance(Atendance add)
    {
        return await _attendeesService.AddAtendanceAsync(add);
    }

    [HttpPut]

    public async Task<Response<string>> UpdateAtendace(Atendance upd)
    {
        return await _attendeesService.UpdateAtendanceAsync(upd);
    }

    [HttpDelete("atendanceId:int")]

    private async Task<Response<bool>> DeleteAtendaceAsync(int atendanceId)
    {
        return await _attendeesService.DeleteAtendanceAsync(atendanceId);
    }
}
