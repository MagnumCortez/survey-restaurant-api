using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Restaurant.Api.UoW;
using Restaurant.Api.UoW.Infra;
using Restaurant.BLL;
using Restaurant.BLL.Infra;
using Restaurant.DAL;
using Restaurant.DAL.DataBaseContext;
using Restaurant.DAL.Infra;

namespace Restaurant.Api
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
            // DB CONTEXT
            services.AddScoped<IRestaurantDbContext, RestaurantDbContext>();

            // REPOSITORY
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ISurveyRepository, SurveryRepository>();

            // BLL
            services.AddScoped<IStudentBLL, StudentBLL>();
            services.AddScoped<ILoginBLL, LoginBLL>();
            services.AddScoped<IRestaurantBLL, RestaurantBLL>();
            services.AddScoped<ISurveyBLL, SurveyBLL>();

            // UoW
            services.AddScoped<IStudentUoW, StudentUoW>();
            services.AddScoped<ILoginUoW, LoginUoW>();
            services.AddScoped<IRestaurantUoW, RestaurantUoW>();
            services.AddScoped<ISurveyUoW, SurveyUoW>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //FORMATAÇÃO JSON (PASCAL CASE)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            );

            app.UseMvc();
        }
    }
}
