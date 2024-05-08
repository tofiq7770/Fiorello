using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> getAllAsync();
        Task<Product> getByIdAsync(int id);
    }
}
