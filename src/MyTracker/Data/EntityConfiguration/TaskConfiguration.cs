using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTracker.Models;


namespace MyTracker.Data.EntityConfiguration
{
    /*public class TaskConfiguration : EntityTypeConfiguration<MyTask>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistId)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);
        }

    }*/

}

