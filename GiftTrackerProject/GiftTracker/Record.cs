namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Swift;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Spectre.Console;


public class Record {

    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required DateTime Birthday {get; set;}
    public required string GiftDescription {get; set;}
    public required string VendorName {get; set;}
    public required string VendorURL {get; set;}
    public required string PriceRange {get; set;}


    public static void ViewAllRecords() {
        string filePath = "gifttracker-data.txt";
        string fileContents;
    
        checkFileExists(filePath);
        fileContents = File.ReadAllText(filePath); 
        ConsoleUI.DisplayFileData(fileContents);
        ConsoleUI.PressAnyKeyToContinue();
    } // end ViewAllRecords() method


    public static async Task ViewAllJsonRecords() {
        
        string filePath = "gifttracker-data.txt";
        string fileContents = File.ReadAllText(filePath);
        using (StreamReader r = new StreamReader(filePath))
        {
            string jsonString = File.ReadAllText("filePath");
            Console.WriteLine(jsonString);
            // var options = new JsonSerializerOptions {WriteIndented = true};
            // string prettyJson = Console.WriteLine(fileContents, options);
        }

        ConsoleUI.PressAnyKeyToContinue();
    }


    public static void checkFileExists(string filePath) {
        if (!File.Exists(filePath))
        {
            new FileSaver().CreateFile(filePath);
        } // end if

        else {
            try {
                ConsoleUI.DisplayFileData(filePath);
            } 
            catch (IOException e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        } // end else
    }  // end checkFileExists


    public static void writeToEmptyFile(string filePath) {
        try {
                writeToEmptyFile(filePath);
                Console.WriteLine("Loading data from file..."); 
        } catch (IOException e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            } 
    }


    public static void CreateNewRecord() {


        // Enter record data for gift recipient
        Console.Clear();
        Console.WriteLine("Let's create a new record...");

        string firstName = getValidFirstName();

        Console.Clear();
        string lastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
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
        string recordDisplay = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}\nVendor: {vendorName}\nVendor URL: {vendorURL}\nPrice Range: {priceRange}\n";

        var jsonRecord = new {firstName, lastName, birthday, giftDescription, vendorName, vendorURL, priceRange};
        string jsonString = JsonSerializer.Serialize(jsonRecord);

        // Confirm data entry and save to file
        ConfirmNewEntry("gifttracker-data.txt", jsonString);
    } // end CreateNewRecord() method

    public static void ConfirmNewEntry(string filePath, string jsonString)
    {
        // Confirm data entry and save to file
        Console.Clear();
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(jsonString);

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
                var lines = File.ReadAllLines(filePath).ToList();
                lines.Insert(lines.Count-1, $"\t{jsonString},\n");
                File.WriteAllLines(filePath, lines);
                
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


    public static string getValidFirstName() 
    {
        Console.WriteLine("\nEnter first name: ");
        string firstName= Console.ReadLine()!;
        // Check if the input is null or empty
        bool isValid = false;
        if (string.IsNullOrEmpty(firstName)) {
            do {
                Console.WriteLine("We need a name to track your gift ideas!\n\nPlease enter a valid (non-empty) first name:");
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

        return firstName!;
    }


    public static string getValidBirthday(string firstName) {
        DateTime birthday;
        string birthdayString;
        // Loop until the user provides a valid date in dd-MM-yyyy format
        while (true)
        {
            birthdayString = ConsoleUI.AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
            if (DateTime.TryParseExact(birthdayString, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthday))
            {
                break; 
            }
            Console.WriteLine("Invalid format. Please enter the date as DD-MM-YYYY (e.g., 31-12-2010).");
        }
        return birthday.ToString();
    }
} // end class Record