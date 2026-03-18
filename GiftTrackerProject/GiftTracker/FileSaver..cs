namespace GiftTracker;

public class FileSaver{
    string filePath = "gifttracker-data.txt";

    public void CreateFile(string filePath) {
        this.filePath = filePath;
        File.Create(filePath).Close();
        Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
        File.WriteAllText(filePath, "");
        Console.WriteLine("\nNew datafile created.\nPlease return to menu to enter add records.");
        Console.WriteLine("\nPress any key to return to menu:");
        Console.ReadKey();
        return;
    }

    public void SaveData(string filePath, string record)
    {   
        this.filePath = filePath;
        Console.Clear();
        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("Data saved successfully!");
        return;
    }
}