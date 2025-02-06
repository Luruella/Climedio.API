using Climedio.Repositorio;
using Climedio.Aplicacao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner
builder.Services.AddControllers();


// Adicione o DbContext, que deve ser sua classe que herda de DbContext (ClimedioContexto)
builder.Services.AddDbContext<ClimedioContexto>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registre as interfaces e implementações
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IAgendamentoAplicacao, AgendamentoAplicacao>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();

// Configurações Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurações CORS (Aqui você configura a política antes de usá-la)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")  // Certifique-se que é a URL correta do seu frontend
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Use CORS antes de configurar o restante do pipeline
app.UseCors();  // Essa linha é importante para permitir CORS

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
