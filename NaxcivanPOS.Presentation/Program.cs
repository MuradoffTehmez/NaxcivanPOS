using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Business.Services;
using NaxcivanPOS.Data;
using NaxcivanPOS.Data.Contexts;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Presentation.Forms;

namespace NaxcivanPOS.Presentation;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Create host with configured services
        var host = CreateHostBuilder().Build();

        // Initialize application
        ApplicationConfiguration.Initialize();

        // Get AnaForm from service provider and run it
        using var scope = host.Services.CreateScope();
        var anaForm = scope.ServiceProvider.GetRequiredService<AnaForm>();
        
        Application.Run(anaForm);
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Add Entity Framework DbContext
                services.AddDbContext<NaxcivanPOSContext>(options =>
                    // YENİ: DbContext konfiqurasiyası artıq appsettings.json-dan oxunur
                    Microsoft.EntityFrameworkCore.SqlServerDbContextOptionsExtensions.UseSqlServer(
                        options, 
                        context.Configuration.GetConnectionString("DefaultConnection")));

                // Add repositories and UnitOfWork
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                // Add business services
                services.AddScoped<IMehsulYonetimi, MehsulYonetimi>();
                services.AddScoped<ISatisEmeliyyatlari, SatisEmeliyyatlari>();

                // Add forms as transient services
                services.AddTransient<AnaForm>();
                services.AddTransient<SatisForm>();
                services.AddTransient<MehsulForm>();
                services.AddTransient<AxtarisForm>();
            });
    }
}