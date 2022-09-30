using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciarProjetos.Database;
using GerenciarProjetos.Helpers;
using GerenciarProjetos.Helpers.Interface;
using GerenciarProjetos.Middlewares;
using GerenciarProjetos.Models.Requests.Empregado;
using GerenciarProjetos.Repositories;
using GerenciarProjetos.Repositories.Interfaces;
using GerenciarProjetos.Services;
using GerenciarProjetos.Services.Interfaces;
using GerenciarUsuarios.Services;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.OperationFilter<AuthOperationFilter>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira um token de autenticação",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

});

builder.Services.AddFluentValidationRulesToSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbGerenciarProjetos"))
);

builder.Services.AddScoped<IAuthHelper, AuthHelper>();

builder.Services.AddScoped<IEmpregadoService, EmpregadoService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IEmpregadoRepository, EmpregadoRepository>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSecret"]);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

app.Services.GetRequiredService<AutoMapper.IConfigurationProvider>().AssertConfigurationIsValid();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Context>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
