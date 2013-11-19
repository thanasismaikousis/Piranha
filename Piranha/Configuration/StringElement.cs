using System;
using System.Configuration;

namespace Piranha.Configuration
{
	/// <summary>
	/// A configuration element with a string value.
	/// </summary>
	public class StringElement : ConfigurationElement
	{
		/// <summary>
		/// Gets/sets the element value.
		/// </summary>
		[ConfigurationProperty("value", IsRequired=true)]
		public string Value {
			get { return (string)this["value"] ; }
			set { this["value"] = value ; }
		}
	}
}