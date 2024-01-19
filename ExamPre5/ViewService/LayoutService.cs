using ExamPre5.Business.Service.Interfaces;
using ExamPre5.Core.Models;

namespace ExamPre5.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<List<Setting>> GetSettings()
        {
            return await _settingService.GetAllAsync();
        }
    }
}
