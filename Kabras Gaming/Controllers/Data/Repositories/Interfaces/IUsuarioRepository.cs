using Kabras_Gaming.Controllers.Data.Models;
using Kabras_Gaming.Controllers.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kabras_Gaming.Controllers.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();  // Obtener todos los usuarios
        Task<Usuario?> GetUsuarioByIdAsync(string id);     // Obtener un usuario por ID
        Task<Usuario?> GetUsuarioByUsernameAsync(string username); // Obtener un usuario por nombre de usuario
        Task CreateUsuarioAsync(Usuario usuario);           // Crear un nuevo usuario

    }
}
