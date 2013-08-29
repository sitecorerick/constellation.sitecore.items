using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Diamond.FieldProperties
{
	/// <summary>
	/// Wraps a Sitecore ReferenceField
	/// </summary>
	public class ReferenceProperty : FieldProperty
	{
		/// <summary>
		/// The field to wrap.
		/// </summary>
		private ReferenceField referenceField;

		#region Properties
		/// <summary>
		/// Gets or sets the path to the target.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		public string Path
		{
			get { return referenceField.Path; }
			set { referenceField.Path = value; }
		}

		/// <summary>
		/// Gets the target ID.
		/// </summary>
		/// <value>
		/// The target ID.
		/// </value>
		public ID TargetID
		{
			get { return referenceField.TargetID; }
		}

		/// <summary>
		/// Gets the target item.
		/// </summary>
		/// <value>
		/// The target item.
		/// </value>
		public Item TargetItem
		{
			get { return referenceField.TargetItem; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ReferenceProperty"/> class.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		public ReferenceProperty(Field field)
			: base(field)
		{
			referenceField = field;
		}
		#endregion

		#region Operators
		/// <summary>
		/// Allows interoperability with Sitecore ReferenceField.
		/// </summary>
		/// <param name="field">The field to wrap.</param>
		/// <returns>A new instance of ReferenceProperty using the supplied field.</returns>
		public static implicit operator ReferenceProperty(ReferenceField field)
		{
			return new ReferenceProperty(field.InnerField);
		}

		/// <summary>
		/// Allows interoperability with Sitecore ReferenceField.
		/// </summary>
		/// <param name="property">The property to convert.</param>
		/// <returns>The property.InnerField.</returns>
		public static implicit operator ReferenceField(ReferenceProperty property)
		{
			return property.InnerField;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Relinks the specified item.
		/// </summary>
		/// <param name="itemLink">The item link.</param>
		/// <param name="newLink">The new link.
		/// </param>
		public override void Relink(ItemLink itemLink, Item newLink)
		{
			referenceField.Relink(itemLink, newLink);
		}

		/// <summary>
		/// Removes the link.
		/// </summary>
		/// <param name="itemLink">The item link.</param>
		public override void RemoveLink(ItemLink itemLink)
		{
			referenceField.RemoveLink(itemLink);
		}

		/// <summary>
		/// Validates the links.
		/// </summary>
		/// <param name="result">The result.</param>
		public override void ValidateLinks(LinksValidationResult result)
		{
			referenceField.ValidateLinks(result);
		}
		#endregion
	}
}
