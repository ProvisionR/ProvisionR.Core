using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IProvisionContainer
    {
        IEnumerable GetAllInstances(Type pluginType);
        object GetInstance(Type pluginType);
        IComponentHandler<TCommand> GetCommandHandler<TCommand>();
        IComponentImport GetCommandHandlerByType(Type pluginType);
        IEnumerable<IComponentImport> GetAllInstances<T>();
    }
}
