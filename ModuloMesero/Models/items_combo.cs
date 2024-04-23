using System.ComponentModel.DataAnnotations;

namespace ModuloMesero.Models
{
    public class items_combo
    {
        [Key]
        public int id_combo { get; set; }
        public int id_item_menu {  get; set; }

    }
}
