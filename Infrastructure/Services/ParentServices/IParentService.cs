using Domain.Models;
using Domain.Reponses;

namespace Infrastructure.Services.ParentServices;

public interface IParentService
{
    Task<Response<List<Parent>>> GetParentAsync();
    Task<Response<Parent>> GetParentByIdAsync(int id);
    Task<Response<string>> AddParentAsync(Parent parent);
    Task<Response<string>> UpdateParentAsync( Parent parent);
    Task<Response<bool>> DeleteParentAsync(int id);
}
