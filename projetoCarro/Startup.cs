using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using projetoCarro.Context;
using projetoCarro.Services;
using projetoCarro.UserCase;
using projetoCarro.UseCase;
using projetoCarro.Borders.Interfaces;
using projetoCarro.Repositories;
using projetoCarro.Adapter;
using projetoCarro.Borders.Adapter;

namespace projetoCarro
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
            services.AddEntityFrameworkNpgsql().AddDbContext<CarDbContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("urlCarro")));

            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IDeleteCarsUseCase, DeleteCarsUseCase>();
            services.AddScoped<IAddCarsUseCase, AddCarsUseCase>();
            services.AddScoped<IReturnCarsIdUseCase, ReturnCarsIdUseCase>();
            services.AddScoped<IReturnListCarsUseCase, ReturnListCarsUseCase>();
            services.AddScoped<IUpdateCarsUseCase, UpdateCarsUseCase>();

            services.AddScoped<IRepositoriesCars, RepositoriesCars>();

            services.AddScoped<IAddCarsAdapter, AddCarsAdapter>();


            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "projetoCarro", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "projetoCarro v1"));
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
