namespace GiftTracker.Tests;

using System.Diagnostics.Contracts;
using System.Reflection;
using GiftTracker;

public class FileSaverTests
{
    string filePath;

    public FileSaverTests() {
        filePath = "test-data.txt";
    }

    [Fact]
    public void Test_SaveData()
    {
        // Writes a test "record" to the data filePath, then loads the data to ensure it matches

        // Clear the file first
        File.WriteAllText(filePath, "");
        // Call the static SaveData method
        FileSaver.SaveData(filePath, "Bob Smith");
        // Load data from filePath
        var contents = File.ReadAllText(filePath);

        // Compare to ensure they are equal
        Assert.Equal("Bob Smith", contents);
    }
}
