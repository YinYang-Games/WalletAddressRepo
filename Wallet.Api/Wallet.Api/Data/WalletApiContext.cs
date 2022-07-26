using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Entities;

namespace Wallet.Api.Data
{
    public class WalletApiContext : DbContext
    {
        public WalletApiContext (DbContextOptions<WalletApiContext> options)
            : base(options)
        {
        }

        public DbSet<Wallet.Api.Entities.WalletAddress> WalletAddress { get; set; } = default!;
    }
}
