using System.IO;

int lineNumber;

while (true)
{
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

    var newLine = Console.ReadLine();
    lines[lineNumber - 1] = newLine;
    File.WriteAllLines("file.txt", lines);

    Console.WriteLine("Do you want to keep editing this file?");
    var input = Console.ReadLine();
    if(input == "exit")
    {
        break;
    }
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