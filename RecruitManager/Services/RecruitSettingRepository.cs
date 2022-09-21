using RecruitManager.Data;
using RecruitManager.Models;

namespace RecruitManager.Services
{
    public class RecruitSettingRepository : IRecruitSettingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RecruitSettingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RecruitSetting>? GetAll()
        {
            return this.dbContext.RecruitSettings?
                .OrderByDescending(rs => rs.Id)
                .ToList();
        }

        public RecruitSetting Add(RecruitSetting model)
        {
            var newModel = this.dbContext.Add(model);
            this.dbContext.SaveChanges();

            model.Id = newModel.Entity.Id;
            model.CreationDate = newModel.Entity.CreationDate;

            return model;
        }
    }
}
