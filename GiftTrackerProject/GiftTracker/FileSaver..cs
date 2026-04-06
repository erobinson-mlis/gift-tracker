using System.IO;
using Spectre.Console;

namespace GiftTracker;

public class FileSaver{
    public static void CheckFileExists(string filePath)
    {
        // Checks for existence of passed filePath
        // if it doesn't exist, create it
        if (!File.Exists(filePath)) {
            CreateFile(filePath);
            Console.WriteLine("New file successfully created. ");
            ConsoleUI.PressAnyKeyToContinue();
            return;
        } // end if
        return;
    } // end CheckFileExists()

    public static void CreateFile(string filePath) {
        // Creates a datafile and saves it to the local 
        // project folder for accepting saved records
        // Accepts:
        //   filePath : the path to the datafile
        Console.WriteLine("\nNo file present.\n>>> Creating new file...");

        File.Create(filePath).Close();
        File.WriteAllText(filePath, "");
        return;
    } // End CreateFile()

    public static void SaveData(string filePath, string record) {   
        // Writes a data record to the datafile
        // Accepts:
        // filePath : the path to the datafile
        // record : a string record to be saved to the datafile
        Console.Clear();
        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("Data saved successfully!");
        return;
    }
}