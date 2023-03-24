using Compass.Core;
using Compass.Infrastructure;
using Compass.Infrastructure.DbInitializers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
// Database context
builder.Services.AddDbContext(connStr);
// Add identity
builder.Services.AddIdentity();
// Add core services
builder.Services.AddCoreServices();
// Add automapper
builder.Services.AddAutoMapper();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseCors(options => options.SetIsOriginAllowed(origin => true)
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await UserInitializer.Seed(app);
app.Run();