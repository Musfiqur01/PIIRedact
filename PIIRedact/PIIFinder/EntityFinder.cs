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
    public class EntityFinder : IPatternFinder
    {
        private CRFClassifier classifier;
        /// <summary>
        /// Create a new instance of <see cref="EntityFinder"/> class.
        /// </summary>
        public EntityFinder():this(System.AppDomain.CurrentDomain.BaseDirectory)
        {
        }

        /// <summary>
        /// Create a new instance of <see cref="EntityFinder"/> class.
        /// </summary>
        /// <param name="path">The directory path of english.all.3class.distsim.crf.ser.gz</param>
        public EntityFinder(string path)
        {
            var classifierpath = path + @"\english.all.3class.distsim.crf.ser.gz";
            if(!File.Exists(classifierpath)){
                throw new FileNotFoundException($"english.all.3class.distsim.crf.ser.gz could not be found in the :{path}. Please set the appropriate directory address");
            }

            classifier = CRFClassifier.getClassifierNoExceptions(classifierpath);
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