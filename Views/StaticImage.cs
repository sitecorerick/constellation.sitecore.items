using Diamond.Items;
using Spark.Html;

namespace Diamond.Views
{
	/// <summary>
	/// Renders an image tag using the designated static file host.
	/// </summary>
	public abstract class StaticImage : StaticFileReference<IStandardTemplate>
	{
		/// <summary>
		/// Gets or sets the alternate text for the image file.
		/// </summary>
		public string Alt { get; set; }

		/// <summary>
		/// Gets or sets the relative path to the image file.
		/// </summary>
		public string Src { get; set; }

		/// <summary>
		/// Renders the output of the control
		/// </summary>
		/// <param name="output">The response writer.</param>
		protected override void RenderNormal(System.Web.UI.HtmlTextWriter output)
		{
			output.RenderImg(this.GetAbsoluteUrl(this.Src), this.Alt);
		}
	}
}