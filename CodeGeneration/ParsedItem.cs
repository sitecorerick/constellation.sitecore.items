namespace Diamond.CodeGeneration
{
	using Sitecore.Data.Fields;
	using Sitecore.Data.Items;
	using System.Collections.Generic;

	/// <summary>
	/// Holds all the Item information passed to NVelocity templates.
	/// </summary>
	public class ParsedItem
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ParsedItem"/> class.
		/// </summary>
		/// <param name="item">
		/// The item.
		/// </param>
		public ParsedItem(Item item)
		{
			this.ClassName = item.DisplayName.AsClassName();
			this.ID = item.ID.ToString();
			this.FieldItems = GenerateFieldList(item);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the class name.
		/// </summary>
		public string ClassName { get; set; }

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public string ID { get; set; }

		/// <summary>
		/// Gets the field items.
		/// </summary>
		public IList<ParsedField> FieldItems { get; private set; }
		#endregion

		/// <summary>
		/// Generates the list of Fields/
		/// </summary>
		/// <param name="item">
		/// The item.
		/// </param>
		/// <returns>
		/// The list of <see cref="ParsedField"/>.
		/// </returns>
		private static List<ParsedField> GenerateFieldList(BaseItem item)
		{
			var fields = new List<ParsedField>();

			item.Fields.ReadAll();

			foreach (Field field in item.Fields)
			{
				if (field == null || field.Name.StartsWith("__"))
				{
					continue;
				}

				fields.Add(new ParsedField()
				{
					ClassName = field.DisplayName.AsClassName(),
					ID = field.ID.ToString(),
					FieldType = field.Type.ToLower()
				});
			}

			return fields;
		}
	}
}
