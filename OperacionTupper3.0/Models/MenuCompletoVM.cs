namespace OperacionTupper3._0.Models
{
    public class MenuCompletoVM
    {
        public int Cantidad_Dias { get; set; }
        public int Cantidad_Comidas { get; set; }
        public int Cantidad_Cenas { get; set; }

        public DateTime Fecha_Creacion { get; set; }
        public List<Menu> Menu { get; set; } = new List<Menu>();
        public List<DiaMenu> DiaMenu { get; set; } = new List<DiaMenu>();
        public List<Plato_DiaMenu> Plato_DiaMenu { get; set; } = new List<Plato_DiaMenu>();

        public List<HoraDelDia> HoraDelDia { get; set; } = new List<HoraDelDia>();


    }
}
