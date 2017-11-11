using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIIRedact
{
    /// <summary>
    /// This class represents the config that determines which redactors will be included in the PIIRedactor.
    /// </summary>
    public class PIIRedactorConfig
    {
        /// <summary>
        /// Determines if the regex for email should be included in the PII config
        /// </summary>
        public bool IncludeEmail { get; set; } = true;

        /// <summary>
        /// Determines if the regex for UK passport should be included in the PII config
        /// </summary>
        public bool IncludeUKPassportNo { get; set; } = true;

        /// <summary>
        /// Determines if the regex for CAD driver license should be included in the PII config
        /// </summary>
        public bool IncludeCADriverLicense { get; set; } = true;

        /// <summary>
        /// Determines if the regex for US phone number should be included in the PII config
        /// </summary>
        public bool IncludeUSPhoneNumber { get; set; } = true;

        /// <summary>
        /// Determines if the regex for SSN should be included in the PII config
        /// </summary>
        public bool IncludeSSN { get; set; } = true;

        /// <summary>
        /// Determines if the regex for US passport should be included in the PII config
        /// </summary>
        public bool IncludeUSPassport { get; set; } = true;

        /// <summary>
        /// Determines if the regex for US TIN should be included in the PII config
        /// </summary>
        public bool IncludeUSITIN { get; set; } = true;

        /// <summary>
        /// Determines if the regex for IP Address should be included in the PII config
        /// </summary>
        public bool IncludeIPAddress { get; set; } = true;

        /// <summary>
        /// Determines if the regex for number should be included in the PII config
        /// </summary>
        public bool IncludeNumber { get; set; } = true;

        /// <summary>
        /// Determines if Entity redaction should be included the PII config
        /// </summary>
        public bool IncludeEntityRedaction { get; set; } = true;
    }
}