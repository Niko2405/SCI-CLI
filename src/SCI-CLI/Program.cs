using SCI_Logger;

namespace SCI_CLI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Logging.IsDebugEnabled = true;
			Logging.Debug("Starting app...");

			Init.StartInit();

			Logging.Debug("Run -> LoginTerminal");
			if (Terminal.RunLoginTerminal())
			{
				Logging.Info("Login is correct");
				Logging.Debug("Run -> Terminal");
				Thread.Sleep(1000);

				Terminal.RunTerminal();
				System.Environment.Exit(0);
			}
			else
			{
				Logging.Error("Login incorrect. You are now reported.");
				System.Environment.Exit(-1);
			}
		}
	}
}
