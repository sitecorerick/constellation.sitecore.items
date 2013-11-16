﻿namespace Diamond.FieldProperties
{
	using Sitecore.Data;
	using Sitecore.Data.Fields;
	using Sitecore.Links;

	/// <summary>
	/// Wraps the Sitecore WordDocumentField
	/// </summary>
	public class WordDocumentProperty : FieldProperty
	{
		/// <summary>
		/// The field to wrap.
		/// </summary>
		private readonly WordDocumentField wordDocumentField;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="WordDocumentProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		public WordDocumentProperty(Field field)
			: base(field)
		{
			this.wordDocumentField = field;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the plain text.
		/// </summary>
		/// <value>
		/// The plain text.
		/// </value>
		public string PlainText
		{
			get
			{
				return this.wordDocumentField.PlainText;
			}
		}

		/// <summary>
		/// Gets the HTML.
		/// </summary>
		/// <value>
		/// The HTML.
		/// </value>
		public string Html
		{
			get
			{
				return this.wordDocumentField.Html;
			}
		}

		/// <summary>
		/// Gets the styles.
		/// </summary>
		/// <value>
		/// The styles.
		/// </value>
		public string Styles
		{
			get
			{
				return this.wordDocumentField.Styles;
			}
		}

		/// <summary>
		/// Gets the BLOB id.
		/// </summary>
		/// <value>
		/// The BLOB id.
		/// </value>
		public ID BlobId
		{
			get
			{
				return this.wordDocumentField.BlobId;
			}
		}
		#endregion

		#region Operators
		/// <summary>
		/// Allows interoperability with Sitecore WordDocumentField.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		/// <returns>A new instance of WordDocumentProperty using the supplied field.</returns>
		public static implicit operator WordDocumentProperty(WordDocumentField field)
		{
			return new WordDocumentProperty(field.InnerField);
		}

		/// <summary>
		/// Allows interoperability with Sitecore WordDocumentField.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The property.InnerField.</returns>
		public static implicit operator WordDocumentField(WordDocumentProperty property)
		{
			return property.InnerField;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Validates the links.
		/// </summary>
		/// <param name="result">The result.</param><contract><requires name="result" condition="not null"/></contract>
		public override void ValidateLinks(LinksValidationResult result)
		{
			this.wordDocumentField.ValidateLinks(result);
		}
		#endregion
	}
}
