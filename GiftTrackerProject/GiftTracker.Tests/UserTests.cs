namespace GiftTracker.Tests;

using System.Diagnostics.Contracts;
using System.Reflection;
using GiftTracker;

public class UserTests
{

    string userFilePath;

    public UserTests() {
        userFilePath = "user-account.txt";
    }

    [Fact]
    public void Test_ViewUserAccount()
    {
        // Saves user info to a file, then calls ViewUserAccount to ensure it doesn't throw

        // Clear the file first
        File.WriteAllText(userFilePath, "");

        // Write the test account info to the file
        string testAccountInfo = "Name: Bob Smith\nEmail: bob.smith@gmail.com\nTelephone/SMS number: 555-212-2121\n";
        File.WriteAllText(userFilePath, testAccountInfo);

        // Call ViewUserAccount - it should display the data without throwing
        User.ViewUserAccount(userFilePath);

        // Since it displays to console, we can't easily test output, but ensure no exception
        Assert.True(true); // Placeholder - the call above should not throw
    }
}
