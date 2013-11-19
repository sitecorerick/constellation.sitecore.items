namespace Diamond.CodeGeneration
{
	using HedgehogDevelopment.SitecoreProject.VSIP.CodeGeneration.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class ParsingUtility
	{
		public static string GetInheritanceChain(string _namespace, SitecoreTemplate template)
		{
			var interfaces = GetInheritedInterfaces(new List<string>(), _namespace, template);

			return interfaces.Any() ? ", " + string.Join(", ", interfaces) : string.Empty;
		}

		private static List<string> GetInheritedInterfaces(List<string> interfaces, string _namespace, SitecoreTemplate template)
		{
			if (interfaces == null)
			{
				interfaces = new List<string>();
			}

			foreach (SitecoreTemplate baseTemplate in template.BaseTemplates)
			{
				interfaces.Add(
					string.Concat(GetFullyQualifiedName(_namespace, baseTemplate).Substring(0, GetFullyQualifiedName(_namespace, baseTemplate).LastIndexOf(".")),
					".",
					baseTemplate.Name.AsInterfaceName()));

				interfaces = GetInheritedInterfaces(interfaces, _namespace, baseTemplate);
			}

			return interfaces;
		}

		/// <summary>
		/// Gets the fuly qualified name of the object.
		/// </summary>
		/// <param name="defaultNamespace">The default namespace.</param>
		/// <param name="template">The template.</param>
		public static string GetFullyQualifiedName(string defaultNamespace, SitecoreItem item)
		{
			return GetFullyQualifiedName(defaultNamespace, item, (string s) => s);
		}

		/// <summary>
		/// Gets the fuly qualified name of the object.
		/// </summary>
		/// <param name="defaultNamespace">The default namespace.</param>
		/// <param name="template">The template.</param>
		/// <param name="nameFunc">The function to run the template name through.</param>
		public static string GetFullyQualifiedName(string defaultNamespace, SitecoreItem item, Func<string, string> nameFunc)
		{
			return string.Concat(GetNamespace(defaultNamespace, item, true), ".", nameFunc(item.Name));
		}

		/// <summary>
		/// Gets the calculated namespace for the template
		/// </summary>
		public static string GetNamespace(string defaultNamespace, SitecoreItem item, bool includeGlobal = false)
		{


			List<string> namespaceSegments = new List<string>();
			//namespaceSegments.Add(defaultNamespace);
			namespaceSegments.Add(item.Namespace);
			string ns = namespaceSegments.AsNamespace().Replace(".sitecore.templates", string.Empty); // use an extension method in the supporting assembly

			return includeGlobal ? string.Concat("global::", ns) : ns;
		}

		/// <summary>
		/// Takes multiple namespaces ('.' delimited strings) and joins them together
		/// </summary>
		/// <param name="namespaces">The namespaces.</param>
		public static string JoinNamespaces(params string[] namespaces)
		{
			// leverage an extension method in the support assembly
			return namespaces.AsNamespace();
		}

		/// <summary>
		/// Gets a list of all fields from the template. 
		/// <para>If desired, fields from all base templates will be included.</para>
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="includeBases">if set to <c>true</c> include base template's fields.</param>
		public static List<SitecoreField> GetFieldsForTemplate(SitecoreTemplate item, bool includeBases)
		{
			List<SitecoreField> fields = new List<SitecoreField>();

			// Add direct fields that aren't ignored
			fields.AddRange(item.Fields.Where(f => GetCustomProperty(f.Data, "ignore") != "true"));

			if (includeBases)
			{
				// leverage an extenstion method to recursively select base templates, then flatten the fields down
				IEnumerable<SitecoreField> baseFields = item.BaseTemplates.SelectRecursive(i => i.BaseTemplates).SelectMany(t => t.Fields);

				// only grab base fields who aren't ignored
				fields.AddRange(baseFields.Where(f => GetCustomProperty(f.Data, "ignore") != "true"));
			}

			return fields;
		}

		/// <summary>
		/// Given a sitecore field, returns the name of the property to use.
		/// <para>If the field is plural, it returns a plural property name</para>
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>A string to use for a property representing the field</returns>
		public static string GetPropertyName(SitecoreField field)
		{
			// has the field been configured in TDS with a custom name?
			string customName = GetCustomProperty(field.Data, "name");
			if (!string.IsNullOrEmpty(customName))
			{
				return customName;
			}

			bool isFieldPlural = IsFieldPlural(field);

			return field.Name.AsPropertyName(isFieldPlural);
		}

		/// <summary>
		/// Determines whether the Sitecore Field holds multiple values.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>
		///   <c>true</c> if the field holds multiple values; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsFieldPlural(SitecoreField field)
		{
			string[] multipleValueFields = new string[]
	{
			"treelist",
			"treelistex",
			"treelist descriptive",
			"checklist",
			"multilist"
	};

			return multipleValueFields.Contains(field.Type.ToLower());
		}

		/// <summary>
		/// Gets a custom propery from the data assuming it is querystring format
		/// </summary>
		/// <param name="data">A string in query string format.</param>
		/// <param name="key">The key to get the value for.</param>
		/// <returns>The value, or an empty string</returns>
		public static string GetCustomProperty(string data, string key)
		{
			if (string.IsNullOrEmpty(data))
				return "";

			string[] strArray = data.Split(new char[] { '&' });
			string keyEquals = key + "=";
			int length = keyEquals.Length;
			foreach (string keyValuePair in strArray)
			{
				if ((keyValuePair.Length > length) && keyValuePair.StartsWith(keyEquals, StringComparison.OrdinalIgnoreCase))
				{
					return keyValuePair.Substring(length);
				}
			}
			return "";
		}
	}
}
