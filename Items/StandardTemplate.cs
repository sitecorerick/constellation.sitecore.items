namespace Constellation.Sitecore.Items
{
	using global::Sitecore.Data;
	using global::Sitecore.Data.Fields;
	using global::Sitecore.Data.Items;
	using global::Sitecore.Globalization;

	/// <summary>
	/// Represents a Sitecore Item that descends from the Standard Template.
	/// </summary>
	[TemplateID("{1930BBEB-7805-471A-A3BE-4858AC7CF696}")]
	public class StandardTemplate : CustomItem, IStandardTemplate
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="StandardTemplate"/> class.
		/// </summary>
		/// <param name="item">The Item to wrap.</param>
		public StandardTemplate(Item item)
			: base(item)
		{
			// Nothing to do.
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets a value indicating whether the Item (version) is empty.
		/// </summary>
		public bool Empty
		{
			get { return InnerItem.Empty; }
		}

		/// <summary>
		/// Gets a value indicating whether the Item has child Items.
		/// </summary>
		public bool HasChildren
		{
			get { return InnerItem.HasChildren; }
		}

		/// <summary>
		/// Gets a value indicating whether the Item has any clones.
		/// </summary>
		public bool HasClones
		{
			get { return InnerItem.HasClones; }
		}

		/// <summary>
		/// Gets the help object associated with this Item.
		/// </summary>
		public ItemHelp Help
		{
			get { return InnerItem.Help; }
		}

		/// <summary>
		/// Gets a value indicating whether the Item is a clone.
		/// </summary>
		public bool IsClone
		{
			get { return InnerItem.IsClone; }
		}

		/// <summary>
		/// Gets a value indicating whether the Item is an Item Clone.
		/// </summary>
		public bool IsItemClone
		{
			get { return InnerItem.IsItemClone; }
		}

		/// <summary>
		/// Gets the Item's Key (lowercased Item.Name).
		/// </summary>
		public string Key
		{
			get { return InnerItem.Key; }
		}

		/// <summary>
		/// Gets the current Item Version's Language.
		/// </summary>
		public Language Language
		{
			get { return InnerItem.Language; }
		}

		/// <summary>
		/// Gets a value indicating whether the Item has been modified.
		/// </summary>
		public bool Modified
		{
			get { return InnerItem.Modified; }
		}

		/// <summary>
		/// Gets the ID of the Item's Parent.
		/// </summary>
		public ID ParentID
		{
			get { return InnerItem.ParentID; }
		}

		/// <summary>
		/// Gets the ID of the Item's Data Template.
		/// </summary>
		public ID TemplateID
		{
			get { return InnerItem.TemplateID; }
		}

		/// <summary>
		/// Gets the name of the Item's Data Template.
		/// </summary>
		public string TemplateName
		{
			get { return InnerItem.TemplateName; }
		}

		/// <summary>
		/// Gets the Item's Version.
		/// </summary>
		public Version Version
		{
			get { return InnerItem.Version; }
		}
		#endregion

		#region Operators
		/// <summary>
		/// Provides compatibility with Sitecore Item.
		/// </summary>
		/// <param name="item">The Item to convert.</param>
		/// <returns>A new instance of IStandardTemplateItem.</returns>
		public static implicit operator StandardTemplate(Item item)
		{
			return ItemFactory.GetStronglyTypedItem(item);
		}

		/// <summary>
		/// Provides compatibility with Sitecore Item.
		/// </summary>
		/// <param name="item">The StandardTemplateItem to convert.</param>
		/// <returns>The InnerItem.</returns>
		public static implicit operator Item(StandardTemplate item)
		{
			return item.InnerItem;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Verifies that the Item, in its current Language, is not effectively empty.
		/// </summary>
		/// <returns>True if the Item's Language has one or more Versions.</returns>
		public bool LanguageVersionIsEmpty()
		{
			return this.InnerItem.LanguageVersionIsEmpty();
		}

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <param name="targetLanguage">The expected language.</param>
		/// <returns>The current language version, or a language version in a more generalized language if available.</returns>
		public IStandardTemplate GetBestFitLanguageVersion(Language targetLanguage)
		{
			return this.InnerItem.GetBestFitLanguageVersion(targetLanguage).AsStronglyTyped();
		}

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <typeparam name="TItem">The Constellation.Sitecore.Items Item Type</typeparam>
		/// <param name="targetLanguage">
		/// The expected language.
		/// </param>
		/// <returns>
		/// The current language version, or a language version in a more generalized language if available.
		/// </returns>
		public TItem GetBestFitLanguageVersion<TItem>(Language targetLanguage) where TItem : class, IStandardTemplate
		{
			return this.InnerItem.GetBestFitLanguageVersion(targetLanguage).As<TItem>();
		}

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <returns>The current language version, or a language version in a more generalized language if available.</returns>
		public IStandardTemplate GetBestFitLanguageVersion()
		{
			return this.InnerItem.GetBestFitLanguageVersion().AsStronglyTyped();
		}

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <typeparam name="TItem">The Constellation.Sitecore.Items Item Type</typeparam>
		/// <returns>The current language version, or a language version in a more generalized language if available.</returns>
		public TItem GetBestFitLanguageVersion<TItem>() where TItem : class, IStandardTemplate
		{
			return this.InnerItem.GetBestFitLanguageVersion().As<TItem>();
		}

		/// <summary>
		/// Shorthand for accessing a Field from the inner item.
		/// </summary>
		/// <param name="name">The Name of the field.</param>
		/// <returns>The field with the matching name or null.</returns>
		protected Field GetField(string name)
		{
			return this.InnerItem.Fields[name];
		}

		/// <summary>
		/// Shorthand for accessing a Field from the inner item.
		/// </summary>
		/// <param name="id">The ID of the field.</param>
		/// <returns>The field with the matching ID or null.</returns>
		protected Field GetField(ID id)
		{
			return this.InnerItem.Fields[id];
		}
		#endregion
	}
}
