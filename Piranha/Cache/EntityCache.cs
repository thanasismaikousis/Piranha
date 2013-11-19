using System;

namespace Piranha.Cache
{
    /// <summary>
    /// The main entity cache object.
    /// </summary>
    internal class EntityCache
    {
        /// <summary>
        /// The param cache.
        /// </summary>
        public readonly InternalIdCache<Entities.Permission> Permissions = new InternalIdCache<Entities.Permission>() ;
    }
}
