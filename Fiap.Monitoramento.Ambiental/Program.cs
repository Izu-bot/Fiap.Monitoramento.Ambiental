using Asp.Versioning;
using AutoMapper;
using Fiap.Monitoramento.Ambiental;
using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Configuração do banco de dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(

    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)

    );

#endregion

#region Configurando a serialização/deserialização do Json

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

#endregion

#region Repository

builder.Services.AddScoped<IDesastresNaturaisRepository, DesastresNaturaisRepository>();
builder.Services.AddScoped<IMonitoraQualidadeArRepository, MonitoraQualidadeArRepository>();
builder.Services.AddScoped<IIrrigacaoRepository, IrrigacaoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Service

builder.Services.AddScoped<IDesastresNaturaisService, DesastresNaturaisService>();
builder.Services.AddScoped<IMonitoraQualidadeArService, MonitoraQualidadeArService>();
builder.Services.AddScoped<IIrrigacaoService, IrrigacaoService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthService, AuthService>();

#endregion

#region Configurando o AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(a =>
    {
        // Permite mapear coleções nulas
        a.AllowNullCollections = true;

        // Permite que valores de destino nulo sejam mapeados
        a.AllowNullDestinationValues = true;

        #region Configuração MVVM DesastresNaturais
        a.CreateMap<DesastresNaturaisModel, DesastresNaturaisViewModel>();
        a.CreateMap<DesastresNaturaisViewModel, DesastresNaturaisModel>();

        a.CreateMap<DesastresNaturaisCreateViewModel, DesastresNaturaisModel>();
        a.CreateMap<DesastresNaturaisModel, DesastresNaturaisCreateViewModel>();

        a.CreateMap<DesastresPaginacaoViewModel, DesastresNaturaisModel>();
        a.CreateMap<DesastresNaturaisModel, DesastresPaginacaoViewModel>();
        #endregion

        #region Configuração MVVM MonitoraQualidadeAr
        a.CreateMap<MonitoraQualidadeArModel, MonitoraQualidadeArViewModel>();
        a.CreateMap<MonitoraQualidadeArViewModel, MonitoraQualidadeArModel>();

        a.CreateMap<MonitoraQualidadeArCreateViewModel, MonitoraQualidadeArModel>();
        a.CreateMap<MonitoraQualidadeArModel, MonitoraQualidadeArCreateViewModel>();

        a.CreateMap<MonitoraQualidadeArPaginacaoViewModel, MonitoraQualidadeArModel>();
        a.CreateMap<MonitoraQualidadeArModel, MonitoraQualidadeArPaginacaoViewModel>();
        #endregion

        #region Configuração MVVM Irrigacao
        a.CreateMap<IrrigacaoViewModel, IrrigacaoModel>();
        a.CreateMap<IrrigacaoModel, IrrigacaoViewModel>();

        a.CreateMap<IrrigacaoCreateViewModel, IrrigacaoModel>();
        a.CreateMap<IrrigacaoModel, IrrigacaoCreateViewModel>();

        a.CreateMap<IrrigacaoPaginacaoViewModel, IrrigacaoModel>();
        a.CreateMap<IrrigacaoModel, IrrigacaoPaginacaoViewModel>();
        #endregion

        #region Configuração MVVM Users
        a.CreateMap<UserViewModel, UserModel>();
        a.CreateMap<UserModel, UserViewModel>();

        a.CreateMap<UserCreateViewModel, UserModel>();
        a.CreateMap<UserModel, UserCreateViewModel>();

        #endregion

        #region Configrução MVVM Login

        a.CreateMap<LoginViewModel, UserModel>();
        a.CreateMap<UserModel, LoginViewModel>();

        #endregion
    }
);

// Cria o mapper com base na config definida
IMapper mapper = mapperConfig.CreateMapper();

#region Autenticação

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#endregion

// Registra o mapper como serviço
builder.Services.AddSingleton(mapper);
#endregion

#region versionamento
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);

    options.ReportApiVersions = true;

    options.AssumeDefaultVersionWhenUnspecified = true;

    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    
    options.SubstituteApiVersionInUrl = true;
});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
