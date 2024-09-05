using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using System.Linq.Expressions;



namespace App_Application.Services.Interfaces
{
    public interface IServiceStory
    {
        public int Create(Story story);
        public int Update(Story story);
        public int Delete(Story story);
        public Story GetById(int id);
        public bool GetAny(Expression<Func<Story, bool>> filter=null);
        public IEnumerable<CreateStoryVM> GetAllAsStoryVM(User currentUser,Units units);
        public Story GetFiltered(Expression<Func<Story, bool>> filter=null);
        public IEnumerable<Story> GetAllFiltered
            (
                Expression<Func<Story, bool>>? filter = null
            );
        public void AddStoryViewCount(Story story);
        public ReadStoryVM GetSelectedStoryInfo(User selectedStoryUser, Story selectedStory, IServiceLikeUserStory serviceLikeUserStory, User currentUser);
        public bool UpdateStoryLikeCount(int storyId, int likeCount);

        public IEnumerable<CreateStoryVM> Search(string search, List<int> selectedTopics, User currentUser, Units _units);
    }
}
