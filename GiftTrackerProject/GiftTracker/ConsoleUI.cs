namespace GiftTracker;

public class ConsoleUI {

     public void DisplayWelcomeMessage() {
        Console.Clear();
        Console.WriteLine("🎁GiftTracker🎁\n\nWelcome to GiftTracker, an app for storing names,\nbirthdays, and gift idea information to simplify\ngift idea tracking.");
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
        return;
    }

     public void DisplayMenu() {
        Console.Clear();
        Console.Write("🎁GiftTracker🎁\n\nPlease select mode:\n  'view' to view records\n  'add' to enter new records\n  'exit' to exit the app\n> ");
     }

     public void DisplayData(string data) {
        Console.Clear();
        Console.WriteLine("Loading data from file...");
        if(data.Length < 1) {
            Console.WriteLine("\nData file is currently empty.\nReturn to menu to add new records.");
        } // end if

        if(data.Length > 1) {
            Console.WriteLine($"\n{data}");
        }

        Console.WriteLine("\nPress any key to return to menu:");
        Console.ReadKey();
    } // end DisplayData() method

    public void DisplayGoodbyeMessage() {
        Console.WriteLine("\nThank you for using GiftTracker! Goodbye!");
    } // end DisplayGoodbyeMessage() method

} // end class ConsoleUI