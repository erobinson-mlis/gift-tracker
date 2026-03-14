namespace GiftTracker;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the 🎁GiftTracker🎁");
        Console.Write("\nPlease select mode (view OR record):");
        string mode = Console.ReadLine();
        
        // data.View(): View data from file
        if(mode=="view") {
            Console.Clear();
            Console.WriteLine("Loading data from file...");
            string fileContents = File.ReadAllText("gifttracker-data.txt");

            Console.WriteLine($"\n{fileContents}");

        } //if(mode=="view")


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

                Console.WriteLine("\nEnter command (end OR continue): ");
                command = Console.ReadLine();
            } while(command != "end");

        } // if(mode=="record")

    } //static void Main

} //class Program
