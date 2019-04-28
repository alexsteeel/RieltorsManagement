using Autofac;
using RieltorsManagement.DAL;

namespace RieltorsManagement.BLL
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();
        }
    }
}
