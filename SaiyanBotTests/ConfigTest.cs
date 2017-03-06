﻿using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SaiyanBot3_0.Configuration;
using System;

namespace SaiyanBotTests
{
    [TestClass]
    public class ConfigTest
    {
        string dummyConfig;
        string[] configLines;

        [TestInitialize]
        public void InitializeTest()
        {
            // Create dummy config file contents
            StringBuilder sbuild = new StringBuilder();
            sbuild.AppendLine("[Twitch]");
            sbuild.AppendLine("user=SaiyanBot");
            sbuild.AppendLine("pass=1234pass");
            sbuild.AppendLine("channels=");
            sbuild.AppendLine("\tgunnerwolfgaming");
            sbuild.AppendLine("    skidsdev");
            sbuild.AppendLine("\ttearrotime");
            sbuild.AppendLine("[Discord]");
            sbuild.AppendLine("token=12345678abcdef");

            dummyConfig = sbuild.ToString();
            configLines = Regex.Split(dummyConfig, "\r\n|\r|\n");
        }

        [TestMethod]
        public void ParseConfigTest()
        {
            // Parse dummy config
            Config newConf = Config.ParseConfig(dummyConfig);

            bool assertion = true;

            // Valid Twitch config
            assertion = (assertion && newConf.IsTwitch);
            // Valid Discord config
            assertion = (assertion && newConf.IsDiscord);
            // Twitch username correctly parsed
            assertion = (assertion && newConf.Twitch.User == "SaiyanBot");
            // Twitch channels correctly parsed
            assertion = (assertion && newConf.Twitch.Channels.Count == 3);
            assertion = (assertion && newConf.Twitch.Channels[0] == "gunnerwolfgaming");
            assertion = (assertion && newConf.Twitch.Channels[1] == "skidsdev");
            assertion = (assertion && newConf.Twitch.Channels[2] == "tearrotime");

            // Assert
            Assert.IsTrue(assertion);
        }

        [TestMethod]
        public void GetDiscordConfigTest_1()
        {
            DiscordConfig discord = null;
            try
            {
                discord = Config.GetDiscordConfig(configLines, 7);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(discord != null && discord.Token == "12345678abcdef");
        }
        [TestMethod]
        public void GetDiscordConfigTest_2()
        {
            try
            {
                DiscordConfig discord = Config.GetDiscordConfig(configLines, 6);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetDiscordConfigTest_3()
        {
            try
            {
                DiscordConfig discord = Config.GetDiscordConfig(configLines, -1);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetDiscordConfigTest_4()
        {
            try
            {
                DiscordConfig discord = Config.GetDiscordConfig(new string[0], 7);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetDiscordConfigTest_5()
        {
            try
            {
                DiscordConfig discord = Config.GetDiscordConfig(null, 7);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GetTwitchConfigTest_1()
        {
            TwitchConfig twitch = null;
            try
            {
                twitch = Config.GetTwitchConfig(configLines, 0);
            }
            catch
            {
                Assert.Fail();
            }

            bool assertion = true;

            assertion = (assertion && twitch != null);
            // Twitch username correctly parsed
            assertion = (assertion && twitch.User == "SaiyanBot");
            // Twitch channels correctly parsed
            assertion = (assertion && twitch.Channels.Count == 3);
            assertion = (assertion && twitch.Channels[0] == "gunnerwolfgaming");
            assertion = (assertion && twitch.Channels[1] == "skidsdev");
            assertion = (assertion && twitch.Channels[2] == "tearrotime");

            Assert.IsTrue(assertion);
        }
        [TestMethod]
        public void GetTwitchConfigTest_2()
        {
            try
            {
                TwitchConfig twitch = Config.GetTwitchConfig(configLines, 7);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetTwitchConfigTest_3()
        {
            try
            {
                TwitchConfig twitch = Config.GetTwitchConfig(configLines, -1);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetTwitchConfigTest_4()
        {
            try
            {
                TwitchConfig twitch = Config.GetTwitchConfig(new string[0], 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void GetTwitchConfigTest_5()
        {
            try
            {
                TwitchConfig twitch = Config.GetTwitchConfig(null, 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
