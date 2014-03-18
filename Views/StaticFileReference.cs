namespace Diamond.Views
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Text;
	using System.Web;

	/// <summary>
	/// Base class for renderings that turn local dev urls into absolute
	/// URLs to enhance the load time of static assets like CSS files.
	/// </summary>
	/// <typeparam name="TModel">The model to use.</typeparam>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
	public abstract class StaticFileReference<TModel> : WebControlView<TModel>
		where TModel : class
	{
		/// <summary>
		/// return the hostname based upon the model or whatever custom business rules are
		/// required. Returning null or string empty is valid, but the url will remain relative.
		/// </summary>
		/// <returns>the hostname to use.</returns>
		protected abstract string GetHostname();

		/// <summary>
		/// Gets the specified hostname for the installation and prefixes the supplied
		/// file source with it.
		/// </summary>
		/// <param name="path">The relative path.</param>
		/// <returns>An absolute URL, including scheme.</returns>
		protected string GetAbsoluteUrl(string path)
		{
			var hostName = this.GetHostname();

			if (string.IsNullOrEmpty(hostName))
			{
				return path;
			}

			if (string.IsNullOrEmpty(path))
			{
				return path;
			}

			var builder = new StringBuilder(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Scheme));
			builder.Append(hostName);

			if (!path.StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
			{
				builder.Append("/");
			}

			builder.Append(path);

			return builder.ToString();
		}
	}
}