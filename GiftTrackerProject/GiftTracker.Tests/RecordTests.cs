// namespace GiftTracker.Tests;

// using System.Reflection;
// using GiftTracker;

// public class RecordTests
// {
//     FileSaver myFileSaver;
//     string testFilePath;
//     string testDataString;

//     public FileSaverTests()
//     {
//         myFileSaver = new FileSaver();
//         testFilePath = "test-file.txt";
//         testDataString = "Bob Smith";
//         testBirthdayFalse = "12-30-2010";
//     }

//     [Fact]
//     public void Test_GetValidBirthday() {   
//         // Creates a datafile with a single testDataString entry saved, and then displays the data to be sure that the file is display is equal to the file contents

//         myFileSaver.getValidBirthday(testFilePath, testBirthdayFalsee);
//         testDisplay = myFileSaver.ViewAllRecords(testFilePath);

//         Assert.Equal(testDataString, testDisplay);

//     }

//     [Fact]
//     public void Test_CreateNewRecord() {   
//         // Creates a datafile with a single testDataString entry saved, and then displays the data to be sure that the file is display is equal to the file contents

//         myFileSaver.SaveData(testFilePath, testDataString);
        
//         var contentFromFile = File.ReadAllText(testFilePath);
//         Assert.Equal("Bob Smith", contentFromFile);
//     }
// }
