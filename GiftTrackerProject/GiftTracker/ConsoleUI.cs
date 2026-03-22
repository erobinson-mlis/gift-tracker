using System.Reflection.Metadata;
using Spectre.Console;

namespace GiftTracker;

public class ConsoleUI() {

     public void DisplayWelcomeMessage() {
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
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "None";
    } // end AskForInput method
    
    
    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
        return;
    }


    public void DisplayGoodbyeMessage() {
        Console.WriteLine("\nThank you for using GiftTracker! Goodbye!\n");
    } // end DisplayGoodbyeMessage() method

} // end ConsoleUI class