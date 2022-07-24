namespace WR.Gateway.Web.Configurations;

public static class AuthenticationConfiguration
{
    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(configureOptions: options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration[key: "Jwt:Issuer"],
                    ValidAudience = configuration[key: "Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(s: configuration[key: "Jwt:Key"])),
                };
            });
    }
}