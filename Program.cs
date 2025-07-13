using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ColaboradorService>();
builder.Services.AddScoped<PontuacaoService>();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Busca a configuração do AppSettings para conexão com BD
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");

//Faz a conexão com o BD passando a connectionString
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
