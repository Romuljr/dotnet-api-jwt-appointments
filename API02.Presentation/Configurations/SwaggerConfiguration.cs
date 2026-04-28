using Microsoft.OpenApi.Models;

namespace API02.Presentation.Configurations
{
    public class SwaggerConfiguration
    {
        public static void AddSwagger(IServiceCollection services)
        {

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Agenda de Compromissos - API",
                    Version = "v1",
                    Description = "Projeto desenvolvido em .NET com Entity Framework.",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática - Treinamento C# WebDeveloper",
                        Url = new Uri("http://www.cotiinformatica.com.br"),
                        Email = "contato@cotiinformatica.com.br"
                    }
                });
            });
        }

        public static void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Funcionários v1");
            });
        }
    }
}
