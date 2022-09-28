using RecruitManager.Data;
using RecruitManager.Models;

namespace RecruitManager.Services
{
    public class RecruitRegistrationRepository : IRecruitRegistrationRepository
    {
        private readonly ApplicationDbContext context;

        public RecruitRegistrationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public RecruitRegistration Add(RecruitRegistration model)
        {
            throw new NotImplementedException();
        }

        public List<RecruitRegistration>? GetAll()
        {
            return this.context.RecruitRegistrations?
                .OrderByDescending(rr => rr.Id)
                .ToList();
        }

        public List<RecruitRegistration>? GetAll(string boardName, int boardNum)
        {
            return this.context.RecruitRegistrations?
                .Where(rr => rr.BoardName == boardName && rr.BoardNum == boardNum)
                .OrderByDescending(rr => rr.Id)
                .ToList();
        }

        public List<RecruitRegistration>? GetAllByRecruitSettingId(int recruitSettingId)
        {
            return this.context.RecruitRegistrations?
                .Where(rr => rr.RecruitSettingId == recruitSettingId)
                .OrderByDescending(rr => rr.Id)
                .ToList();
        }

        public RecruitRegistration? GetById(int id)
        {
            return this.context.RecruitRegistrations?
                .SingleOrDefault(rr => rr.Id == id);
        }

        public bool IsRecruitSettings(string boardName, int boardNum)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                this.context.Remove(entity);
                this.context.SaveChanges();
            }            
        }

        public RecruitRegistration Update(RecruitRegistration model)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecruitRegistration(string boardName, int boardNum, string username)
        {
            var entities = this.context.RecruitRegistrations?
                .Where(rr => rr.BoardName == boardName && rr.BoardNum == boardNum && rr.Username == username);

            if(entities != null)
            {
                this.context.RemoveRange(entities);
                this.context.SaveChanges();
            }              
        }
    }
}
