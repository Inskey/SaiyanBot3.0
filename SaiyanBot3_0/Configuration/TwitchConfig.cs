using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiyanBot3_0.Configuration
{
    public class TwitchConfig
    {
        public string User { get; private set; }
        public string Pass { get; private set; }
        public List<string> Channels { get; private set; }

        public TwitchConfig(string user, string pass, List<string> channels)
        {
            User = user;
            Pass = pass;
            Channels = channels;
        }
    }
}
