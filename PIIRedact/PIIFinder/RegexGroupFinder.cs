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
        public RegexGroupFinder(string pattern) : base(pattern)
        {
        }

        protected override PatternMatchResult GetPatternMatchResult(Match m)
        {
            return new PatternMatchResult(m.Groups[2].Index, m.Groups[2].Index + m.Groups[2].Length);
        }
    }
}
