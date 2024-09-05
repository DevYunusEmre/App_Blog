using App_Domain.Concretes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Concretes.VMs
{
    public class HomeStoryVM
    {
        public IList<CreateStoryVM> StoryVMs { get; set; }
        public List<SelectListItem>? SelectForTopicId { get; set; }
        public List<int> SelectedCategoryIds { get; set; }= new List<int>();
        public List<Topic> Topics { get; set; }
    }
}
