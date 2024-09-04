using System.ComponentModel.DataAnnotations;

namespace Kabras_Gaming.DTOS
{
    public class CreateproductoDTO
    {
        public string Id { get; set; }
        [Required]

        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public decimal Precio { get; set; }
        [Required]
        public int CantidadEnStock { get; set; }


    }
}
