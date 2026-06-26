using Mawred_Task.Enums;
using Mawred_Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mawred_Task.Data.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(c => c.Email)
                   .IsUnique();

            builder.Property(c => c.Track)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(c => c.Level)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(c => c.Status)
                   .HasConversion<int>()
                   .HasDefaultValue(CandidateStatus.Pending);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}