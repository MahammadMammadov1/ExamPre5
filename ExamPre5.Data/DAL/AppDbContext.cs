using ExamPre5.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContext) : base(dbContext) { }
        
        public DbSet<Team> Teams { get; set; }
    }
}
