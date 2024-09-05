using App_DAL.Context;
using App_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.Interfaces
{
    public interface IRepoBase<T> where T : IBase
    {
        public int Create(T entity);
        public int Update(T entity);
        public int Delete(T entity);
        public int Delete(T entity, bool removeFromDb);
        public T GetById(int id);
        public T GetById(string key1, int key2);
        public bool GetAny(Expression<Func<T, bool>> filter);
        public T GetFiltered(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filter=null);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null);



    }
}
