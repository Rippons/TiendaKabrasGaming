using Kabras_Gaming.Controllers.Data.Models;
using Kabras_Gaming.Controllers.Data.Repositories.Interfaces;
using Kabras_Gaming.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kabras_Gaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

      


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (response == null)
            {
                return NotFound("El usuario no existe");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioDTO request)
        {
            var newUsuario = new Usuario
            {
                Username = request.Username,
                Password = request.Password
            };

            // Verificar si el usuario ya existe
            var existingUser = await _usuarioRepository.GetUsuarioByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return BadRequest(new { error = "El nombre de usuario ya está en uso." });
            }

            try
            {
                await _usuarioRepository.CreateUsuarioAsync(newUsuario);
                return Ok(new { message = "Usuario creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Error al crear el usuario: {ex.Message}" });
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            var user = await _usuarioRepository.GetUsuarioByUsernameAsync(loginRequest.Username);

            if (user == null || user.Password != loginRequest.Password) // Asegúrate de usar un método seguro para comparar contraseñas
            {
                return BadRequest(new { error = "Usuario o contraseña incorrectos" });
            }

            // Lógica para iniciar sesión (puedes incluir tokens JWT u otros métodos)
            return Ok(new { message = "Login exitoso" });
        }





    }
}

