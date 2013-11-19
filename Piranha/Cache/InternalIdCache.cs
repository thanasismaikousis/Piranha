using System;
using System.Collections.Generic;

namespace Piranha.Cache
{
    /// <summary>
    /// Enity cache for slug entities.
    /// </summary>
    /// <typeparam name="T">The entity cache</typeparam>
    internal class InternalIdCache<T> where T : Entities.IInternalIdEntity
    {
        #region Members
        /// <summary>
        /// Private dictionary for mapping internal id to entity id.
        /// </summary>
        private IDictionary<string, Guid> InternalIdMap = new Dictionary<string, Guid>() ;

        /// <summary>
        /// Private cache dictionary.
        /// </summary>
        private IDictionary<Guid, T> Cache = new Dictionary<Guid, T>() ;

        /// <summary>
        /// Cache mutex.
        /// </summary>
        private object mutex = new object() ;
        #endregion

        /// <summary>
        /// Adds the given entity to the cache.
        /// </summary>
        /// <param name="entity">The entity</param>
        public void Add(T entity) {
            lock (mutex) {
                InternalIdMap[entity.InternalId] = entity.Id ;
                Cache[entity.Id] = entity ;
            }
        }

        /// <summary>
        /// Gets the cached entity with the given id.
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <returns>The entity, null if it wasn't found</returns>
        public T Get(Guid id) {
            lock (mutex) { 
                try { 
                    return Cache[id] ;
                } catch { }
            }
            return default(T) ;
        }

        /// <summary>
        /// Gets the cached entity with the given internal id.
        /// </summary>
        /// <param name="slug">The unique internal id</param>
        /// <returns>The entity, null if it wasn't found</returns>
        public T Get(string internalid) {
            lock (mutex) { 
                try {
                    return Cache[InternalIdMap[internalid]] ;
                } catch { }
            }
            return default(T) ;
        }

        /// <summary>
        /// Removes the entity with the given id from the cache.
        /// </summary>
        /// <param name="id">The unique id</param>
        public void Remove(Guid id) {
            lock (mutex) {
                if (Cache.ContainsKey(id)) {
                    if (InternalIdMap.ContainsKey(Cache[id].InternalId))
                        InternalIdMap.Remove(Cache[id].InternalId) ;
                    Cache.Remove(id) ;
                }
            }
        }
    }
}
