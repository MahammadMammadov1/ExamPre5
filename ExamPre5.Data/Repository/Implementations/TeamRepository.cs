using ExamPre5.Core.Models;
using ExamPre5.Core.Repository.Interfaces;
using ExamPre5.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Data.Repository.Implementations
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
