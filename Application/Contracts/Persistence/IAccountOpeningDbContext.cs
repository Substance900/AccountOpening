using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
   public interface IAccountOpeningDbContext
    {
        public DbSet<AccountOwner> AccountOwners { get; set; }

        public DbSet<AccountOwnerAddress> AccountOwnerAddresses { get; set; }

        public DbSet<AccountReason> AccountReasons { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Fatca> Fatcas { get; set; }

        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<OtpInfo> OtpInfos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
