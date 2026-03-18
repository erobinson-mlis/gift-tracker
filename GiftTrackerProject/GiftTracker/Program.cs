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
                Record.ViewData();
            }

            // Record.CreateNew(): Create new record and save to file
            if(mode=="add") {

                string command; 

                do {
                    // Enter record data for gift recipient
                    Console.Clear();
                    Console.WriteLine("Let's create a new record...");

                    Console.WriteLine("\nEnter first name: ");
                    string firstName= Console.ReadLine()!;

                    // Check if the input is null or empty
                    bool isValid = false;
                    if (string.IsNullOrEmpty(firstName))
                        do {
                            
                            Console.WriteLine("We need a name to track your gift ideas!\nPlease enter a valid (non-empty) first name:");
                            firstName = Console.ReadLine()!;
                        
                            if (!string.IsNullOrEmpty(firstName))
                            {
                                isValid = true;
                            }
                    } while(!isValid);

                    if (firstName != null) {
                        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
                    }

                    string lastName = AskForInput("\nEnter last name (optional): ");
                    if (!string.IsNullOrEmpty(lastName)) {
                        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
                    }
                    
                    string birthday = AskForInput($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
                
                    string giftDescription = AskForInput("\nPlease enter a description of your gift idea: ");

                    string vendorName = AskForInput("\nEnter an optional vendor who sells this gift: ");

                    string vendorURL = AskForInput("\nEnter an optional online vendor URL: ");

                    string priceRange = AskForInput("\nEnter an optional price range for the gift (e.g. $50-$100): ");

                    string recordEntry = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}\nVendor: {vendorName}\nVendor URL: {vendorURL}\nPrice Range: {priceRange}\n";
                    
                    // Record.ConfirmEntry(): Confirm data entry and save to file
                    Record.ConfirmEntry("gifttracker-data.txt", recordEntry);
                    
                    command = AskForInput("\nEnter 'menu' to return to menu or 'add' to add another new record: ").ToLower();

                } while(command != "menu");
            } // end if add mode

        } while(mode != "exit"); // mode selection loop
        Console.WriteLine("\nThank you for using GiftTracker! Goodbye!");
    }

    public static string AskForInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "None";
    } // end AskForInput method


} //class Program



