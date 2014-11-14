using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BananaUtils
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks whether the given <see cref="object"/> inherits or implements the type parameter.
        /// </summary>
        /// <typeparam name="T">The Type that will be checked for being inherited or implemented.</typeparam>
        /// <param name="obj">The <see cref="object"/> to check on.</param>
        /// <returns>Whether the given <see cref="object"/> inherits or implements the type parameter.</returns>
        public static bool Is<T>(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj", "Object to check can't be null.");

            return obj.GetType().InheritsOrImplements(typeof(T));
        }

        /// <summary>
        /// Checks whether the given <see cref="object"/> inherits or implements the given <see cref="Type"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to check on.</param>
        /// <param name="type">The <see cref="TypeInfo"/> to check whether it's inherited or implemented.</param>
        /// <returns>Whether the given <see cref="object"/> inherits or implements the given <see cref="Type"/>.</returns>
        public static bool Is(this object obj, Type type)
        {
            if (obj == null)
                throw new ArgumentNullException("obj", "Object to check can't be null.");

            if (type == null)
                throw new ArgumentNullException("type", "Type to check can't be null.");

            return obj.GetType().InheritsOrImplements(type);
        }

        /// <summary>
        /// Checks whether the given <see cref="object"/> inherits or implements the given <see cref="TypeInfo"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to check on.</param>
        /// <param name="typeInfo">The <see cref="TypeInfo"/> to check whether it's inherited or implemented.</param>
        /// <returns>Whether the given <see cref="object"/> inherits or implements the given <see cref="TypeInfo"/>.</returns>
        public static bool Is(this object obj, TypeInfo typeInfo)
        {
            if (obj == null)
                throw new ArgumentNullException("obj", "Object to check can't be null.");

            if (typeInfo == null)
                throw new ArgumentNullException("typeInfo", "TypeInfo to check can't be null.");

            return obj.GetType().GetTypeInfo().InheritsOrImplements(typeInfo);
        }
    }
}