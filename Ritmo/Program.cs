var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar o CORS para permitir requisi��es de outras origens (ajustar conforme sua necessidade).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Configura��o do Swagger (OpenAPI).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione o banco de dados aqui, se necess�rio. Exemplo com SQL Server:
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adiciona o middleware CORS (Se voc� estiver fazendo chamadas de uma origem diferente).
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Se n�o for usar autentica��o/autorization, remova o 'UseAuthorization'
app.UseAuthorization();

// Mapeia os controllers.
app.MapControllers();

app.Run();
