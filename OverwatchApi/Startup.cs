using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OverwatchApi.Data;
using OverwatchApi.Data.Repositories;
using OverwatchApi.Models.RepositoryInterfaces;

namespace RecipeApi
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

            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DataContext")));

            services.AddScoped<DataInitializer>();
            services.AddScoped<IHeroRepository, HeroRepository>();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Recipe API";
                c.Version = "v1";
                c.Description = "The Recipe API documentation description.";
            }); //for OpenAPI 3.0 else AddSwaggerDocument();

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataInitializer dataInitiliazer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseSwagger();

            dataInitiliazer.InitializeData(); //.Wait();
        }
    }
}