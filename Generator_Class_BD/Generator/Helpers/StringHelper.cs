using System;

namespace Generator_Class_BD.Generator.Helpers
{
    public static class StringHelper
    {
        public static bool CompareString(string str1, string str2)
            => string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
    }
}
