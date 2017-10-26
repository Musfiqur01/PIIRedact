using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    public interface IPatternFinder
    {
        IEnumerable<IPIIMatchResult> LocatePIIData(string sensitiveInformation);
    }
}
