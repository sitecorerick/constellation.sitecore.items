﻿namespace Constellation.Sitecore.Items.FieldProperties
{
	using global::Sitecore.Data.Fields;

	using System.Xml;

	/// <summary>
	/// Wraps a Sitecore XmlField.
	/// </summary>
	public class XmlProperty : FieldProperty
	{
		/// <summary>
		/// The field to wrap.
		/// </summary>
		private readonly XmlField xmlField;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="XmlProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		public XmlProperty(Field field)
			: base(field)
		{
			this.xmlField = field;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the root tag.
		/// </summary>
		/// <value>
		/// The root.
		/// </value>
		public string Root
		{
			get { return this.xmlField.Root; }
			set { this.xmlField.Root = value; }
		}

		/// <summary>
		/// Gets the XML document contained in this field value.
		/// </summary>
		/// <value>
		/// The XML.
		/// </value>
		public XmlDocument Xml
		{
			get { return this.xmlField.Xml; }
		}
		#endregion

		#region Operators
		/// <summary>
		/// Allows interoperability with XmlDocument.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The Property's XML value.</returns>
		public static implicit operator XmlDocument(XmlProperty property)
		{
			return property.Xml;
		}

		/// <summary>
		/// Allows interoperability with Sitecore XmlField.
		/// </summary>
		/// <param name="field">The field to convert.</param>
		/// <returns>A new instance of XmlProperty.</returns>
		public static implicit operator XmlProperty(XmlField field)
		{
			return new XmlProperty(field.InnerField);
		}

		/// <summary>
		/// Allows interoperability with Sitecore XmlField.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The property.InnerField.</returns>
		public static implicit operator XmlField(XmlProperty property)
		{
			return property.InnerField;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Gets the attribute.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <returns>
		/// The attribute.
		/// </returns>
		public string GetAttribute(string name)
		{
			return this.xmlField.GetAttribute(name);
		}

		/// <summary>
		/// Sets the attribute.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <param name="value">The attribute value.</param>
		public void SetAttribute(string name, string value)
		{
			this.xmlField.SetAttribute(name, value);
		}
		#endregion
	}
}
