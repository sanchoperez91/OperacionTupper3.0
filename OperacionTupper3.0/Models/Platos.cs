using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Platos
{
    [Key]
    public int IdPlato { get; set; }

    public string NombrePlato { get; set; } = null!;

    public string? Descripcion { get; set; }

    [InverseProperty(nameof(PlatoIngredientes.PlatosNavigation))]
    public virtual ICollection<PlatoIngredientes> PlatoIngredientesNavigation { get; set; } = new List<PlatoIngredientes>();
}