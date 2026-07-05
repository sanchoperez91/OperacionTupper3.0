using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class PlatoIngredientes
{
    public int IdPlato { get; set; }

    public int IdIngrediente { get; set; }

    [ForeignKey(nameof(IdPlato))]
    public virtual Platos PlatosNavigation { get; set; } = null!;

    [ForeignKey(nameof(IdIngrediente))]
    public virtual Ingredientes IngredientesNavigation { get; set; } = null!;
}