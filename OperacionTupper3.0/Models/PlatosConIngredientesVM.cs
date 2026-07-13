using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionTupper3._0.Models;

public partial class PlatosConIngredientesVM
{
    public Platos Plato { get; set; } = new Platos();

    public List<int> IngredientesSeleccionados { get; set; } = new List<int>();
   
    public List<Ingredientes> TodosLosIngredientes { get; set; } = new List<Ingredientes>();
}