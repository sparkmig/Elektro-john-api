namespace ElektroJohnAPI;

public static class CorsPolicy
{
    public const string PolicyName = "_corsPolicy";
    public static void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: PolicyName,
                policy  =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });
    }
}