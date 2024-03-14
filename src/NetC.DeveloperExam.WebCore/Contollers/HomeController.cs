using Microsoft.AspNetCore.Mvc;

namespace NetC.DeveloperExam.WebCore.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
