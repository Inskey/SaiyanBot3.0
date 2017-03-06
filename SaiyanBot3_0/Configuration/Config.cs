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

            }

            if (twitchHeaderIndex >= 0)
            {
            }
        }

        public DiscordConfig GetDiscordConfig(string[] configLines, int index)
        {
            if (configLines == null || configLines.Length == 0) throw new ArgumentException("");
            if (index < 0 || index > configLines.Length - 1) throw new ArgumentException("");

            List<string> discordConf = new List<string>();

            discordConf.Add(configLines[index]);

            for (int i = index + 1; i < configLines.Length && !configLines[i].StartsWith("["); i++)
            {
                discordConf.Add(configLines[i]);
            }

            string token = discordConf.Where(x => x.ToLower().StartsWith("token=")).Single().Substring(6);

            return new DiscordConfig(token);
        }

        public TwitchConfig GetTwitchConfig(string[] configLines, int index)
        {
            if (configLines == null || configLines.Length == 0) throw new ArgumentException("");
            if (index < 0 || index > configLines.Length - 1) throw new ArgumentException("");

            List<string> twitchConf = new List<string>();

            twitchConf.Add(configLines[index]);

            for (int i = index + 1; i < configLines.Length && !configLines[i].StartsWith("["); i++)
            {
                twitchConf.Add(configLines[i]);
            }

            string user = twitchConf.Where(x => x.ToLower().StartsWith("user=")).Single().Substring(5);
            string pass = twitchConf.Where(x => x.ToLower().StartsWith("pass=")).Single().Substring(5);

            List<string> channels = new List<string>();

            int channelStartIndex = twitchConf.FindIndex(x => x.ToLower() == "channels=");

            for(int i = channelStartIndex + 1; i < twitchConf.Count && (twitchConf[i].StartsWith("\t") || twitchConf[i].StartsWith("    ")); i++)
            {
                if (twitchConf[i].StartsWith("\t")) channels.Add(twitchConf[i].Substring(1));
                else if (twitchConf[i].StartsWith("    ")) channels.Add(twitchConf[i].Substring(4));
            }

            return new TwitchConfig(user, pass, channels);
        }
    }
}
