using App_Application.Services.Interfaces;
using App_DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes
{
    public class Units
    {
        private readonly AppDbContext _context;
        public readonly IServiceStory _story;
        public readonly IServiceTopic _topic;
        public readonly IServiceOperations _operations;
        public readonly IServiceUserTopic _userTopic;
        public readonly IServiceStoryTopic _storyTopic;
        public readonly IServiceLikeUserStory _likeUserStory;
        public readonly IServiceUser _user;
        public Units(AppDbContext context)
        {
            _context = context;
            _story = new ServiceStory(context);
            _topic = new ServiceTopic(context);
            _operations = new ServiceOperations();
            _userTopic = new ServiceUserTopic(context);
            _storyTopic = new ServiceStoryTopic(context);
            _likeUserStory = new ServiceLikeUserStory(context);
            _user = new ServiceUser();
        }
    }
}
