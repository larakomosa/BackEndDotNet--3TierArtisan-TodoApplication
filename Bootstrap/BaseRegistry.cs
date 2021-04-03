using System;
using Artisan.Core.Bootstrap;

namespace ToDoApplicationAPI.Bootstrap
{
    /// <summary>
    /// The base structure map registry. 
    /// </summary>
    /// <remarks>Used to call to use <see cref="Artisan.Service.Core.Bootstrap.CoreRegistry"/>
    /// with structure map implementation.
    /// </remarks>
    public class BaseRegistry : IRegistry
    {
        /// <inheritdoc />
        public virtual void Register(IRegistryConfiguration configuration)
        {
            configuration.IncludeRegistry<Artisan.Service.Core.Bootstrap.CoreRegistry>();
        }
    }
}

