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
using TodoApi.Models;
using ToDoApplicationAPI.Biz;
using ToDoApplicationAPI.Data;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;
using ToDoApplicationAPI.Biz.Models;
using Artisan.Service.Core.Web;
using ToDoApplicationAPI.Controllers.Contracts;
using ToDoApplicationAPI.Controllers.Builders;
using StructureMap;
using Container = StructureMap.Container;
using CommonServiceLocator;
using Artisan.Core.Bootstrap.StructureMap;
using ToDoApplicationAPI.Bootstrap;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ToDoApplicationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

          
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddTransient<IMessageBuilder<TodoItem, TodoItemResponse>, TodoItemResponseBuilder>();
            services.AddTransient<ITodoItemsManager, TodoItemsManager>();
            services.AddTransient<ITodoItemsDao, TodoItemsDao>();
            services.AddDbContext<TodoContext>(opt =>
                                    {opt.UseSqlServer(Configuration.GetConnectionString("TodoDb"));
                                    });

              services.AddMvc();

            // Wire up StructureMap
            var container = new Container();
            container.Configure(config =>
            {
                config.Populate(services);
                config.For<IServiceLocator>().Singleton().Use(new StructureMapServiceLocator(container));
            });

            var registrar = new StructureMapRegistrar(container);

            registrar.Register<BaseRegistry>();

            return new StructureMapServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
