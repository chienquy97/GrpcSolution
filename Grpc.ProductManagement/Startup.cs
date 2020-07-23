using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.ProductManagement.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Grpc.ProductManagement.IRepositories;
using Grpc.ProductManagement.IServices;
using Grpc.ProductManagement.Services;
using Grpc.ProductManagement.Repositories;

namespace Grpc.ProductManagement
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

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
            });
            services.AddControllers();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("tokens");
            services.Configure<Tokens>(appSettingsSection);
            var appSettings = appSettingsSection.Get<Tokens>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Key);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
              
            /*  services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
              services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));


              services.AddTransient<IPermissionRepository, PermissionRepository>();
              services.AddTransient<IRoleRepository, RoleRepository>();


              
              services.AddTransient<IRoleService, RoleService>();
              services.AddTransient<IPermissionService, PermissionService>();
              services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            // Config Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
