using BancoAPI.AppServicesExtensions;
using BancoAPI.Context;
using BancoAPI.EndPoints;
using BancoAPI.Models;
using BancoAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//ConfigureService
builder.AddSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

var connectioString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connectioString));

#region Login - Desativado (Use apenas se for necessario)
//Caso necessite de autenticação (Por isso esta desativado) - Autenticação a partir da UserModel e do ServiceToken

//builder.Services.AddSingleton<ITokenService>(new TokenService());
//
//builder.Services.AddAuthentication
//        (JwtBearerDefaults.AuthenticationScheme)
//                    .AddJwtBearer(opt =>
//                    {
//                        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//                        {
//                            ValidateLifetime = true,
//                            ValidateIssuerSigningKey = true,
//
//                            IssuerSigningKey = new SymmetricSecurityKey
//                            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//                        };
//                    });
#endregion

var app = builder.Build();

//EndPoints
#region Login - Desativado (Use apenas se for necessario)
//Caso necessite de autenticação (Por isso esta desativado) - Autenticação a partir da UserModel e do ServiceToken

//app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
//{
//    if (userModel == null)
//    {
//        return Results.BadRequest("Login não existe ou apresenta informações erradas");
//    }
//    if (userModel.UserName == "teste" && userModel.Password == "teste123")
//    {
//        var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
//            userModel);
//        return Results.Ok(new { token = tokenString });
//    }
//    else
//    {
//        return Results.BadRequest("Login não existe ou apresenta informações erradas");
//    }
//}).Produces(StatusCodes.Status400BadRequest)
//            .Produces(StatusCodes.Status200OK)
//            .WithName("Login")
//            .WithTags("Autenticar");
#endregion
app.MapCadastrarClienteEndPoint();
app.MapConsultarClienteEndPoint();
app.MapTransferirPixEndPoint();

//Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Login - Desativado (Use apenas se for necessario)
//Caso necessite de autenticação (Por isso esta desativado) - Autenticação a partir da UserModel e do ServiceToken

//app.UseAuthentication();
//app.UseAuthorization();
#endregion

app.Run();
