namespace GiftTracker.Tests;

using System.Reflection;
using GiftTracker;

public class FileSaverTests
{
    FileSaver myFileSaver;
    string testFilePath;
    string testDataString;

    public void FileSaverTests()
    {
        myFileSaver = new FileSaver();
        testFilePath = "test-file.txt";
        testDataString = "Bob Smith";
    }

    [Fact]
    public void Test_SaveData() {   
        // Saves data string to a file at testFilePath; Ensures that the content is written to the file, and that the updated file is the appropriate length

        myFileSaver.SaveData(testFilePath, testDataString);
        var contentFromFile = File.ReadAllText(testFilePath);
        
        Assert.Equal("Bob Smith", contentFromFile);
    }
}
