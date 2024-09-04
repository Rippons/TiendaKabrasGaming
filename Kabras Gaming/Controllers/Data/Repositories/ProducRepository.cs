using Kabras_Gaming.Controllers.Data.Models;
using Kabras_Gaming.Controllers.Data.Repositories.Interfaces;
using MongoDB.Driver;

namespace Kabras_Gaming.Controllers.Data.Repositories
{
    public class ProducRepository : IProductoRepository
    {
        private readonly IMongoCollection<producto> _productos;

        public ProducRepository(IMongoClient client)
        {

            var database = client.GetDatabase("KabrasGaming");
            _productos = database.GetCollection<producto>("Productos");

        }
        public async Task<IEnumerable<producto>> GetAllProductosAsync()
        {

            return await _productos.Find(producto => true).ToListAsync();

        }

        public async Task<producto?> GetProductoByIdAsync(string id)
        {

            return await _productos.Find(producto => producto.Id == id).FirstOrDefaultAsync();

        }

        public async Task CreateproductoAsync(producto producto)
        {

            await _productos.InsertOneAsync(producto);

        }

        public async Task<bool> UpdateproductoAsync(string id, producto producto)
        {

            var result = await _productos.ReplaceOneAsync(p => p.Id == id, producto);
            return result.IsAcknowledged && result.ModifiedCount > 0;

        }

        public async Task<bool> DeleteproductoAsync(string id)
        {
            var result = await _productos.DeleteOneAsync(p => p.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

    }
}
