using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PIIRedact
{
    /// <summary>
    /// A PII redactor based on Regular expression
    /// </summary>
    public class RegexFinder : IPatternFinder
    {
        /// <summary>
        /// The regular expression
        /// </summary>
        protected readonly string pattern;

        /// <summary>
        /// Creates a new instance of RegexRedactor 
        /// </summary>
        /// <param name="pattern">The regular expression</param>
        public RegexFinder(string pattern)
        {
            this.pattern = pattern;
        }

        /// <summary>
        /// Returns the <see cref="PatternMatchResult"/> from the regex match
        /// </summary>
        /// <param name="m">Regex match</param>
        /// <returns>The pattern match</returns>
        protected virtual PatternMatchResult GetPatternMatchResult(Match m)
        {
            return new PatternMatchResult(m.Index, m.Index + m.Length);
        }

        /// <summary>
        /// Returns the string after redacting the PII
        /// </summary>
        /// <param name="sensitiveInformation"></param>
        /// <returns>THe list of matches</returns>
        public IEnumerable<IPatternMatchResult> LocatePIIData(string sensitiveInformation)
        {
            MatchCollection mc = Regex.Matches(sensitiveInformation, this.pattern);
            var redactedResults = new List<IPatternMatchResult>();
            foreach (Match m in mc)
            {
                redactedResults.Add(GetPatternMatchResult(m));
            }

            return redactedResults;
        }
    }
}
