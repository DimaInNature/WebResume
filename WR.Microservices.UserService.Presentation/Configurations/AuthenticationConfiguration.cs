namespace WR.Microservices.UserService.Presentation.Configurations;

public static class AuthenticationConfiguration
{
    public static void AddAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(configureOptions: options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration[key: "Jwt:Issuer"],
                    ValidAudience = builder.Configuration[key: "Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(s: builder.Configuration[key: "Jwt:Key"]))
                };
            });
    }
}