﻿using System;
using Sitecore.Data;

namespace Diamond
{
	/// <summary>
	/// Allows a class to be labeled as representing a specific Sitecore Data Template.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class TemplateIDAttribute : Attribute
	{
		/// <summary>
		/// Gets the ID of the Sitecore Data Template represented by the class.
		/// </summary>
		public ID ID { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TemplateIDAttribute"/> class.
		/// </summary>
		/// <param name="id">The ID of the Sitecore Data Template represnted by the class.</param>
		public TemplateIDAttribute(ID id)
		{
			ID = id;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TemplateIDAttribute"/> class.
		/// </summary>
		/// <param name="id">The ID of the Sitecore Data Template represnted by the class.</param>
		public TemplateIDAttribute(string id)
		{
			ID = new ID(id);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TemplateIDAttribute"/> class.
		/// </summary>
		/// <param name="id">The ID of the Sitecore Data Template represnted by the class.</param>
		public TemplateIDAttribute(Guid id)
		{
			ID = new ID(id);
		}
	}
}
