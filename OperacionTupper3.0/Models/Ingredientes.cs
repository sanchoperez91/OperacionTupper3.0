using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Ingredientes
{
    [Key]
    public int IdIngrediente { get; set; }
    public string NombreIngrediente { get; set; } = null!;
    public string TipoIngrediente { get; set; } = null!;

    [InverseProperty(nameof(PlatoIngredientes.IngredientesNavigation))]
    public virtual ICollection<PlatoIngredientes> PlatoIngredientesNavigation { get; set; } = new List<PlatoIngredientes>();
}
