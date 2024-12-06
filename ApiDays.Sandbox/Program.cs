using ApiDays.Models;
using Corvus.Json;

string jsonText =
    """
    {
        "firstName": "Matthew",
        "lastName": "Adams"
    }
    """;

Person person = Person.Parse(jsonText);

bool value = person.OtherNames.Match(
    (in JsonString otherNames) =>
    {
        Console.WriteLine($"{otherNames}");
        return true;
    },
    (in Person.Othernames.OneOf1Array otherNamesArray) =>
    {
        foreach(JsonString name in otherNamesArray.EnumerateArray())
        {

        }

        return true;
    },
    (in Person.Othernames _) => throw new Exception()
    );

Console.WriteLine($"{person.LastName}, {person.FirstName}");