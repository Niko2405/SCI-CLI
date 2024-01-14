using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI_CLI
{
	internal class Terminal
	{
		/// <summary>
		/// Primary Logo
		/// </summary>
		private static readonly string[] LogoAscii = [
			"                                                                                \n",
			"                                                                                \n",
			"                                                                                \n",
			"                         ,  @@@@@@             @@@@@@  ,                        \n",
			"                        ,,,  @@@@@@@@@@@@@@@@@@@@@@@  ,,,                       \n",
			"                      ,,,,,,  @@@@@@@@@@@@@@@@@@@@@  ,,,,,,                     \n",
			"                    ,,,,,,,,,  @@@@@@@@@@@@@@@@@@@ ,,,,,,,,,,                   \n",
			"                  ,,,,,,,,,,,,  @@@@@@@@@@@@@@@@@ ,,,,,,,,,,,,,                 \n",
			"               ,,,,,,,,,,,,,,,,, @@@@@@@@@@@@@@@ ,,,,,,,,,,,,,,,,,              \n",
			"           ,,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,,          \n",
			"       ,,,,,,,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,,,,,,,      \n",
			"      @@@   ,,,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,,,   @@@     \n",
			"       @@@@@@@    ,,,,,,,,,,,,,,,,,, @@@@@@@ ,,,,,,,,,,,,,,,,,,   @@@@@@@@      \n",
			"        @@@@@@@@@@@@@   ,,,,,,,,,,,,, @@@@@ ,,,,,,,,,,,,,   @@@@@@@@@@@@@       \n",
			"        @@@@@@@@@@@@@@@@@@@   ,,,,,,,, @@@ ,,,,,,,,   @@@@@@@@@@@@@@@@@@@       \n",
			"         @@@@@@@@@@@@@@@@@@@@@@@@   ,,, @ ,,,   @@@@@@@@@@@@@@@@@@@@@@@@        \n",
			"         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@        \n",
			"         @@@@@@@@@@@@@@@@@@@@@@@@   ,,, @ ,,,   @@@@@@@@@@@@@@@@@@@@@@@@        \n",
			"        @@@@@@@@@@@@@@@@@@@   ,,,,,,,, @@@ ,,,,,,,,   @@@@@@@@@@@@@@@@@@@       \n",
			"        @@@@@@@@@@@@@   ,,,,,,,,,,,,, @@@@@ ,,,,,,,,,,,,,   @@@@@@@@@@@@@       \n",
			"       @@@@@@@@   ,,,,,,,,,,,,,,,,,, @@@@@@@ ,,,,,,,,,,,,,,,,,,   @@@@@@@@      \n",
			"      @@@   ,,,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,,,   @@@     \n",
			"       ,,,,,,,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,,,,,,,      \n",
			"            ,,,,,,,,,,,,,,,,,,,,, @@@@@@@@@@@@@ ,,,,,,,,,,,,,,,,,,,,,           \n",
			"               ,,,,,,,,,,,,,,,,, @@@@@@@@@@@@@@@ ,,,,,,,,,,,,,,,,,              \n",
			"                  ,,,,,,,,,,,,  @@@@@@@@@@@@@@@@@ ,,,,,,,,,,,,,                 \n",
			"                    ,,,,,,,,,  @@@@@@@@@@@@@@@@@@@ ,,,,,,,,,,                   \n",
			"                      ,,,,,,  @@@@@@@@@@@@@@@@@@@@@  ,,,,,,                     \n",
			"                        ,,,  @@@@@@@@@@@@@@@@@@@@@@@  ,,,                       \n",
			"                         ,  @@@@@@             @@@@@@  ,                        \n",
			"                                                                                \n",
			"                                                                                \n",
			"                                                                                \n"
		];

		/// <summary>
		/// Set the Default White / Black mode
		/// </summary>
		private static void SetDefaultColors()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
		}

		/// <summary>
		/// Print the Primary logo
		/// </summary>
		private static void PrintLogo()
		{
			foreach (var line in LogoAscii )
			{
				char[] charArray = line.ToCharArray();
				foreach (var code in charArray)
				{
					if (code == '@')
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(code);
					}
					else if (code == ',' || code == ' ')
					{
						SetDefaultColors();
						Console.Write(code);
					}
					else if (code == '\n')
					{
						Console.WriteLine();
					}
				}
				Thread.Sleep(50);
			}
			SetDefaultColors();
		}

		/// <summary>
		/// Run the Login Terminal
		/// </summary>
		/// <returns>True if login is correct, false when incorrect</returns>
		public static bool RunLoginTerminal()
		{
			bool LoginCorrect = false;

			Console.Title = "Login Interace - CLI Mode";
			PrintLogo();

			string? sInputUser = string.Empty;
			string? sInputAccessCode = string.Empty;
			string? sInputSecurityKey = string.Empty;

			// USERNAME
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("User: ");
			SetDefaultColors();
			sInputUser = Console.ReadLine();

			// ACCESS CODE
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Access Code: ");
			SetDefaultColors();
			sInputAccessCode = Console.ReadLine();

			// SECRUITY KEY
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Security Key: ");
			SetDefaultColors();
			sInputSecurityKey = Console.ReadLine();

			// TODO: SCI-CLI -> SCI-Server -> SCI-CLI (Database)
			NetworkClient.SendData($"database login");
			if (sInputUser == "root" && sInputAccessCode == "123" && sInputSecurityKey == "321")
			{
				LoginCorrect = true;
			}
			return LoginCorrect;
		}

		/// <summary>
		/// Run the main terminal
		/// </summary>
		public static void RunTerminal()
		{
			Console.Clear();
			Console.Title = "Control Interface - CLI Mode";
			PrintLogo();

			while (true)
			{
				string? sInput;
				Console.Write("\ncmd>");
				sInput = Console.ReadLine();
				Console.WriteLine(NetworkClient.SendData(sInput));
			}
		}
		
	}
}
