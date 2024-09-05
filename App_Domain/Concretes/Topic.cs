using App_Domain.Concretes.Composites;
using App_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain.Concretes
{
    public class Topic : Base, IBase, ITopics
    { 
        public string TopicName { get; set; }
        public string? SubTopicName { get; set; }
        //Navigarion Properties
        public virtual ICollection<StoryTopic> StoryTopics { get; set; }
        public virtual ICollection<UserTopic> UserTopics { get; set; }

    }
}
