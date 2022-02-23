using Microsoft.Extensions.DependencyInjection;
using WinFormsCalculator.Services;
namespace WinFormsCalculator
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);

            Application.Run(new Main());
        }

   
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<ICalcService, CalcService>();

        }

    }
}

