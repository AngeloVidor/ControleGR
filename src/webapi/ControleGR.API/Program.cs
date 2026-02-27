using System.Reflection;
using ControleGR.API.Application.Handlers;
using ControleGR.API.Domain.Interfaces;
using ControleGR.API.Infrastructure.Data;
using ControleGR.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddControllers();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Repositories
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

//Handlers
builder.Services.AddScoped<CreatePessoaHandler>();
builder.Services.AddScoped<CreateCategoriaHandler>();
builder.Services.AddScoped<CreateTransacaoHandler>();
builder.Services.AddScoped<GetTotaisGeraisHandler>();
builder.Services.AddScoped<GetTotaisPorCategoriaHandler>();
builder.Services.AddScoped<GetPessoasHandler>();
builder.Services.AddScoped<GetCategoriasHandler>();
builder.Services.AddScoped<GetTransacoesHandler>();
builder.Services.AddScoped<UpdatePessoaHandler>();
builder.Services.AddScoped<DeletePessoaHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleGR API V1");

    });
}
//Middlewares
app.UseHttpsRedirection();
app.UseCors("ReactCorsPolicy");

app.MapControllers();

app.Run();

