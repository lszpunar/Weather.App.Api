using System;
using System.Collections.Generic;
using Autofac;
using AutofacSerilogIntegration;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Weather.DAL.Context;
using Weather.DAL.SQLiteContext;

namespace Weather.Api.Installers
{
    public class HostModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db => new SQLiteAppDbContext()).As<AppDbContext>();

            //Automapper
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg => {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>()) {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            //Serilog
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.RegisterLogger();
        }
    }
}
