
using PI06.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using PI06.Api.IServiceRepository;
using PI06.Api.IServiceRepository.ServiceRepositories;
using PI06.IRepository;
using PI06.IRepository.Repository;
using PI06.Data.IRepository.Repositories;
using PI06.Data.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PI06.Data.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PI06.Api
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
            
            services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(Configuration
            .GetConnectionString("PI06")));
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddMvc();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Contexto>()
                .AddDefaultTokenProviders();

            //JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidadoEm,
                    ValidIssuer = appSettings.Emissor

                };

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "API - Orientação",
                    Version = "v1"
                });
            });

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
                c.SwaggerEndpoint("v1/swagger.json", "API - PI06 V 1");
                c.DefaultModelExpandDepth(-1);
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
