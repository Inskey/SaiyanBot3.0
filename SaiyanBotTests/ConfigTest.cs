using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SaiyanBot3_0.Configuration;

namespace SaiyanBotTests
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void ParseConfigTest()
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

            // Parse dummy config
            Config newConf = Config.ParseConfig(sbuild.ToString());

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
    }
}
