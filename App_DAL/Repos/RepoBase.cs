using App_DAL.Context;
using App_DAL.Interfaces;
using App_Domain.Concretes;
using App_Domain.Enums;
using App_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.Repos
{
    public class RepoBase<T> : IRepoBase<T> where T : Base, IBase
    {
        //Fields
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        //Constructor
        public RepoBase(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Create(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.Status = Status.Dropped;
            entity.DropDate = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Delete(T entity, bool removeFromDb)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return _dbSet.ToList();
            else
                return _dbSet.Where(filter);
        }

        public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return _dbSet.ToList();
            else
                return _dbSet.Where(filter).ToList();
        }

        public bool GetAny(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(string key1, int key2)
        {
            return _dbSet.Find(key1, key2);
        }

        public T GetFiltered(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public int Update(T entity)
        {
            _dbSet.Update(entity);
            return _context.SaveChanges();
        }
    }
}
