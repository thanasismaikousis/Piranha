using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity map for the permission.
	/// </summary>
	internal class PermissionMap : EntityTypeConfiguration<Permission>
	{
		public PermissionMap() {
			ToTable("Permissions") ;

			Property(p => p.InternalId).IsRequired().HasMaxLength(32) ;
			Property(p => p.Name).IsRequired().HasMaxLength(64) ;
			Property(p => p.Description).HasMaxLength(255) ;
			Property(p => p.Roles).HasMaxLength(255) ;
		}
	}
}
