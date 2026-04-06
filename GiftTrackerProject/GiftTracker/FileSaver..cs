namespace GiftTracker;

public class FileSaver{
    string filePath = "gifttracker-data.txt";

    public void CreateFile(string filePath) {
        this.filePath = filePath;
        File.Create(filePath).Close();
        Console.WriteLine("\nNo datafile present.\n>>> Creating new datafile...");
        string emptyJson = "{\n}";
        File.AppendAllText(filePath, emptyJson);
        return;
    } // end CreateFile

    public void SaveData(string filePath, string record)
    {   
        this.filePath = filePath;
        Console.Clear();
        Console.WriteLine("\nSaving data to file...");
        Console.WriteLine(record);
        File.AppendAllText(filePath, record);
        Console.WriteLine("Data saved successfully!");
        return;
    } // end SaveData()

    public static void SaveRecord(string filePath, string jsonString) {
        // TODO: FileSaver.SaveRecord(record)
        Console.Clear();
        filePath = "gifttracker-data.txt";
        Console.WriteLine("\nSaving data to file...\n");
        var lines = File.ReadAllLines(filePath).ToList();
        lines.Insert(lines.Count - 1, $"\t{jsonString},\n");
        File.WriteAllLines(filePath, lines);

        Console.WriteLine("Data saved successfully!");
        ConsoleUI.PressAnyKeyToContinue();
        return;
    } // end SaveRecord()

} // end FileSaver