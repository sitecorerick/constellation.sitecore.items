namespace Diamond.CodeGeneration
{
	using Sitecore.Data.Items;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;

	/// <summary>
	/// Holds all the information needed for CodeGen.
	/// </summary>
	public class CodeGenerationJob
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodeGenerationJob"/> class.
		/// </summary>
		/// <param name="nVelocityTemplatePath">
		/// the file system path to the NVelocity template to use when generating Items.
		/// </param>
		/// <param name="items">
		/// The items to use for code generation.
		/// </param>
		/// <param name="baseNameSpace">
		/// The base name space.
		/// </param>
		/// <param name="fileOutputPath">
		/// The file output path.
		/// </param>
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public CodeGenerationJob(string nVelocityTemplatePath, IList<Item> items, string baseNameSpace, string fileOutputPath)
		{
			this.NVelocityTemplateFilePath = nVelocityTemplatePath;
			this.JobItems = new List<ParsedItem>(items.Select(i => new ParsedItem(i)));
			this.FileOutputPath = fileOutputPath;
			this.ItemNamespaces = new Dictionary<string, IEnumerable<ParsedItem>>();

			foreach (var groupItem in items.GroupBy(i => i.Paths.ParentPath.Replace("/sitecore/templates/", string.Empty)))
			{
				var key = baseNameSpace + "." + groupItem.Key.Split('/').AsNamespace();
				var queuedItem = groupItem.Select(item => new ParsedItem(item)).ToList();

				this.ItemNamespaces.Add(key, queuedItem);
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the file output path.
		/// </summary>
		public string FileOutputPath { get; set; }

		/// <summary>
		/// Gets the list of <see cref="ParsedItem"/>.
		/// </summary>
		public IList<ParsedItem> JobItems { get; private set; }

		/// <summary>
		/// Gets the item namespaces.
		/// </summary>
		public Dictionary<string, IEnumerable<ParsedItem>> ItemNamespaces { get; private set; }

		/// <summary>
		/// Gets the file system path to the NVelocity template to use when generating Items.
		/// </summary>
		public string NVelocityTemplateFilePath { get; private set; }
		#endregion
	}
}
