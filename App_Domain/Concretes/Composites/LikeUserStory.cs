using App_Domain.Interfaces;
using App_Domain.Interfaces.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Domain.Concretes.Composites
{
    /// <summary>
    /// her bir kullanıcı her bir hikayeyi, sadece ve sadece bir kez beğenebilir.
    /// bunu sağlamak için: 
    /// bir kullanıcı bir hikayeyi beğenirse ona ait bir composite key veri oluşturulur
    /// eğer bu veri var ise kullanıcı bunu beğenmiş demektir 
    /// eğer bu veri yok ise kullanıcı bunu beğenmemiş demektir.
    /// </summary>
    public class LikeUserStory : Base, IBase,ILikeUserStory
    {
        public string UserId { get; set; }
        public int StoryId { get; set; }

    }
}
