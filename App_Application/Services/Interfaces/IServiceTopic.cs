 
using App_Domain.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Services.Interfaces
{
    public interface IServiceTopic
    {
        public int Create(Topic topic);
        public int Update(Topic topic);
        public int Delete(Topic topic);
        public Topic GetById(int id); 
        public bool GetAny(Expression<Func<Topic, bool>> filter);
        public IEnumerable<Topic> GetAll(Expression<Func<Topic, bool>>? filter=null);
        public Topic GetFiltered(Expression<Func<Topic, bool>> filter);
        public IEnumerable<Topic> GetAllFiltered
            (
                Expression<Func<Topic, bool>>? filter  
            );
        public IList<Topic> GetMainTopics();
        public IList<Topic> GetParentTopics();
        public IList<Topic> GetSubTopics();



    }
   
}
