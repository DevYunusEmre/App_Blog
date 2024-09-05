using App_Domain.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.ConfigurationMapping
{
    public class ConfigStory : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(x=>x.Title)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.Content)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("nvarchar(10)");

            builder.Property(x => x.CreateDate)
                .IsRequired(true)
                .HasColumnType("date");

            builder.Property(x => x.DropDate)
                .IsRequired(false)
                .HasColumnType("date");

              
        }
    }
}
