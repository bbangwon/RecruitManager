﻿using RecruitManager.Models;

namespace RecruitManager.Services
{
    public interface IRecruitSettingRepository
    {
        RecruitSetting Add(RecruitSetting model);
        List<RecruitSetting>? GetAll();
        RecruitSetting? GetById(int id);
        RecruitSetting Update(RecruitSetting model);
    }
}