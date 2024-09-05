using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Services.Interfaces
{
    public interface IServiceUserTopic
    {
        public int Create(UserTopic userTopic);
        public int Update(UserTopic userTopic);
        public int Delete(UserTopic userTopic);
        public int Delete(UserTopic userTopic,bool deleteFromDb); 
        public UserTopic GetById(string key1,int key2);
        public bool GetAny(Expression<Func<UserTopic, bool>> filter);
        public UserTopic GetFiltered(Expression<Func<UserTopic, bool>> filter);
        public IEnumerable<UserTopic> GetAllFiltered
            (
                Expression<Func<UserTopic, bool>>? filter  
            );
    }
}
