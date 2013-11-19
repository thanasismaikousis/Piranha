using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;

namespace Piranha.Repositories
{
	/// <summary>
	/// Default implementation of the permission repository.
	/// </summary>
	internal class PermissionRepository : IPermissionRepository
	{
		#region Members
		private readonly DataContext uow ;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="db">The current data context</param>
		public PermissionRepository(DataContext db) { 
			uow = db ;
		}

		/// <summary>
		/// Gets the model identified by the given unique id. The results of this 
		/// method is cached in memory resulting in higher performance than the 
		/// generic get method.
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The model</returns>
		public Models.Permission GetById(Guid id) {
			var permission = Application.Current.EntityCache.Permissions.Get(id) ;

			if (permission == null) {
				permission = uow.Permissions.Where(p => p.Id == id).SingleOrDefault() ;

				if (permission != null)
					Application.Current.EntityCache.Permissions.Add(permission) ;
			}
			if (permission != null)
				return Map(permission) ;
			return null ;
		}

		/// <summary>
		/// Gets the model identitified by the given unique internal id. The results 
		/// of this method is cached in memory resulting in higher performance than 
		/// the generic get method.
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The model</returns>
		public Models.Permission GetByInternalId(string internalId) {
			var permission = Application.Current.EntityCache.Permissions.Get(internalId) ;

			if (permission == null) {
				permission = uow.Permissions.Where(p => p.InternalId == internalId).SingleOrDefault() ;

				if (permission != null)
					Application.Current.EntityCache.Permissions.Add(permission) ;
			}
			if (permission != null)
				return Map(permission) ;
			return null ;
		}

		/// <summary>
		/// Gets the models matching the given predicate.
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <returns>The models</returns>
		public IList<Models.Permission> Get(Expression<Func<Entities.Permission, bool>> predicate = null) {
			var models = new List<Models.Permission>() ;
			var permission = uow.Permissions
				.Where(predicate)
				.ToList() ;

			foreach (var p in permission) { 
				models.Add(Map(p)) ;
			}
			return models ;
		}

		/// <summary>
		/// Inserts the model to the current unit of work.
		/// </summary>
		/// <param name="model">The model</param>
		public void Add(Models.Permission model) {
			Entities.Permission permission = null ;

			// Get the entity if this is an update
			if (model.Id.HasValue)
				permission = uow.Permissions
					.Where(p => p.Id == model.Id.Value)
					.Single() ;

			// Create entity if this is an insert
			if (permission == null) { 
				permission = new Entities.Permission() ;
				model.Id = permission.Id = Guid.NewGuid() ;
				uow.Permissions.Add(permission) ;
			}

			// Update entity
			Mapper.Map<Models.Permission, Entities.Permission>(model, permission) ;
			permission.Roles = model.Roles.Implode(",") ;
		}

		/// <summary>
		/// Removes the given model.
		/// </summary>
		/// <param name="model">The model</param>
		public void Remove(Models.Permission model) {
			if (model.Id.HasValue)
				Remove(model.Id.Value) ;
		}

		/// <summary>
		/// Removes the model with the given id.
		/// </summary>
		/// <param name="id">The id</param>
		public void Remove(Guid id) {
			var permission = uow.Permissions.Where(p => p.Id == id).Single() ;
			if (!permission.IsLocked)
				uow.Permissions.Remove(permission) ;
			else throw new UnauthorizedAccessException("System permissions can't be removed.") ;
		}

		#region Private methods
		/// <summary>
		/// Maps the given permission entity to a permission model.
		/// </summary>
		/// <param name="permission">The entity</param>
		/// <returns>The model</returns>
		private Models.Permission Map(Entities.Permission permission) { 
			var model = Mapper.Map<Entities.Permission, Models.Permission>(permission) ;

			foreach (var role in permission.Roles.Split(new char[] { ',' })) { 
				model.Roles.Add(role) ;
			}
			return model ;
		}
		#endregion
	}
}