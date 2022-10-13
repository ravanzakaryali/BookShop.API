var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
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

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1"
    });
    opt.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "2"
    });
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}
app.UseSwaggerUI(options =>
{

    options.DocumentTitle = "Test Title";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
