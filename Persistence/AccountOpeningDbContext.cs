
using Application.Contracts.Persistence;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class AccountOpeningDbContext : DbContext, IAccountOpeningDbContext
    {

        public AccountOpeningDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<AccountOwner> AccountOwners { get; set; }
        public DbSet<AccountOwnerAddress> AccountOwnerAddresses { get; set; }
        public DbSet<AccountReason> AccountReasons { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Fatca> Fatcas { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<OtpInfo> OtpInfos { get; set; }

        public DbSet<AccountOpeningStage> AccountOpeningStages { get; set; }

        public DbSet<ChoiceOfAccount> ChoiceOfAccounts { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
