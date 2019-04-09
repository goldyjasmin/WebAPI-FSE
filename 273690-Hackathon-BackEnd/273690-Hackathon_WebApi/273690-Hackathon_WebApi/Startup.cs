using FSE.BAL;
using FSE.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace _273690_Hackathon_WebApi
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,

                  ValidIssuer = "http://localhost:4545",
                  ValidAudience = "http://localhost:4545",
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
              };
          });

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

            //var connection = @"Server=DOTNET;Database=FeedBackManagementSystem;user id=sa;password=pass@word1;ConnectRetryCount=0";
            //services.AddDbContext<FeedBackManagementSystemContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<FeedBackManagementSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<AuthorizationRepo>();
            services.AddTransient<EventDetailRepository>();
            services.AddScoped<FeedbackRepo>();
            services.AddScoped<SettingsRepo>();            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
