using Kabras_Gaming.Controllers.Data.Models;
using Kabras_Gaming.Controllers.Data.Repositories.Interfaces;
using MongoDB.Driver;

namespace Kabras_Gaming.Controllers.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(IMongoClient client)
        {
            var database = client.GetDatabase("KabrasGaming");
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarios.Find(usuario => true).ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(string id)
        {
            return await _usuarios.Find(usuario => usuario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> GetUsuarioByUsernameAsync(string username)
        {
            return await _usuarios.Find(usuario => usuario.Username == username).FirstOrDefaultAsync();
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }

    }
}


