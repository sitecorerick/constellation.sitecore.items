namespace Diamond.CodeGeneration
{
	using NVelocity;
	using NVelocity.App;
	using System.IO;

	/// <summary>
	/// Handles the logic for CodeGen via NVelocity templates.
	/// </summary>
	public class Generator
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Generator"/> class.
		/// </summary>
		/// <param name="job">
		/// The item builder information.
		/// </param>
		public Generator(CodeGenerationJob job)
		{
			this.Job = job;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the <see cref="Job"/>.
		/// </summary>
		public CodeGenerationJob Job { get; private set; }
		#endregion

		#region Methods
		/// <summary>
		/// Generates the code based upon the supplied <see cref="Job"/>.
		/// </summary>
		public void GenerateCode()
		{
			TextReader reader = new StreamReader(this.Job.NVelocityTemplateFilePath);
			var template = reader.ReadToEnd();

			var baseContext = new VelocityContext();

			baseContext.Put("CodeGenerationJob", this.Job);

			var filePath = this.Job.FileOutputPath.EndsWith("\\") ? this.Job.FileOutputPath : this.Job.FileOutputPath + "\\";

			using (var sw = new StreamWriter(filePath + @"_Generated.cs"))
			{
				Velocity.Init();
				sw.Write(Sitecore.Text.NVelocity.VelocityHelper.Evaluate(baseContext, template, "item-builder"));
			}
		}
		#endregion
	}
}
