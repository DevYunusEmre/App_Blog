using App_Application.Concretes;
using App_Application.Concretes.VMs;
using App_Domain.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Application.Services.Interfaces
{
    public interface IServiceUser
    {
        public OthersProfileVM GetOtherProfileVM(User otherUser, Units _units);
        
    }
}
