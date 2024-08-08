namespace Lec7Practice.Utils
{
	public static class Chalk
	{
		public static string Red(string text) => $"\u001b[31m{text}\u001b[0m";
		public static string Green(string text) => $"\u001b[32m{text}\u001b[0m";
		public static string Blue(string text) => $"\u001b[34m{text}\u001b[0m";
		public static string Yellow(string text) => $"\u001b[33m{text}\u001b[0m";
		public static string Magenta(string text) => $"\u001b[35m{text}\u001b[0m";
		public static string Cyan(string text) => $"\u001b[36m{text}\u001b[0m";

		public static string Red(this string me, string other) => $"{me}{Red(other)}";
		public static string Green(this string me, string other) => $"{me}{Green(other)}";
		public static string Blue(this string me, string other) => $"{me}{Blue(other)}";
		public static string Yellow(this string me, string other) => $"{me}{Yellow(other)}";
	}
}
// Console.WriteLine(Chalk.Blue("nice").Green("dog").Yellow("!"));