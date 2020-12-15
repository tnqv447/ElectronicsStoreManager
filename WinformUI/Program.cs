using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;
using AppCore.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Winform {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main () {
            Application.SetHighDpiMode (HighDpiMode.SystemAware);
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);

            ConfigureServices ();

            /// seed data
            /*var context = ServiceProvider.GetRequiredService<ElectronicsStoreContext> ();
            var unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork> ();
            DataSeeds.Initialize (context, unitOfWork);
            context.SaveChanges ();*/

            ///run forms
            var mainForm = ServiceProvider.GetRequiredService<MainForm> ();
            Application.Run (mainForm);
        }

        private static IServiceProvider ServiceProvider { get; set; }
        //private static IHostingEnvironment _appHost;
        static void ConfigureServices () {
            var services = new ServiceCollection ();

            //forms
            services.AddScoped<MainForm> ();

            //add repositories
            services.AddScoped<IItemRepos, ItemRepos> ();
            services.AddScoped<IItemRelationRepos, ItemRelationRepos> ();
            services.AddScoped<IOrderRepos, OrderRepos> ();
            services.AddScoped<IOrderDetailRepos, OrderDetailRepos> ();
            services.AddScoped<ICustomerRepos, CustomerRepos> ();
            services.AddScoped<ISubOrderDetailRepos, SubOrderDetailRepos> ();
            services.AddScoped<IUnitOfWork, UnitOfWork> ();

            services.AddScoped<IOrderService, OrderService> ();

            //var db_path = Path.GetDirectoryName (System.IO.Directory.GetCurrentDirectory ()) + "\\Infrastructure\\electronics.db";
            //services.AddDbContext<ElectronicsStoreContext> (options => options.UseSqlite ($"Data Source=" + db_path).UseLazyLoadingProxies ());
            services.AddDbContext<ElectronicsStoreContext> ();
            //services.AddDbContext<ManageToursContext>(options => options.UseSqlite($"Data Source=D:\\Code\\Visual Studio\\ManageToursDemo\\ManageToursDemo\\Presentation\\tours.db", x => x.MigrationsAssembly("Presentation.Migrations")));
            //services.AddDbContext<ManageToursContext>(options => options.UseSqlite($"..\\ManageToursDemo\\Presentation\\tours.db", x => x.MigrationsAssembly("Presentation.Migrations")));
            ServiceProvider = services.BuildServiceProvider ();
        }
    }
}