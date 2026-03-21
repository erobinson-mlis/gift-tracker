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


    public static void CreateNewRecord() {
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

            Console.Clear();
            string lastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
            if (!string.IsNullOrEmpty(lastName)) {
                lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
            }
            
            Console.Clear();
            string birthday = ConsoleUI.AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");

            Console.Clear();
            string giftDescription = ConsoleUI.AskForInput("\nPlease enter a description of your gift idea: ");

            Console.Clear();
            string vendorName = ConsoleUI.AskForInput("\nEnter an optional vendor who sells this gift: ");

            Console.Clear();
            string vendorURL = ConsoleUI.AskForInput("\nEnter an optional online vendor URL: ");

            Console.Clear();
            string priceRange = ConsoleUI.AskForInput("\nEnter an optional price range for the gift (e.g. $50-$100): ");

            Console.Clear();
            string recordEntry = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}\nVendor: {vendorName}\nVendor URL: {vendorURL}\nPrice Range: {priceRange}\n";
            
            // Confirm data entry and save to file
            ConfirmNewEntry("gifttracker-data.txt", recordEntry);
            
            command = ConsoleUI.AskForInput("\nEnter 'menu' to return to menu or 'add' to add another new record: ").ToLower();

        } while(command != "menu");
    } // end CreateNewRecord() method

    public static void ConfirmNewEntry(string filePath, string record)
    {
        // Confirm data entry and save to file
        Console.Clear();
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(record);
                    
        string confirmation = ConsoleUI.AskForInput("Is this correct?\n('yes' to save data OR 'no' to re-enter data): ")!.ToLower();

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
            ConfirmNewEntry(filePath, record);
        } // end else
    } // end ConfirmNewEntry() method

} // end class Record