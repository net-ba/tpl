using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.BrowserExercise.Model
{
    public class HtmlProcessor
    {
        private const string ImageSrcPattern = @"<img\s[^>]*src=[""'](?<srcValue>[^""']+)[""']";

        public IEnumerable<string> GetImageUrls(string html)
        {
            const RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
            var matches = Regex.Matches(html, ImageSrcPattern, options);
            return matches.Cast<Match>()
                .Where(m => m.Success)
                .Select(m => m.Groups["srcValue"].Value)
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();
        }
    }
}
