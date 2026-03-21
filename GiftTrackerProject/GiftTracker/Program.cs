namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Print welcome message
        ConsoleUI ConsoleUI = new ConsoleUI();
        ConsoleUI.DisplayWelcomeMessage();

        string mode;
        // Mode selection loop
        do {
            // Prompt to select mode
            ConsoleUI.DisplayMenu();
            
            mode = Console.ReadLine()!.ToLower();
            
            if(mode=="view") {        
                Record.ViewData(); // Load data from file for display
            }

            if(mode=="add") {
                Record.CreateNewRecord(); // Create new record and save to file
            }

        } while(mode != "exit"); // mode selection loop

        ConsoleUI.DisplayGoodbyeMessage();
    }

    public static string AskForInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "None";
    } // end AskForInput method

} //class Program



