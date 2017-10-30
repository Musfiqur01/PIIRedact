namespace PIIRedact
{
    /// <summary>
    /// The library which contains the regex pattern for common PII items.
    /// </summary>
    public static class RegexLibrary
    {
        /// <summary>
        /// Regex for email
        /// </summary>
        public const string Email = "[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-]+";
        
        /// <summary>
        /// Regex for UK passport
        /// </summary>
        public const string UKPassportNo = @"\b[0-9]{10}GBR[0-9]{7}[U,M,F]{1}[0-9]{9}\b";
        
        /// <summary>
        /// Regex for california driver license
        /// </summary>
        public const string CADriverLicense = @"[A-Z]{1}\d{7}";

        /// <summary>
        /// Regex for majority US driver license which begins with a letter
        /// </summary>
        public const string USDriverLicense = @"[A-Z]{1}\d{6,18}";

        /// <summary>
        /// Regex for Ohio driver license which begins with a letter
        /// </summary>
        public const string OhioDriverLicense = @"[A-Z]{2}\d{6}";

        /// <summary>
        /// Regex for Ohio driver license which begins with a letter
        /// </summary>
        public const string WADriverLicense = @"\w{7}\d{3}\w{2}";


        /// <summary>
        /// Regex for US phone number
        /// </summary>
        public const string USPhoneNumber = @"\b\(?\d{3}\)?[-]?\d{3}[-]?\d{4}\b";
        
        /// <summary>
        /// Regex for social security number
        /// </summary>
        public const string SSN = @"\b\d{3}-?\d{2}-?\d{4}\b";
        
        /// <summary>
        /// Regex for US passport 
        /// </summary>
        public const string USPassport = @"\b\d\w{4,7}\d\b";
        
        /// <summary>
        /// Regex for US Income Tax Identification Number
        /// </summary>
        public const string USITIN = @"(9\d{2})([ \-]?)([7]\d|8[0-8])([ \-]?)(\d{4})";
        
        /// <summary>
        /// Regex for IP Address
        /// </summary>
        public const string IPAddress = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
        
        /// <summary>
        /// Most of the PII are numbers. This redacts any number with 3 or more continuous digits.
        /// </summary>
        public const string Number = @"\d{3}[\w-]+\b";
    }
}
