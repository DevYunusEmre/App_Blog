using App_Application.Concretes.VMs;
using App_Application.Services.Interfaces;
using App_Domain.Concretes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes
{
    public class ServiceUser : IServiceUser
    { 
        public OthersProfileVM GetOtherProfileVM(User otherUser,Units _units)
        { 
            IList<CreateStoryVM> storyVMs = new List<CreateStoryVM>();
            var stories = _units._story.GetAllFiltered(x => x.UserId == otherUser.Id);
            foreach (var item in stories)
            {
                storyVMs.Add(new CreateStoryVM()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    UserName = item.User.Email,
                });
            }

            OthersProfileVM othersProfileVM = new OthersProfileVM()
            {
                Email = otherUser.Email,
                Description = otherUser.Description,
                FirstName = otherUser.FirstName,
                ImageUrl = otherUser.ImageUrl,
                LastName = otherUser.LastName,
                StoryVMs = storyVMs
            };
            return othersProfileVM;
        }
    }
}
