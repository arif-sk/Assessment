using Assessment.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected AssessmentContext _entities;
        protected readonly DbSet<T> _dbset;

        protected GenericRepository(AssessmentContext context)
        {
            _entities = context as AssessmentContext;
            _dbset = _entities.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            _dbset.Add(entity);
            await _entities.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _dbset.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                await _entities.SaveChangesAsync();
            }
        }

        public async Task<IList<T>> FilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbset.Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbset.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Attach(entity);
            _entities.Entry(entity).State = EntityState.Modified;
            await _entities.SaveChangesAsync();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbset.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                _entities.SaveChanges();
            }
        }

        public List<T> Filter(Expression<Func<T, bool>> filter)
        {
            return _dbset.Where(filter).ToList();
        }

        public T Get(int id)
        {
            return _dbset.FirstOrDefault(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public DbSet<T> GetQueryAbleDbSet()
        {
            return _dbset;
        }

        public AssessmentContext GetDbContex()
        {
            return _entities;

            //using (var command = _entities.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = "GetData";
            //    command.CommandType = CommandType.StoredProcedure;
            //    _entities.Database.OpenConnection();
            //    using (var result = command.ExecuteReader())
            //    {
            //        result.
            //    }
            //}
            //_entities.Database.ExecuteSqlCommand
            //DbSet<TEntity>.FromSql()
            //throw new NotImplementedException();
        }
    }
}
