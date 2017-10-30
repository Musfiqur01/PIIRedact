namespace PIIRedact
{
    /// <summary>
    /// Interface for PatternMatch Result
    /// </summary>
    public interface IPatternMatchResult
    {
        /// <summary>
        /// Gets the index where the pattern match will start
        /// </summary>
        int Start { get; }
        /// <summary>
        /// Gets the index where the pattern match will end
        /// </summary>
        int End { get; }
        /// <summary>
        /// Indicates if an index within {start,end} range
        /// </summary>
        /// <param name="x">The index to check</param>
        /// <returns>Returns true if the index is within the range, false otherwise</returns>
        bool isWithinRange(int x);
    }
}
