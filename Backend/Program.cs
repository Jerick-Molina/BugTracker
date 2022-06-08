using Backend.Databases;
using Backend.csScripts;
using Backend.Modules;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



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
builder.Services.AddSingleton<IMongoDBConnection<UserModule>,MongoDBConnection<UserModule>>();
builder.Services.AddSingleton<IMongoDBConnection<BlogModule>,MongoDBConnection<BlogModule>>();
builder.Services.AddSingleton<IUserDB,UserDB>();
builder.Services.AddSingleton<IBlogDB,BlogDB>();
builder.Services.AddSingleton<IUserAccount,UserAccount>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
