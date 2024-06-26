using Asp.Versioning;
using AutoMapper;
using Fiap.Monitoramento.Ambiental;
using Fiap.Monitoramento.Ambiental.Data.Database;
using Fiap.Monitoramento.Ambiental.Data.Repository;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

#region Configuração do banco de dados

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<DatabaseContext>(

    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)

    );

#endregion

#region Repository

builder.Services.AddScoped<IDesastresNaturaisRepository, DesastresNaturaisRepository>();

#endregion

#region Service

builder.Services.AddScoped<IDesastresNaturaisService, DesastresNaturaisService>();

#endregion

#region Configurando o AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(a =>
    {
        // Permite mapear coleções nulas
        a.AllowNullCollections = true;

        // Permite que valores de destino nulo sejam mapeados
        a.AllowNullDestinationValues = true;

        // Mapeamento DesastresNaturaisViewModel
        a.CreateMap<DesastresNaturaisModel, DesastresNaturaisViewModel>();
        a.CreateMap<DesastresNaturaisViewModel, DesastresNaturaisModel>();

        // Mapeamento DesastresNaturaisCreateViewModel
        a.CreateMap<DesastresNaturaisCreateViewModel, DesastresNaturaisModel>();
        a.CreateMap<DesastresNaturaisModel, DesastresNaturaisCreateViewModel>();

        // Mapeamento DesastresPaginacaoViewModel
        a.CreateMap<DesastresPaginacaoViewModel, DesastresNaturaisModel>();
        a.CreateMap<DesastresNaturaisModel, DesastresPaginacaoViewModel>();
    }
);

// Cria o mapper com base na config definida
IMapper mapper = mapperConfig.CreateMapper();

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

//app.UseAuthorization();

app.MapControllers();

app.Run();
