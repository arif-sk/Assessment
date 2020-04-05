using Assessment.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetAsync(int id);

        Task<IList<T>> GetAllAsync();

        Task<IList<T>> FilterAsync(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        T Get(int id);

        List<T> GetAll();

        List<T> Filter(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
        DbSet<T> GetQueryAbleDbSet();
        AssessmentContext GetDbContex();


    }
}
