using Microsoft.AspNetCore.Mvc;
namespace UsandoViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}