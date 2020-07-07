using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewAndNotificationAPI.Models;

using NewAndNotificationAPI.Data;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace NewAndNotificationAPI
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
            services.AddDbContext<NewAndNotificationContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("NewAndNotificationAPIConnection")));
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITopicRepo, SqlTopicRepo>();
            services.AddScoped<IPostRepo, SqlPostRepo>();
            services.AddScoped<ITagRepo, SqlTagRepo>();
            services.AddScoped<IPostTagsRepo, SqlPostTagsRepo>();
            services.AddScoped<IStudentRepo, SqlStudentRepo>();
            services.AddScoped<IStudentTopicRepo, SqlStudentTopicRepo>();
            services.AddScoped<IStudentTagRepo, SqlStudentTagsRepo>();
            services.AddMvc();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
