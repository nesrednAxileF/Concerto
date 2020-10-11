using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<ConcertoDbContext> options;
        //private readonly IApplicationSessionDataAccessor applicationSessionDataAccessor;
        public DbContextFactory(DbContextOptions<ConcertoDbContext> options
            //, IApplicationSessionDataAccessor applicationSessionDataAccessor
            )
        {
            this.options = options;
            //this.applicationSessionDataAccessor = applicationSessionDataAccessor;
        }

        public DbContext GetContext()
        {
            DbContext ctx = new ConcertoDbContext(options); ;
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return ctx;
        }
    }
}
