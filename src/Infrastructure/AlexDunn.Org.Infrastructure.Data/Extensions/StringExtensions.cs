using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlexDunn.Org.Infrastructure.Data.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces break tags with new lines
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ReplaceBreaks(this string html)
        {
            var regex = new Regex("<br/>");
            html = regex.Replace(html, "\n");
            return html;
        }

        /// <summary>
        /// replaces break tags with spaces
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ReplaceBreaksWithSpace(this string html)
        {
            var regex = new Regex("<br/>");
            html = regex.Replace(html, " ");
            return html;
        }
        /// <summary>
        /// Trims new lines from a string
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string TrimLines(this string originalString)
        {
            originalString = originalString.Trim('\n');
            return originalString;
        }
        /// <summary>
        /// Removes all html or xml tags
        /// </summary>
        /// <param name="html"></param>
        /// <param name="stripBreaks"></param>
        /// <returns></returns>
        public static string StripTags(this string html, bool stripBreaks = false)
        {
            if (stripBreaks)
            {
                html = html.ReplaceBreaksWithSpace();
            }
            else
            {
                html = html.ReplaceBreaks();
            }
            var regHtml = new Regex("<[^>]*>");
            var strippedString = regHtml.Replace(html, "");
            strippedString = strippedString.TrimLines();
            return WebUtility.HtmlDecode(strippedString);
        }

        /// <summary>
        /// Returns a substring of the first given count of characters
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string Take(this string originalString, int count, bool useEllipses = false)
        {
            return originalString.Length > count
                ? originalString.Substring(0, count) + (useEllipses ? "..." : string.Empty)
                : originalString;
        }

    }
}
