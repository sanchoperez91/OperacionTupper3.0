using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Plato_DiaMenu
{
    [Key]
    public int Id_Plato_DiaMenu { get; set; }
    public int Id_DiaMenu { get; set; }
    public int Id_Plato { get; set; }
    public int Id_HoraDelDia { get; set; }
    public bool PlatoUnico { get; set; }

    [ForeignKey(nameof(Id_DiaMenu))]
    public virtual DiaMenu? DiaMenuNavigation { get; set; } = null!;

    [ForeignKey(nameof(Id_Plato))]
    public virtual Platos? PlatoNavigation { get; set; } = null!;

    [ForeignKey(nameof(Id_HoraDelDia))]
    public virtual HoraDelDia? HoraDelDiaNavigation { get; set; } = null!;
}