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
        ConsoleUI ui = new ConsoleUI();

        // Display welcome splash page
        ui.DisplayWelcomeMessage();

        // Mode selection loop
        ui.DisplayMenu();

        // Confirm signout with goodbye message
        ui.DisplayGoodbyeMessage();
    }

} //class Program



