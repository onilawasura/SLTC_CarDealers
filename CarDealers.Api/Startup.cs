using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.DataManager.Repositories;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CarDealers.Api
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
            services.AddControllers();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            string connectionString = Configuration["connectionStrings:IdentityConnection"];
            services.AddDbContext<CarDealerDbContext>(o => o.UseSqlServer(connectionString));
            //services.AddDbContext<CarDealerDbContext>();

            // services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddScoped<IAdvertistmentRepository, AdvertistmentRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();


            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                //add EF implementation of the identity core
                .AddEntityFrameworkStores<CarDealerDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );


            var key = Encoding.UTF8.GetBytes("1234567890123456");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                 //disables https
                 x.RequireHttpsMetadata = false;

                 //after successfull authentication save the token inside the token or not
                 x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                     //system will validate the security key during the token validation
                     ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddCors();

            //dsdsdsd

            //services.AddControllers();

            ////inject appsetting.js file so that it can be access with the any web api controller class

            //services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));


            ////step 1 we dont have to create object using new key word 
            ////asp.net dependency injection will inject this type of object for whenever constructor paremeter of this type  
            //services.AddDbContext<CarDealerDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));



            ////#*Function
            ////this function call will add common sevices from identity core in to this application
            ////responsible for adding [AspNetUser] table to DI system
            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    //add EF implementation of the identity core
            //    .AddEntityFrameworkStores<CarDealerDbContext>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 4;
            //}
            //);

            //services.AddScoped<IAdvertistmentRepository, AdvertistmentRepository>();
            //services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            //services.AddCors();

            ////Jwt Authentication 

            ////below this all code segments are for login part only

            //var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x => {
            //    //disables https
            //    x.RequireHttpsMetadata = false;

            //    //after successfull authentication save the token inside the token or not
            //    x.SaveToken = false;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        //system will validate the security key during the token validation
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            ////cors
            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseAuthentication();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }


            ////
            ///

            app.UseStaticFiles();// For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "Content/Images")),
                RequestPath = "/Content/Images"
            });
            //Enable directory browsing
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "Content/Images")),
                RequestPath = "/Content/Images"
            });

            /////



            //cors
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
