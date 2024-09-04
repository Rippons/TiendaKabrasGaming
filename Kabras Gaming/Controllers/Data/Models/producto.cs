using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Kabras_Gaming.Controllers.Data.Models
{
    public class producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

     
        public string Nombre { get; set; }

       
        public string Descripcion { get; set; }

     
        public decimal Precio { get; set; }

        public int CantidadEnStock { get; set; }
    }
}