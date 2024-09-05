using App_Application.Services.Interfaces;
using App_DAL.Context;
using App_DAL.Interfaces.Composites;
using App_DAL.Repos.Composites;
using App_Domain.Concretes;
using App_Domain.Concretes.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes
{
    public class ServiceLikeUserStory : IServiceLikeUserStory
    {
        private readonly AppDbContext _context;
        private readonly IRepoLikeUserStory _repoLikeUserStory;

        public ServiceLikeUserStory(AppDbContext context)
        {
            _context = context;
            _repoLikeUserStory = new RepoLikeUserStory(context);
        }

        public int Create(LikeUserStory likeUserStory)
        {
            return _repoLikeUserStory.Create(likeUserStory);
        }

        public int Delete(LikeUserStory likeUserStory, bool deleteFromDb)
        {
            return _repoLikeUserStory.Delete(likeUserStory, deleteFromDb);
        }

        public IEnumerable<LikeUserStory> GetAll(Expression<Func<LikeUserStory, bool>> filter)
        {
            return _repoLikeUserStory.GetAll(filter);
        }

        public bool GetAny(Expression<Func<LikeUserStory, bool>> filter)
        {
            return _repoLikeUserStory.GetAny(filter);
        }

        public LikeUserStory GetById(string key1, int key2)
        {
            return _repoLikeUserStory.GetById(key1, key2);
        }

        public int Update(LikeUserStory likeUserStory)
        {
            return _repoLikeUserStory.Update(likeUserStory);
        }

        public bool LikeAStory(int storyId, string userId, out int likeCount)
        {
            LikeUserStory likeUserStory = new LikeUserStory() { StoryId = storyId, UserId = userId };
            int result = 0;
            if (_repoLikeUserStory.GetAny(x => x.StoryId == storyId && x.UserId == userId))
                result = _repoLikeUserStory.Delete(likeUserStory, true);
            else
                result = _repoLikeUserStory.Create(likeUserStory);

            likeCount = _repoLikeUserStory.GetAll(x => x.StoryId == storyId).Count();

            return result > 0 ? true : false;
        }

        public bool IsUserLiked(int storyId, string userId)
        {
            return _repoLikeUserStory.GetAny(x => x.StoryId == storyId && x.UserId == userId);
        }
    }
}
