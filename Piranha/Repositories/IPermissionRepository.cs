using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Piranha.Repositories
{
	/// <summary>
	/// The permission repository contains all of the actions for permissions.
	/// </summary>
	public interface IPermissionRepository
	{
		/// <summary>
		/// Gets the model identified by the given unique id. The results of this 
		/// method is cached in memory resulting in higher performance than the 
		/// generic get method.
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The model</returns>
		Models.Permission GetById(Guid id) ;

		/// <summary>
		/// Gets the model identitified by the given unique internal id. The results 
		/// of this method is cached in memory resulting in higher performance than 
		/// the generic get method.
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The model</returns>
		Models.Permission GetByInternalId(string internalId) ;
		
		/// <summary>
		/// Gets the models matching the given predicate.
		/// </summary>
		/// <param name="predicate">The predicate</param>
		/// <returns>The models</returns>
		IList<Models.Permission> Get(Expression<Func<Entities.Permission, bool>> predicate = null) ;

		/// <summary>
		/// Adds the model to the current unit of work.
		/// </summary>
		/// <param name="model">The model</param>
		void Add(Models.Permission model) ;

		/// <summary>
		/// Removes the given model.
		/// </summary>
		/// <param name="model">The model</param>
		void Remove(Models.Permission model) ;

		/// <summary>
		/// Removes the model with the given id.
		/// </summary>
		/// <param name="id">The id</param>
		void Remove(Guid id) ;
	}
}
