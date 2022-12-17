using CadastroReceitas.Application.Interfaces;
using CadastroReceitas.Application.Services;
using CadastroReceitas.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroReceitas.IoC;
public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        var connection = @"Server=(localdb)\mssqllocaldb;Database=CadastroReceitas;Trusted_Connection=True;ConnectRetryCount=0";
        services.AddDbContext<ApplicationDbContext>
            (o => o.UseSqlServer(connection));

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddControllersWithViews();

        services.AddTransient<IReceitaService, ReceitaService>();

        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddResponseCompression(o =>
        {
            o.Providers.Add<GzipCompressionProvider>();
        });
    }
}
