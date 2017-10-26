using edu.stanford.nlp.ie.crf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PIIRedact
{
    public class EntityFinder : IPIIFinder
    {
        private CRFClassifier classifier;
        public EntityFinder()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"\english.all.3class.distsim.crf.ser.gz";
            classifier = CRFClassifier.getClassifierNoExceptions(path);
        }
        public IEnumerable<IPIIMatchResult> LocatePIIData(string sensitiveInformation)
        {
            var redactedResults = new List<IPIIMatchResult>();
            var result = this.classifier.classifyToCharacterOffsets(sensitiveInformation);
            for(int i = 0; i < result.size(); i++)
            {
                var match = result.get(i);
                var tokens = match.ToString().Split(new[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                redactedResults.Add(new PatternMatchResult(int.Parse(tokens[1]), int.Parse(tokens[2])));
            }

            return redactedResults;
        }
    }
}
