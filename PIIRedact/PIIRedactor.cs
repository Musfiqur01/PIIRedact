using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    /// <summary>
    /// Redacts sensitive information like PII. 
    /// </summary>
    public class PIIRedactor : IPIIRedactor
    {
        /// <summary>
        /// The list of redactors
        /// </summary>
        private List<IPIIFinder> redactors = new List<IPIIFinder>();
        
        /// <summary>
        /// The list of whitelist
        /// </summary>
        private List<IPatternFinder> whitelists = new List<IPatternFinder>();

        /// <summary>
        /// Creates a new instance of PIIRedactor
        /// </summary>
        public PIIRedactor()
        {
            this.NonRedactableCharacters = new List<char> { '@', '-', '.', ',' };
            this.PIIRedactorConfig = new PIIRedactorConfig();
            this.Load();
        }

        /// <summary>
        /// The config for PIIredactor.
        /// </summary>
        public PIIRedactorConfig PIIRedactorConfig { get; }

        /// <summary>
        /// The character used to redact the data. Default is 'x'
        /// </summary>
        public char FillerCharacter { get; set; } = 'x';

        /// <summary>
        /// The list of characters that will not be redacted. The defaults are '@','-','.',','
        /// </summary>
        public List<char> NonRedactableCharacters { get; set; }

        /// <summary>
        /// Adds a new redactor to the list of redactors.
        /// </summary>
        /// <param name="redactor"></param>
        public void AddToRedactors(IPIIFinder redactor)
        {
            redactors.Add(redactor);
        }

        /// <summary>
        /// Adds a pattern which will whitelist an expression
        /// </summary>
        /// <param name="whitelist"></param>
        public void AddToWhiteList(IPatternFinder whitelist)
        {
            whitelists.Add(whitelist);
        }

        /// <summary>
        /// Loads the redactors and whitelists.
        /// </summary>
        public void Load()
        {
            this.redactors.Clear();
            this.whitelists.Clear();
            if (this.PIIRedactorConfig.IncludeCADriverLicense)
            {
                redactors.Add(new RegexFinder(RegexLibrary.CADriverLicense));
            }
            if (this.PIIRedactorConfig.IncludeEmail)
            {
                redactors.Add(new RegexFinder(RegexLibrary.Email));
            }
            if (this.PIIRedactorConfig.IncludeEntityRedaction)
            {
                redactors.Add(new EntityFinder());
            }
            if (this.PIIRedactorConfig.IncludeIPAddress)
            {
                redactors.Add(new RegexFinder(RegexLibrary.IPAddress));
            }
            if (this.PIIRedactorConfig.IncludeNumber)
            {
                redactors.Add(new RegexFinder(RegexLibrary.Number));
            }
            if (this.PIIRedactorConfig.IncludeSSN)
            {
                redactors.Add(new RegexFinder(RegexLibrary.SSN));
            }
            if (this.PIIRedactorConfig.IncludeUKPassportNo)
            {
                redactors.Add(new RegexFinder(RegexLibrary.UKPassportNo));
            }
            if (this.PIIRedactorConfig.IncludeUSITIN)
            {
                redactors.Add(new RegexFinder(RegexLibrary.USITIN));
            }
            if (this.PIIRedactorConfig.IncludeUSPassport)
            {
                redactors.Add(new RegexFinder(RegexLibrary.USPassport));
            }
            if (this.PIIRedactorConfig.IncludeUSPhoneNumber)
            {
                redactors.Add(new RegexFinder(RegexLibrary.USPhoneNumber));
            }
        }

        /// <summary>
        /// Redacts the PII data from the input string 
        /// </summary>
        /// <param name="senstiveData">The data to be redacted</param>
        /// <returns>Redacted data</returns>
        public string GetRedactedData(string senstiveData)
        {
            StringBuilder result = new StringBuilder(senstiveData);
            var redactedResultSet = new ConcurrentBag<IPatternMatchResult>();
            var whitelistedResultSet = new ConcurrentBag<IPatternMatchResult>();
            Parallel.ForEach(redactors, (redactor) => {
                var redactedResults = redactor.LocatePIIData(senstiveData);
                foreach(var redactedResult in redactedResults)
                {
                    redactedResultSet.Add(redactedResult);
                }
            });

            Parallel.ForEach(whitelists, (redactor) => {
                var whitelistResults = redactor.LocatePIIData(senstiveData);
                foreach (var whitelistresult in whitelistResults)
                {
                    whitelistedResultSet.Add(whitelistresult);
                }
            });

            
            Parallel.ForEach<IPatternMatchResult>(redactedResultSet.AsEnumerable(), (redactedResult) => {
                for(int i=redactedResult.Start; i < redactedResult.End; i++)
                {
                    if (!NonRedactableCharacters.Contains(result[i]))
                        {
                            bool ignore = false;
                            foreach (var whitelistedRegion in whitelistedResultSet)
                            {
                                if (whitelistedRegion.isWithinRange(i))
                                {
                                    ignore = true;
                                    break;
                                }
                            }

                            if (!ignore) result[i] = this.FillerCharacter;
                        }
                    }
            });

            return result.ToString();
        }
    }
}