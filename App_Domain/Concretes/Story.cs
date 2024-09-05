using App_Domain.Concretes.Composites;
using App_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain.Concretes
{
    public class Story : Base, IBase, IStory
    {
        public string Title { get; set; }
        public string Content { get; set; } 
        public string? ImageUrl { get; set; }
        public int? ViewCount { get; set; } = 0;
        public int? Likes { get; set; } = 0;
        //Navigation Properties
        public virtual ICollection<StoryTopic> StoryTopics { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
