using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiyanBot3_0.Core
{
    public class Bot
    {
        public Config Conf { get; private set; }

        public Bot(Config conf)
        {
            Conf = conf;
        }
    }
}