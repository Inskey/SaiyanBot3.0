using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiyanBot3_0.Configuration
{
    public class DiscordConfig
    {
        public string Token { get; private set; }

        public DiscordConfig(string token)
        {
            Token = token;
        }
    }
}
