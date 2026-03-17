namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
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
            Console.Write("🎁GiftTracker🎁\n\nPlease select mode:\n  'view' to view records\n  'new' to enter new records\n  'exit' to exit the app\n> ");
            mode = Console.ReadLine()!.ToLower();

            // Record.ViewAll(): View data from file
            if(mode=="view") {        

                // check that gifttracker-data.txt file is available; if not, create it
                string filePath = "gifttracker-data.txt";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
                    File.WriteAllText(filePath, "");
                    Console.WriteLine("\nNew datafile created.\nPlease return to menu to enter add records.");

                    Console.WriteLine("\nPress any key to return to menu:");
                    Console.ReadKey();
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
            if(mode=="new") {

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

                    Console.WriteLine("\nEnter last name: ");
                    string lastName = Console.ReadLine() ?? "None";
                    if (!string.IsNullOrEmpty(lastName)) {
                        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
                    }
                    
                    Console.WriteLine($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
                    string birthday = Console.ReadLine() ?? "None";

                    Console.WriteLine("\nPlease enter a description of your gift idea.");
                    string giftDescription = Console.ReadLine() ?? "None";

                    Console.WriteLine("\nEnter an optional vendor who sells this gift: ");
                    string vendorName = Console.ReadLine() ?? "None";

                    Console.WriteLine("\nEnter an optional online vendor URL:");
                    string vendorURL = Console.ReadLine() ?? "None";

                    Console.WriteLine("\nEnter an approximate price range for the gift (e.g. $50-$100): ");
                    string priceRange = Console.ReadLine() ?? "None";

                    Console.WriteLine("\nPlease confirm the data below:\n");
                    string recordEntry = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}\nVendor: {vendorName}\nVendor URL: {vendorURL}\nPrice Range: {priceRange}";
                    Console.WriteLine(recordEntry);
                    
                    // Record.ConfirmEntry(): Confirm data entry and save to file
                    Console.WriteLine("\nIs this correct?\n('yes' to save data OR 'no' to re-enter data): ");
                    string confirmation = Console.ReadLine()!.ToLower();

                    if(confirmation=="yes")
                    {
                        // Save to datafile
                        Console.WriteLine("\nSaving data to file...");
                        Console.WriteLine(recordEntry);
                        File.AppendAllText("gifttracker-data.txt", $"{recordEntry}\n\n");
                    }

                    if (confirmation == "no")
                    {
                        break;
                    }
                    
                    Console.WriteLine("\nEnter 'menu' to return to menu or 'new' to add another new record: ");
                    command = Console.ReadLine()!.ToLower();

                } while(command != "menu");

            } // record data loop

        } while(mode != "exit"); // mode selection loop

    } // static void Main

} //class Program
