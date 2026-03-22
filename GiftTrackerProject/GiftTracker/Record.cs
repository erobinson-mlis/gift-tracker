namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Swift;
using Spectre.Console;

public class Record {
    public static void ViewAllRecords() {
        string filePath = "gifttracker-data.txt";

        if (!File.Exists(filePath))
        {
            new FileSaver().CreateFile(filePath);

        } // end if

        else {
            try {
                Console.WriteLine("Loading data from file..."); 
                string fileContents = File.ReadAllText(filePath); 
                ConsoleUI.DisplayFileData(fileContents); 
            } 
            catch (IOException e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }
        
        ConsoleUI.PressAnyKeyToContinue();
    } // end ViewAllRecords() method


    public static void CreateNewRecord() {
        // Enter record data for gift recipient
        Console.Clear();
        Console.WriteLine("Let's create a new record...");

        Console.WriteLine("\nEnter first name: ");
        string firstName= Console.ReadLine()!;

        // Check if the input is null or empty
        bool isValid = false;
        if (string.IsNullOrEmpty(firstName)) {
            do {
                Console.WriteLine("We need a name to track your gift ideas!\nPlease enter a valid (non-empty) first name:");
                firstName = Console.ReadLine()!;
            
                if (!string.IsNullOrEmpty(firstName))
                {
                    isValid = true;
                }

            } while(!isValid);
        } // end if

        if (firstName != null) {
            firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
        } // end if

        Console.Clear();
        string lastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
        if (!string.IsNullOrEmpty(lastName)) {
            lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
        } // end if
        
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

    } // end CreateNewRecord() method

    public static void ConfirmNewEntry(string filePath, string record)
    {
        // Confirm data entry and save to file
        Console.Clear();
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(record);

        while (true)
        {
            string confirmation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Is this correct")
                .AddChoices(new[] {"yes", "no", "cancel"}));

            switch (confirmation) {
            case "yes":
                // TODO: FileSaver.SaveRecord(record)
                Console.Clear();
                filePath = "gifttracker-data.txt";
                Console.WriteLine("\nSaving data to file...\n");
                Console.WriteLine(record);
                File.AppendAllText(filePath, $"{record}\n");
                Console.WriteLine("Data saved successfully!");
                ConsoleUI.PressAnyKeyToContinue();
                return;

            case "no":
                Console.WriteLine("\nReturn to the menu to re-enter this record...\n");
                ConsoleUI.PressAnyKeyToContinue();
                //TODO: ADD DATA ENTRY LOGIC HERE
                //TODO:Loop back to data entry if user selects 'no' and add option to return to menu
                return;

            case "cancel":
                return;
            }
        }

    } // end ConfirmNewEntry() method

} // end class Record