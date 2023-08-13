using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        //T will be a category or any other generic model.
        //T will be a category
        //Get All
        IEnumerable<T> GetAll(string? includeProperties = null);
        //Get a single record
        T Get(Expression<Func<T,bool>> filter, string? includeProperties = null);
        //Create a record
        void Add(T entity);
        
        //Delete a record.
        void Remove(T entity);
        //delete a range of records
        void RemoveRange(IEnumerable<T> entity);
    }
}
