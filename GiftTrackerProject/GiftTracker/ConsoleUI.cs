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
        // presents menu choices for hierarchical function choices.
        while (true) // this loop keeps the menu active
        {
            Console.Clear();
            string mode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(new[] {"View all records", "Add new record", "Close"}));
            
            switch (mode)
            {
                case "View all records":        
                    Record.ViewAllRecords(); // Load data from file for display
                    break;

                case "Add new record":
                    Record.CreateNewRecord(); // Create new record and save to 
                    break;

                case "Close":
                    return;
                
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