using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.Utils;

namespace WebAPI
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
                b => b.MigrationsAssembly("Repository"))
            );
            services.AddMvc();
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
            });

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info {
                    Title = "eHobby Back-end Api",
                    Description = "Swagger api for eHobby",
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                x.AddSecurityDefinition("Bearer", new ApiKeyScheme {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                x.AddSecurityRequirement(security);
            });
            services.AddScoped<IPostHobbyService, PostHobbyService>();
            services.AddScoped<IPostHobbyRepository, PostHobbyRepository>();

            services.AddScoped<IHobbyService, HobbyService>();
            services.AddScoped<IHobbyRepository, HobbyRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IAccountVerificationRepository, AccountVerificationRepository>();
            services.AddScoped<IAccountVerificationService, AccountVerificationService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Token Param

            var tokenParams = new TokenValidationParameters() {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = Configuration["JWT:issuer"],
                ValidAudience = Configuration["JWT:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration["JWT:key"]))
            };

            //AUTH
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtconfig => {
                    jwtconfig.TokenValidationParameters = tokenParams;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API")
            );
        }
    }
}
