namespace Diamond.Items
{
	using Sitecore.Data;
	using Sitecore.Data.Items;
	using Sitecore.Globalization;

	/// <summary>
	/// Represents a Sitecore Item that descends from the Standard Template.
	/// </summary>
	public interface IStandardTemplate
	{
		/// <summary>
		/// Gets the database that originated the Item.
		/// </summary>
		Database Database { get; }

		/// <summary>
		/// Gets the Display Name for the current version and language
		/// of the Item, otherwise returns the Item.Name value.
		/// </summary>
		string DisplayName { get; }

		/// <summary>
		/// Gets a value indicating whether the Item (version) is empty.
		/// </summary>
		bool Empty { get; }

		/// <summary>
		/// Gets a value indicating whether the Item has child Items.
		/// </summary>
		bool HasChildren { get; }

		/// <summary>
		/// Gets a value indicating whether the Item has any clones.
		/// </summary>
		bool HasClones { get; }

		/// <summary>
		/// Gets the help object associated with this Item.
		/// </summary>
		ItemHelp Help { get; }

		/// <summary>
		/// Gets the ID of the Item.
		/// </summary>
		ID ID { get; }

		/// <summary>
		/// Gets the internal Item version.
		/// </summary>
		Item InnerItem { get; }

		/// <summary>
		/// Gets a value indicating whether the Item is a clone.
		/// </summary>
		bool IsClone { get; }

		/// <summary>
		/// Gets a value indicating whether the Item is an Item Clone.
		/// </summary>
		bool IsItemClone { get; }

		/// <summary>
		/// Gets the Item's Key (lowercased Item.Name).
		/// </summary>
		string Key { get; }

		/// <summary>
		/// Gets the current Item Version's Language.
		/// </summary>
		Language Language { get; }

		/// <summary>
		/// Gets a value indicating whether the Item has been modified.
		/// </summary>
		bool Modified { get; }

		/// <summary>
		/// Gets the Item's Name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the ID of the Item's Parent.
		/// </summary>
		ID ParentID { get; }

		/// <summary>
		/// Gets the ID of the Item's Data Template.
		/// </summary>
		ID TemplateID { get; }

		/// <summary>
		/// Gets the name of the Item's Data Template.
		/// </summary>
		string TemplateName { get; }

		/// <summary>
		/// Gets the Item's Version.
		/// </summary>
		Version Version { get; }

		/// <summary>
		/// Verifies that the Item, in its current Language, is not effectively empty.
		/// </summary>
		/// <returns>True if the Item's Language has one or more Versions.</returns>
		bool LanguageVersionIsEmpty();

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <param name="targetLanguage">The expected language.</param>
		/// <returns>The current language version, or a language version in a more generalized language if available.</returns>
		IStandardTemplate GetBestFitLanguageVersion(Language targetLanguage);

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <typeparam name="TItem">The Diamond Item type.</typeparam>
		/// <param name="targetLanguage">
		/// The expected language.
		/// </param>
		/// <returns>
		/// The current language version, or a language version in a more generalized language if available.
		/// </returns>
		TItem GetBestFitLanguageVersion<TItem>(Language targetLanguage) where TItem : class, IStandardTemplate;

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <returns>The current language version, or a language version in a more generalized language if available.</returns>
		IStandardTemplate GetBestFitLanguageVersion();

		/// <summary>
		/// Given an Item in a specific language dialect (ex: en-GB), determines if the
		/// dialect has a version, and if not, attempts to find a more generalized language (ex: en).
		/// If there is a more generalized language, returns an item instance in that more generalized
		/// language. The instance may be "empty" and should be checked using the LanguageVersionIsEmpty() extension.
		/// </summary>
		/// <typeparam name="TItem">The Diamond Item type.</typeparam>
		/// <returns>
		/// The current language version, or a language version in a more generalized language if available.
		/// </returns>
		TItem GetBestFitLanguageVersion<TItem>() where TItem : class, IStandardTemplate;
	}
}
