using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    /// <summary>
    /// Class for PatternMatch Result
    /// </summary>
    public class PatternMatchResult : IPatternMatchResult
    {
        /// <summary>
        /// Create a new instance of <see cref="PatternMatchResult"/> class.
        /// </summary>
        /// <param name="start">The index of the start of the pattern match</param>
        /// <param name="end">The index of the end of the pattern match</param>
        public PatternMatchResult(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Gets the index where the pattern match will start
        /// </summary>
        public int Start { get; private set; }

        /// <summary>
        /// Gets the index where the pattern match will end
        /// </summary>
        public int End { get; private set; }

        /// <summary>
        /// Indicates if an index within {start,end} range
        /// </summary>
        /// <param name="x">The index to check</param>
        /// <returns>Returns true if the index is within the range, false otherwise</returns>
        public bool isWithinRange(int x)
        {
            return x >= Start && x < End;
        }
    }
}