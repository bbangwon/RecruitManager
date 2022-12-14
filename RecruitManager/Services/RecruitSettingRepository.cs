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

        public void Remove(int id)
        {
            var recruitSetting = GetById(id);

            if(recruitSetting != null)
            {
                this.dbContext.RecruitSettings?.Remove(recruitSetting);
                this.dbContext.SaveChanges();
            }            
        }

        /// <summary>
        /// 특정 게시판에 대한 모집 관련 세부 설정이 되었는지 안되었는지 확인
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="boardNum"></param>
        /// <returns></returns>
        public bool IsRecruitSettings(string boardName, int boardNum)
        {
            return this.dbContext.RecruitSettings?
                .Any(rs => rs.BoardName == boardName && rs.BoardNum == boardNum)
                ?? false;
        }

        public bool IsClosedRecruit(string boardName, int boardNum)
        {
            var entity = this.dbContext.RecruitSettings?
                .SingleOrDefault(rs => rs.BoardName == boardName && rs.BoardNum == boardNum);

            var cnt = entity?.MaxCount ?? 0;
            return cnt == 0;
        }

        /// <summary>
        /// 모집 마감 여부 확인
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="boardNum"></param>
        /// <returns></returns>
        public bool IsFinishedRecruit(string boardName, int boardNum)
        {
            // 최대 모집 카운트
            var entity = this.dbContext.RecruitSettings?
                .SingleOrDefault(rs => rs.BoardName == boardName && rs.BoardNum == boardNum);

            // 모집 등록 카운트
            var cnt = this.dbContext.RecruitRegistrations?
                .Count(rs => rs.BoardName == boardName && rs.BoardNum == boardNum);

            if (entity != null)
            {
                // 모집에 등록된 숫자가 같거나, 더 많으면 마감된 모집으로 봄
                if (entity.MaxCount != 0 && entity.MaxCount <= cnt)
                {
                    return true;
                }
            }              
            return false;
        }
    }
}
