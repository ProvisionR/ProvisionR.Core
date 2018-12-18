using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using StructureMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.DependencyResolution
{
    public class ProvisioningContainer : IProvisionContainer
    {
        /// <summary>The container.</summary>
        private readonly IContainer container;

        /// <summary>Initializes a new instance of the <see cref="DependencyContainerWrapper"/> class.</summary>
        /// <param name="container">The container.</param>
        public ProvisioningContainer(IContainer container)
        {
            this.container = container;
        }

        /// <summary>The get all instances.</summary>
        /// <param name="pluginType">The plugin type.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable GetAllInstances(Type pluginType)
        {
            return this.container.GetAllInstances(pluginType);
        }

        public IEnumerable<IComponentImport> GetAllInstances<T>()
        {
            return container.GetAllInstances<IComponentImport>();
        }

        public IComponentHandler<TCommand> GetCommandHandler<TCommand>()
        {
            return this.container.GetInstance<IComponentHandler<TCommand>>();
        }

        public IComponentImport GetCommandHandlerByName(object key)
        {
            return null;
        }
              

        public IComponentImport GetCommandHandlerByType(Type pluginType)
        {
            return (IComponentImport)this.container.GetInstance(pluginType);
        }

        /// <summary>The get instance.</summary>
        /// <param name="pluginType">The plugin type.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetInstance(Type pluginType)
        {
            return this.container.GetInstance(pluginType);
        }

       
    }
}