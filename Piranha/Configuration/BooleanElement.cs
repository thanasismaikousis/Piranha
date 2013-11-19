using System;
using System.Configuration;

namespace Piranha.Configuration
{
	/// <summary>
	/// A configuration element with a boolean value.
	/// </summary>
	public class BooleanElement : ConfigurationElement
	{
		/// <summary>
		/// Gets/sets the element value.
		/// </summary>
		[ConfigurationProperty("value", IsRequired=true)]
		public bool Value { 
			get { return (bool)this["value"] ; }
			set { this["value"] = value ; }
		}
	}
}