# PIIRedact
Redacts the PII information. This package uses Stanford NER package to identify and scrub Name, Organization and location. It also redacts email,ssn,driver license,
passport no. It aggressively removes any number with more than 4 consecutive digits. Use AddToWhitelist to whitelist any pattern.In order to use this you must have java installed.


The usage is:
var redactor = new PIIRedactor();
var redactedData = redactor.GetRedactedData("My name is John Doe. My email is m@n.o");

the redacted string looks like : My name is xxxx xxx. My email is x@x.x


If you want to whitelist any pattern i.e any number with 6-8 consecutive digits, should be done as follows:

redactor.AddToWhitelist(new RegexFinder("\b\d{6,8}\b"));

similarly to add a new redactable pattern will redact any word 6-8 consecutive digits. 
redactor.AddToWhitelist(new RegexFinder("\b\d{6,8}\b"));

