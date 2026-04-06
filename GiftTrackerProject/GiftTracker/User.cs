using System.IO;
using System.Threading.Tasks.Dataflow;
using Spectre.Console;

namespace GiftTracker;


public static class User{

    static string userFilePath = "user-account.txt";

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
                    .AddChoices(new[] {"Add User", "View user information", "Go back"}));
            
            switch (userAccountMode)
            {
                case "Add user":   
                    // Load all data from file for display     
                    User.AddUser(); 
                    break;

                case "Edit user":
                    // Create new record and save to datafile
                    User.EditUserAccount(); 
                    break;

                case "Go back":
                    // Return to main selection menu
                    inSubMenu = false;
                    break;
            }
        }
    } // end DisplayMenu() method

    private static void EditUserAccount()
    {
        FileSaver.CheckFileExists("user-account.txt");
    }

    private static void EditUser()
    {
        throw new NotImplementedException();
    }

    private static void AddUser()
    {
        throw new NotImplementedException();
    }
}