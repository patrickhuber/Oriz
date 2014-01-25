using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace Xacml
{
    public class CompositionDependencyResolver : IDependencyResolver
    {
        private CompositionContainer compositionContainer;

        public CompositionDependencyResolver(CompositionContainer container)
        {            
            this.compositionContainer = container;
        }

        public void Register<T>(T value)
        {
            this.compositionContainer.ComposeExportedValue<T>(value);
        }

        public T GetService<T>()
        {
            return compositionContainer.GetExportedValue<T>();
        }
    }
}
