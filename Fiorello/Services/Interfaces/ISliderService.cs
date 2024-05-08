using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();

    }
}
