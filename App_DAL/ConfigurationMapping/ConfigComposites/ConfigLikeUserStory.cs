using App_Domain.Concretes.Composites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.ConfigurationMapping.ConfigComposites
{
    public class ConfigLikeUserStory : IEntityTypeConfiguration<LikeUserStory>
    {
        public void Configure(EntityTypeBuilder<LikeUserStory> builder)
        {
            builder.HasKey(lus => new {lus.StoryId , lus.UserId });              
        }
    }
}
