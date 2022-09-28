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

                return RedirectToAction(nameof(RecruitSettingList));
            }

            return View(model);
        }
        #endregion

        /// <summary>
        /// 모집 리스트
        /// </summary>
        /// <returns></returns>
        public IActionResult RecruitSettingList()
        {
            var recruits = repository.GetAll();

            return View(recruits);
        }

        /// <summary>
        /// 모집 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RecruitSettingDetail(int id)
        {
            ViewData["Id"] = id;

            var recruit = repository.GetById(id);

            return View(recruit);
        }

        /// <summary>
        /// 상세 데이터 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RecruitSettingEditOrDelete(RecruitSetting model, string action)
        {
            if(action == "update")
            {
                if (ModelState.IsValid)
                {
                    this.repository.Update(model);
                }

                return RedirectToAction(nameof(RecruitSettingDetail), new { model.Id });
            }
            else
            {
                if(ModelState.IsValid)
                {
                    this.repository.Remove(model.Id);
                }

                return RedirectToAction(nameof(RecruitSettingList));
            }
        }

        /// <summary>
        /// 쿼리 스트링 받기 [FromQuery] 특성
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="boardNum"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BoardView(
            [FromQuery]string boardName, [FromQuery]int boardNum)
        {
            ViewData["BoardName"] = boardName;
            ViewData["BoardNum"] = HttpContext.Request.Query["BoardNum"];

            ViewBag.IsRecruitSettings 
                = repository.IsRecruitSettings(boardName, boardNum);

            ViewBag.IsClosedRecruit 
                = repository.IsClosedRecruit(boardName, boardNum);

            return View();
        }
    }
}
