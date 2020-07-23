using AutoMapper;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Workly.Api.Authorization;
using Workly.Api.Hubs;
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
        //private readonly UserManager<ApplicationUser> userManager;
        private ICustomIdProvider customIdProvider;
        public Startup(IConfiguration configuration, ICustomIdProvider customIdProvider)
        {
            Configuration = configuration;
            this.customIdProvider = customIdProvider;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<AgentDbContext>();


            services.AddTokenAuthentication(Configuration);

            services.AddDbContextPool<AgentDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("MyWorkerDbConnection")));
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );


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
            services.AddTransient<INotification, NotificationManager>();

            //SignalR Configuration
            //I wanna create object of UserIdProvider so like var customId = new UserIdProvider(constructor argument)
            //then GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => customId);
            //so I use userId instead of default signlaR connectionId
            services.AddSignalR();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationSender>("notification");
            });
        }
    }
}
