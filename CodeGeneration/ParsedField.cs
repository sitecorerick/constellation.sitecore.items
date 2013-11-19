namespace Diamond.CodeGeneration
{
	/// <summary>
	/// Represents the Field information passed to NVelocity templates.
	/// </summary>
	public class ParsedField
	{
		/// <summary>
		/// Gets or sets the field type.
		/// </summary>
		public string FieldType { get; set; }

		/// <summary>
		/// Gets or sets the class name.
		/// </summary>
		public string ClassName { get; set; }

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public string ID { get; set; }
	}
}
