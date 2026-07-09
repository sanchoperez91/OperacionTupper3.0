using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class HoraDelDia
{
    [Key]
    public int Id_HoraDelDia { get; set; }

    public string Nombre_HoraDelDia { get; set; } = null!;


    [InverseProperty(nameof(Platos.HoraDelDiaNavigation))]
    public virtual ICollection<Platos> PlatosNavigation { get; set; } = new List<Platos>();
}