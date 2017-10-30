using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PIIRedact
{
    /// <summary>
    /// Use this when the pattern to redact will be in the 2nd group. i.e (word)\s+(2016). Here 2016 will be readcated or whitelisted. 
    /// </summary>
    public class RegexGroupFinder : RegexFinder
    {
        /// <summary>
        /// Creates a new instance of <see cref="RegexGroupFinder"/>
        /// </summary>
        /// <param name="pattern">The regex expression where the 2nd group will be redacted/whitelisted. i.e. (USD)(\d+). Here the digit after USD will be redacted or whitelisted.</param>
        public RegexGroupFinder(string pattern) : base(pattern)
        {
        }

        /// <summary>
        /// Returns the <see cref="PatternMatchResult"/> from the regex match
        /// </summary>
        /// <param name="m">Regex match</param>
        /// <returns>The pattern match</returns>
        protected override PatternMatchResult GetPatternMatchResult(Match m)
        {
            return new PatternMatchResult(m.Groups[2].Index, m.Groups[2].Index + m.Groups[2].Length);
        }
    }
}