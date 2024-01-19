using ExamPre5.Business.CustomExceptions.Setting;
using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;
using ExamPre5.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.Service.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<List<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return await _settingRepository.GetByIdAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Setting setting)
        {
            var exist = await _settingRepository.GetByIdAsync(x=>x.Id== setting.Id);
            if (exist == null) throw new SettingNullException();

           exist.Value = setting.Value;
           exist.CreateDate= setting.CreateDate;
           exist.UpdateDate= setting.UpdateDate;
           await _settingRepository.CommitAsync();
        }
    }
}
