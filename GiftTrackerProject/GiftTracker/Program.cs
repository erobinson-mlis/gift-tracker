namespace GiftTracker;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Print welcome message
        Console.Clear();
        Console.WriteLine("🎁GiftTracker🎁\n\nWelcome to GiftTracker, an app for storing names,\nbirthdays, and gift idea information to simplify\ngift idea tracking");
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();

        string mode;

        // Mode selection loop
        do {
            // Prompt to select mode
            Console.Clear();
            Console.Write("\nPlease select mode:\n'view' to view records\n'record' to enter new records\n'exit' to exit the app\n: ");
            mode = Console.ReadLine();

            // data.View(): View data from file
            if(mode=="view") {        

                // check that gifttracker-data.txt file is available; if not, create it
                string filePath = "gifttracker-data.txt";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
                    File.WriteAllText(filePath, "");
                    Console.WriteLine("\nNew datafile created.\nPlease return to menu to enter add records.");

                    string main_menu;
                    // Load data from filePath
                    do
                    {
                        Console.WriteLine("\nEnter 'return' to return to menu:");
                        main_menu = Console.ReadLine();
                    } while (main_menu != "return");
                } // end if

                else {
                    string command; 
                    string fileContents = File.ReadAllText("gifttracker-data.txt");
                    // Load data from filePath
                    do {
                        Console.Clear();
                        Console.WriteLine("Loading data from file...");
                        // Check length of data file and display file empty if no contents
                        if(fileContents.Length < 1) {
                            Console.WriteLine("Data file is currently empty.\nReturn to menu to add new records.");
                        } // end if

                        Console.WriteLine($"\n{fileContents}");

                        Console.WriteLine("Enter 'return' to return to menu:");
                        command = Console.ReadLine();
                    } while(command != "return");
                } // end else


            } // view data loop

            // data.Record(): Record new record for gift recipient
            if(mode=="record") {

                string command; 

                do {
                    // data.newRecord()
                    Console.Clear();
                    Console.WriteLine("Let's create a new record...");

                    Console.WriteLine("\nEnter first name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine($"\nThis gift is for {firstName} {lastName}.");
                    
                    Console.WriteLine($"\nEnter {firstName}'s birthday: (DD-MM-YYYY): ");
                    string birthday = Console.ReadLine();

                    Console.WriteLine("\nPlease enter a description of your gift idea.");
                    string giftDescription = Console.ReadLine();

                    Console.WriteLine("\nRecording data...");
                    string recordEntry = $"Name: {firstName} {lastName}\nBirthday: {birthday}\nGift Idea: {giftDescription}";
                    Console.WriteLine(recordEntry);
                    File.AppendAllText("gifttracker-data.txt", $"{recordEntry}\n\n");

                    Console.WriteLine("\nEnter 'return' to return to menu or 'add' to add another record: ");
                    command = Console.ReadLine();
                } while(command != "return");

            } // record data loop

        } while(mode != "exit"); // mode selection loop

    } // static void Main

} //class Program
