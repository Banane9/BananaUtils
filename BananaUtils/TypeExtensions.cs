using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BananaUtils
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Produces the default value for the given <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to produce the default value for.</param>
        /// <returns>The default value for the given <see cref="Type"/>.</returns>
        public static object GetDefaultValue(this Type type)
        {
            if (type == null)
                return null;

            return type.GetTypeInfo().IsValueType ? Activator.CreateInstance(type) : null;
        }

        /// <summary>
        /// Checks whether this <see cref="Type"/> inherits or implements the given one.
        /// </summary>
        /// <param name="child">The <see cref="Type"/> to check whether it inherits or implements the given one.</param>
        /// <param name="parent">The <see cref="Type"/> to check whether it's inherited or implemented.</param>
        /// <returns>Whether this one inherits or implements the given one.</returns>
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            if (child == null)
                throw new ArgumentNullException("child", "Child Type can't be null.");

            if (parent == null)
                throw new ArgumentNullException("parent", "Parent Type can't be null.");

            return child.GetTypeInfo().InheritsOrImplements(parent.GetTypeInfo());
        }
    }
}