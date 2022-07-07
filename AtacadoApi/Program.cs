
using Atacado.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//string conStr = this.Configuration.GetConnectionString("MyConn");

builder.Services.AddDbContext<AtacadoContext>(options => options.UseSqlServer());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Atacado API - PSG - Capacita��o 2022-04",
            Description = "API REST utilizada para estudo e desenvolvimento do modelo de aplica��es, " +
                "baseado em boas pr�ticas e no modelo de maturidade de Richardson.",
            TermsOfService = new Uri("http://www.psgtecnologia.com.br"),
            Contact = new OpenApiContact()
            {
                Name = "Luiz Augusto Rodrigues",
                Email = "prof.luiz.a.rodrigues.2018@gmail.com"
            },
            License = new OpenApiLicense()
            {
                Name = "PSG Tecnologia - Todos os direitos reservados.",
                Url = new Uri("http://www.psgtecnologia.com.br")
            }
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
);

var app = builder.Build();

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
