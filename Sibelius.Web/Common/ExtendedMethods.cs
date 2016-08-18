using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Sibelius.Web.Common
{
    public static class ExtendedMethods
    {
        /// <summary>
        /// This method receives a Url and replaces the {0} with an int param
        /// </summary>
        /// <param name="url">Url with only {0} param</param>
        /// <param name="value">Integer value to replace</param>
        /// <returns></returns>
        public static string Param(this string url, int value)
        {
            return string.Format(url, value);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/286813/how-do-you-convert-html-to-plain-text
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string GetPlainText(this string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }
    }
}