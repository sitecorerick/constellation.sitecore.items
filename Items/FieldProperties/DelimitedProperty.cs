﻿namespace Constellation.Sitecore.Items.FieldProperties
{
	using global::Sitecore.Data.Fields;
	using global::Sitecore.Data.Items;
	using global::Sitecore.Links;
	using global::Sitecore.Text;

	using System.Collections;

	/// <summary>
	/// Facade for the Sitecore DelimitedField.
	/// </summary>
	public class DelimitedProperty : FieldProperty
	{
		/// <summary>
		/// The Field to wrap.
		/// </summary>
		private readonly DelimitedField delimitedField;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DelimitedProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		public DelimitedProperty(Field field)
			: base(field)
		{
			this.delimitedField = new DelimitedField(field, this.Separator);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DelimitedProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		/// <param name="separator">The character to use for delimiting values.</param>
		public DelimitedProperty(Field field, char separator)
			: base(field)
		{
			this.delimitedField = new DelimitedField(field, separator);
			this.Separator = separator;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the count of items in this field.
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		public int Count
		{
			get { return this.delimitedField.Count; }
		}

		/// <summary>
		/// Gets an array of values.
		/// </summary>
		/// <value>
		/// The members of the array.
		/// </value>
		public string[] Items
		{
			get { return this.delimitedField.Items; }
		}

		/// <summary>
		/// Gets the value as <see cref="T:Sitecore.Text.ListString"/>.
		/// </summary>
		/// <value>
		/// The list.
		/// </value>
		public ListString List
		{
			get { return this.delimitedField.List; }
		}

		/// <summary>
		/// Gets the character to use for delimiting.
		/// </summary>
		public char Separator { get; private set; }
		#endregion

		#region Indexers
		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">The index of the value to return.</param>
		/// <returns>The string at the specified index.</returns>
		public string this[int index]
		{
			get { return this.delimitedField[index]; }
		}
		#endregion

		#region Operators
		/// <summary>
		/// Allows automatic interoperability with Sitecore DelimitedFields.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>A new instance of DelimitedProperty using the supplied field.</returns>
		public static implicit operator DelimitedProperty(DelimitedField field)
		{
			return new DelimitedProperty(field.InnerField);
		}

		/// <summary>
		/// Allows automatic interoperability with Sitecore DelimitedFields.
		/// </summary>
		/// <param name="property">The property.</param>
		/// <returns>The property.InnerField witha appropriate configuration.</returns>
		public static implicit operator DelimitedField(DelimitedProperty property)
		{
			return new DelimitedField(property.InnerField, property.Separator);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds the specified string.
		/// </summary>
		/// <param name="item">The string to add.</param>
		/// <returns>
		/// The string with the addition.
		/// </returns>
		public string Add(string item)
		{
			return this.delimitedField.Add(item);
		}

		/// <summary>
		/// Adds the specified string.
		/// </summary>
		/// <param name="item">The string to add.</param>
		/// <param name="includeBlank">Whether to include a blank value.</param>
		/// <returns>
		/// The string with the addition.
		/// </returns>
		public string Add(string item, bool includeBlank)
		{
			return this.delimitedField.Add(item, includeBlank);
		}

		/// <summary>
		/// Gets the index of an item in the value.
		/// </summary>
		/// <param name="item">The string to find.</param>
		/// <returns>
		/// The index of the string.
		/// </returns>
		public int CharIndexOf(string item)
		{
			return this.delimitedField.CharIndexOf(item);
		}

		/// <summary>
		/// Determines if the specified item is present in the value.
		/// </summary>
		/// <param name="item">The string to find.</param>
		/// <returns>
		/// Returns <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(string item)
		{
			return this.delimitedField.Contains(item);
		}

		/// <summary>
		/// Gets an enumerator.
		/// </summary>
		/// <returns>
		/// The enumerator.
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			return this.delimitedField.GetEnumerator();
		}

		/// <summary>
		/// Get the index of an item.
		/// </summary>
		/// <param name="item">Item to find.</param>
		/// <returns>
		/// The index position of the item if the item is found, or -1 if it is not.
		/// </returns>
		public int IndexOf(string item)
		{
			return this.delimitedField.IndexOf(item);
		}

		/// <summary>
		/// Removes the specified item.
		/// </summary>
		/// <param name="item">Item to remove.</param>
		/// <returns>
		/// The string with the item removed.
		/// </returns>
		public string Remove(string item)
		{
			return this.delimitedField.Remove(item);
		}

		/// <summary>
		/// Replaces the specified item.
		/// </summary>
		/// <param name="item">Item to replace.</param>
		/// <param name="with">The replacement.</param>
		/// <returns>
		/// The string with the item replaced.
		/// </returns>
		public string Replace(string item, string with)
		{
			return this.delimitedField.Replace(item, with);
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return this.delimitedField.ToString();
		}

		/// <summary>
		/// Relinks the specified item.
		/// </summary>
		/// <param name="itemLink">The item link.</param><param name="newLink">The new link.</param>
		public override void Relink(ItemLink itemLink, Item newLink)
		{
			this.delimitedField.Relink(itemLink, newLink);
		}

		/// <summary>
		/// Removes the link.
		/// </summary>
		/// <param name="itemLink">The item link.</param>
		public override void RemoveLink(ItemLink itemLink)
		{
			this.delimitedField.RemoveLink(itemLink);
		}

		/// <summary>
		/// Validates the links.
		/// </summary>
		/// <param name="result">The result.</param>
		public override void ValidateLinks(LinksValidationResult result)
		{
			this.delimitedField.ValidateLinks(result);
		}
		#endregion
	}
}
