using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Universe.DataAccess
{
    public interface IRepository<TEntity>
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetTest(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
    }
}
