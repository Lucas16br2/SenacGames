using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacGames.Infrastructure.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(g => g.Description)
                .HasMaxLength(2000);

            builder.Property(g => g.CoverImageUrl)
                .HasMaxLength (500);

            builder.HasOne(g => g.Category) // um gamer tem uma categoria 
                .WithMany(c => c.Games) //uma categoria tem muitos games
                .HasForeignKey(g => g.Category) // a FK é CategoryId
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
