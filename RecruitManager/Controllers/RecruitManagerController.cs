using Microsoft.AspNetCore.Mvc;
using RecruitManager.Models;

namespace RecruitManager.Controllers
{
    public class RecruitManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region 모집 추가
        [HttpGet]
        public IActionResult RecruitSettingCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RecruitSettingCreate(RecruitSetting model)
        {
            return View(model);
        }
        #endregion

        public IActionResult RecruitSettingList()
        {
            return View();
        }
    }
}
