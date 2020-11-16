using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ITForumV3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ITForumV3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider serviceProvider { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("UserList"));
            //services.AddDbContext<PostContext>(opt => opt.UseInMemoryDatabase("PostList"));
            //services.AddDbContext<ThreadContext>(opt => opt.UseInMemoryDatabase("ThreadList"));
            services.AddControllers();
            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddAutoMapper(typeof(Startup));

            services.AddEntityFrameworkNpgsql().AddDbContext<PostContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<UserContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<ThreadContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));

            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Query.ContainsKey("access_token"))
                            {
                                context.Token = context.Request.Query["access_token"];
                            }

                            return Task.CompletedTask;
                        }
                    };

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = Constants.Issuer,
                        ValidAudience = Constants.Audiance,
                        IssuerSigningKey = key,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RoleAdmin", policy => policy.RequireClaim("Role", "Admin"));
            });

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseStatusCodePages();

            /*app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home";
                    await next();
                }
            });*/

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("HomePage");
            //});

            app.UseHttpsRedirection();

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
