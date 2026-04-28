using API02.Infra.Contracts;
using API02.Infra.Repositories;
using API02.Presentation.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

SwaggerConfiguration.AddSwagger(builder.Services);
JwtConfiguration.AddJwt(builder.Services, builder.Configuration);

builder.Services.AddControllers();

EntityFrameworkConfiguration.AddEntityFramework(builder.Services, builder.Configuration);

var app = builder.Build();

SwaggerConfiguration.UseSwagger(app);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();