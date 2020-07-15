using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GenreLibrary.Repositories;
using GenreLibrary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace GenreLibrary
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
            services.AddScoped<IDbConnection>(x => CreateDBContext());


            services.AddTransient<ArtistService>();
            services.AddTransient<ArtistRepository>();

            services.AddTransient<GenreService>();
            services.AddTransient<GenreRepository>();

            services.AddTransient<ArtistGenreService>();
            services.AddTransient<ArtistGenreRepository>();
        }

        private IDbConnection CreateDBContext()
        {
            var _connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
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
