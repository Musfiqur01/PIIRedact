# PIIREdact

Redacts the PII information. This package uses Stanford NER package to identify and scrub Name, Organization and location. It also redacts email,ssn,driver license,
passport no. It aggressively removes any number with more than 3 consecutive digits. Use AddToWhitelist to whitelist any pattern.In order to use this you must have java installed.

## Getting Started

Install the nuget package to get started.

The usage is:
var redactor = new PIIRedactor();
var redactedData = redactor.GetRedactedData("My name is John Doe. My email is m@n.o");

The redacted string looks like : My name is xxxx xxx. My email is x@x.x


If you want to whitelist any pattern i.e any number with 6-8 consecutive digits, it should be done as follows:
redactor.AddToWhitelist(new RegexFinder("\b\d{6,8}\b"));


Similarly to add a new redactable pattern will redact any word 6-8 consecutive digits. 
redactor.AddToWhitelist(new RegexFinder("\b\d{6,8}\b"));


### Prerequisites

In order to use this package , you have to have java installed. If you dont want to use java, you have to disable IncludeEntityRedaction = false;

## Versioning

We use appveyor for versioning.

## Authors

Musfiqur Rahman

See also the list of [contributors](https://github.com/Musfiqur01/PIIRedact/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

This project uses Standford NER package.