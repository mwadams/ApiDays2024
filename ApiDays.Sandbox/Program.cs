using ApiDays.Models;
using Corvus.Json;

string jsonText =
    """
    {
        "firstName": "Matthew",
        "lastName": "Adams",
        "otherNames": ["William"]
    }
    """;

Person person = Person.Parse(jsonText);

Console.Write($"{person.LastName}, {person.FirstName}");

bool value = person.OtherNames.Match(
    HandleString,
    HandleArrayOfStrings,
    (in Person.Othernames _) => { Console.WriteLine(); return false; });

static bool HandleString(in JsonString otherNames)
{
    Console.WriteLine($" [{otherNames}]");
    return true;
}

static bool HandleArrayOfStrings(in Person.Othernames.OneOf1Array otherNamesArray)
{
    if (otherNamesArray.GetArrayLength() == 0)
    {
        return false;
    }

    Console.Write(" [");

    bool first = true;
    foreach (JsonString name in otherNamesArray.EnumerateArray())
    {
        if (first)
        {
            first = false;
        }
        else
        {
            Console.Write(' ');
        }

        Console.Write((string)name);
    }

    Console.WriteLine("]");

    return true;
}