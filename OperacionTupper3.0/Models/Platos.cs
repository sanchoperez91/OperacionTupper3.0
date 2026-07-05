using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Platos
{
    [Key]
    public int Id_Plato { get; set; }

    public string Nombre_Plato { get; set; } = null!;

    public string? Descripcion_Plato { get; set; }

    [InverseProperty(nameof(PlatoIngredientes.PlatosNavigation))]
    public virtual ICollection<PlatoIngredientes> PlatoIngredientesNavigation { get; set; } = new List<PlatoIngredientes>();
}