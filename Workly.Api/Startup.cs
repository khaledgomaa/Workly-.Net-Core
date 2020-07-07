using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Workly.Domain;
using Workly.Repository;
using Workly.Repository.Implementation;
using Workly.Repository.Interfaces;
using Workly.Service.Implementation;
using Workly.Service.Interfaces;

namespace Workly.Api
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContextPool<AgentDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("MyWorkerDbConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(WorkerRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IUnitOfWork, GenericUnitOfWork>();
            services.AddTransient<IAgentManager, AgentManager>();
            services.AddTransient<IJobManager, JobManager>();
            services.AddTransient<IAddressManager, AddressManager>();
            services.AddTransient<ISkillManager, SkillManager>();
            services.AddTransient<IAgentSkillManager, AgentSkillManager>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<AgentDbContext>();
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MapperProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.SetIsOriginAllowed(s => _ = true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
