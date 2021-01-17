using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warren.Banking.Core.Aggregates.Acounts;

namespace Warren.Banking.Infra.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany();

            builder.HasMany(a => a.TransactionsHistory)
                .WithOne();

            builder.Property(a => a.Balance)
                .IsRequired();
        }
    }
}