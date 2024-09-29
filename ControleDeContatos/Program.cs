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

// Configura��o do pipeline HTTP para ambientes n�o desenvolvimento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Middleware para servir arquivos est�ticos (wwwroot)
app.UseStaticFiles();

// Middleware de roteamento
app.UseRouting();

// Middleware de autoriza��o
app.UseAuthorization();

// Configura as rotas padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
