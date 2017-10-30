namespace PIIRedact
{
    /// <summary>
    /// Redacts sensistive information like PII. 
    /// </summary>
    public interface IPIIRedactor
    {
        /// <summary>
        /// The config for PIIredactor.
        /// </summary>
        PIIRedactorConfig PIIRedactorConfig { get; }

        /// <summary>
        /// Adds a new redactor to the list of redactors.
        /// </summary>
        /// <param name="redactor">The patter which will be redacted</param>
        void AddToRedactors(IPIIFinder redactor);

        /// <summary>
        /// Adds a pattern which will whitelist a expression
        /// </summary>
        /// <param name="whitelist">The pattern which will be whitelisted</param>
        void AddToWhiteList(IPatternFinder whitelist);

        /// <summary>
        /// Loads the redactors and whitelists.
        /// </summary>
        void Load();
        
        /// <summary>
        /// Redacts the PII data from the input string 
        /// </summary>
        /// <param name="senstiveData">The data to be redacted</param>
        /// <returns>Redacted data</returns>
        string GetRedactedData(string senstiveData);
    }
}