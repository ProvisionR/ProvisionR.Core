using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.DependencyResolution
{
    public interface IIOC
    {

    }

    public class IOC : IIOC
    {
        public static IContainer Container;

        public static void Register()
        {
            Container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.Assembly("MarkTek.SharePoint.Provisioning.Core");
                    x.Assembly("MarkTek.SharePoint.Provisioning.Core.Engine");
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.ConnectImplementationsToTypesClosing(typeof(IComponentHandler<>));
                  //  x.ConnectImplementationsToTypesClosing(typeof(IComponentImport));
                });

               
                 _.For<IProvisionContainer>().Use<ProvisioningContainer>();
                _.For<IContainer>().Use(() =>Container);

             
                _.For<IComponentImport>().Use<SharePointSearchHandler>().Named("SearchTemplate");
                _.For<IComponentImport>().Use<PnPTemplateHandler>().Named("PnPTemplate");
                _.For<IComponentImport>().Use<PowerShellHandler>().Named("PowerShellHandler");

            });
        }

        public static IContainer GetContainer()
        {
            return Container;
        }

    }
}
