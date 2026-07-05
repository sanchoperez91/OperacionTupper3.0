using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class Ingredientes
{
    [Key]
    public int Id_Ingrediente { get; set; }
    public string Nombre_Ingrediente { get; set; } = null!;
    public int Id_TipoIngrediente { get; set; } 

    [InverseProperty(nameof(PlatoIngredientes.IngredientesNavigation))]
    public virtual ICollection<PlatoIngredientes> PlatoIngredientesNavigation { get; set; } = new List<PlatoIngredientes>();

    [ForeignKey(nameof(Id_TipoIngrediente))]
    public virtual TipoIngrediente? TipoIngredienteNavigation { get; set; } = null!;
}
