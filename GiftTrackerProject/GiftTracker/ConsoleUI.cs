using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Spectre.Console;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Text.Json;

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


     public static async Task DisplayMenu() {
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
                    // Load data from file for display    
                    Record.ViewAllRecords(); 
                    break;

                case "Add new record":
                    // Create new record and save to 
                    Record.CreateNewRecord(); 
                    break;

                case "Close":
                    // Close the program and exit
                    return;
            }
        }
    } // end DisplayMenu() method


    public static void DisplayFileData(string data) {
        if(data.Length < 5) {
            Console.WriteLine("\nData file is currently empty.\nReturn to menu to add new records.");
            } // end if

        else if(data.Length > 1) {
             Console.WriteLine($"\n{data}");
        } // end else
        
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
        _ = Console.ReadKey();
        return;
    }


    public void DisplayGoodbyeMessage() {
        Console.WriteLine("\nThank you for using GiftTracker! Goodbye!\n");
    } // end DisplayGoodbyeMessage() method

} // end ConsoleUI class