using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BananaUtils
{
    public static class TypeInfoExtensions
    {
        /// <summary>
        /// Produces the default value for the given <see cref="TypeInfo"/>.
        /// </summary>
        /// <param name="typeInfo">The <see cref="TypeInfo"/> to produce the default value for.</param>
        /// <returns>The default value for the given <see cref="TypeInfo"/>.</returns>
        public static object GetDefaultValue(this TypeInfo typeInfo)
        {
            if (typeInfo == null)
                return null;

            return typeInfo.IsValueType ? Activator.CreateInstance(typeInfo.AsType()) : null;
        }

        /// <summary>
        /// Checks whether this <see cref="TypeInfo"/> inherits or implements the given one.
        /// </summary>
        /// <param name="child">The <see cref="TypeInfo"/> to check whether it inherits or implements the given one.</param>
        /// <param name="parent">The <see cref="TypeInfo"/> to check whether it's inherited or implemented.</param>
        /// <returns>Whether this one inherits or implements the given one.</returns>
        public static bool InheritsOrImplements(this TypeInfo child, TypeInfo parent)
        {
            if (child == null || parent == null)
                return false;

            parent = resolveGenericTypeDefinition(parent);

            var currentChild = child.IsGenericType
                                   ? child.GetGenericTypeDefinition().GetTypeInfo()
                                   : child;

            while (currentChild != typeof(object).GetTypeInfo())
            {
                if (parent == currentChild || hasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.GetTypeInfo().IsGenericType
                                   ? currentChild.BaseType.GetTypeInfo().GetGenericTypeDefinition().GetTypeInfo()
                                   : currentChild.BaseType.GetTypeInfo();

                if (currentChild == null)
                    return false;
            }

            return false;
        }

        private static bool hasAnyInterfaces(TypeInfo parent, TypeInfo child)
        {
            return child.ImplementedInterfaces
                        .Any(childInterface =>
                        {
                            var currentInterface = childInterface.GetTypeInfo().IsGenericType
                                                       ? childInterface.GetGenericTypeDefinition()
                                                       : childInterface;

                            return currentInterface.GetTypeInfo() == parent;
                        });
        }

        private static TypeInfo resolveGenericTypeDefinition(TypeInfo parent)
        {
            var shouldUseGenericType = !(parent.IsGenericType && parent.GetGenericTypeDefinition().GetTypeInfo() != parent);

            if (parent.IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition().GetTypeInfo();

            return parent;
        }
    }
}