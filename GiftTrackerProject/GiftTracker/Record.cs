namespace GiftTracker;

using System.Runtime.InteropServices.Swift;

public class Record {
    public static void ViewData() {
        string filePath = "gifttracker-data.txt";

        if (!File.Exists(filePath))
        {
            new FileSaver().CreateFile(filePath);
        } // end if

        else {
            // Load data from filePath
            string fileContents = File.ReadAllText("gifttracker-data.txt");
            Console.Clear();
            Console.WriteLine("Loading data from file...");
            // Check length of data file and display file empty if no contents
            if(fileContents.Length < 1) {
                Console.WriteLine("\nData file is currently empty.\nReturn to menu to add new records.\n");
            } // end if

            if(fileContents.Length > 1) {
                Console.WriteLine($"\n{fileContents}");
            }

            Console.WriteLine("Press any key to return to menu:");
            Console.ReadKey();
        } // end else
    } // view data method


    public static void ConfirmEntry(string filePath, string record)
    {
        // Confirm data entry and save to file
        Console.Clear();
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(record);
                    
        string confirmation = Program.AskForInput("Is this correct?\n('yes' to save data OR 'no' to re-enter data): ")!.ToLower();

        if(confirmation=="yes")
        {
            Console.Clear();
            filePath = "gifttracker-data.txt";
            Console.WriteLine("\nSaving data to file...\n");
            Console.WriteLine(record);
            File.AppendAllText(filePath, $"{record}\n");
            Console.WriteLine("Data saved successfully!");
            return;
        } // end if

        if (confirmation == "no")
        {
            Console.WriteLine("\nLet's re-enter the data...\n");
            return;
            //ADD DATA ENTRY LOGIC HERE
            //TODO:Loop back to data entry if user selects 'no' and add option to return to menu
        } // end if

        else {
            Console.WriteLine("\nInvalid input. Please enter 'yes' to save data or 'no' to re-enter data.");
            ConfirmEntry(filePath, record);
        } // end else
    } // end ConfirmEntry method

} // end class Record