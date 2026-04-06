using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml;
using Spectre.Console;

namespace GiftTracker;

public class Record
{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime Birthday { get; set; }
    public required string GiftDescription { get; set; }
    public required string VendorName { get; set; }
    public required string VendorURL { get; set; }
    public required string PriceRange { get; set; }


    public static void CreateNewRecord()
    {
        // Enter record data for gift recipient
        Console.Clear();
        Console.WriteLine("Let's create a new record...");

        // Input data to save as json string
        string jsonString = getNewRecordData();

        // Confirm data entry and save to file
        ConfirmNewEntry("gifttracker-data.txt", jsonString);

    } // end CreateNewRecord() method

    public static void ViewAllRecords()
    {
        string filePath = "gifttracker-data.txt";
        string fileContents;

        checkFileExists(filePath);
        fileContents = File.ReadAllText(filePath);
        ConsoleUI.DisplayFileData(fileContents);
        ConsoleUI.PressAnyKeyToContinue();
    } // end ViewAllRecords() method

    public static void ViewAllJsonRecords()
    {
        string filePath = "gifttracker-data.txt";
        string jsonResponse = File.ReadAllText(filePath);
        try {
            AnsiConsole.Write(  
                new Panel(jsonResponse)
                .Header("Birthday Records")
                .RoundedBorder()
                .BorderColor(Color.Green)
            );
        } catch {
            Console.WriteLine("Cannot write jsonResponse to console.");
        };

        ConsoleUI.PressAnyKeyToContinue();
    }

    public static async Task OLDViewAllJsonRecords()
    {

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


    public static void checkFileExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            new FileSaver().CreateFile(filePath);
        } // end if
        else
        {
            try
            {
                ConsoleUI.DisplayFileData(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        } // end else
    }  // end checkFileExists


    public static void writeToEmptyFile(string filePath)
    {
        try
        {
            writeToEmptyFile(filePath);
            Console.WriteLine("Loading data from file...");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }





    public static string getNewRecordData() {
        string firstName = getValidFirstName();

        Console.Clear();
        string lastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
        if (!string.IsNullOrEmpty(lastName))
        {
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

        var jsonRecord = new { firstName, lastName, birthday, giftDescription, vendorName, vendorURL, priceRange };
        string jsonString = JsonSerializer.Serialize(jsonRecord);

        return(jsonString);
    }

    public static void ConfirmNewEntry(string filePath, string jsonString)
    {
        DisplayDataForConfirmation(jsonString);
        
        while (true)
        {
            string confirmation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Is this correct")
                .AddChoices(new[] { "yes", "no", "cancel" }));

            switch (confirmation)
            {
                case "yes":
                    FileSaver.SaveRecord(filePath, jsonString);
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
        string firstName = Console.ReadLine()!;
        // Check if the input is null or empty
        bool isValid = false;
        if (string.IsNullOrEmpty(firstName))
        {
            do
            {
                Console.WriteLine("We need a name to track your gift ideas!\n\nPlease enter a valid (non-empty) first name:");
                firstName = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(firstName))
                {
                    isValid = true;
                }

            } while (!isValid);
        } // end if

        if (firstName != null)
        {
            firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
        } // end if

        return firstName!;
    }


    public static string getValidBirthday(string firstName)
    {
        DateTime birthday;
        string birthdayString;
        // Loop until the user provides a valid date in MM-DD-YYYY format
        while (true)
        {
            birthdayString = ConsoleUI.AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
            if (DateTime.TryParseExact(birthdayString, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthday))
            {
                break;
            }
            Console.WriteLine("Invalid format. Please enter the date as MM-DD-YYYY (e.g., 01-31-2010).");
        }
        return birthday.ToString();
    }


    public static void DisplayDataForConfirmation(string jsonString) {
        // Confirm data entry and save to file
        Console.Clear();
        Console.WriteLine("\nPlease confirm the data below:\n");

        var node = JsonNode.Parse(jsonString);
        
        if (node == null)
        {
            AnsiConsole.MarkupLine("[red]Error: Invalid JSON format.[/red]");
            return;
        }
        else  {}
            foreach (var child in node.AsObject()) 
            {
                AnsiConsole.MarkupLine($"{child.Value?.ToString() ?? string.Empty}");
            }
    }

} // end class Record



internal class JsonText
{
    private string jsonContent;

    public JsonText(string jsonContent)
    {
        this.jsonContent = jsonContent;
    }

    internal object StringColor(Color green)
    {
        throw new NotImplementedException();
    }
}