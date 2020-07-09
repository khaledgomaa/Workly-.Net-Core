using AutoMapper;
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
        //string secretKey = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(option =>
            //    {
            //        option.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            //what to validate
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateIssuerSigningKey = true,
            //            //validate Data
            //            ValidIssuer = "workly.api",
            //            ValidAudience = "allRoles",
            //            IssuerSigningKey = symmetricSecurityKey
            //        };
            //    });

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
            });
        }
    }
}
