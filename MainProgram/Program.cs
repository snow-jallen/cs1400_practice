using System.IO;
using System.Linq;


//const
const decimal MAX_SCORE = 5_000_000_000.0234567M;

//One-dimensional array (e.g. a regular, normal array)
string[] nameArray = new string[5];
nameArray[0] = "Jack";

//2-D array
string[,] twoDarray = new string[50, 20_000];
twoDarray[0, 0] = "Jonathan";
twoDarray[0, 1] = "Allen";

//jagged array
string[][] jaggedArray = new string[5][];
jaggedArray[0] = new string[2];
jaggedArray[0][0] = "Jonathan";
jaggedArray[0][1] = "Allen";

jaggedArray[1] = new string[3];
jaggedArray[1][0] = "item 1";
jaggedArray[1][1] = "item 2";
jaggedArray[1][2] = "item 3";

//string formatting
string interpolatedString = $"The max score is {MAX_SCORE,-25:n0}!";
Console.WriteLine(interpolatedString);
Console.WriteLine("The max score is {2,5}|{1,25}|{0:n0}|", MAX_SCORE, MAX_SCORE / 2, MAX_SCORE * 2);

Console.WriteLine("{0}, {1} {2:00000}", "New Haven", "CT", 1234);
Console.WriteLine("{0}, {1} {2:00000}", "Ephraim", "UT", 84627);

//parallel arrays / lists
var userInfo = new List<(string name, int score, string favoriteColor)>();
var names = new List<string>();
var scores = new List<int>();
var favoriteColors = new List<string>();

while (names.Count < 5)
{
    getUser(names, scores, favoriteColors);
}

printUserInfo(names, scores, favoriteColors);



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

static void printUserInfo(List<string> names, List<int> scores, List<string> favoriteColors)
{
    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"{names[i],-12} | {scores[i]:n3} | {favoriteColors[i]}");
    }
}

void getUser(List<string> names, List<int> scores, List<string> favoriteColors)
{
    Console.WriteLine(MyStrings.Greeting);
    names.Add(Console.ReadLine());
    scores.Add(scores.Count + 5);
    Console.WriteLine("COlor?");
    favoriteColors.Add(Console.ReadLine());
}


record Weapon(string Name, int HitPoints, string Provenance);
record Person(string Name, int Age, int Score, int HealthPoints, Weapon[] weapons);
