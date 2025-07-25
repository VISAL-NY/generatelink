
using GenerateLink.Controllers;
using GenerateLink.Logic;
using GenerateLink.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(o => o.AddPolicy("corsPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddControllers();
var envConf = builder.Configuration.GetSection("App");
builder.Services.Configure<AppSetting>(envConf);
builder.Services.AddScoped<DeeplinkLogic>();
builder.Services.AddScoped<DirectDebitLogic>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var appVersion = builder.Configuration["App:Version"] ?? "1.0.0";
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Generate Link API",
        Version = appVersion,
        Description = "API for generating deep links"
    });
});


builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseCors("corsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
