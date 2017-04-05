using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiyanBot3_0
{
    class Program
    {
        static void Main(string[] args)
        {
        	string configPath = "/saiyanbot.cfg";
        	if (args.Length > 0)
        	{
        		if (args[0] == "-c" || args[0] == "--config")
        		{
        			if (args.Length < 2)
        			{
        				Console.WriteLine($"Invalid value after flag \"{args[0]}\"");
        				return;
        			}

        			configPath = args[1];
        		}
        		else if (args[0] == "-h" || args[0] == "--help")
        		{
        			Console.WriteLine("Options:");
        			Console.WriteLine("    -c  --config: Specify a different configuration file directory");
        			Console.WriteLine("    -h  --help:   Show this info");
        		}
        	}

        	Config conf = Config.ParseConfig(Config.LoadConfigFile(File.GetDirectory(Assembly.GetExecutingAssembly.Location) + configPath));

        	Bot bot = new Bot(conf);

        }
    }
}
