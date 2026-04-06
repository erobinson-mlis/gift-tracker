using System.ComponentModel.Design;
using System.IO;
using System.Threading.Tasks.Dataflow;
using Spectre.Console;

namespace GiftTracker;


public static class User{
    public static void ViewUserAccount()
    {
        // Loads data from userFilePath and displays to screen
        string userFilePath = "user-account.txt";
        if (!File.Exists(userFilePath))
        {
            FileSaver.CreateFile(userFilePath);

        } // end if

        else {
            try {
                Console.WriteLine("Loading data from file..."); 
                string fileContents = File.ReadAllText(userFilePath); 
                ConsoleUI.DisplayFileData(fileContents); 
            } 
            catch (IOException e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }
        ConsoleUI.PressAnyKeyToContinue();
    }


    public static void AddUser()
    {
        string userFilePath = "user-account.txt";
        // Loads data from userFilePath and displays to screen
        if (!File.Exists(userFilePath))
        {
            FileSaver.CreateFile(userFilePath);

        } // end if

        string fileContents = File.ReadAllText(userFilePath);
        if (fileContents.Length <= 2)
        {
            PromptUserAccountEntry();
        }
        
        else
        {
            Console.WriteLine("User account file has already been created.\nOnly one user account is currently allowed.\n");
            while (true)
            {
                // Prompts user with a yes/no selection menu to 
                // confirm presented data
                string overwriteApproved = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Would you like to overwrite the data?")
                    .AddChoices(new[] { "yes", "no", "cancel" }));

                switch (overwriteApproved)
                {
                    case "yes":
                        PromptUserAccountEntry();
                        return;

                    case "no":
                        // if no, returns to previous menu
                        return;

                    case "cancel":
                        // if cancel, cancels entry and returns user to main menu
                        return;
                }
            }
        }
    } // end CreateNewRecord() method


    public static void PromptUserAccountEntry()
    {
        // Creates user account data for application user to store
        // email address and sms contact for future enhancements

        string userFilePath = "user-account.txt";
        Console.Clear();
        Console.WriteLine("Let's add your user information...");
        File.WriteAllText(userFilePath, "");
        Console.WriteLine("\nEnter the user's first name: ");
        string userFirstName = Console.ReadLine()!;

        // Check if the input is null or empty
        bool isValid = false;
        if (string.IsNullOrEmpty(userFirstName))
        {
            do
            {
                Console.WriteLine("We need a name to attach to your user account.");
                userFirstName = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(userFirstName))
                {
                    isValid = true;
                }

            } while (!isValid);
        } // end if

        // Convert first name to Title case 
        if (userFirstName != null)
        {
            userFirstName = char.ToUpper(userFirstName[0]) + userFirstName.Substring(1).ToLower();
        } // end if

        Console.Clear();
        string userLastName = ConsoleUI.AskForInput("\nEnter last name (optional): ");
        if (!string.IsNullOrEmpty(userLastName))
        {
            userLastName = char.ToUpper(userLastName[0]) + userLastName.Substring(1).ToLower();
        } // end if

        Console.Clear();
        string userEmail = ConsoleUI.AskForInput("\nPlease enter your email address: ");

        Console.Clear();
        string userSMS = ConsoleUI.AskForInput("\nEnter your telephone number: ");


        Console.Clear();
        string userEntry = $"Name: {userFirstName} {userLastName}\nEmail: {userEmail}\nTelephone/SMS number: {userSMS}\n";

        // Confirm data entry and save to file
        ConfirmNewEntry("user-account.txt", userEntry);
    }
    public static void ConfirmNewEntry(string userFilePath, string userData)
    {
        // Confirm user data entry and save to file
        Console.Clear();

        // Prompts the user with entered data record and solicits
        // confimation of the correct data. 
        Console.WriteLine("\nPlease confirm the data below:\n");
        Console.WriteLine(userData);

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
                // if yes, saves data to the datafile at userFilePath
                Console.Clear();
                Console.WriteLine("\nSaving user account information to file...\n");
                Console.WriteLine(userData);
                File.AppendAllText(userFilePath, $"{userData}\n");
                Console.WriteLine("Data saved successfully!");
                ConsoleUI.PressAnyKeyToContinue();
                return;

            case "no":
                // if no, retuns user to main menu
                Console.WriteLine("\nReturn to the menu to re-enter this user...\n");
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


    private static void EditUser()
    {
        throw new NotImplementedException();
    }
}