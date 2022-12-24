using BSAspExam.API.Core;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAppIdentity(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Asp.NET EXAM API",
        Version = "v1",
        License = new OpenApiLicense
        {
            Name = "ASP.NET Exam",
            Url = new Uri("https://brainstation23.com")
        },
        Contact = new OpenApiContact
        {
            Name = "Rashed Khan Arif",
            Email = "arifkhan0713@gmail.com",
            Url = new Uri("https://rashedkhan.com/")
        },
        Description = "Api Documentation"
    }); ;
});

builder.Services.AddResponseCompression();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
