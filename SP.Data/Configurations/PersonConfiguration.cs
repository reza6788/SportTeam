using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SP.Data.Entities;

namespace SP.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.CreateDateTime).IsRequired();

            builder.HasOne(p => p.PersonContactInfo)
                .WithOne(p => p.Person)
                .HasForeignKey<PersonContactInfoEntity>(p => p.PersonId);

            builder.HasOne(p => p.PersonContribution)
                .WithOne(p => p.Person)
                .HasForeignKey<PersonContributionEntity>(p => p.PersonId);
        }
    }
}
