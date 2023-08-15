using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StudentTeacherContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(StudentTeacherContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool trackChanges = false, List<string> includes = default)
        {
            IQueryable<T> query = _dbSet;
            if (includes is not null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }



            return !trackChanges ? await query.AsNoTracking().FirstOrDefaultAsync(expression)
                : await query.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = default, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = default, bool trackChanges = false, List<string> includes = default)
        {
            IQueryable<T> query = _dbSet;

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (includes is not null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            return !trackChanges ? query.AsNoTracking() : query;
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> expression)
        {
            var exist = _context.Set<T>().Where(expression);
            return await exist.AnyAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
