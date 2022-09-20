using Microsoft.AspNetCore.Mvc;

namespace RecruitManager.Controllers
{
    public class RecruitManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
