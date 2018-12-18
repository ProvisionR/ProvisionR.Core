using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System.Linq;

namespace MarkTek.SharePoint.Provisioning.Core
{
    public class HandlerFactory : IHandlerFactory
    {
        private readonly IProvisionContainer container;

        public HandlerFactory(IProvisionContainer container)
        {
            this.container = container;
        }

        public IComponentImport GetHandlerForElement(ImportBaseElement x)
        {     
            var handler = container.GetAllInstances<IComponentImport>().Where(el => el.CanHandle(x)).FirstOrDefault();
            return handler;
        }
    }
}
