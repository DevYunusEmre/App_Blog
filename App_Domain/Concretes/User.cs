using App_Domain.Concretes.Composites;
using App_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain.Concretes
{
    public class User : IdentityUser
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Navigation Property
        public virtual ICollection<Story>? Stories { get; set; }
        public virtual ICollection<UserTopic> UserTopics { get; set; }

    }
}
