using System;
using System.Configuration;

namespace Piranha
{
	/// <summary>
	/// The main configuration section for Piranha CMS
	/// </summary>
	internal class ConfigFile : ConfigurationSection
	{
		#region Inner classes
		/// <summary>
		/// The settings element of the configuration section.
		/// </summary>
		internal class SettingsElement : ConfigurationElement
		{
			#region Members
			private const string DISABLE_METHOD_BINDING = "disableMethodBinding" ;
			private const string DISABLE_MODELSTATE_BINDING = "disableModelStateBinding" ;
			private const string DISABLE_MANAGER = "disableManager" ;
			private const string MANAGER_NAMESPACES = "managerNamespaces" ;
			private const string PASSIVE_MODE = "passiveMode" ;
			private const string PREFIXLESS_PERMALINKS = "prefixlessPermalinks" ;
			private const string MANAGER_ROLES = "managerRoles" ;
			#endregion

			/// <summary>
			/// Gets/sets if method binding for Web Pages should be disabled or not.
			/// </summary>
			[ConfigurationProperty(DISABLE_METHOD_BINDING, IsRequired=false)]
			public Configuration.BooleanElement DisableMethodBinding {
				get { return (Configuration.BooleanElement)this[DISABLE_METHOD_BINDING] ; }
				set { this[DISABLE_METHOD_BINDING] = value ; }
			}

			/// <summary>
			/// Gets/sets if modelstate binding for Web Pages should be disabled or not.
			/// </summary>
			[ConfigurationProperty(DISABLE_MODELSTATE_BINDING, IsRequired=false)]
			public Configuration.BooleanElement DisableModelStateBinding {
				get { return (Configuration.BooleanElement)this[DISABLE_MODELSTATE_BINDING] ; }
				set { this[DISABLE_MODELSTATE_BINDING] = value ; }
			}

			/// <summary>
			/// Gets/sets if the manager interface should be disabled or not.
			/// </summary>
			[ConfigurationProperty(DISABLE_MANAGER, IsRequired=false)]
			public Configuration.BooleanElement DisableManager {
				get { return (Configuration.BooleanElement)this[DISABLE_MANAGER] ; }
				set { this[DISABLE_MANAGER] = value ; }
			}

			/// <summary>
			/// Gets/sets the additional manager namespaces.
			/// </summary>
			[ConfigurationProperty(MANAGER_NAMESPACES, IsRequired=false)]
			public Configuration.StringElement ManagerNamespaces {
				get { return (Configuration.StringElement)this[MANAGER_NAMESPACES] ; }
				set { this[MANAGER_NAMESPACES] = value ; }
			}

			/// <summary>
			/// Gets/sets the roles that have access to the manager interface.
			/// </summary>
			[ConfigurationProperty(MANAGER_ROLES, IsRequired=false)]
			public Configuration.StringElement ManagerRoles {
				get { return (Configuration.StringElement)this[MANAGER_ROLES] ; }
				set { this[MANAGER_ROLES] = value ;  }
			}

			/// <summary>
			/// Gets/sets if the application is running in passive mode.
			/// </summary>
			[ConfigurationProperty(PASSIVE_MODE, IsRequired=false)]
			public Configuration.BooleanElement PassiveMode {
				get { return (Configuration.BooleanElement)this[PASSIVE_MODE] ; }
				set { this[PASSIVE_MODE] = value ; }
			}

			/// <summary>
			/// Gets/sets if the generated permalinks should be prefixless.
			/// </summary>
			[ConfigurationProperty(PREFIXLESS_PERMALINKS, IsRequired=false)]
			public Configuration.BooleanElement PrefixlessPermalinks {
				get { return (Configuration.BooleanElement)this[PREFIXLESS_PERMALINKS] ; }
				set { this[PREFIXLESS_PERMALINKS] = value ; }
			}

			/// <summary>
			/// Default constructor.
			/// </summary>
			public SettingsElement() {
				DisableMethodBinding = new Configuration.BooleanElement() ;
				DisableModelStateBinding = new Configuration.BooleanElement() ;
				DisableManager = new Configuration.BooleanElement() ;
				ManagerNamespaces = new Configuration.StringElement() ;
				ManagerRoles = new Configuration.StringElement() ;
				PassiveMode = new Configuration.BooleanElement() ;
				PrefixlessPermalinks = new Configuration.BooleanElement() ;
			}
		}

		/// <summary>
		/// The provider element of the configuration section.
		/// </summary>
		internal class ProviderElement : ConfigurationElement
		{
			#region Members
			private const string MEDIA_PROVIDER = "mediaProvider" ;
			private const string MEDIA_CACHE_PROVIDER = "mediaCacheProvider" ;
			private const string CACHE_PROVIDER = "cacheProvider" ;
			private const string LOG_PROVIDER = "logProvider" ;
			#endregion

			/// <summary>
			/// Gets/sets the current configured media provider.
			/// </summary>
			[ConfigurationProperty(MEDIA_PROVIDER, IsRequired=false)]
			public Configuration.StringElement MediaProvider {
				get { return (Configuration.StringElement)this[MEDIA_PROVIDER] ; }
				set { this[MEDIA_PROVIDER] = value ; }
			}

			/// <summary>
			/// Gets/sets the current configured media cache provider.
			/// </summary>
			[ConfigurationProperty(MEDIA_CACHE_PROVIDER, IsRequired=false)]
			public Configuration.StringElement MediaCacheProvider {
				get { return (Configuration.StringElement)this[MEDIA_CACHE_PROVIDER] ; }
				set { this[MEDIA_CACHE_PROVIDER] = value ; }
			} 

			/// <summary>
			/// Gets/sets the current configured cache provider.
			/// </summary>
			[ConfigurationProperty(CACHE_PROVIDER, IsRequired = false)]
			public Configuration.StringElement CacheProvider
			{
				get { return (Configuration.StringElement)this[CACHE_PROVIDER]; }
				set { this[CACHE_PROVIDER] = value; }
			}

			/// <summary>
			/// Gets/sets the current configured log provider.
			/// </summary>
			[ConfigurationProperty(LOG_PROVIDER, IsRequired = false)]
			public Configuration.StringElement LogProvider
			{
				get { return (Configuration.StringElement)this[LOG_PROVIDER]; }
				set { this[LOG_PROVIDER] = value; }
			}

			/// <summary>
			/// Default constructor.
			/// </summary>
			public ProviderElement() {
				MediaProvider = new Configuration.StringElement() ;
				MediaCacheProvider = new Configuration.StringElement() ;
				CacheProvider = new Configuration.StringElement() ;
				LogProvider = new Configuration.StringElement() ;
			}
		}
		#endregion

		#region Members
		private const string SETTINGS = "settings" ;
		private const string PROVIDERS = "providers" ;
		#endregion

		/// <summary>
		/// Gets/sets the settings.
		/// </summary>
		[ConfigurationProperty(SETTINGS, IsRequired=false)]
		public SettingsElement Settings {
			get { return (SettingsElement)this[SETTINGS] ; }
			set { this[SETTINGS] = value ; }
		}

		/// <summary>
		/// Gets/sets the providers.
		/// </summary>
		[ConfigurationProperty(PROVIDERS, IsRequired=false)]
		public ProviderElement Providers {
			get { return (ProviderElement)this[PROVIDERS] ; }
			set { this[PROVIDERS] = value ; }
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ConfigFile() {
			Settings = new SettingsElement() ;
			Providers = new ProviderElement() ;
		}
	}
}