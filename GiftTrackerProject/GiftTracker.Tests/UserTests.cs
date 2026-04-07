namespace GiftTracker.Tests;

using System.Diagnostics.Contracts;
using System.Reflection;
using GiftTracker;

public class UserTests
{

    User user;
    string userFilePath;

    public FileSaverTests() {
        userFilePath = "user-account.txt";
        user = new User(filePath);
    }

    [Fact]
    public void Test_ViewUserAccount()
    {
        // Saves user info to a file, then reads the file to ensure that read data matches

        // Clear the file first
        File.WriteAllText(userFilePath, "");

        // Write the test account info to the filePat
        string testAccountInfo = "Bob Smith\nbob.smith@gmail.com\n555-212-2121";
        File.WriteAllText(userFilePath, testAccountInfo);

        var contents = Test_ViewUserAccount(userFilePath);

        // Compare to ensure thay are equal
        Assert.Equal(testAccountInfo, contents);
    }
}
