using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShoppingAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Using SqLite As a Database
            services.AddDbContext<IdentityDbContext>(options => 
                options.UseSqlite("Data Source=users.sqlite", 
                    OptionsBuilder => OptionsBuilder.MigrationsAssembly("ShoppingAPI")));

            //Register Identity Service
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Setup Using Identity as Security
            app.UseAuthentication();

            app.UseStaticFiles();

            //Add this line to make MVC use the Default Route System
            app.UseMvcWithDefaultRoute();
        }
    }
}
