namespace Constellation.Sitecore.Items
{
	using global::Sitecore.ContentSearch.SearchTypes;
	using global::Sitecore.Globalization;

	/// <summary>
	/// The base class for custom Plain Old Class Objects generated
	/// by a Constellation.Sitecore.Items type generator.
	/// </summary>
	public class Poco : SearchResultItem
	{
		/// <summary>
		/// Converts a Poco into a strongly typed Item descending from
		/// IStandardTemplateItem. Will return null if there is no class
		/// defined for the Item's TemplateID.
		/// </summary>
		/// <typeparam name="TItem">The Type of object to create, must descend from IStandardTemplateItem.</typeparam>
		/// <returns>An instance of TItem or null if conversion fails.</returns>
		public TItem As<TItem>()
			where TItem : class, IStandardTemplate
		{
			var item = this.GetItem();
			return item.As<TItem>();
		}

		/// <summary>
		/// Converts a Poco into a strongly typed Item descending from
		/// IStandardTemplateItem. Will return null if there is no class
		/// defined for the Item's TemplateID.
		/// </summary>
		/// <param name="language">
		/// The target language for the item.
		/// </param>
		/// <typeparam name="TItem">
		/// The Type of object to create, must descend from IStandardTemplateItem.
		/// </typeparam>
		/// <returns>
		/// An instance of TItem or null if conversion fails.
		/// </returns>
		public TItem As<TItem>(Language language)
			where TItem : class, IStandardTemplate
		{
			var item = this.GetItem();
			return item.As<TItem>(language);
		}

		/// <summary>
		/// Converts a Poco into a strongly typed Item descending from
		/// IStandardTemplateItem. Will return null if there is no class
		/// defined for the Item's TemplateID.
		/// </summary>
		/// <returns>An instance of IStandardTemplateItem or null.</returns>
		public IStandardTemplate AsStronglyTyped()
		{
			var item = this.GetItem();
			return item.AsStronglyTyped();
		}

		/// <summary>
		/// Converts a Poco into a strongly typed Item descending from
		/// IStandardTemplateItem. Will return null if there is no class
		/// defined for the Item's TemplateID.
		/// </summary>
		/// <param name="language">
		/// The target language for the item.
		/// </param>
		/// <returns>An instance of IStandardTemplateItem or null.</returns>
		public IStandardTemplate AsStronglyTyped(Language language)
		{
			var item = this.GetItem();
			return item.AsStronglyTyped(language);
		}
	}
}
