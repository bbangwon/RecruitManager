using RecruitManager.Data;

namespace RecruitManager.Services
{
    public class RecruitSettingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RecruitSettingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
