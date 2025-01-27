using GerenciarEstoque.Aplicacao;
using GerenciarEstoque.Repositorio;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Adicione serviços ao conteiner
builder.Services.AddControllers();

//Adicione serviços ao banco de dados
builder.Services.AddDbContext<ClimedioContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//configuraçoes swagger/openApi em http:aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IAgendamentoAplicacao, AgendamentoAplicacao>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();






