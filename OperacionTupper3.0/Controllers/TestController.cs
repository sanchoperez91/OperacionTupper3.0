using Microsoft.AspNetCore.Mvc;
using OperacionTupper3._0.Data;
using System.Linq;

namespace OperacionTupper3._0.Controllers
{
    public class TestController : Controller
    {
        private readonly MiDbContext _context;

        public TestController(MiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Content("Conexión OK");
        }
    }
}