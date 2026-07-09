using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class TipoIngrediente
{
    [Key]
    public int Id_TipoIngrediente { get; set; }
    public string Nombre_TipoIngrediente { get; set; } = null!;
 

    [InverseProperty(nameof(Ingredientes.TipoIngredienteNavigation))]
    public virtual ICollection<Ingredientes> IngredientesNavigation { get; set; } = new List<Ingredientes>();
}
