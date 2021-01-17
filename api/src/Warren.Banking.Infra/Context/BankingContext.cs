using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Infra.Mappings;

namespace Warren.Banking.Infra.Context
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> TransactionsHistory { get; set; }

        public BankingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        public void Seed()
        {
            if (Users.Any() || Accounts.Any())
                return;

            Database.ExecuteSqlRaw(File.ReadAllText($"{AppContext.BaseDirectory}/Seed/Users.sql"));
            SaveChanges();

            Database.ExecuteSqlRaw(File.ReadAllText($"{AppContext.BaseDirectory}/Seed/Accounts.sql"));
            SaveChanges();
        }
    }
}