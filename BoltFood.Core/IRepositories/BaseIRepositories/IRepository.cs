using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.IRepositories.BaseIRepositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(Func<T,bool> expression);


    }
}
