using System;
using System.Collections.Generic;
using System.Reflection;
using SAL.Flatbed;

namespace Plugin.Configuration
{
	internal static class Utils
	{
		/// <summary>Получить список поисковых параметров в плагине</summary>
		/// <param name="plugin">Экземпляр плагин для возврата поисковых строк</param>
		/// <returns>Найденные поисковые строки в плагине</returns>
		public static IEnumerable<String> GetPluginSearchMembers(IPluginDescription plugin)
		{
			foreach(String value in SearchProperties(plugin, false))
				yield return value;

			IPluginSettings settings = plugin.Instance as IPluginSettings;
			if(settings != null)
				foreach(String value in SearchProperties(settings.Settings, true))
					yield return value;
		}

		/// <summary>Поиск по свойствам экземпляра объекта</summary>
		/// <param name="instance">Объект, по свойствам которого поискать</param>
		/// <param name="searchAttributes">Поиск по атрибутам каждого свойства</param>
		/// <returns>Найденные поисковые строки в свойствах экземпляра объекта</returns>
		private static IEnumerable<String> SearchProperties(Object instance, Boolean searchAttributes)
		{
			PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy);
			foreach(PropertyInfo property in properties)
			{
				yield return property.Name;

				if(searchAttributes)
				{//Ищем по всем атрибутам, дабы не хардкодить конкретные атрибуты
					Object[] attributes = property.GetCustomAttributes(false);
					if(attributes != null)
						foreach(Object attribute in attributes)
							foreach(String value in Utils.SearchProperties(attribute, false))
								yield return value;
				}

				if(property.CanRead
					&& property.GetIndexParameters().Length == 0
					&& Array.Exists<Type>(property.PropertyType.GetInterfaces(), p => { return p == typeof(IComparable); }))
				{
					Object value = property.GetValue(instance, null);
					if(value != null)
						yield return value.ToString();
				}
			}
		}
	}
}