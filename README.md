# TermReplacementService
**A service that can be configured to replace terms in a sequence of integers with strings**

This is a service written with .NET Core Web API, which provides functionality for replacing integers in a sequence with strings. Strings can be added to the configuration along with a number, multiples of which in a sequence will be replaced with that string.

## Configuration (TermReplacementConfiguration.json)

```json
{
  "ReplaceTermSettings": [
    {
      "MultipleOf": 3,
      "ReplaceWith": "Live"
    },
    {
      "MultipleOf": 5,
      "ReplaceWith": "Nation"
    }
  ]
}
```

For instance `{ "MultipleOf": 6, "ReplaceWith":"Hello" }` will, when given a sequence, replace all multiples of 6 with the string "Hello".

## Building
To build the code, open the TermReplacementService.sln file in Visual Studio, and build within the IDE. This should also resolve the Nuget packages needed to run the service and associated tests.

## Tests
To run the tests, open up test explorer in Visual Studio and run all. The tests are written using XUnit.

## Running
To run the service, run the TermReplacementService WebApi project from within Visual Studio.

## Using the service
To get a sequence with configured terms replaced once the service is running, send a get request to the endpoint http://localhost:64163/api/TermReplacement/ReplaceInRange?lowerBound={LOWERBOUND}&upperBound={UPPERBOUND}  
Replacing LOWERBOUND and UPPERBOUND with respective bounds. (note: both bounds are inclusive).

The http response body will contain:  
**result** - a string of the transformed sequence separated by spaces  
**summary** - the frequencies of changed terms in the sequence (Integer being those which have remained unchanged)  

### Example request
http://localhost:64163/api/TermReplacement/ReplaceInRange?lowerBound=1&upperBound=20

### Example response (using the above configuration)
```json
{
  "result":"1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation",
  "summary":
  {
    "Integer":11,
    "Live":5,
    "Nation":3,
    "LiveNation":1
  }
}
```
