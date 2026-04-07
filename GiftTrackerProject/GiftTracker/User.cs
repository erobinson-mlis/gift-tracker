using System.ComponentModel.Design;
using System.IO;
using System.Threading.Tasks.Dataflow;
using Spectre.Console;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GiftTracker;


public static class User{
    public static void ViewUserAccount()
    {
        string userFilePath = "user-account.txt";
        
        // check for existing of user data file
        FileSaver.CheckFileExists(userFilePath);
    }


    public static void EditUser()
    {
        string userFilePath = "user-account.txt";
        
        FileSaver.CheckFileExists(userFilePath);

        string fileContents = File.ReadAllText(userFilePath);
        if (fileContents.Length <= 2)
        {
            PromptUserAccountEntry();
        }
        
        else
        {
            // Parse existing data
            var lines = fileContents.Trim().Split('\n');
            string existingFirstName = "";
            string existingLastName = "";
            string existingEmail = "";
            string existingSMS = "";

            foreach (var line in lines)
            {
                if (line.StartsWith("Name: "))
                {
                    var nameParts = line.Substring(6).Split(' ');
                    if (nameParts.Length >= 1) existingFirstName = nameParts[0];
                    if (nameParts.Length >= 2) existingLastName = string.Join(" ", nameParts.Skip(1));
                }
                else if (line.StartsWith("Email: "))
                {
                    existingEmail = line.Substring(7);
                }
                else if (line.StartsWith("Telephone/SMS number: "))
                {
                    existingSMS = line.Substring(22);
                }
            }



            while (true)
            {
                // Prompts user with a yes/no selection menu to 
                // confirm presented data
                string editApproved = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Would you like to edit the existing data?")
                    .AddChoices(new[] { "yes", "no", "cancel" }));

                switch (editApproved)
                {
                    case "yes":
                        PromptUserAccountEntry(existingFirstName, existingLastName, existingEmail, existingSMS);
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
    } // end EditUser() method


    public static void PromptUserAccountEntry(string defaultFirstName = "", string defaultLastName = "", string defaultEmail = "", string defaultSMS = "")
    {
        // Creates or edits user account data for application user to store
        // email address and sms contact for future enhancements

        Console.Clear();
        Console.WriteLine("Let's add/edit your user information...");
        // Removed: File.WriteAllText(userFilePath, ""); - will clear in ConfirmNewEntry if confirmed

        // First name
        Console.WriteLine($"\nEnter the user's first name{(string.IsNullOrEmpty(defaultFirstName) ? "" : $" (current: {defaultFirstName})")}: ");
        string userFirstName = Console.ReadLine()!;
        if (string.IsNullOrEmpty(userFirstName) && !string.IsNullOrEmpty(defaultFirstName))
        {
            userFirstName = defaultFirstName;
        }
        else if (string.IsNullOrEmpty(userFirstName))
        {
            while (string.IsNullOrEmpty(userFirstName))
            {
                Console.WriteLine("We need a name to attach to your user account.");
                userFirstName = Console.ReadLine()!;
            }
        }

        // Convert first name to Title case 
        if (!string.IsNullOrEmpty(userFirstName))
        {
            userFirstName = char.ToUpper(userFirstName[0]) + userFirstName.Substring(1).ToLower();
        }

        Console.Clear();
        string userLastName = ConsoleUI.AskForInput($"\nEnter last name (optional{(string.IsNullOrEmpty(defaultLastName) ? "" : $", current: {defaultLastName}")}) : ");
        if (string.IsNullOrEmpty(userLastName) && !string.IsNullOrEmpty(defaultLastName))
        {
            userLastName = defaultLastName;
        }
        if (!string.IsNullOrEmpty(userLastName))
        {
            userLastName = char.ToUpper(userLastName[0]) + userLastName.Substring(1).ToLower();
        } // end if


        // Get valid email address (using regex pattern match)
        string userEmail;
        bool emailIsValid = false;
        do
        {
            userEmail = ConsoleUI.AskForInput($"\nPlease enter your email address{(string.IsNullOrEmpty(defaultEmail) ? "" : $" (current: {defaultEmail})")}: ");
            if (string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(defaultEmail))
            {
                userEmail = defaultEmail;
                emailIsValid = true;
            }
            else
            {
                try {
                    // Validate format using MailAddress
                    var addr = new MailAddress(userEmail);
                    emailIsValid = addr.Address == userEmail;
                } catch {
                    emailIsValid = false;
                }

                if (!emailIsValid) {
                    Console.WriteLine("Invalid email format. Please try again.");
                }
            }
        } while (!emailIsValid); // Loop until input is valid





        Console.Clear();
        // Get valid telephone number for SMS
        string userSMS;
        // Regex for format XXX-XXX-XXXX
        string pattern = @"^\d{3}-\d{3}-\d{4}$"; 
        do
        {
            userSMS = ConsoleUI.AskForInput($"\nEnter your telephone number{(string.IsNullOrEmpty(defaultSMS) ? "" : $" (current: {defaultSMS})")}: ");
            if (string.IsNullOrEmpty(userSMS) && !string.IsNullOrEmpty(defaultSMS))
            {
                userSMS = defaultSMS;
            }
            else if (!Regex.IsMatch(userSMS, pattern))
            {
                Console.WriteLine("Invalid format. Please enter a 10-digit number (###-###-####).");
            }
        } 
        while (!Regex.IsMatch(userSMS, pattern));

        Console.WriteLine($"Valid number entered: {userSMS}");








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
                File.WriteAllText(userFilePath, $"{userData}\n");
                Console.WriteLine("Data saved successfully!");
                return;

            case "no":
                // if no, retuns user to main menu
                Console.WriteLine("\nReturn to the menu to re-enter this user...\n");
                //TODO: ADD DATA ENTRY LOGIC HERE
                //TODO:Loop back to data entry if user selects 'no' and add option to return to menu
                return;

            case "cancel":
                // if cancel, cancels entry and returns user to main menu
                return;
            }
        }
    } // end ConfirmNewEntry() method
}