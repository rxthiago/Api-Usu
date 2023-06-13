using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApi.Services.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Definindo o tipo de autenticação do projeto

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(bearer => 
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenSecurity.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

#region Configurando o CORS

builder.Services.AddCors(cors => cors.AddPolicy("DefaultPolicy",
    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
