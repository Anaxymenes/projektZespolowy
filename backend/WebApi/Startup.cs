using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;


using Repository;
using Services.Services;
using Services.Interfaces;
using Repository.Interfaces;
using Repository.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Data.DBModels;

namespace WebApi
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
            services.AddCors();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default"),
                b=>b.MigrationsAssembly("Repository"))
            );
            services.AddScoped<IAccountService, AccountService>();
            
            services.AddMvc();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IPictureRepository, PictureRepository>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSwaggerGen(x =>
                x.SwaggerDoc("v1", new Info { Title = "eHobby Back-end Api" ,
                    Description = "Swagger api for eHobby",
                })

            );
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API")
            );
            //SeedData.Seed(app);
        }
    }
}
