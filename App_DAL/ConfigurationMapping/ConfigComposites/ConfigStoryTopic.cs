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
    public class ConfigStoryTopic : IEntityTypeConfiguration<StoryTopic>
    {
        public void Configure(EntityTypeBuilder<StoryTopic> builder)
        {
            builder.HasKey(st => new { st.StoryId, st.TopicId });

            //Relational Properties:
            //StoryTopic => Story
            builder
                .HasOne(st => st.Story)
                .WithMany(s => s.StoryTopics)
                .HasForeignKey(st => st.StoryId);

            //StoryTopic => Topic
            builder
                .HasOne(st => st.Topic)
                .WithMany(t => t.StoryTopics)
                .HasForeignKey(st => st.TopicId);

        }
    }
}
