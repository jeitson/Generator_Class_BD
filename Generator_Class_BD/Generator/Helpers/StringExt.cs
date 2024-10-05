using System;
using System.Text;

namespace Generator_Class_BD.Generator.Helpers
{
    public static class StringExt
    {
        public static bool CompareString(this string str1, string str2)
            => string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Convert the first character to lowercase and concatenate with the rest of the string
            return char.ToLower(input[0]) + input.Substring(1);
        }

        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    if (i > 0)
                    {
                        result.Append('_');
                    }
                    result.Append(char.ToLower(input[i]));
                }
                else
                {
                    result.Append(input[i]);
                }
            }
            return result.ToString();
        }
    }
}
