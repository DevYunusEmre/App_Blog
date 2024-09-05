using App_DAL.Context;
using App_DAL.Interfaces;
using App_Domain.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.Repos
{
    public class RepoTopic : RepoBase<Topic>, IRepoTopic
    {
        public RepoTopic(AppDbContext context) : base(context)
        {
        }
    }
}
