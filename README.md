# PIIRedact
Redacts the PII information. This package uses Stanford NER package to identify and scrub PII data. It redacts email,ssn,driver license,
passport no. It aggressively removes any number with more than 4 consecutive digits. Use AddToWhitelist to whitelist any pattern.In order to use this you must have java installed.


The usage is:
var redactor = new PIIRedactor();'
var redactedData = redactor.GetRedactedData("email is x@y.z");
