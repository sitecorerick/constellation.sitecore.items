﻿namespace Diamond.FieldProperties
{
	using Sitecore.Data.Fields;
	using System;

	/// <summary>
	/// Facade for the Sitecore DateField.
	/// </summary>
	public class DateProperty : FieldProperty
	{
		/// <summary>
		/// The Sitecore field to wrap.
		/// </summary>
		private readonly DateField dateField;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DateProperty"/> class.
		/// </summary>
		/// <param name="field">The Field to wrap.</param>
		public DateProperty(Field field)
			: base(field)
		{
			this.dateField = field;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the value as a <see cref="T:System.DateTime"/>.
		/// </summary>
		/// <value>
		/// The date time.
		/// </value>
		public DateTime DateTime
		{
			get { return this.dateField.DateTime; }
		}
		#endregion

		#region Operators
		/// <summary>
		/// Converts a DateProperty into a DateTime.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The property.DateTime value.</returns>
		public static implicit operator DateTime(DateProperty property)
		{
			return property.DateTime;
		}

		/// <summary>
		/// Allows automatic interoperability with Sitecore DateFields.
		/// </summary>
		/// <param name="field">The field to convert.</param>
		/// <returns>A new instance of DateProperty based on the field.</returns>
		public static implicit operator DateProperty(DateField field)
		{
			return new DateProperty(field.InnerField);
		}

		/// <summary>
		/// Allows automatic interoperability with Sitecore DateFields.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>A Sitecore Field.</returns>
		public static implicit operator DateField(DateProperty property)
		{
			return property.InnerField;
		}
		#endregion
	}
}
