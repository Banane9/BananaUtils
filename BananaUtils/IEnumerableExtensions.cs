using System;
using System.Collections.Generic;
using System.Linq;

namespace BananaUtils
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Adds an item to the end of an <see cref="IEnumerable&lt;T&gt;"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to append the item to.</param>
        /// <param name="item">The item to append.</param>
        /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> with the given item appended to the end.</returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item)
        {
            if (source != null)
                foreach (var sourceItem in source)
                    yield return sourceItem;

            yield return item;
        }
    }
}