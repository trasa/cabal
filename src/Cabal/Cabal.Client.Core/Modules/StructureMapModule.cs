using Cabal.Client.Core.Services;
using Microsoft.Practices.Composite.Modularity;
using StructureMap;

namespace Cabal.Client.Core.Modules
{
    public abstract class StructureMapModule : IModule
    {
        public abstract void Initialize();

        protected IContainer Container { get { return ClientIoCContainer.Container; } }
    }
}
