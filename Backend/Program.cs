using Backend.Databases;
using Backend.csScripts;
using Backend.Modules;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyCORS = "_myCORS";

builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidIssuer = "https://localhost:7235",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("4zljz0npg5c9bmm5"))
    };
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(builder.Configuration.GetSection("Jwt").Get<JwtSettings>());
builder.Services.AddSingleton<IMongoClient>(serviceProvider => {
    
    var settings =  builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddSingleton<IMongoDBConnection<UserModule>,MongoDBConnection<UserModule>>();
builder.Services.AddSingleton<IMongoDBConnection<BlogModule>,MongoDBConnection<BlogModule>>();
builder.Services.AddSingleton<IMongoDBConnection<SubcriberModule>,MongoDBConnection<SubcriberModule>>();
builder.Services.AddSingleton<IUserDB,UserDB>();
builder.Services.AddSingleton<ISubcriberDB,SubcriberDB>();
builder.Services.AddSingleton<IBlogDB,BlogDB>();
builder.Services.AddSingleton<IUserAccount,UserAccount>();

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyCORS,policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
        
    });
});

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseCors(MyCORS);
if(app.Environment.IsDevelopment()){
    app.UseHttpsRedirection();
}

app.UseEndpoints(endpoints =>{
    endpoints.MapHealthChecks("/healths");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
