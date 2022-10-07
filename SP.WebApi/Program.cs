using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SP.Data;
using SP.Services.Person.Implementation;
using SP.WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SPDbContext>(options =>
    options.UseInMemoryDatabase("SoftParkCodeChallengeDB"));

// Add services to the container.

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();
SPContextSeed.SeedAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Media")),
    RequestPath = new PathString("/Media")
});

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

app.MapControllers();

app.Run();
