using Kabras_Gaming.Controllers.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kabras_Gaming.Controllers.Data.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<producto>> GetAllProductosAsync();
        Task<producto?> GetProductoByIdAsync(string id);
        Task CreateproductoAsync(producto producto);
        Task<bool> UpdateproductoAsync(string id, producto producto);
        Task<bool> DeleteproductoAsync(string id);
    }
}
