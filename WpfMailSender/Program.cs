using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WpfMailSender
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(Args);
            hostBuilder.UseContentRoot(Environment.CurrentDirectory);
            hostBuilder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
            });

            hostBuilder.ConfigureServices(App.ConfigureServices);

            return hostBuilder;
        }

    }
}
