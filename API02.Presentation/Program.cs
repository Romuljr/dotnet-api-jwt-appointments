using API02.Infra.Contracts;
using API02.Infra.Repositories;
using API02.Presentation.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

SwaggerConfiguration.AddSwagger(builder.Services);
JwtConfiguration.AddJwt(builder.Services, builder.Configuration);
CorsConfiguration.AddCors(builder.Services);


builder.Services.AddControllers();

EntityFrameworkConfiguration.AddEntityFramework(builder.Services, builder.Configuration);

var app = builder.Build();

SwaggerConfiguration.UseSwagger(app);

app.UseRouting();

CorsConfiguration.UseCors(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();