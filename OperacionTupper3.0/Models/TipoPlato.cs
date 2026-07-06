using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class TipoPlato
{
    [Key]
    public int Id_TipoPlato { get; set; }
    public string Nombre_TipoPlato { get; set; } = null!;
 

    [InverseProperty(nameof(Platos.TipoPlatoNavigation))]
    public virtual ICollection<Platos> PlatosNavigation { get; set; } = new List<Platos>();
}
