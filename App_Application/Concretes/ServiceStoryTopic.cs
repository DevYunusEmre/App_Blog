using App_Application.Services.Interfaces;
using App_DAL.Context;
using App_DAL.Interfaces.Composites;
using App_DAL.Repos.Composites;
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
    public class ServiceStoryTopic : IServiceStoryTopic
    {
        private readonly AppDbContext _context;
        private readonly IRepoStoryTopic repoStoryTopic;

        public ServiceStoryTopic(AppDbContext context)
        {
            _context = context;
            repoStoryTopic = new RepoStoryTopic(context);
        }

        public int Create(StoryTopic storyTopic)
        {
            return repoStoryTopic.Create(storyTopic);
        }

        public int Delete(StoryTopic storyTopic, bool deleteFromDb)
        {
            return repoStoryTopic.Delete(storyTopic, true);
        }

        public IEnumerable<StoryTopic> GetAllFiltered(Expression<Func<StoryTopic, bool>>? filter)
        {
            return repoStoryTopic.GetAllFiltered(filter);
        }

        public bool GetAny(Expression<Func<StoryTopic, bool>> filter)
        {
            return repoStoryTopic.GetAny(filter);
        }

        public StoryTopic GetById(int id)
        {
            return repoStoryTopic.GetById(id);
        }

        public StoryTopic GetFiltered(Expression<Func<StoryTopic, bool>> filter)
        {
            return repoStoryTopic.GetFiltered(filter);
        }

        public int Update(StoryTopic storyTopic)
        {
            return repoStoryTopic.Update(storyTopic);
        }
    }
}









