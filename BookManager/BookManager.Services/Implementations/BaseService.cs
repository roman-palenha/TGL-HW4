using BookManager.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Services.Implementations
{
    public class BaseService<T> where T : class
    {
		private readonly BookDbContext _dbContext;

		public BaseService(BookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> SaveChanges()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<T> Get(Guid id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetRange()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task Insert(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(T entity)
		{
			_dbContext.Set<T>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}
		
		public async Task<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			var result = await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
			return result;
		}
	}
}
