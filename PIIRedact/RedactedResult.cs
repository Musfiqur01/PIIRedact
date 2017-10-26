using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    public class PatternMatchResult : IPIIMatchResult
    {
        public PatternMatchResult(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; private set; }

        public int End { get; private set; }

        public bool isWithinRange(int x)
        {
            return x >= Start && x < End;
        }
    }
}
