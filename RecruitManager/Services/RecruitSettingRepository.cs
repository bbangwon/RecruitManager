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

        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RecruitSetting? GetById(int id)
        {
            return this.dbContext.RecruitSettings?
                .SingleOrDefault(rs => rs.Id == id);
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RecruitSetting Update(RecruitSetting model)
        {
            this.dbContext.RecruitSettings?.Update(model);
            this.dbContext.SaveChanges();

            return model;
        }
    }
}
