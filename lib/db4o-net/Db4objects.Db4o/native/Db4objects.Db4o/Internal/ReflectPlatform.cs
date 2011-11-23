/* Copyright (C) 2007   Versant Inc.   http://www.db4o.com */

using System;
using Sharpen.Lang;

namespace Db4objects.Db4o.Internal
{
	public class ReflectPlatform
	{
		public static Type ForName(string typeName)
		{
			try
			{
				return TypeReference.FromString(typeName).Resolve();
			}
			catch
			{
				return null;
			}
		}

		public static object CreateInstance(string typeName)
		{
            return ReflectPlatform.CreateInstance(ForName(typeName));
		}

        public static object CreateInstance(Type type)
        {
            try
            {
                return Activator.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

	    public static string FullyQualifiedName(Type type)
	    {
	        return TypeReference.FromType(type).GetUnversionedName();
	    }

	    public static bool IsNamedClass(Type type)
	    {
	        return true;
	    }

        public static string SimpleName(Type type)
        {
            return type.Name;
        }
    }
}
