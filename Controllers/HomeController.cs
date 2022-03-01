using Microsoft.AspNetCore.Mvc;

namespace ProjetoAgenda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}