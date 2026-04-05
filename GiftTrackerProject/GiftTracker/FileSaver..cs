namespace GiftTracker;

public class FileSaver{
    string filePath = "gifttracker-data.txt";

    public void CreateFile(string filePath) {
        // Creates a datafile and saves it to the local 
        // project folder for accepting saved records
        // Accepts:
        // filePath : the path to the datafile
        this.filePath = filePath;
        File.Create(filePath).Close();
        Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
        File.WriteAllText(filePath, "");
        return;
    }

    public void SaveData(string filePath, string record) {   
        // Writes a data record to the datafile
        // Accepts:
        // filePath : the path to the datafile
        // record : a string record to be saved to the datafile
        this.filePath = filePath;
        Console.Clear();
        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("Data saved successfully!");
        return;
    }
}