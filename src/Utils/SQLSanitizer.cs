```csharp
using System;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class SQLSanitizer
    {
        public static string Sanitize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }

            // Remove any potentially harmful SQL characters or phrases
            string pattern = @"(--)|(\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE)?|INSERT( INTO)?|MERGE|SELECT|UPDATE|UNION( ALL)?)\b)";

            string sanitizedInput = Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase);

            return sanitizedInput;
        }
    }
}
```