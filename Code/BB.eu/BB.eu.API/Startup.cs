using BB.eu.API.Data;
using BB.eu.API.Mapper;
using BB.eu.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BB.eu.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BB.eu.API", Version = "v1" });
            });

            services.AddCors(corsOptions =>
            {
                corsOptions.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            // services.AddSingleton<DataContext>();
            services.AddSingleton<DataContextFactory>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IRenterDataService, RenterDataService>();
            services.AddScoped<ITenantDataService, TenantDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BB.eu.API v1"));
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}