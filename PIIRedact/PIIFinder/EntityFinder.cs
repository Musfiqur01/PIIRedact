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
    /// <summary>
    /// Identifies Entity like name, location and organization.
    /// </summary>
    public class EntityFinder : IPIIFinder
    {
        private CRFClassifier classifier;
        /// <summary>
        /// Create a new instance of <see cref="EntityFinder"/> class.
        /// </summary>
        public EntityFinder()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"\english.all.3class.distsim.crf.ser.gz";
            classifier = CRFClassifier.getClassifierNoExceptions(path);
        }

        /// <summary>
        /// Returns the string after redacting the PII
        /// </summary>
        /// <param name="sensitiveInformation"></param>
        /// <returns>THe list of matches</returns>
        public IEnumerable<IPatternMatchResult> LocatePIIData(string sensitiveInformation)
        {
            var redactedResults = new List<IPatternMatchResult>();
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
