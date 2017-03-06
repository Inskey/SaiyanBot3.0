using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaiyanBot3_0.Configuration
{
    public class Config
    {
        public TwitchConfig Twitch;
        public DiscordConfig Discord;

        public Config(TwitchConfig twitch, DiscordConfig discord)
        {
            Twitch = twitch;
            Discord = discord;
        }
        public Config(TwitchConfig twitch)
        {
            Twitch = twitch;
        }
        public Config(DiscordConfig discord)
        {
            Discord = discord;
        }

        public static Config ParseConfig(string configFile)
        {
            string[] configLines = Regex.Split(configFile, "\r\n|\r|\n");

            string[] twitchConfig, discordConfig;

            if (!configLines[0].StartsWith("[")) throw new ArgumentException("Config file did not start with a config header");

            int discordHeaderIndex = configLines.ToList().FindIndex(x => (x == "[Discord]"));
            int twitchHeaderIndex = configLines.ToList().FindIndex(x => (x == "[Twitch]"));

            if (discordHeaderIndex < 0 && twitchHeaderIndex < 0) throw new ArgumentException("Config file does not contain any valid config headers");

            if (discordHeaderIndex >= 0)
            {
                List<string> discordConf = new List<string>();

                discordConf.Add(configLines[discordHeaderIndex]);

                for (int i = discordHeaderIndex + 1; i < configLines.Length && !configLines[i].StartsWith("["); i++)
                {
                    discordConf.Add(configLines[i]);
                }

                discordConfig = discordConf.ToArray();
            }

            if (twitchHeaderIndex >= 0)
            {
                List<string> twitchConf = new List<string>();

                twitchConf.Add(configLines[discordHeaderIndex]);

                for (int i = twitchHeaderIndex + 1; i < configLines.Length && !configLines[i].StartsWith("["); i++)
                {
                    twitchConf.Add(configLines[i]);
                }

                twitchConfig = twitchConf.ToArray();
            }
        }
    }
}
