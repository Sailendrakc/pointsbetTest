using System.Text;
using System;

/*
    Improve a block of code as you see fit in C#.
    You may make any improvements you see fit, for example:
      - Cleaning up code
      - Removing redundancy
      - Refactoring / simplifying
      - Fixing typos
      - Any other light-weight optimisation
    */
public class StringFormatter
{
	#region refactored method

	/* Below are the refactorings I intend to do.
		1. Change name of function to represent what it does.
		2. Perform null checks and include comments in the way.
		3. Provide default parameter value for the quote.
		4. Removing string.format as it creates new instance of string, 
			defeating the purpose of using stringbuilder.
		5. Use foreach to simplify code and make it more clean and readable.
		6. My intention was to print a string from a list, with items wrapped in quotes.
	*/

	/// <summary>
	/// This method takes an array of strings and returns a comma-separated string of those items, each wrapped in the specified quote character.
	/// </summary>
	public static string ToCommaSepatatedString(string[] items, string quote = "\"")
	{
		//null check
		if (items == null || items.Length < 1)
		{
			Console.WriteLine("Empty/null string list passed");
			return "";
		}

		//initiate stringbuilder instance
		StringBuilder resultString = new StringBuilder();

		//loop and append the string in required format for example,
		//to have end result like '"hello", "how", "are", "you"'
		foreach (string str in items)
		{
			resultString.Append(quote).Append(str).Append(quote).Append(", ");
		}

		//removing the traling comma and space
		resultString.Remove(resultString.Length - 2, 2);

		//return
		return resultString.ToString();
	}

	#endregion

	#region Old Method for documentation
	/// <summary>
	/// This is old original method for documentation prupose.
	/// </summary>
	public static string ToCommaSepatatedList(string[] items, string quote)
	{
		StringBuilder qry = new StringBuilder(string.Format("{0}{1}{0}", quote, items[0]));

		if (items.Length > 1)
		{
			for (int i = 1; i < items.Length; i++)
			{
				qry.Append(string.Format(", {0}{1}{0}", quote, items[i]));
			}
		}

		return qry.ToString();
	}
	#endregion



	#region Run and test
	/// <summary>
	/// This method and run the refactored method.
	/// Did not created unit tests to simplify.
	/// Run using 'dotnet run --project StringFormatter.csproj' in CLI.
	/// </summary>
	public static void Main()
	{
		string[] stringArray = ["Hello", "how", "are", "you"];
		string result = ToCommaSepatatedString(stringArray);
		Console.WriteLine(result);
	}

	#endregion
}
