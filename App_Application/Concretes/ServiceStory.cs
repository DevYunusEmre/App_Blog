using App_Application.Concretes.VMs;
using App_Application.Services.Interfaces;
using App_DAL.Context;
using App_DAL.Interfaces;
using App_DAL.Repos;
using App_Domain.Concretes;
using App_Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes
{
    public class ServiceStory : IServiceStory
    {
        private readonly AppDbContext _context;
        private readonly IRepoStory repoStory;
        private readonly UserManager<User> _userManager;
        public ServiceStory(AppDbContext context)
        {
            _context = context;
            repoStory = new RepoStory(_context);
        }

        public int Create(Story story)
        {
            return repoStory.Create(story);
        }

        public int Delete(Story story)
        {
            return repoStory.Delete(story);
        }

        public IEnumerable<CreateStoryVM> GetAllAsStoryVM(User currentUser, Units units)
        {
            IEnumerable<Story> allStories = repoStory.GetAllFiltered().ToList();
            IList<CreateStoryVM> allStoryVMs = new List<CreateStoryVM>();

            foreach (Story item in allStories)
            {
                allStoryVMs.Add(new CreateStoryVM()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    UserName = item.User.UserName,
                    Title = item.Title,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    ViewCount = item.ViewCount,
                    Likes = item.Likes,
                    IsUserLiked = units._likeUserStory.GetAny(x => x.UserId == currentUser.Id && x.StoryId == item.Id),
                    CurrentUserId = currentUser.Id,
                    UserImageUrl = currentUser.ImageUrl
                });
            }
            return allStoryVMs;
        }

        public IEnumerable<Story> GetAllFiltered(Expression<Func<Story, bool>>? filter = null)
        {
            return repoStory.GetAllFiltered(filter);
        }

        public bool GetAny(Expression<Func<Story, bool>> filter)
        {
            return repoStory.GetAny(filter);
        }

        public Story GetById(int id)
        {
            return repoStory.GetById(id);
        }

        public Story GetFiltered(Expression<Func<Story, bool>> filter)
        {
            return repoStory.GetFiltered(filter);
        }

        public int Update(Story story)
        {
            return repoStory.Update(story);
        }

        /// <summary>
        /// Story görüntülenmesini 1 arttırır
        /// </summary>
        /// <param name="story"></param>
        public void AddStoryViewCount(Story story)
        {
            story.ViewCount++;
            repoStory.Update(story);
        }

        /// <summary>
        /// Bu servis seçili story ve yazarının bilgilerini VM olarak getirir. 
        /// </summary>
        /// <param name="selectedStoryUser"></param>
        /// <param name="selectedStory"></param>
        /// <returns></returns>
        public ReadStoryVM GetSelectedStoryInfo(User selectedStoryUser, Story selectedStory, IServiceLikeUserStory serviceLikeUserStory, User currentUser)
        {
            ReadStoryVM readStoryVM = new ReadStoryVM()
            {
                Id = selectedStory.Id,
                Title = selectedStory.Title,
                Content = selectedStory.Content,
                ImageUrl = selectedStory.ImageUrl,
                UserImageUrl = selectedStoryUser.ImageUrl,
                UserId = selectedStory.UserId,
                UserName = selectedStory.User.UserName,
                Likes = selectedStory.Likes,
                ViewCount = selectedStory.ViewCount,
                IsUserLiked = serviceLikeUserStory.GetAny(x => x.UserId == currentUser.Id && x.StoryId == selectedStory.Id),
                CurrentUserId = currentUser.Id,
                CreatedDate = selectedStory.CreateDate
            };
            return readStoryVM;
        }

        public bool UpdateStoryLikeCount(int storyId, int likeCount)
        {
            Story story = repoStory.GetById(storyId);
            story.Likes = likeCount;

            if (repoStory.Update(story) > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<CreateStoryVM> Search(string search, List<int> selectedTopics, User currentUser, Units _units)
        {
            IList<CreateStoryVM> storyVMs = new List<CreateStoryVM>();

            List<Story> stories = new List<Story>();
            List<int> selectedTopicStoryIds = new List<int>();

            //seçilen kategorilerdeki storylerin Idlerini selectedTopicStoryIds ekler
            foreach (int topicId in selectedTopics)
            {
                foreach (var item in _units._storyTopic.GetAllFiltered(x => x.TopicId == topicId))
                {
                    selectedTopicStoryIds.Add(item.StoryId);
                };
            }
            foreach (int storyId in selectedTopicStoryIds)
            {
                stories.AddRange(_units._story.GetAllFiltered(x =>
                x.Title.Contains(search) ||
                x.Content.Contains(search) &&
                x.Status == Status.Created &&
                x.Id == storyId
                ).ToList());
            }
            foreach (var item in stories)
            {
                storyVMs.Add(new CreateStoryVM()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    UserName = item.User.Email,
                    CreatedDate = item.CreateDate,
                    ViewCount = item.ViewCount,
                    Likes = item.Likes,
                    UserId = item.UserId,
                    IsUserLiked = _units._likeUserStory.GetAny(x => x.UserId == currentUser.Id && x.StoryId == item.Id)
                });
            }
            return storyVMs;
        }
    }
}
