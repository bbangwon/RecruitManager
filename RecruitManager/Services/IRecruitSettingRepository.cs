using RecruitManager.Models;

namespace RecruitManager.Services
{
    public interface IRecruitSettingRepository
    {
        RecruitSetting Add(RecruitSetting model);
        List<RecruitSetting>? GetAll();
        RecruitSetting? GetById(int id);
        bool IsRecruitSettings(string boardName, int boardNum);
        void Remove(int id);
        RecruitSetting Update(RecruitSetting model);

        bool IsClosedRecruit(string boardName, int boardNum);
    }
}