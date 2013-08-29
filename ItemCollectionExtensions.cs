using System.Collections.Generic;
using System.Linq;

using Sitecore.Data.Items;
using Sitecore.Globalization;

using Diamond.Items;

namespace Diamond
{
	public static class ItemCollectionExtensions
	{
		public static IEnumerable<IStandardTemplate> AsStronglyTypedCollection(this Item[] items)
		{
			return items.Select(i => i.AsStronglyTyped());
		}

		public static IEnumerable<IStandardTemplate> AsStronglyTypedCollection(this Item[] items, Language language)
		{
			return items.Select(i => i.AsStronglyTyped(language));
		}

		public static IEnumerable<TItem> As<TItem>(this Item[] items)
			where TItem : class, IStandardTemplate
		{
			return items.Select(i => i.As<TItem>());
		}

		public static IEnumerable<TItem> As<TItem>(this Item[] items, Language language)
			where TItem : class, IStandardTemplate
		{
			return items.Select(i => i.As<TItem>(language));
		}
	}
}
