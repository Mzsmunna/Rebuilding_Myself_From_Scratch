using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Repositories.Mongo;
using Repositories.Mongo.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration Configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<MongoDBSettings>(Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddTransient<MongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddTransient<IMongoDBContext, MongoDBContext>();

//RegisterCollectionMapping();

builder.Services.AddSingleton<IMongoDBContext, MongoDBContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var _lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
//var _userRepo = app.Services.GetService<IUserRepository>(); //.Services.GetRequiredService<IUserRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
