using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ZdorovayaNorka.DAL.Interfaces;
using ZdorovayaNorka.DAL.Repositories;
using ZdorovayaNorka.Service.Implementaitons;
using ZdorovayaNorka.Service.Interfaces;

namespace ZdorovayaNorka.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZdorovayaNorka.WebApi", Version = "v1" });
            });




            services.AddScoped<IEmployeeManagerRepository, EmployeeManagerRepository>();
            services.AddScoped<IEmployeeManagerService, EmployeeManagerService>();

            services.AddScoped<IShiftManagerRepository, ShiftManagerRepository>();
            services.AddScoped<IShiftManagerService, ShiftManagerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZdorovayaNorka.WebApi v1"));
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
