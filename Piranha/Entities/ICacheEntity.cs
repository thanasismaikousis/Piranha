using System;

namespace Piranha.Entities
{
    /// <summary>
    /// Interface for entities that are cached server-side by the application object.
    /// </summary>
    public interface ICacheEntity
    {
        /// <summary>
        /// Removes the current entity from the application cache.
        /// </summary>
        void RemoveFromCache() ;
    }
}
