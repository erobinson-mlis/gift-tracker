using System.Reflection.Metadata;
using Spectre.Console;

namespace GiftTracker;

public class ConsoleUI() {

     public void DisplayWelcomeMessage() {
        // Displays a splash page welcome message when the program is loaded.
        Console.Clear();
        string title = "🎁GiftTracker🎁\n";
        string welcome = "Welcome to GiftTracker, an app for storing names, birthdays, and gift ideas to simplify gift idea tracking.\n";

        Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
        Console.WriteLine(title);
        Console.WriteLine(welcome);

        PressAnyKeyToContinue();
        return;
    } // end DisplayWelcomeMessage() method


     public void DisplayMenu() {
        // Loops over the main menu selection screen;
        // presents menu choices for hierarchical function choices.\
        bool inMenu = true;
        while (inMenu == true) // this loop keeps the menu active
        {
            Console.Clear();
            string mainMenuMode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(new[] {"View all records", "Add new record", "User account", "Exit"}));
            
            switch (mainMenuMode)
            {
                case "View all records":   
                    // Load all data from file for display     
                    Record.ViewAllRecords(); 
                    break;

                case "Add new record":
                    // Create new record and save to datafile
                    Record.CreateNewRecord(); 
                    break;

                case "User account":
                    // Edit user account information for syncing
                    ConsoleUI.UserAccountMenu();
                    break;

                case "Exit":
                    inMenu = false;
                    return;
                
            }
        }
    } // end DisplayMenu() method


     public static void UserAccountMenu() {
        // Loops over the user account menu selection screen;
        // presents menu choices adding users viewing user info 
        bool inSubMenu = true;
        while (inSubMenu == true) // this loop keeps the menu active
        {
            Console.Clear();
            string userAccountMode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select mode")
                    .AddChoices(new[] {"Add user", "View user account", "Go back"}));
            
            switch (userAccountMode)
            {
                case "Add user":   
                    // Load all data from file for display     
                    User.AddUser(); 
                    break;

                case "View user account":
                    // Create new record and save to datafile
                    User.ViewUserAccount(); 
                    break;

                case "Go back":
                    // Return to main selection menu
                    inSubMenu = false;
                    break;
            }
        }
    } // end DisplayMenu() method


     public static void DisplayFileData(string data) {
        // accepts a string of loaded file data and displays it to the screen
        // Accepts:
        // string data : data loaded from the file to be displayed
        if(data.Length < 1) {
            Console.WriteLine("\nData file is currently empty.\nReturn to menu to add new records.");
        } // end if

        if(data.Length > 1) {
            Console.WriteLine($"\n{data}");
        }
        return;
    } // end DisplayData() method


    public static string AskForInput(string prompt)
    {
        // Generic function for presenting a prompt to the user 
        // and accepting input to be returned and saved as a variable
        // Accepts
        // string prompt : the prompt to the user
        // 
        Console.WriteLine(prompt);
        string response = Console.ReadLine() ?? "None";
        return response;
    } // end AskForInput method
    
    
    public static void PressAnyKeyToContinue()
    {
        // Halts screen presentation and waits for user to press
        // a key before clearning the screen and continuing
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
        return;
    }


    public void DisplayGoodbyeMessage() {
        // Presents a simple signout message when exiting the program
        Console.WriteLine("\nThank you for using GiftTracker! Goodbye!\n");
    } // end DisplayGoodbyeMessage() method

} // end ConsoleUI class