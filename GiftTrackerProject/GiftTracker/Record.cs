namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Swift;
using Spectre.Console;

public class Record {

    public static void CreateNewRecord() {
        // Creates record data for gift recipient by prompting the user to enter data into several data fields, and passes the data to confirmRecord() be confirmed and saved
        Console.Clear();
        Console.WriteLine("Let's create a new record...");

        Console.WriteLine("\nEnter the gift recipient's first name: ");
        string firstName= Console.ReadLine()!;
        // Check if the input is null; first name is required.
        bool isValid = false;
        if (string.IsNullOrEmpty(firstName)) {
            do {
                Console.WriteLine("We need a name to attach to your gift ideas!\nPlease enter a valid (non-empty) first name:");
                firstName = Console.ReadLine()!;
            
                if (!string.IsNullOrEmpty(firstName))
                {
                    isValid = true;
                }

            } while(!isValid);
        } // end if
        // Convert first name to 'title' Upper
        if (firstName != null) {
            firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
        } // end if

        Console.Clear();
        string lastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
        // Convert last name to 'title' Upper
        if (!string.IsNullOrEmpty(lastName)) {
            lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
        } // end if
        Console.Clear();
        string birthday = getValidBirthday(firstName!);
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

    } // end CreateNewRecord() method

    public static void ConfirmNewEntry(string filePath, string record)
    {
        // Confirm data entry and save to file
        Console.Clear();

        // Prompts the user with entered data record and solicits
        // confimation of the correct data. 
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(record);

        while (true)
        {
            // Prompts user with a yes/no selection menu to 
            // confirm presented data
            string confirmation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Is this correct")
                .AddChoices(new[] {"yes", "no", "cancel"}));

            switch (confirmation) {
            case "yes":
                // if yes, saves data to the datafile at filePath
                Console.Clear();
                filePath = "gifttracker-data.txt";
                FileSaver.SaveData(filePath, record);
                ConsoleUI.PressAnyKeyToContinue();
                return;

            case "no":
                // if no, retuns user to main menu
                Console.WriteLine("\nReturn to the menu to re-enter this record...\n");
                ConsoleUI.PressAnyKeyToContinue();
                //TODO: ADD DATA ENTRY LOGIC HERE
                //TODO:Loop back to data entry if user selects 'no' and add option to return to menu
                return;

            case "cancel":
                // if cancel, cancels entry and returns user to main menu
                return;
            }
        }
    } // end ConfirmNewEntry() method

    public static string getValidBirthday(string firstName) {
        // Validates the entry for birthday variable to ensure 
        // that variable is convertable to DateTime type
        DateTime birthday;
        string birthdayString;
        // Loop until the user provides a valid date in dd-MM-yyyy format
        while (true)
        {
            // checks that the birthday variable is in DateTime formtat
            birthdayString = ConsoleUI.AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
            if (DateTime.TryParseExact(birthdayString, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthday))
            {
                break; 
            }
            // Reprompts user to enter the birthday in DateTime format.
            Console.WriteLine("Invalid format. Please enter the date as DD-MM-YYYY (e.g., 31-12-2010).");
        }
        return birthday.ToString();
    }

    public static void ViewAllRecords(string filePath) {
        // Loads data from datafile and displays to screen
        FileSaver.CheckFileExists(filePath);

        Fi
    } // end ViewAllRecords() method
} // end class Record