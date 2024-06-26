using Asp.Versioning;
using Fiap.Monitoramento.Ambiental;
using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Carregando as variaveis de ambiente do arquivo .env
DotNetEnv.Env.Load();

#region Configuração do banco de dados

// Obtenha a senha/login/host do banco de dados do arquivo .net
var dbLogin = Environment.GetEnvironmentVariable("DB_LOGIN");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");


var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

connectionString = connectionString
    .Replace("{DB_LOGIN}", dbLogin)
    .Replace("{DB_PASSWORD}", dbPassword)
    .Replace("{DB_HOST}", dbHost);

builder.Services.AddDbContext<DatabaseContext>(

    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)

    );

#endregion

#region Configurando o AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(a =>
    {
        // Permite mapear coleções nulas
        a.AllowNullCollections = true;

        // Permite que valores de destino nulo sejam mapeados
        a.AllowNullDestinationValues = true;

        // Define mapeamento
        a.CreateMap<DesastresNaturaisModel, DesastresNaturaisViewModel>();
        a.CreateMap<DesastresNaturaisViewModel, DesastresNaturaisModel>();
    }
);


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

//app.UseAuthorization();

app.MapControllers();

app.Run();
