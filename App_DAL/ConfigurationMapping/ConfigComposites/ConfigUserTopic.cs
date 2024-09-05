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
    public class ConfigUserTopic : IEntityTypeConfiguration<UserTopic>
    {
        public void Configure(EntityTypeBuilder<UserTopic> builder)
        {
            builder.HasKey(ut => new { ut.UserId, ut.TopicId });

            //Relational Properties:
            //UserTopic => User
            builder
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTopics)
                .HasForeignKey(ut => ut.UserId);

            //UserTopic => Topic
            builder
                .HasOne(ut => ut.Topic)
                .WithMany(t => t.UserTopics)
                .HasForeignKey(ut => ut.TopicId);

        }
    }
}
