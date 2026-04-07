using System.Runtime.InteropServices;

namespace GiftTracker;

public class FileSaver{
    
    static string filePath = "gifttracker-data.txt";

    public static int CheckFileExists(string filePath)
    {
        // Checks for existence of passed filePath
        // if it doesn't exist, create it
        if (!File.Exists(filePath))
        {
            FileSaver.CreateFile(filePath);
            return 0;
        } // end if
        else { 
            try
            {
                ConsoleUI.DisplayFileData(filePath);
                return 0;
            } catch {
                Console.WriteLine("Error accessing the file.");
                return 1; 
            }
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
        return;
    } // End CreateFile()

    public static void SaveData(string filePath, string record)
    {
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