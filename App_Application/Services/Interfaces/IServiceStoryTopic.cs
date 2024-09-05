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
    public interface IServiceStoryTopic
    {
        public int Create(StoryTopic storyTopic);
        public int Update(StoryTopic storyTopic); 
        public int Delete(StoryTopic storyTopic, bool deleteFromDb);
        public StoryTopic GetById(int id);
        public bool GetAny(Expression<Func<StoryTopic, bool>> filter);
        public StoryTopic GetFiltered(Expression<Func<StoryTopic, bool>> filter);
        public IEnumerable<StoryTopic> GetAllFiltered
            (
                Expression<Func<StoryTopic, bool>>? filter  
            );
    }
}
