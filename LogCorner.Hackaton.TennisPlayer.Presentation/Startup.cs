using LogCorner.Hackaton.TennisPlayer.Application;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using LogCorner.Hackaton.TennisPlayer.Presentation.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LogCorner.Hackaton.TennisPlayer.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IPlayerRepository, JsonPlayerRepository>();
            services.AddScoped<IGetPlayersUsesCase, PlayerUseCase>();
            services.AddScoped<IGetPlayerUsesCase, PlayerUseCase>();
            services.AddScoped<IDeletePlayerUsesCase, PlayerUseCase>();
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Tennis Player Service HTTP API",
                    Version = "v1",
                    Description = "Tennis Player Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tennis Player Service HTTP API V1");
            });

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
        }
    }
}