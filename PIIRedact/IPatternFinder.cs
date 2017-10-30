using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    /// <summary>
    /// Interface for a finding a pattern
    /// </summary>
    public interface IPatternFinder
    {
        /// <summary>
        /// Locate the PII data in the input string
        /// </summary>
        /// <param name="sensitiveInformation">The input data that may contain sensitive information like email, ssn etc.</param>
        /// <returns>A list of <see cref="IPatternMatchResult"/></returns>
        IEnumerable<IPatternMatchResult> LocatePIIData(string sensitiveInformation);
    }
}
