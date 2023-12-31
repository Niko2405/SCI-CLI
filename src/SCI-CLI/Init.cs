using SCI_Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI_CLI
{
	internal class Init
	{
		public static void StartInit()
		{
			try
			{
				// Create file system
				Logging.Info($"Create Directory\t{Data.ROOT_PATH}");
				Directory.CreateDirectory(Data.ROOT_PATH);

				Logging.Info($"Create Directory\t{Data.CONF_PATH}");
				Directory.CreateDirectory(Data.CONF_PATH);

				// check config if exists
				if (!File.Exists(Data.CONF_FILE))
				{
					Logging.Info($"Create config file\t{Data.CONF_FILE}");
					ConfigManager.CreateConfig();
				}
			}
			catch (Exception ex)
			{
				Logging.Error(ex.Message);
			}

			// load config
			Logging.Info("Load config file");
			ConfigManager.LoadConfig();
		}
	}
}
