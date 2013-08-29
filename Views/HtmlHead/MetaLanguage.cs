using System.Web.UI;

using Diamond.Items;
using Spark.Html;

namespace Diamond.Views.HtmlHead
{
	/// <summary>
	/// Renders a Meta element for the Language of the context Item.
	/// </summary>
	public class MetaLanguage : WebControlView<IStandardTemplate>
	{
		/// <summary>
		/// Renders the HTML output.
		/// </summary>
		/// <param name="output">The response writer.</param>
		protected override void RenderNormal(System.Web.UI.HtmlTextWriter output)
		{
			////<META HTTP-EQUIV="Content-Language" CONTENT="en">

			output.RenderSelfClosingTag(
				HtmlTextWriterTag.Meta,
				new HtmlAttribute("http-equiv", "Content-Language"),
				new HtmlAttribute(HtmlTextWriterAttribute.Content, ViewModel.InnerItem.Language.Name));
		}
	}
}