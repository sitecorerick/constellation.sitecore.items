using System.Web.UI;

using Spark.Html;

namespace Diamond.Views.HtmlHead
{
	/// <summary>
	/// Renders a script tag for an external Javascript file with the correct static hostname.
	/// </summary>
	/// <typeparam name="TModel">The model to use.</typeparam>
	public abstract class StaticJavascriptReference<TModel> : StaticFileReference<TModel>
		where TModel : class
	{
		/// <summary>
		/// Gets or sets the relative path to the Javascript source file.
		/// </summary>
		public string Src { get; set; }

		/// <summary>
		/// Renders the output of the control
		/// </summary>
		/// <param name="output">The response writer.</param>
		protected override void RenderNormal(HtmlTextWriter output)
		{
			using (output.RenderTag(
				HtmlTextWriterTag.Script,
				new HtmlAttribute(HtmlTextWriterAttribute.Type, "text/javascript"),
				new HtmlAttribute(HtmlTextWriterAttribute.Src, this.GetAbsoluteUrl(this.Src))))
			{
				// nothing needed inside.
			}
		}
	}
}