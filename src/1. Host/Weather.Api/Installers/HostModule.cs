using Autofac;
using Weather.DAL.Context;
using Weather.DAL.SQLiteContext;

namespace Weather.Api.Installers
{
    public class HostModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db => new SQLiteAppDbContext()).As<AppDbContext>();
        }
    }
}
