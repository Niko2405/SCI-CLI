using SCI_Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI_CLI
{
	internal class ConfigManager
	{
		public static void CreateConfig()
		{
			try
			{
				File.WriteAllText(Data.CONF_FILE, $"ServerIP{Data.CONF_SEPERATOR}{Data.ServerIP}\nServerPort{Data.CONF_SEPERATOR}{Data.ServerPort}");
			}
			catch (Exception ex)
			{
				Logging.Error(ex.Message);
			}
		}
		public static void LoadConfig()
		{
			try
			{
				using var fileStream = File.OpenRead(Data.CONF_FILE);
				using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128);
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{
					if (line.Contains("ServerIP"))
					{
						Data.ServerIP = line.Split(Data.CONF_SEPERATOR)[1];
						if (Data.ServerIP == string.Empty)
						{
							Logging.Warn("Config file is corrupted. Set default Value");
							Data.ServerIP = "127.0.0.1";
						}
						Logging.Debug($"Config -> ServerIP updated to {Data.ServerIP}");
					}
					if (line.Contains("ServerPort"))
					{
						try
						{
							Data.ServerPort = int.Parse(line.Split(Data.CONF_SEPERATOR)[1]);
							Logging.Debug($"Config -> ServerPort updated to {Data.ServerPort}");
						}
						catch (FormatException)
						{
							Logging.Warn("Config file is corrupted. Set default Value");
							Data.ServerPort = 8080;
							Logging.Debug($"Config -> ServerPort updated to {Data.ServerPort}");
						}
						
					}
				}
			}
			catch (Exception ex)
			{
				Logging.Error(ex.Message);
			}
		}
		public static void SaveConfig()
		{

		}
	}
}
