using System;
namespace CSharp.Demo9a.Helper
{
	public class StringHelper
	{
		public static bool IsNullOrEmpty(string value)
		{
			return value == null || "".Equals(value.Trim());
		}
	}
}

