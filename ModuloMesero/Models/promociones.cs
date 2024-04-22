using System.ComponentModel.DataAnnotations;

namespace ModuloMesero.Models
{
    public class promociones
    {
        [Key]
        public int id_promo { get; set; }
        public string descripcion { get; set; }
        public decimal precio {  get; set; }
        public DateTime fecha_inicio {  get; set; }
        public DateTime fecha_fin {  get; set; }
        public int id_estado {  get; set; }
        public string nombre { get; set; }
        public string imagen {  get; set; }



    }
}
