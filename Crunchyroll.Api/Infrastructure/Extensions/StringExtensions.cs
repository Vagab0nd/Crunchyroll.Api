using System.Text;

namespace Crunchyroll.Api.Infrastructure.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            bool isFirstCharacter = true;

            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    if (!isFirstCharacter)
                    {
                        result.Append('_');
                    }
                    result.Append(char.ToLower(c));
                }
                else
                {
                    result.Append(c);
                }

                isFirstCharacter = false;
            }

            return result.ToString();
        }
    }
}
