using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StringsHW
{
    internal class Program
    {
        public static string ConcatenateStrings(string originalString, string addString)
        {
            string result = string.Concat(originalString, addString);
            return result;
        }

        public static string GreetUser(string name, int age)
        {
            string result = $"Hello, {name}!\nYou are {age} years old!";
            return result;
        }

        public static string StringInfo(string input)
        {
            string result = ($"{input.Length}, {input.ToLower()}, {input.ToUpper()}");
            return result;
        }

        public static string ReturnFirstFive(string input)
        {
            string result = input.Substring(0, 5);
            return result;
        }

        public static string BuildSentence(string[] words)
        {
            var sb = new StringBuilder();
            sb.AppendJoin(" ", words);
            return sb.ToString();
        }

        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {
            string result = inputString.Replace(wordToReplace, replacementWord);
            return result;
        }

        static void Main(string[] args)
        {
            string checkFirstMethod = ConcatenateStrings("It's a ", "beautiful world!");
            Console.WriteLine(checkFirstMethod);

            string checkSecondMethod = GreetUser("Bob", 70);
            Console.WriteLine(checkSecondMethod);

            string checkThirdMethod = StringInfo("An example string!");
            Console.WriteLine(checkThirdMethod);

            string checkForthMethod = ReturnFirstFive("Roses are red");
            Console.WriteLine(checkForthMethod);;
            Console.WriteLine(checkForthMethod.Length);

            string[] words = new[]{ "Roses", "are", "red", "violets", "are", "blue"};
            Console.WriteLine(BuildSentence(words));

            string checkSixthMethod = ReplaceWords("Roses are blue", "Roses", "Violets");
            Console.WriteLine(String.Equals("Violets are blue", checkSixthMethod));
        }
    }
}
