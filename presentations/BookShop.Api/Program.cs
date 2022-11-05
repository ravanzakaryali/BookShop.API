using BookShop.Api.Middlewares;
using BookShop.Application.Common;
using BookShop.Persistence.Data;
using System.ComponentModel;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(opt =>
{
    opt.ReportApiVersions = true;
    opt.DefaultApiVersion = new ApiVersion(Convert.ToInt32(builder.Configuration["Version"]), 0);
    opt.AssumeDefaultVersionWhenUnspecified = false;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;

});
//Todo: Response Middelware
//Todo: Exception Middelware


builder.Services.AddSwaggerGen(opt =>
{
    opt.UseInlineDefinitionsForEnums();
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1"
    });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    //opt.SwaggerDoc("v2", new OpenApiInfo
    //{
    //    Version = "2"
    //});
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    AppDbContextInitialiser initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
    await initializer.SeedAsync();
    await initializer.InitializeAsync();
    app.UseSwagger();
}
app.UseSwaggerUI(options =>
{

    options.DocumentTitle = "Test Title";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
});


app.UseExceptionMiddelware();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
