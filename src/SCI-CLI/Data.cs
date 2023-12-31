using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI_CLI
{
	internal class Data
	{
		public const string VERSION = "v0.1";
		public const string ROOT_PATH = "client/";
		public const string CONF_PATH = ROOT_PATH + "configs/";
		public const string CONF_FILE = CONF_PATH + "settings.conf";

		public const char CONF_SEPERATOR = '=';

		public static string ServerIP = "127.0.0.1";
		public static int ServerPort = 8080;
	}
}
