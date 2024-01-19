using ExamPre5.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.Service.Interfaces
{
    public interface ITeamService
    {
        Task CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
        Task<Team> GetByIdAsync(int id);
        Task<List<Team>> GetAllAsync();
    }
}
