using System.IO;

int lineNumber;
string[] lines = File.ReadAllLines("file.txt");
for (int i = 0; i < lines.Length; i++)
{
    Console.WriteLine($"{i + 1} {lines[i]} ");
}
do
{
    Console.WriteLine("What line would you like to edit?");
} while (!(int.TryParse(Console.ReadLine(), out lineNumber) && numberIsValid(lineNumber, 1, lines.Length)));
Console.WriteLine($"You asked to edit line {lineNumber}.");


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