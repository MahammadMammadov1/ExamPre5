using ExamPre5.Core.Repository.Interfaces;
using ExamPre5.Data.DAL;
using ExamPre5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Data.Repository.Implementations
{

    public class GenericRepository<TEentity> : IGenericRepository<TEentity> where TEentity : BaseEntity, new()
    {
        private readonly AppDbContext _appDb;

        public GenericRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public DbSet<TEentity> Table => _appDb.Set<TEentity>();

        public async Task<int> CommitAsync()
        {
            return await _appDb.SaveChangesAsync();
        }

        public async Task CreateAsync(TEentity entity)
        {
            await _appDb.AddAsync(entity);
        }

        public void Delete(TEentity entity)
        {
             _appDb.Remove(entity);

        }

        public async Task<List<TEentity>> GetAllAsync(Expression<Func<TEentity, bool>>? expression = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEentity> GetByIdAsync(Expression<Func<TEentity, bool>>? expression = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        private IQueryable<TEentity> GetQuery(string[] includes)
        {
            var query  = Table.AsQueryable();
            if(includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }
    }
}
