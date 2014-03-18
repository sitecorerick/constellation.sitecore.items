

namespace Diamond.Views.HtmlHead
{
	using Spark.Html;
	using System;
	using System.Collections.Generic;
	using System.Web.UI;

	/// <summary>
	/// Renders a link tag for an external css file with the correct static hostname.
	/// </summary>
	/// <typeparam name="TModel">The model to use.</typeparam>
	public abstract class StaticCssReference<TModel> : StaticFileReference<TModel>
		where TModel : class
	{

		#region Properties
		/// <summary>
		/// Gets or sets the relative path to the CSS source file.
		/// </summary>
		public string Href { get; set; }

		/// <summary>
		/// Gets or sets the relevance attribute for the link tag; default is "stylesheet".
		/// </summary>
		public string Rel { get; set; }

		/// <summary>
		/// Gets or sets the media attribute value for the link tag.
		/// </summary>
		public string Media { get; set; }

		/// <summary>
		/// Gets or sets the type attribute value for the link tag.
		/// </summary>
		[Obsolete]
		public string LinkType { get; set; }
		#endregion

		/// <summary>
		/// Renders the output of the control
		/// </summary>
		/// <param name="output">The response writer.</param>
		protected override void RenderNormal(HtmlTextWriter output)
		{
			// <link rel="stylesheet" media="screen" type="text/css" href="/css/ie8.css">
			var attributes = new List<HtmlAttribute>();

			attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Href, this.GetAbsoluteUrl(this.Href)));

			if (!string.IsNullOrEmpty(this.Rel))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Rel, this.Rel));
			}

			if (!string.IsNullOrEmpty(this.Media))
			{
				attributes.Add(new HtmlAttribute("media", this.Media));
			}

			if (!string.IsNullOrEmpty(this.LinkType))
			{
				attributes.Add(new HtmlAttribute(HtmlTextWriterAttribute.Type, this.LinkType));
			}

			output.RenderSelfClosingTag(HtmlTextWriterTag.Link, attributes.ToArray());
		}
	}
}