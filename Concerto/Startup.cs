using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concerto.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.Context;
using Repository.Repositories;
using Service.Modules.API.AuthModule;

namespace Concerto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ConcertoDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ConcertoDbConnection"));
                }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddHttpContextAccessor();

            /* Helpers */
            //services.AddTransient<IApplicationSessionDataAccessor, ApplicationSessionDataAccessor>();

            /*
             *  Repositories
             */
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IConcertMerchandiseRepository, ConcertMerchandiseRepository>();
            services.AddTransient<IConcertRepository, ConcertRepository>();
            services.AddTransient<IConcertStatisticRepository, ConcertStatisticRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            /*
             * API Services
             */
            services.AddTransient<IAuthService, AuthService>();

            /*
             * Handlers
             */
            services.AddTransient<IAuthHandler, AuthHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
