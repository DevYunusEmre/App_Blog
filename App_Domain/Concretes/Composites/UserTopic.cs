using App_Domain.Interfaces;
using App_Domain.Interfaces.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain.Concretes.Composites
{
    public class UserTopic : Base, IBase, IUserTopic
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }


    }
}
