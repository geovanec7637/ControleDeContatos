using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto de banco de dados com SQL Server
builder.Services.AddDbContext<BancoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbControleDeContatos"));
});

// Adiciona suporte a controllers com views (MVC)
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

var app = builder.Build();

// Configuração do pipeline HTTP para ambientes não desenvolvimento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Middleware para servir arquivos estáticos (wwwroot)
app.UseStaticFiles();

// Middleware de roteamento
app.UseRouting();

// Middleware de autorização
app.UseAuthorization();

// Configura as rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
