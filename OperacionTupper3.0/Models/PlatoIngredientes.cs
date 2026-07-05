using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class PlatoIngredientes
{
    public int Id_Plato { get; set; }

    public int Id_Ingrediente { get; set; }

    [ForeignKey(nameof(Id_Plato))]
    public virtual Platos PlatosNavigation { get; set; } = null!;

    [ForeignKey(nameof(Id_Ingrediente))]
    public virtual Ingredientes IngredientesNavigation { get; set; } = null!;
}