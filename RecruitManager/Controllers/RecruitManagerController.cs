using Microsoft.AspNetCore.Mvc;
using RecruitManager.Models;
using RecruitManager.Services;

namespace RecruitManager.Controllers
{
    public class RecruitManagerController : Controller
    {
        private readonly IRecruitSettingRepository repository;

        public RecruitManagerController(IRecruitSettingRepository repository)
        {
            this.repository = repository;
        }

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
            if(ModelState.IsValid)
            {
                this.repository.Add(model);

                return View(nameof(RecruitSettingList));
            }

            return View(model);
        }
        #endregion

        public IActionResult RecruitSettingList()
        {
            var recruits = repository.GetAll();

            return View(recruits);
        }
    }
}
