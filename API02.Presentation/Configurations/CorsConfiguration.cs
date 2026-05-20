namespace API02.Presentation.Configurations
{
    public class CorsConfiguration
    {
        public static void AddCors(IServiceCollection services) 
        { 
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    })
                );
        }

        public static void UseCors(IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
