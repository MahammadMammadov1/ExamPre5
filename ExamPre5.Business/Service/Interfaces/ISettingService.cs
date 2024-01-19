using ExamPre5.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.Service.Interfaces
{
    public interface ISettingService 
    {
        Task UpdateAsync(Setting setting);
        Task<Setting> GetByIdAsync(int id);
        Task<List<Setting>> GetAllAsync();
    }
}
