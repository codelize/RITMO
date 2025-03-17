var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar o CORS para permitir requisições de outras origens (ajustar conforme sua necessidade).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Configuração do Swagger (OpenAPI).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione o banco de dados aqui, se necessário. Exemplo com SQL Server:
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Adiciona o middleware CORS (Se você estiver fazendo chamadas de uma origem diferente).
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Se não for usar autenticação/autorization, remova o 'UseAuthorization'
app.UseAuthorization();

// Mapeia os controllers.
app.MapControllers();

app.Run();
