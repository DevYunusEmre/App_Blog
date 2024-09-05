using App_DAL.Context;
using App_DAL.Interfaces.Composites;
using App_Domain.Concretes.Composites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.Repos.Composites
{
    public class RepoUserTopic : RepoBase<UserTopic>, IRepoUserTopic
    {
        public RepoUserTopic(AppDbContext context) : base(context)
        {
        }
    }
}
