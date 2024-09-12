//using Institute.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//var builder = WebApplication.CreateBuilder(args);

//// Configure services
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "yourIssuer", // Set your issuer
//        ValidAudience = "yourAudience", // Set your audience
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey")) // Set your secret key
//    };
//});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Enable CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Use CORS policy
//app.UseCors("AllowReactApp");

//app.UseAuthentication();  // Ensure authentication is added
//app.UseAuthorization();

//app.UseAuthorization();
//app.MapControllers();

//app.Run();

using Institute.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS policy
app.UseCors("AllowReactApp");

// Remove authentication/authorization middleware
app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();

