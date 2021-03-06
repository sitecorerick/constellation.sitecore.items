﻿namespace Constellation.Sitecore.Items.FieldProperties
{
	using global::Sitecore.Data.Fields;

	/// <summary>
	/// Facade for the Sitecore CheckboxField.
	/// </summary>
	public class CheckboxProperty : FieldProperty
	{
		/// <summary>
		/// The Field to wrap.
		/// </summary>
		private readonly CheckboxField checkboxField;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CheckboxProperty"/> class.
		/// </summary>
		/// <param name="field">The Sitecore field to wrap.</param>
		public CheckboxProperty(Field field)
			: base(field)
		{
			this.checkboxField = field;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Constellation.Sitecore.Items.FieldProperties.CheckboxProperty"/> is checked.
		/// </summary>
		/// <value>
		/// <c>true</c> if checked; otherwise, <c>false</c>.
		/// </value>
		public bool Checked
		{
			get { return this.checkboxField.Checked; }
			set { this.checkboxField.Checked = value; }
		}
		#endregion

		#region Operators
		/// <summary>
		/// Converts a checkbox property to a Boolean value.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The value of property.Checked.</returns>
		public static implicit operator bool(CheckboxProperty property)
		{
			return property.Checked;
		}

		/// <summary>
		/// Allows automatic interoperability with Sitecore CheckboxFields.
		/// </summary>
		/// <param name="field">The field to convert.</param>
		/// <returns>A new instance of CheckboxProperty based on the Field.</returns>
		public static implicit operator CheckboxProperty(CheckboxField field)
		{
			return new CheckboxProperty(field.InnerField);
		}

		/// <summary>
		/// Allows automatic interoperability with Sitecore CheckboxFields.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>A Sitecore Field.</returns>
		public static implicit operator CheckboxField(CheckboxProperty property)
		{
			return property.InnerField;
		}
		#endregion
	}
}
