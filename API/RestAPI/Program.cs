using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.Mongo;
using Repositories.Mongo.Core;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration _configuration = builder.Configuration;

//builder.Services.AddJwtValidation();
builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<MongoDBSettings>(_configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddTransient<MongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddTransient<IMongoDBContext, MongoDBContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetValue<string>("JWTAuthSecretKey"))),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

var _lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
//var _userRepo = app.Services.GetService<IUserRepository>(); //.Services.GetRequiredService<IUserRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(options =>
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
}
else
{
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
