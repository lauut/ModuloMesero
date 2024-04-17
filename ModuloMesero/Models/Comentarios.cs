using System.ComponentModel.DataAnnotations;

namespace ModuloMesero.Models
{
    public class Comentarios
    {
        [Key]
        public int Id_comentario { get; set; }
        public int id_detallepedido { get; set; }
        public string Comentario { get; set; }


    }
}
