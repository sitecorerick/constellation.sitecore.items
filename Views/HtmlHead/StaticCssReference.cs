using System.Web.UI;

using Spark.Html;

namespace Diamond.Views.HtmlHead
{
	/// <summary>
	/// Renders a link tag for an external css file with the correct static hostname.
	/// </summary>
	/// <typeparam name="TModel">The model to use.</typeparam>
	public abstract class StaticCssReference<TModel> : StaticFileReference<TModel>
		where TModel : class
	{
		/// <summary>
		/// Gets or sets the relative path to the CSS source file.
		/// </summary>
		public string Href { get; set; }

		/// <summary>
		/// Renders the output of the control
		/// </summary>
		/// <param name="output">The response writer.</param>
		protected override void RenderNormal(HtmlTextWriter output)
		{
			// <link rel="stylesheet" type="text/css" href="/css/ie8.css">
			output.RenderLink(this.GetAbsoluteUrl(this.Href), "stylesheet", "text/css");
		}
	}
}