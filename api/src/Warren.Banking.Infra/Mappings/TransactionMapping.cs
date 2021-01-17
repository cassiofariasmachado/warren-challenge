using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warren.Banking.Core.Aggregates.Acounts;

namespace Warren.Banking.Infra.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("TransactionsHistory");
            
            builder.HasKey(a => a.Id);

            builder.Ignore(o => o.Operation);
            builder.Property(o => o.OperationValue);
            builder.Property(o => o.OperationType);

            builder.Property(t => t.Balance)
                .IsRequired();

            builder.Property(t => t.Date)
                .IsRequired();
        }
    }
}