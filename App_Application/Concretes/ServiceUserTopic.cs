using App_Application.Services.Interfaces;
using App_DAL.Context;
using App_DAL.Interfaces.Composites;
using App_DAL.Repos.Composites;
using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes
{
    public class ServiceUserTopic : IServiceUserTopic
    {
        private readonly AppDbContext _context;
        private readonly IRepoUserTopic repoUserTopic;

        public ServiceUserTopic(AppDbContext context)
        {
            _context = context;
            repoUserTopic = new RepoUserTopic(context);
        }

        public int Create(UserTopic userTopic)
        {
            return repoUserTopic.Create(userTopic);
        }

        public int Delete(UserTopic userTopic)
        {
            return repoUserTopic.Delete(userTopic);
        }

        public int Delete(UserTopic userTopic, bool deleteFromDb)
        {
            return repoUserTopic.Delete(userTopic, deleteFromDb);
        }

        public IEnumerable<UserTopic> GetAllFiltered(Expression<Func<UserTopic, bool>>? filter)
        {
            return repoUserTopic.GetAllFiltered(filter);
        }

        public bool GetAny(Expression<Func<UserTopic, bool>> filter)
        {
            return repoUserTopic.GetAny(filter);
        }

        public UserTopic GetById(string key1, int key2)
        {
            return repoUserTopic.GetById(key1, key2);
        }

        public UserTopic GetFiltered(Expression<Func<UserTopic, bool>> filter)
        {
            return repoUserTopic.GetFiltered(filter);
        }

        public int Update(UserTopic userTopic)
        {
            return repoUserTopic.Update(userTopic);
        }


    }
}
