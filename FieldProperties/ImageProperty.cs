using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;

namespace Diamond.FieldProperties
{
	/// <summary>
	/// Wraps a Sitecore ImageField
	/// </summary>
	public class ImageProperty : XmlProperty
	{
		/// <summary>
		/// The Image Field to wrap.
		/// </summary>
		private ImageField _imageField;

		#region Properties
		/// <summary>
		/// Gets or sets the Alt text.
		/// </summary>
		/// <value>
		/// The alt text.
		/// </value>
		public string Alt
		{
			get { return _imageField.Alt; }
			set { _imageField.Alt = value; }
		}

		/// <summary>
		/// Gets or sets the Border value.
		/// </summary>
		/// <value>
		/// The Border value.
		/// </value>
		public string Border
		{
			get { return _imageField.Border; }
			set { _imageField.Border = value; }
		}

		/// <summary>
		/// Gets or sets the HTML class.
		/// </summary>
		/// <value>
		/// The class.
		/// </value>
		public string Class
		{
			get { return _imageField.Class; }
			set { _imageField.Class = value; }
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		public string Height
		{
			get { return _imageField.Height; }
			set { _imageField.Height = value; }
		}

		/// <summary>
		/// Gets or sets the HSpace value.
		/// </summary>
		/// <value>
		/// The HSpace value.
		/// </value>
		public string HSpace
		{
			get { return _imageField.HSpace; }
			set { _imageField.HSpace = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the image is internal.
		/// </summary>
		/// <value>
		/// <c>true</c> if the image is internal; otherwise, <c>false</c>.
		/// </value>
		public bool IsInternal
		{
			get { return _imageField.IsInternal; }
		}

		/// <summary>
		/// Gets or sets the link type.
		/// </summary>
		/// <value>
		/// The type of the link.
		/// </value>
		public string LinkType
		{
			get { return _imageField.LinkType; }
			set { _imageField.LinkType = value; }
		}

		/// <summary>
		/// Gets or sets the database containing the the media.
		/// </summary>
		/// <value>
		/// The media database.
		/// </value>
		public Database MediaDatabase
		{
			get { return _imageField.MediaDatabase; }
			set { _imageField.MediaDatabase = value; }
		}

		/// <summary>
		/// Gets or sets the ID of the media item.
		/// </summary>
		/// <value>
		/// The media ID.
		/// </value>
		public ID MediaID
		{
			get { return _imageField.MediaID; }
			set { _imageField.MediaID = value; }
		}

		/// <summary>
		/// Gets the media item.
		/// </summary>
		/// <value>
		/// The media item.
		/// </value>
		public Item MediaItem
		{
			get { return _imageField.MediaItem; }
		}

		/// <summary>
		/// Gets or sets the language of the media item to use.
		/// </summary>
		/// <value>
		/// The media language.
		/// </value>
		public Language MediaLanguage
		{
			get { return _imageField.MediaLanguage; }
			set { _imageField.MediaLanguage = value; }
		}

		/// <summary>
		/// Gets or sets the version of the media item to use.
		/// </summary>
		/// <value>
		/// The media version.
		/// </value>
		public Version MediaVersion
		{
			get { return _imageField.MediaVersion; }
			set { _imageField.MediaVersion = value; }
		}

		/// <summary>
		/// Gets or sets the VSpace value.
		/// </summary>
		/// <value>
		/// The VSpace value.
		/// </value>
		public string VSpace
		{
			get { return _imageField.VSpace; }
			set { _imageField.VSpace = value; }
		}

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>
		/// The width.
		/// </value>
		public string Width
		{
			get { return _imageField.Width; }
			set { _imageField.Width = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		public ImageProperty(Field field)
			: base(field)
		{
			_imageField = field;
		}
		#endregion

		#region Operators
		/// <summary>
		/// Allows interoperability with Sitecore ImageField.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		/// <returns>A new instance of ImageProperty using the supplied field.</returns>
		public static implicit operator ImageProperty(ImageField field)
		{
			return new ImageProperty(field.InnerField);
		}

		/// <summary>
		/// Allows interoperability with Sitecore ImageField.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The property.InnerField.</returns>
		public static implicit operator ImageField(ImageProperty property)
		{
			return property.InnerField;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Relinks the specified item.
		/// </summary>
		/// <param name="itemLink">The item link.</param><param name="newLink">The new link.</param><contract><requires name="itemLink" condition="not null"/><requires name="newLink" condition="not null"/></contract>
		public override void Relink(ItemLink itemLink, Item newLink)
		{
			_imageField.Relink(itemLink, newLink);
		}

		/// <summary>
		/// Removes the link.
		/// </summary>
		/// <param name="itemLink">The item link.</param><contract><requires name="itemLink" condition="not null"/></contract>
		public override void RemoveLink(ItemLink itemLink)
		{
			_imageField.RemoveLink(itemLink);
		}

		/// <summary>
		/// Updates the link.
		/// </summary>
		/// <param name="itemLink">The link.</param><contract><requires name="itemLink" condition="not null"/></contract>
		public override void UpdateLink(ItemLink itemLink)
		{
			_imageField.UpdateLink(itemLink);
		}

		/// <summary>
		/// Validates the links.
		/// </summary>
		/// <param name="result">The result.</param><contract><requires name="result" condition="not null"/></contract>
		public override void ValidateLinks(LinksValidationResult result)
		{
			_imageField.ValidateLinks(result);
		}
		#endregion
	}
}
