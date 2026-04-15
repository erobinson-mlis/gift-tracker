using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GiftTracker;

public class FileSaver{
    private readonly string _filePath;

    public FileSaver(string filePath)
    {
        _filePath = filePath;
    }

    public static void CheckFileExists(string filePath) {
        // Checks for existence of passed filePath
        // if it doesn't exist, create it
        if (!File.Exists(filePath))
        {
            FileSaver.CreateFile(filePath);
        }
        else
        {
            return;
        }
    } // end CheckFileExists()

    public static void CreateFile(string filePath) {
        // Creates a datafile and saves it to the local 
        // project folder for accepting saved records
        // Accepts:
        //   filePath : the path to the datafile
        Console.WriteLine("\nNo file present.\n>>> Creating new file...");

        File.Create(filePath).Close();
        File.WriteAllText(filePath, "");
    } // End CreateFile()

    public static void SaveData(string filePath, string record)
    {
        // Writes a data record to the datafile
        // Accepts:
        // filePath : the path to the datafile
        // record : a string record to be saved to the datafile
        Console.Clear();
        
        CheckFileExists(filePath);

        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("Data saved successfully!");
    }

    // public static string LoadData(string filepath);{
    //     try {ConsoleUI.DisplayFileData(filePath);
    //     } catch {
    //         Console.WriteLine("Error accessing the file.");
    //     }

    //     return string 
    // }
}