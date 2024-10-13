using System.ComponentModel.DataAnnotations;

namespace Kabras_Gaming.DTOS
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

