using System.IO;


do
{
    string[] lines = File.ReadAllLines("file.txt");

    printLines(lines);

    int lineNumber = getNewLineFromUser(lines, out string newLine);

    updateFileWithNewLine(lines, lineNumber, newLine);

}while(userWantsToKeepEditing());

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