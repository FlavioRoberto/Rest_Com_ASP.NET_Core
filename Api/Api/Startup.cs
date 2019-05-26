using Data.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repositorio;
using Repositorio.Implementatacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using Dominio.Model;
using Tapioca.HATEOAS;
using Dominio.Core.Hypermedia;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
{
    public class Startup
    {
        private readonly ILogger _logger;
        private IConfiguration _configuration { get; }
        public IHostingEnvironment environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            this.environment = environment;
            _logger = logger;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnections:ConexaoLocal"];

            services.AddDbContext<MySqlContext>(options => {
                options.UseMySQL(connectionString);
            });
                     
            services.AddMvc();

            services.AddApiVersioning();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PessoaEnricher());
            services.AddSingleton(filterOptions);

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Exemplo REST API com ASP.NET Core 2.0",
                    Version = "v1"
                });
            });

            //Injeção de dependencias do serviço para pessoa
            services.AddScoped<IRepositorio<Pessoa>, PessoaRepositorio>();
            services.AddScoped<IRepositorio<Livro>, LivroRepositorio>();
        }

        // This method gets called by the runtime. Use sthis method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$","swagger");
            app.UseRewriter(option);

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            } );
        }
    }
}
