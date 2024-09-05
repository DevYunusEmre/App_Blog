using App_Domain.Concretes.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Services.Interfaces
{
    public interface IServiceLikeUserStory
    {
        public int Create(LikeUserStory likeUserStory);
        public int Update(LikeUserStory likeUserStory);
        public int Delete(LikeUserStory likeUserStory, bool deleteFromDb);
        public LikeUserStory GetById(string key1, int key2);
        public bool GetAny(Expression<Func<LikeUserStory, bool>> filter);
        public IEnumerable<LikeUserStory> GetAll(Expression<Func<LikeUserStory, bool>> filter);
        public bool LikeAStory(int storyId, string userId, out int likeCount);
        public bool IsUserLiked(int storyId, string userId);
    }
}
