using System.IO;
using System.Linq;

//get a point every time user hits space...
//BUT, not more than one every half a second.

var tuple = (1, true, "Name");


var benjamin = new Person("Benjamin", 25, 250, 25000, null);
benjamin = benjamin with {HealthPoints = 50};
//benjamin.HealthPoints -= 50; (this won't work)

Console.Clear();
int points = 0;
DateTime lastScoreChange = DateTime.MinValue;
while (true)
{
    Console.CursorLeft = 0;
    Console.CursorTop = 0;
    Console.Write(points);
    var key = Console.ReadKey();
    var elapsedTime = DateTime.Now - lastScoreChange;
    var longEnough = elapsedTime > TimeSpan.FromMilliseconds(333);

    if (key.Key == ConsoleKey.Spacebar)
    {
        if (longEnough)
        {
            lastScoreChange = DateTime.Now;
            points += 1;
        }
        else
        { Console.Write("Uh uh uh..."); }
    }
}
return;

do
{
    string[] lines = File.ReadAllLines("file.txt");

    printLines(lines);

    int lineNumber = getNewLineFromUser(lines, out string newLine);

    updateFileWithNewLine(lines, lineNumber, newLine);

} while (userWantsToKeepEditing());

bool userWantsToKeepEditing()
{
    return getString("Do you want to keep editing this file?") != "exit";
}

string getString(string prompt)
{
    Console.WriteLine(prompt);
    return Console.ReadLine();
}

bool numberIsValid(int number, int min, int max)
{
    bool isValid;
    if (number >= min && number <= max)
    {
        isValid = true;
    }
    else
    { isValid = false; }
    return isValid;
}

static void printLines(string[] lines)
{
    for (int i = 0; i < lines.Length; i++)
    {
        Console.WriteLine($"{i + 1} {lines[i]} ");
    }
}

int getNewLineFromUser(string[] lines, out string newLine)
{
    int lineNumber;
    do
    {
        Console.WriteLine("What line would you like to edit?");
    } while (!(int.TryParse(Console.ReadLine(), out lineNumber) && numberIsValid(lineNumber, 1, lines.Length)));
    newLine = getString($"You asked to edit line {lineNumber}.");
    return lineNumber;
}

static void updateFileWithNewLine(string[] lines, int lineNumber, string newLine)
{
    lines[lineNumber - 1] = newLine;
    File.WriteAllLines("file.txt", lines);
}

void doScore(Person p)
{
    
}

record Weapon(string Name, int HitPoints, string Provenance);
record Person(string Name, int Age, int Score, int HealthPoints, Weapon[] weapons);