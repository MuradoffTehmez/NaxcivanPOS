using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Business.Services;
using NaxcivanPOS.Data;
using NaxcivanPOS.Data.Contexts;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Presentation.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaxcivanPOS.Presentation
{
    internal static class Program
    {
        private static IHost? _host;

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            await _host.StartAsync();

            var mainForm = _host.Services.GetRequiredService<AnaForm>();
            Application.Run(mainForm);

            await _host.StopAsync();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // Appsettings yüklə
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // DbContext əlavə et
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<NaxcivanPOSContext>(options =>
                options.UseSqlServer(connectionString));

            // Servislər
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMehsulYonetimi, MehsulYonetimi>();
            services.AddScoped<ISatisEmeliyyatlari, SatisEmeliyyatlari>();

            // Form factory-lər
            services.AddSingleton<Func<SatisForm>>(provider => () => provider.GetRequiredService<SatisForm>());
            services.AddSingleton<Func<MehsulForm>>(provider => () => provider.GetRequiredService<MehsulForm>());
            services.AddSingleton<Func<AxtarisForm>>(provider => () => provider.GetRequiredService<AxtarisForm>());

            // Formlar
            services.AddTransient<SatisForm>();
            services.AddTransient<MehsulForm>();
            services.AddTransient<AxtarisForm>();
            services.AddTransient<AnaForm>();
        }
    }
}