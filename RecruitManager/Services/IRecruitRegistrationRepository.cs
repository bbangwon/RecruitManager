using RecruitManager.Models;

namespace RecruitManager.Services
{
    public interface IRecruitRegistrationRepository
    {
        RecruitRegistration Add(RecruitRegistration model);
        List<RecruitRegistration>? GetAll();
        RecruitRegistration? GetById(int id);
        bool IsRecruitSettings(string boardName, int boardNum);
        void Remove(int id);
        RecruitRegistration Update(RecruitRegistration model);
        List<RecruitRegistration>? GetAll(string boardName, int boardNum);
        List<RecruitRegistration>? GetAllByRecruitSettingId(int recruitSettingId);
        void RemoveRecruitRegistration(string boardName, int boardNum, string username);
    }
}