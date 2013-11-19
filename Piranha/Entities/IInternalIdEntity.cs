using System;

namespace Piranha.Entities
{
    /// <summary>
    /// Internal interface for internal id entities. Used for caching.
    /// </summary>
    internal interface IInternalIdEntity
    {
        /// <summary>
        /// Gets/sets the unique id.
        /// </summary>
        Guid Id { get ; set ; }

        /// <summary>
        /// Gets/sets the unique internal id.
        /// </summary>
        string InternalId { get ; set ; }
    }
}
