using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class DiaMenu
{
    [Key]
    public int Id_DiaMenu { get; set; }
    public int Id_Menu { get; set; }

    [ForeignKey(nameof(Id_Menu))]
    public virtual Menu? MenuNavigation { get; set; } = null!;

    [InverseProperty(nameof(Plato_DiaMenu.DiaMenuNavigation))]
    public virtual ICollection<Plato_DiaMenu> Plato_DiaMenuNavigation { get; set; } = new List<Plato_DiaMenu>();
}