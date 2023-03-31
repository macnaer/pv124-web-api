using Compass.Core;
using Compass.Infrastructure;
using Compass.Infrastructure.DbInitializers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    //RequireExpirationTime = true,
    ClockSkew = TimeSpan.Zero,
    ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
    ValidAudience = builder.Configuration["JwtConfig:Audience"],
};

builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = tokenValidationParameters;
    jwt.RequireHttpsMetadata = false;
});

// Add Template repository
builder.Services.AddRepositories();

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