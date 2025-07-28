using System;
using System.Collections.Generic;
using System.Reflection;
using SAL.Flatbed;

namespace Plugin.Configuration
{
	internal static class Utils
	{
		/// <summary>Get a list of search parameters in the plugin</summary>
		/// <param name="plugin">Instance of plugin for returning search strings</param>
		/// <returns>Search strings found in plugin</returns>
		public static IEnumerable<String> GetPluginSearchMembers(IPluginDescription plugin)
		{
			foreach(String value in SearchProperties(plugin, false))
				yield return value;

			IPluginSettings settings = plugin.Instance as IPluginSettings;
			if(settings != null)
				foreach(String value in SearchProperties(settings.Settings, true))
					yield return value;
		}

		/// <summary>Search by object instance properties</summary>
		/// <param name="instance">The object whose properties to search by</param>
		/// <param name="searchAttributes">Search by attributes of each property</param>
		/// <returns>Search strings found in object instance properties</returns>
		private static IEnumerable<String> SearchProperties(Object instance, Boolean searchAttributes)
		{
			PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy);
			foreach(PropertyInfo property in properties)
			{
				yield return property.Name;

				if(searchAttributes)
				{//We search by all attributes so as not to hardcode specific attributes
					Object[] attributes = property.GetCustomAttributes(false);
					if(attributes != null)
						foreach(Object attribute in attributes)
							foreach(String value in Utils.SearchProperties(attribute, false))
								yield return value;
				}

				if(property.CanRead
					&& property.GetIndexParameters().Length == 0
					&& Array.Exists<Type>(property.PropertyType.GetInterfaces(), p => p == typeof(IComparable)))
				{
					Object value = property.GetValue(instance, null);
					if(value != null)
						yield return value.ToString();
				}
			}
		}
	}
}