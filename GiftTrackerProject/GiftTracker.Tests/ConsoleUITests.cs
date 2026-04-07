namespace GiftTracker.Tests;

using System.Diagnostics.Contracts;
using System.Reflection;
using System.Reflection.Metadata;
using GiftTracker;

public class ConsoleUITests
{
    [Fact]
    public void Test_AskForInput()
    {
        // Tests text entry with AskForInput using simple `input`. The variable should register equal to our input `Bob`.
        var input = "Bob";
        using (var stringReader = new StringReader(input))
        {
            // Redirect Console.In to the string reader
            Console.SetIn(stringReader);

            // Call the static method that uses Console.ReadLine()
            var result = ConsoleUI.AskForInput("Enter your name:");

            // Assert
            Assert.Equal("Bob", result);
        }
    }

    [Fact]
    public void Test_AskForInput_WithEmptyInput()
    {
        // tests the text entry with AskForInput using empty input; should return none if empty.
        var input = "";
        using (var stringReader = new StringReader(input))
        {
            // Redirect Console.In to our string reader
            Console.SetIn(stringReader);

            // Call method that uses Console.ReadLine()
            var result = ConsoleUI.AskForInput("Enter your name:");

            // Should return "None" when input is empty
            Assert.Equal("None", result);
        }
    }
}
