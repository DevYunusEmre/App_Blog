using App_Domain.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DAL.ConfigurationMapping
{
    public class ConfigUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             
            //Relational Properties
            //User => Story
            builder
                .HasMany(u => u.Stories)
                .WithOne(s => s.User)
                .HasForeignKey(u => u.UserId);
             
        }
    }
}
