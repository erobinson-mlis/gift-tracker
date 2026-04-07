namespace GiftTracker.Tests;

using System.Diagnostics.Contracts;
using System.Reflection;
using GiftTracker;

public class FileSaverTests
{

    FileSaver fileSaver;
    string filePath;

    public FileSaverTests() {
        filePath = "test-data.txt";
        fileSaver = new FileSaver(filePath);
    }

    [Fact]
    public void Test_SaveData()
    {
        // Writes a test "record" to the data filePath, then loads the data to ensure it matches

        // Clear the file first
        File.WriteAllText(filePath, "");
        // Write the data to the filePath
        fileSaver.SaveData(filePath, "Bob Smith");
        // Load data from filePath
        var contents = File.ReadAllText(filePath);

        // Compare to ensure thay are equal
        Assert.Equal("Bob Smith", contents);
    }
}
