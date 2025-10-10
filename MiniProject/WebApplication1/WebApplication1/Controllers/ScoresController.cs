using ConsoleApp2;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ScoresController : Controller
    {

        private DatabaseService _dbService;

        public ScoresController(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
