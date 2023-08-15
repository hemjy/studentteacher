using Serilog;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using StudentTeacher;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

// Get log settings from appsettings
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
builder.Logging.ClearProviders();
// Add serilog
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .WithMethods("GET", "POST")
               .WithHeaders("Content-Type");
    });
});
builder.Services.AddControllers().AddFluentValidation()
     .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); ;
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddStudentTeacherServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();
