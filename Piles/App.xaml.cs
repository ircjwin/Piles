﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Piles.Data;
using Piles.HostBuilder;
using Piles.Services;
using System.Windows;
using Piles.Models;
using Piles.ViewModels;

namespace Piles
{
    public partial class App : Application
    {
        private readonly IHost _host;

        private const string CONNECTION_STRING = "Data Source=piles.db";

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddServices()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IPilesDbContextFactory>(new PilesDbContextFactory(CONNECTION_STRING));
                    
                    //services.AddSingleton<IPileService, PileService>();
                    //services.AddSingleton<IRuminationService, RuminationService>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<PileupViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            IPilesDbContextFactory pilesDbContextFactory = _host.Services.GetRequiredService<IPilesDbContextFactory>();
            using (PilesDbContext dbContext = pilesDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
