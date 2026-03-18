namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Print welcome message
        Console.Clear();
        Console.WriteLine("🎁GiftTracker🎁\n\nWelcome to GiftTracker, an app for storing names,\nbirthdays, and gift idea information to simplify\ngift idea tracking");
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();

        string mode;

        // Mode selection loop
        do {
            // Prompt to select mode
            Console.Clear();
            Console.Write("🎁GiftTracker🎁\n\nPlease select mode:\n  'view' to view records\n  'add' to enter new records\n  'exit' to exit the app\n> ");
            mode = Console.ReadLine()!.ToLower();

            // Record.ViewAll(): View data from file
            if(mode=="view") {        

                // check that gifttracker-data.txt file is available; if not, create it
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
                        Console.WriteLine("\nData file is currently empty.\nReturn to menu to add new records.");
                    } // end if

                    if(fileContents.Length > 1) {
                        Console.WriteLine($"\n{fileContents}");
                    }

                    Console.WriteLine("\nPress any key to return to menu:");
                    Console.ReadKey();
                } // end else


            } // view data loop

            // Record.CreateNew(): Create new record and save to file
            if(mode=="add") {

                string command; 

                do {
                    // Enter record data for gift recipient
                    Console.Clear();
                    Console.WriteLine("Let's create a new record...");

                    Console.WriteLine("\nEnter first name: ");
                    string firstName= Console.ReadLine()!;

                    // Check if the input is null or empty
                    bool isValid = false;
                    if (string.IsNullOrEmpty(firstName))
                        do {
                            
                            Console.WriteLine("We need a name to track your gift ideas!\nPlease enter a valid (non-empty) first name:");
                            firstName = Console.ReadLine()!;
                        
                            if (!string.IsNullOrEmpty(firstName))
                            {
                                isValid = true;
                            }
                    } while(!isValid);

                    if (firstName != null) {
                        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
                    }

                    string lastName = AskForInput("\nEnter last name (optional): ");
                    if (!string.IsNullOrEmpty(lastName)) {
                        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
                    }
                    
                    string birthday = AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
                
                    string giftDescription = AskForInput("\nPlease enter a description of your gift idea: ");

                    string vendorName = AskForInput("\nEnter an optional vendor who sells this gift: ");

                    string vendorURL = AskForInput("\nEnter an optional online vendor URL:");

                    string priceRange = AskForInput("\nEnter an optional price range for the gift (e.g. $50-$100): ");

                    string recordEntry = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}\nVendor: {vendorName}\nVendor URL:         {vendorURL}\nPrice Range: {priceRange}\n\n";
                    
                    // Record.ConfirmEntry(): Confirm data entry and save to file
                    ConfirmEntry("gifttracker-data.txt", recordEntry);
                    
                    command = AskForInput("\nEnter 'menu' to return to menu or 'add' to add another new record: ").ToLower();

                } while(command != "menu");

            } // record data loop

        } while(mode != "exit"); // mode selection loop

    } // static void Main


    public static string AskForInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "None";
    }
    

    public static string ConfirmEntry(string filePath, string record)
    {
        // Record.ConfirmEntry(): Confirm data entry and save to file
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(record);
                    
        string confirmation = AskForInput("Is this correct?\n('yes' to save data OR 'no' to re-enter data): ")!.ToLower();

        if(confirmation=="yes")
        {
            filePath = "gifttracker-data.txt";
            Console.WriteLine("\nSaving data to file...");
            Console.WriteLine(record);
            File.AppendAllText(filePath, record);
            Console.WriteLine("\nData saved successfully!");
            return "yes";

        }

        if (confirmation == "no")
        {
            Console.WriteLine("\nLet's re-enter the data...\n");
            return "no";
            //ADD DATA ENTRY LOGIC HERE
        }

        else {
            Console.WriteLine("\nInvalid input. Please enter 'yes' to save data or 'no' to re-enter data.");
            return ConfirmEntry(filePath, record);
        }
    }


} //class Program

public class Record
{
        
}


public class FileSaver{
    string filePath = "gifttracker-data.txt";

    public void CreateFile(string filePath) {
        this.filePath = filePath;
        File.Create(filePath).Close();
        Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
        File.WriteAllText(filePath, "");
        Console.WriteLine("\nNew datafile created.\nPlease return to menu to enter add records.");
        Console.WriteLine("\nPress any key to return to menu:");
        Console.ReadKey();
        return;
    }

    public void SaveData(string filePath, string record)
    {   
        filePath = "gifttracker-data.txt";
        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("\nData saved successfully!");
        return;
    }
}
