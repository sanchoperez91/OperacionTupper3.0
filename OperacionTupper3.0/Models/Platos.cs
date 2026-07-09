using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Platos
{
    [Key]
    public int Id_Plato { get; set; }

    public string Nombre_Plato { get; set; } = null!;

    public string? Descripcion_Plato { get; set; }
    public bool PlatoUnico { get; set; } 
    public int Id_TipoPlato { get; set; }
    public int Id_HoraDelDia { get; set; }

    [InverseProperty(nameof(PlatoIngredientes.PlatosNavigation))]
    public virtual ICollection<PlatoIngredientes> PlatoIngredientesNavigation { get; set; } = new List<PlatoIngredientes>();
    
    [ForeignKey(nameof(Id_TipoPlato))]
    public virtual TipoPlato? TipoPlatoNavigation { get; set; } = null!;
    [ForeignKey(nameof(Id_HoraDelDia))]
    public virtual HoraDelDia? HoraDelDiaNavigation { get; set; } = null!;
}