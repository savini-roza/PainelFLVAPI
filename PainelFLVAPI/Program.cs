using PainelFLVAPI.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using PainelFLVAPI.Services.Interfaces;
using PainelFLVAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IProdutorService, ProdutorService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ICompradorService, CompradorService>();
builder.Services.AddTransient<IEmbalagemService, EmbalagemService>();
builder.Services.AddTransient<IFornecedorService, FornecedorService>();
builder.Services.AddTransient<IContatoService, ContatoService>();
builder.Services.AddTransient<IMaterialService, MaterialService>();


string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<FLVDbContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
