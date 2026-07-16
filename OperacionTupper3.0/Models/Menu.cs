using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Menu
{
    [Key]
    public int Id_Menu { get; set; }
    public int Cantidad_Dias { get; set; }
    public int Cantidad_Comidas { get; set; }
    public int Cantidad_Cenas { get; set; }

    public DateTime Fecha_Creacion { get; set; } 


    [InverseProperty(nameof(DiaMenu.MenuNavigation))]
    public virtual ICollection<DiaMenu> DiaMenuNavigation { get; set; } = new List<DiaMenu>();
}